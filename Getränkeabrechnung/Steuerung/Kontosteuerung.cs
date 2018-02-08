using Getränkeabrechnung.Modell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getränkeabrechnung.Steuerung
{
    public class Kontosteuerung : Steuerung
    {
        public delegate void KontoHandler(Konto konto);
        public event KontoHandler KontoVerändert;
        public event KontoHandler KontoHinzugefügt;


        internal Kontosteuerung(Datenbanksteuerung datenbanksteuerung) : base(datenbanksteuerung)
        {
        }

        public IEnumerable<Konto> Konten => Kontext.Konten.AsEnumerable();

        public void BearbeiteKonto(Konto konto)
        {
            Kontext.SaveChanges();
            KontoVerändert?.Invoke(konto);
        }

        public void BucheUm(Konto vonKonto, Konto nachKonto, double betrag)
        {
            vonKonto.BucheUm(nachKonto, betrag, out Überweisung vonÜberweisung, out Überweisung nachÜberweisung);

            Überweisungssteuerung.NeueÜberweisung(vonÜberweisung);
            Überweisungssteuerung.NeueÜberweisung(nachÜberweisung);
        }
    }
}
