using Getränkeabrechnung.Modell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getränkeabrechnung.Steuerung
{
    public class Produktsteuerung : Steuerung
    {
        public delegate void ProduktHandler(Produkt produkt);
        public event ProduktHandler ProduktVerändert;
        public event ProduktHandler ProduktHinzugefügt;

        internal Produktsteuerung(Datenbanksteuerung datenbanksteuerung) : base(datenbanksteuerung)
        {
        }

        public IEnumerable<Produkt> Produkte => Kontext.Produkte.AsEnumerable();

        public bool KannBearbeitetWerden(Produkt produkt)
        {
            return !BenutzteProdukte.Distinct().ToList().Contains(produkt);
        }

        public IEnumerable<Produkt> BenutzteProdukte
        {
            get
            {
                return Kontext.Einkaufspositionen
                    .Where(p => p.Einkauf.Abrechnung == null || !p.Einkauf.Abrechnung.Abgerechnet)
                    .Select(p => p.Produkt);
            }
        }

        private bool KannMitKlonenBearbeitetWerden(Produkt produkt) => !produkt.Abrechnungen.Any(a => a.Abgerechnet);

        public Produkt BearbeitbaresProdukt(Produkt produkt)
        {
            var sdkfjlskdjf = Produkte.Select(p => p.Abrechnungen.Count).ToArray();

            // Wenn das Produkt nicht Teil einer schon abregerechneten Abrechnung ist, kann es bearbeitet werden.
            if (KannMitKlonenBearbeitetWerden(produkt))
                return produkt;
            else
                return produkt.Klone();
        }

        public void BearbeiteProdukt(Produkt produkt)
        {
            if (produkt.Elternprodukt != null && !produkt.Elternprodukt.Versteckt)
            {
                // Das Produkt wurde bearbeitet, es wird durch ein gleichartiges Produkt ersetzt, damit alte Abrechnungen valide bleiben.
                produkt.Elternprodukt.Versteckt = true;
                NeuesProdukt(produkt);
                ProduktVerändert?.Invoke(produkt.Elternprodukt);
            } else
            {
                Kontext.SaveChanges();
                ProduktVerändert?.Invoke(produkt);
            }
        }

        public void NeuesProdukt(Produkt produkt)
        {
            Kontext.Produkte.Add(produkt);
            Kontext.SaveChanges();
            ProduktHinzugefügt?.Invoke(produkt);
        }
    }
}
