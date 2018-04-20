using Getränkeabrechnung.Modell;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getränkeabrechnung.Steuerung
{
    public class Datenbanksteuerung : Steuerung
    {
        private GetränkeabrechnungKontext kontext;

        protected override GetränkeabrechnungKontext Kontext => kontext;

        private Abrechnungssteuerung abrechnungssteuerung;
        private Benutzersteuerung benutzersteuerung;
        private Einkaufsteuerung einkaufsteuerung;
        private Einkaufspositionssteuerung einkaufspositionssteuerung;
        private Kastengrößensteuerung kastengrößensteuerung;
        private Kontosteuerung kontosteuerung;
        private Produktsteuerung produktsteuerung;
        private Überweisungssteuerung überweisungssteuerung;
        private Verbrauchsteuerung verbrauchsteuerung;
        private Verkaufsproduktsteuerung verkaufsproduktsteuerung;
        private Zahlungssteuerung zahlungssteuerung;

        public override Abrechnungssteuerung Abrechnungssteuerung => abrechnungssteuerung;
        public override Benutzersteuerung Benutzersteuerung => benutzersteuerung;
        public override Verkaufsproduktsteuerung Verkaufsproduktsteuerung => verkaufsproduktsteuerung;
        public override Einkaufsteuerung Einkaufsteuerung => einkaufsteuerung;
        public override Einkaufspositionssteuerung Einkaufspositionssteuerung => einkaufspositionssteuerung;
        public override Kastengrößensteuerung Kastengrößensteuerung => kastengrößensteuerung;
        public override Kontosteuerung Kontosteuerung => kontosteuerung;
        public override Produktsteuerung Produktsteuerung => produktsteuerung;
        public override Überweisungssteuerung Überweisungssteuerung => überweisungssteuerung;
        public override Verbrauchsteuerung Verbrauchsteuerung => verbrauchsteuerung;
        public override Zahlungssteuerung Zahlungssteuerung => zahlungssteuerung;

        public Datenbanksteuerung() : base(null)
        {
            kontext = null;
            abrechnungssteuerung = new Abrechnungssteuerung(this);
            benutzersteuerung = new Benutzersteuerung(this);
            einkaufsteuerung = new Einkaufsteuerung(this);
            einkaufspositionssteuerung = new Einkaufspositionssteuerung(this);
            kastengrößensteuerung = new Kastengrößensteuerung(this);
            kontosteuerung = new Kontosteuerung(this);
            produktsteuerung = new Produktsteuerung(this);
            überweisungssteuerung = new Überweisungssteuerung(this);
            verbrauchsteuerung = new Verbrauchsteuerung(this);
            verkaufsproduktsteuerung = new Verkaufsproduktsteuerung(this);
            zahlungssteuerung = new Zahlungssteuerung(this);
        }

        public bool Geöffnet {
            get
            {
                return kontext != null;
            }
        }

        public void Öffne(string dateiname)
        {
            var kontext = new GetränkeabrechnungKontext(dateiname);
            if (kontext.Database.Exists())
            {
                this.kontext = kontext;
            }
        }

        public void Schließe()
        {
            if (kontext != null)
                kontext.Dispose();
            kontext = null;
        }
    }
}
