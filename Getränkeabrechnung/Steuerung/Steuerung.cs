using Getränkeabrechnung.Modell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getränkeabrechnung.Steuerung
{
    public abstract class Steuerung
    {
        protected Datenbanksteuerung Datenbanksteuerung { get; private set; }
        protected virtual GetränkeabrechnungKontext Kontext => Datenbanksteuerung.Kontext;
        public virtual Abrechnungssteuerung Abrechnungssteuerung => Datenbanksteuerung.Abrechnungssteuerung;
        public virtual Benutzersteuerung Benutzersteuerung => Datenbanksteuerung.Benutzersteuerung;
        public virtual Einkaufsteuerung Einkaufsteuerung => Datenbanksteuerung.Einkaufsteuerung;
        public virtual Einkaufspositionssteuerung Einkaufspositionssteuerung => Datenbanksteuerung.Einkaufspositionssteuerung;
        public virtual Kastengrößensteuerung Kastengrößensteuerung => Datenbanksteuerung.Kastengrößensteuerung;
        public virtual Kontosteuerung Kontosteuerung => Datenbanksteuerung.Kontosteuerung;
        public virtual Produktsteuerung Produktsteuerung => Datenbanksteuerung.Produktsteuerung;
        public virtual Überweisungssteuerung Überweisungssteuerung => Datenbanksteuerung.Überweisungssteuerung;
        public virtual Verbrauchsteuerung Verbrauchsteuerung => Datenbanksteuerung.Verbrauchsteuerung;
        public virtual Verkaufsproduktsteuerung Verkaufsproduktsteuerung => Datenbanksteuerung.Verkaufsproduktsteuerung;
        public virtual Zahlungssteuerung Zahlungssteuerung => Datenbanksteuerung.Zahlungssteuerung;

        internal Steuerung(Datenbanksteuerung datenbanksteuerung)
        {
            Datenbanksteuerung = datenbanksteuerung;
        }
    }
}
