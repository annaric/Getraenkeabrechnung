using Getränkeabrechnung.Modell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getränkeabrechnung.Steuerung
{
    class Überweisungssteuerung : Steuerung
    {
        public delegate void ÜberweisungHandler(Überweisung überweisung);
        public event ÜberweisungHandler ÜberweisungVerändert;
        public event ÜberweisungHandler ÜberweisungHinzugefügt;

        internal Überweisungssteuerung(Datenbanksteuerung datenbanksteuerung) : base(datenbanksteuerung)
        {
        }

        public IEnumerable<Überweisung> Überweisungen => Kontext.Überweisungen.AsEnumerable();

        public void BearbeiteÜberweisung(Überweisung überweisung)
        {
            Kontext.SaveChanges();
            ÜberweisungVerändert?.Invoke(überweisung);
        }

        public void NeueÜberweisung(Überweisung überweisung)
        {
            Kontosteuerung.BearbeiteKonto(überweisung.Konto);
            ÜberweisungHinzugefügt?.Invoke(überweisung);
        }

        public void NeueÜberweisung(Konto konto, Überweisung überweisung)
        {
            konto.Buche(überweisung);
            NeueÜberweisung(überweisung);
        }

        public void StorniereÜberweisung(Überweisung überweisung)
        {
            if (!überweisung.Löschbar)
                throw new InvalidOperationException("Diese Überweisung ist nicht löschbar.");

            var stornoÜberweisung = überweisung.Storniere();
            NeueÜberweisung(stornoÜberweisung);
            BearbeiteÜberweisung(überweisung);
        }
    }
}
