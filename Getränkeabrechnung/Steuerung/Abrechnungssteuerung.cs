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

        public IEnumerable<Produkt> BenötigteProdukte(Abrechnung abrechnung) => abrechnung.Einkäufe.SelectMany(e => e.Positionen).Select(p => p.Kastengröße.Produkt).Distinct();

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
            Verbrauchsteuerung.NeueVerbrauche(abrechnung, abrechnung.Verkaufsprodukte.Select(p => new Verbrauch() { Benutzer = benutzer, Verkaufsprodukt = p, AnzahlFlaschen = 0 }).ToList());
            BearbeiteAbrechnung(abrechnung);
        }

        public void FügeHinzu(Abrechnung abrechnung, ICollection<Benutzer> benutzer)
        {
            abrechnung.Benutzer.AddRange(benutzer);
            Verbrauchsteuerung.NeueVerbrauche(abrechnung, abrechnung.Verkaufsprodukte.SelectMany(p => benutzer.Select(b => new Verbrauch() { Benutzer = b, Verkaufsprodukt = p, AnzahlFlaschen = 0 })).ToList());
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
            using (var transaktion = Kontext.Database.BeginOrReuseTransaction())
            {
                abrechnung.Einkäufe.Add(einkauf);
                einkauf.Abrechnung = abrechnung;
                FügeHinzu(abrechnung, einkauf.Positionen.Select(p => p.Kastengröße.Produkt).Distinct().ToList());
                BearbeiteAbrechnung(abrechnung);
                Einkaufsteuerung.BearbeiteEinkauf(einkauf);
                transaktion?.Commit();
            }       
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
                FügeHinzu(abrechnung, einkäufe.SelectMany(e => e.Positionen).Select(p => p.Kastengröße.Produkt).Distinct().ToList());
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
            if (abrechnung.Produkte.Contains(produkt))
                return;

            var verkaufsprodukt = new Verkaufsprodukt() { Produkt = produkt, Bestand = 0, Verkaufspreis = produkt.AktuellerVerkaufspreis };
            Verbrauchsteuerung.NeueVerbrauche(abrechnung, abrechnung.Benutzer.Select(b => new Verbrauch() { Benutzer = b, Verkaufsprodukt = verkaufsprodukt, AnzahlFlaschen = 0 }).ToList());
            Verkaufsproduktsteuerung.NeuesVerkaufsprodukt(abrechnung, verkaufsprodukt);
            BearbeiteAbrechnung(abrechnung);
        }

        public void FügeHinzu(Abrechnung abrechnung, ICollection<Produkt> produkte)
        {
            produkte = produkte.Except(abrechnung.Produkte).ToList();
            if (produkte.Count == 0)
                return;

            using (var transaktion = Kontext.Database.BeginOrReuseTransaction())
            {
                var verkaufsprodukte = produkte.Select(p => new Verkaufsprodukt() { Produkt = p, Bestand = 0, Verkaufspreis = p.AktuellerVerkaufspreis }).ToList();
                Verbrauchsteuerung.NeueVerbrauche(abrechnung, verkaufsprodukte.SelectMany(p => abrechnung.Benutzer.Select(b => new Verbrauch() { Benutzer = b, Verkaufsprodukt = p, AnzahlFlaschen = 0 })).ToList());
                Verkaufsproduktsteuerung.NeueVerkaufsprodukte(abrechnung, verkaufsprodukte);

                BearbeiteAbrechnung(abrechnung);

                transaktion?.Commit();
            }
        }

        public bool KannEntferntWerden(Abrechnung abrechnung, Produkt produkt)
        {
            return !BenötigteProdukte(abrechnung).Contains(produkt);
        }

        public void Entferne(Abrechnung abrechnung, Produkt produkt)
        {
            if (!KannEntferntWerden(abrechnung, produkt))
                return;

            Verbrauchsteuerung.LöscheVerbrauche(abrechnung.Verbrauche.Where(v => v.Verkaufsprodukt.Produkt == produkt).ToList());
            Verkaufsproduktsteuerung.LöscheVerkaufsprodukt(abrechnung.Verkaufsprodukte.Single(b => b.Produkt == produkt));
            BearbeiteAbrechnung(abrechnung);
        }

        public void Entferne(Abrechnung abrechnung, ICollection<Produkt> produkte)
        {
            produkte = produkte.Except(BenötigteProdukte(abrechnung)).ToList();
            if (produkte.Count == 0)
                return;

            using (var transaktion = Kontext.Database.BeginOrReuseTransaction())
            {
                var hashProdukte = produkte.ToHashSet(); // höhöhöhöhöhö
                Verbrauchsteuerung.LöscheVerbrauche(abrechnung.Verbrauche.Where(v => hashProdukte.Contains(v.Verkaufsprodukt.Produkt)).ToList());
                Verkaufsproduktsteuerung.LöscheVerkaufsprodukte(abrechnung.Verkaufsprodukte.Where(b => hashProdukte.Contains(b.Produkt)).ToList());
                BearbeiteAbrechnung(abrechnung);

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
