using Getränkeabrechnung.Modell;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getränkeabrechnung.Steuerung
{
    class Datenbanksteuerung : Steuerung
    {
        private GetränkeabrechnungKontext kontext;

        protected override GetränkeabrechnungKontext Kontext => kontext;

        private Abrechnungssteuerung abrechnungssteuerung;
        private Benutzersteuerung benutzersteuerung;
        private Kontosteuerung kontosteuerung;
        private Überweisungssteuerung überweisungssteuerung;
        private Zahlungssteuerung zahlungssteuerung;

        public override Abrechnungssteuerung Abrechnungssteuerung => abrechnungssteuerung;
        public override Benutzersteuerung Benutzersteuerung =>benutzersteuerung;
        public override Kontosteuerung Kontosteuerung => kontosteuerung;
        public override Überweisungssteuerung Überweisungssteuerung => überweisungssteuerung;
        public override Zahlungssteuerung Zahlungssteuerung => zahlungssteuerung;

        public Datenbanksteuerung() : base(null)
        {
            kontext = null;
            abrechnungssteuerung = new Abrechnungssteuerung(this);
            benutzersteuerung = new Benutzersteuerung(this);
            kontosteuerung = new Kontosteuerung(this);
            überweisungssteuerung = new Überweisungssteuerung(this);
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
