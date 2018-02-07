using Getränkeabrechnung.Modell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getränkeabrechnung.Steuerung
{
    class Benutzersteuerung : Steuerung
    {
        public delegate void BenutzerHandler(Benutzer benutzer);
        public event BenutzerHandler BenutzerVerändert;
        public event BenutzerHandler BenutzerHinzugefügt;

        internal Benutzersteuerung(Datenbanksteuerung datenbanksteuerung) : base(datenbanksteuerung)
        {
        }

        public IEnumerable<Benutzer> Benutzer => Kontext.Benutzer.AsEnumerable();

        public void BearbeiteBenutzer(Benutzer benutzer)
        {
            Kontext.SaveChanges();
            BenutzerVerändert?.Invoke(benutzer);
        }

        public void NeuerBenutzer(Benutzer benutzer)
        {
            Kontext.Benutzer.Add(benutzer);
            Kontext.SaveChanges();
            BenutzerHinzugefügt?.Invoke(benutzer);
        }

        public void SetzeKaution(Benutzer benutzer, double neueKaution, Konto konto)
        {
            var zahlung = benutzer.SetzeKaution(neueKaution, konto);
            Zahlungssteuerung.NeueZahlung(zahlung);

            if (zahlung.Überweisung != null)
                Überweisungssteuerung.NeueÜberweisung(zahlung.Überweisung);
        }

        public void SetzeAktiv(Benutzer benutzer, bool aktiv)
        {
            benutzer.Aktiv = aktiv;
            BearbeiteBenutzer(benutzer);
        }

        public void SetzeAktiv(IEnumerable<Benutzer> benutzer, bool aktiv)
        {
            foreach (var b in benutzer)
            {
                b.Aktiv = aktiv;
            }
            Kontext.SaveChanges();
            foreach (var b in benutzer)
            {
                BenutzerVerändert?.Invoke(b);
            }
        }
    }
}
