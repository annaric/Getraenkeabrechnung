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

        internal Benutzersteuerung(Datenbanksteuerung datenbanksteuerung) : base(datenbanksteuerung)
        {
        }

        public IEnumerable<Benutzer> Benutzer => Kontext.Benutzer.AsEnumerable();

        public void BearbeiteBenutzer(Benutzer benutzer)
        {
            Kontext.SaveChanges();
            BenutzerVerändert?.Invoke(benutzer);
        }

        public void SetzeKaution(Benutzer benutzer, double neueKaution, Konto konto)
        {
            var zahlung = benutzer.SetzeKaution(neueKaution, konto);
            Zahlungssteuerung.NeueZahlung(zahlung);

            if (zahlung.Überweisung != null)
                Überweisungssteuerung.NeueÜberweisung(zahlung.Überweisung);
        }
    }
}
