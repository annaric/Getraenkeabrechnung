using Getränkeabrechnung.Modell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getränkeabrechnung.Steuerung
{
    abstract class Steuerung
    {
        protected Datenbanksteuerung Datenbanksteuerung { get; private set; }
        protected virtual GetränkeabrechnungKontext Kontext => Datenbanksteuerung.Kontext;
        public virtual Abrechnungssteuerung Abrechnungssteuerung => Datenbanksteuerung.Abrechnungssteuerung;
        public virtual Benutzersteuerung Benutzersteuerung => Datenbanksteuerung.Benutzersteuerung;
        public virtual Kontosteuerung Kontosteuerung => Datenbanksteuerung.Kontosteuerung;
        public virtual Überweisungssteuerung Überweisungssteuerung => Datenbanksteuerung.Überweisungssteuerung;
        public virtual Zahlungssteuerung Zahlungssteuerung => Datenbanksteuerung.Zahlungssteuerung;

        internal Steuerung(Datenbanksteuerung datenbanksteuerung)
        {
            Datenbanksteuerung = datenbanksteuerung;
        }
    }
}
