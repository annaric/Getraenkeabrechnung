using Getränkeabrechnung.Modell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getränkeabrechnung.Steuerung
{
    public class Zahlungssteuerung : Steuerung
    {
        public delegate void ZahlungHandler(Zahlung zahlung);
        public event ZahlungHandler ZahlungVerändert;
        public event ZahlungHandler ZahlungHinzugefügt;

        internal Zahlungssteuerung(Datenbanksteuerung datenbanksteuerung) : base(datenbanksteuerung)
        {
        }

        public IEnumerable<Zahlung> Zahlungen => Kontext.Zahlungen.AsEnumerable();

        public void BearbeiteZahlung(Zahlung zahlung)
        {
            Kontext.SaveChanges();
            ZahlungVerändert?.Invoke(zahlung);
        }

        public void StorniereZahlung(Zahlung zahlung)
        {
            if (!zahlung.Löschbar)
                throw new InvalidOperationException("Diese Zahlung ist nicht löschbar");

            var stornoZahlung = zahlung.Storniere();
            NeueZahlung(stornoZahlung);
            Überweisungssteuerung.NeueÜberweisung(stornoZahlung.Überweisung);
            BearbeiteZahlung(zahlung);
        }

        public void NeueZahlung(Zahlung zahlung)
        {
            Benutzersteuerung.BearbeiteBenutzer(zahlung.Benutzer);
            ZahlungHinzugefügt?.Invoke(zahlung);
        }

        public void NeueZahlung(Benutzer benutzer, Zahlung zahlung)
        {
            benutzer.Buche(zahlung);
            NeueZahlung(zahlung);
        }

        public void NeueZahlung(Benutzer benutzer, Konto konto, Zahlung zahlung)
        {
            var überweisung = new Überweisung()
            {
                Erstellungszeitpunkt = zahlung.Erstellungszeitpunkt,
                Buchungszeitpunkt = zahlung.Buchungszeitpunkt,
                Betrag = zahlung.Betrag,
                Beschreibung = string.Format("{0}: {1}", benutzer.Anzeigename, zahlung.Beschreibung),
                Löschbar = false
            };
            Überweisungssteuerung.NeueÜberweisung(konto, überweisung);
            zahlung.Überweisung = überweisung;
            NeueZahlung(benutzer, zahlung);
        }
    }
}
