using Getränkeabrechnung.Modell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getränkeabrechnung.Steuerung
{
    public class Abrechnungssteuerung : Steuerung
    {
        public delegate void AbrechnungHandler(Abrechnung abrechnung);
        public event AbrechnungHandler AbrechnungVerändert;
        public event AbrechnungHandler AbrechnungHinzugefügt;
        public event AbrechnungHandler AbrechnungGelöscht;
        public event AbrechnungHandler AbrechnungGebucht;

        internal Abrechnungssteuerung(Datenbanksteuerung datenbanksteuerung) : base(datenbanksteuerung)
        {
        }

        public IEnumerable<Abrechnung> Abrechnungen => Kontext.Abrechnungen.AsEnumerable();

        public IEnumerable<Abrechnung> AusgangsBestandAbrechnungen(Abrechnung abrechnung)
        {
            return Abrechnungen.Except(
                    Abrechnungen.Where(a => a.AusgangsBestandAbrechnung != null).Select(a => a.AusgangsBestandAbrechnung))
                .Where(a => a.Id != abrechnung.Id);
        }

        public void BearbeiteAbrechnung(Abrechnung abrechnung)
        {
            Kontext.SaveChanges();
            AbrechnungVerändert?.Invoke(abrechnung);
        }

        public void NeueAbrechnung(Abrechnung abrechnung)
        {
            Kontext.Abrechnungen.Add(abrechnung);
            Kontext.SaveChanges();
            AbrechnungHinzugefügt?.Invoke(abrechnung);
        }

        public void BucheAbrechnung(Abrechnung abrechnung)
        {
            using (var transaktion = Kontext.Database.BeginOrReuseTransaction())
            {
                var zahlungen = abrechnung.Buche();
                zahlungen.ForEach(z => Zahlungssteuerung.NeueZahlung(z));

                transaktion?.Commit();
            }
            AbrechnungGebucht?.Invoke(abrechnung);
        }

        public void FügeHinzu(Abrechnung abrechnung, Benutzer benutzer)
        {
            abrechnung.Benutzer.Add(benutzer);
            Verbrauchsteuerung.NeueVerbrauche(abrechnung, abrechnung.Produkte.Select(p => new Verbrauch() { Benutzer = benutzer, Produkt = p, AnzahlFlaschen = 0 }).ToList());
            BearbeiteAbrechnung(abrechnung);
        }

        public void FügeHinzu(Abrechnung abrechnung, ICollection<Benutzer> benutzer)
        {
            abrechnung.Benutzer.AddRange(benutzer);
            Verbrauchsteuerung.NeueVerbrauche(abrechnung, abrechnung.Produkte.SelectMany(p => benutzer.Select(b => new Verbrauch() { Benutzer = b, Produkt = p, AnzahlFlaschen = 0 })).ToList());
            BearbeiteAbrechnung(abrechnung);
        }

        public void Entferne(Abrechnung abrechnung, Benutzer benutzer)
        {
            abrechnung.Benutzer.Remove(benutzer);
            Verbrauchsteuerung.LöscheVerbrauche(abrechnung.Verbrauche.Where(v => v.Benutzer == benutzer).ToList());
            BearbeiteAbrechnung(abrechnung);
        }

        public void Entferne(Abrechnung abrechnung, ICollection<Benutzer> benutzer)
        {
            foreach (var ben in benutzer)
                abrechnung.Benutzer.Remove(ben);

            var hashBenutzer = benutzer.ToHashSet(); // höhöhö
            Verbrauchsteuerung.LöscheVerbrauche(abrechnung.Verbrauche.Where(v => hashBenutzer.Contains(v.Benutzer)).ToList());
            BearbeiteAbrechnung(abrechnung);
        }

        public void FügeHinzu(Abrechnung abrechnung, Einkauf einkauf)
        {
            abrechnung.Einkäufe.Add(einkauf);
            einkauf.Abrechnung = abrechnung;
            abrechnung.Produkte.AddRange(einkauf.Positionen.Select(p => p.Produkt).Except(abrechnung.Produkte));
            BearbeiteAbrechnung(abrechnung);
            Einkaufsteuerung.BearbeiteEinkauf(einkauf);
        }

        public void FügeHinzu(Abrechnung abrechnung, ICollection<Einkauf> einkäufe)
        {
            using (var transaktion = Kontext.Database.BeginOrReuseTransaction())
            {
                abrechnung.Einkäufe.AddRange(einkäufe);

                foreach (var einkauf in einkäufe)
                {
                    einkauf.Abrechnung = abrechnung;
                    Einkaufsteuerung.BearbeiteEinkauf(einkauf);
                }
                abrechnung.Produkte.AddRange(einkäufe.SelectMany(e => e.Positionen).Select(p => p.Produkt).Distinct().Except(abrechnung.Produkte));
                BearbeiteAbrechnung(abrechnung);

                transaktion?.Commit();
            }
        }

        public void Entferne(Abrechnung abrechnung, Einkauf einkauf)
        {
            abrechnung.Einkäufe.Remove(einkauf);
            einkauf.Abrechnung = null;
            BearbeiteAbrechnung(abrechnung);
            Einkaufsteuerung.BearbeiteEinkauf(einkauf);
        }

        public void Entferne(Abrechnung abrechnung, ICollection<Einkauf> einkäufe)
        {
            using (var transaktion = Kontext.Database.BeginOrReuseTransaction())
            {
                foreach (var einkauf in einkäufe)
                {
                    abrechnung.Einkäufe.Remove(einkauf);
                    einkauf.Abrechnung = null;
                    Einkaufsteuerung.BearbeiteEinkauf(einkauf);
                }
                BearbeiteAbrechnung(abrechnung);

                transaktion?.Commit();
            }
        }

        public void FügeHinzu(Abrechnung abrechnung, Produkt produkt)
        {
            abrechnung.Produkte.Add(produkt);
            produkt.Abrechnungen.Add(abrechnung);
            Verbrauchsteuerung.NeueVerbrauche(abrechnung, abrechnung.Benutzer.Select(b => new Verbrauch() { Benutzer = b, Produkt = produkt, AnzahlFlaschen = 0 }).ToList());
            Bestandsteuerung.NeuerBestand(abrechnung, new Bestand() { Produkt = produkt });
            BearbeiteAbrechnung(abrechnung);
            Produktsteuerung.BearbeiteProdukt(produkt);
        }

        public void FügeHinzu(Abrechnung abrechnung, ICollection<Produkt> produkte)
        {
            using (var transaktion = Kontext.Database.BeginOrReuseTransaction())
            {
                abrechnung.Produkte.AddRange(produkte);

                foreach (var produkt in produkte)
                {
                    produkt.Abrechnungen.Add(abrechnung);
                    Produktsteuerung.BearbeiteProdukt(produkt);
                }
                Bestandsteuerung.NeueBestände(abrechnung, produkte.Select(p => new Bestand() { Produkt = p }).ToList());

                Verbrauchsteuerung.NeueVerbrauche(abrechnung, produkte.SelectMany(p => abrechnung.Benutzer.Select(b => new Verbrauch() { Benutzer = b, Produkt = p, AnzahlFlaschen = 0 })).ToList());
                BearbeiteAbrechnung(abrechnung);

                transaktion?.Commit();
            }
        }

        public bool KannEntferntWerden(Abrechnung abrechnung, Produkt produkt) => !abrechnung.Einkäufe.SelectMany(e => e.Positionen).Select(p => p.Produkt).Contains(produkt);

        public void Entferne(Abrechnung abrechnung, Produkt produkt)
        {
            if (!KannEntferntWerden(abrechnung, produkt))
                throw new InvalidOperationException("Dieses Produkt kann nicht entfernt werden, es ist noch Teil eines Einkaufs.");

            abrechnung.Produkte.Remove(produkt);
            produkt.Abrechnungen.Remove(abrechnung);
            Verbrauchsteuerung.LöscheVerbrauche(abrechnung.Verbrauche.Where(v => v.Produkt == produkt).ToList());
            Bestandsteuerung.LöscheBestand(abrechnung.Bestände.Single(b => b.Produkt == produkt));
            BearbeiteAbrechnung(abrechnung);
            Produktsteuerung.BearbeiteProdukt(produkt);
        }

        public void Entferne(Abrechnung abrechnung, ICollection<Produkt> produkte)
        {
            var benötigt = abrechnung.Einkäufe.SelectMany(e => e.Positionen).Select(p => p.Produkt).ToHashSet();
            if (benötigt.Intersect(produkte).Count() != 0)
                throw new InvalidOperationException("Diese Produkte können nicht entfernt werden, sie sind noch Teil eines Einkaufs.");

            using (var transaktion = Kontext.Database.BeginOrReuseTransaction())
            {
                foreach (var produkt in produkte)
                {
                    abrechnung.Produkte.Remove(produkt);
                    produkt.Abrechnungen.Remove(abrechnung);
                    Produktsteuerung.BearbeiteProdukt(produkt);
                }
                var hashProdukte = produkte.ToHashSet(); // höhöhöhöhöhö
                Verbrauchsteuerung.LöscheVerbrauche(abrechnung.Verbrauche.Where(v => hashProdukte.Contains(v.Produkt)).ToList());
                Bestandsteuerung.LöscheBestände(abrechnung.Bestände.Where(b => hashProdukte.Contains(b.Produkt)).ToList());
                BearbeiteAbrechnung(abrechnung); // Events nachher triggern?

                transaktion?.Commit();
            }
        }

        public void LöscheAbrechnung(Abrechnung abrechnung)
        {
            if (abrechnung.Gebucht)
                throw new InvalidOperationException("Diese Abrechnung kann nicht gelöscht werden, sie ist bereits gebucht.");

            using (var transaktion = Kontext.Database.BeginOrReuseTransaction())
            {
                Entferne(abrechnung, abrechnung.Benutzer.ToList());
                Entferne(abrechnung, abrechnung.Einkäufe.ToList());
                Entferne(abrechnung, abrechnung.Produkte.ToList());

                Kontext.Abrechnungen.Remove(abrechnung);
                Kontext.SaveChanges();

                transaktion?.Commit();
            }
            AbrechnungGelöscht?.Invoke(abrechnung);
        }
    }
}
