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

        public bool KannGelöschtWerden(Produkt produkt) => !BenutzteProdukte.Any(p => p.Id == produkt.Id);

        public IEnumerable<Produkt> BenutzteProdukte => Kontext.Einkäufe
            .Where(e => e.Abrechnung == null || !e.Abrechnung.Gebucht)
            .SelectMany(e => e.Positionen)
            .Select(k => k.Kastengröße.Produkt)
            .Distinct();

        public void BearbeiteProdukt(Produkt produkt)
        {
            Kontext.SaveChanges();
            ProduktVerändert?.Invoke(produkt);
        }

        public void NeuesProdukt(Produkt produkt)
        {
            Kontext.Produkte.Add(produkt);
            Kontext.SaveChanges();
            ProduktHinzugefügt?.Invoke(produkt);
        }

        public void Lösche(Produkt produkt)
        {
            if (!KannGelöschtWerden(produkt))
                throw new InvalidOperationException("Dieses Produkt kann nicht gelöscht werden, es ist Teil einer noch nicht abgerechneten Abrechnung");

            produkt.Versteckt = true;
            BearbeiteProdukt(produkt);
        }
    }
}
