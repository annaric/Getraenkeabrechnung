using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getränkeabrechnung.Modell
{
    [Table("Abrechnungen")]
    public class Abrechnung
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Verkaufsprodukt> Verkaufsprodukte { get; set; }
        public virtual List<Zahlung> Zahlungen { get; set; }
        public virtual List<Benutzer> Benutzer { get; set; }
        public virtual List<Einkauf> Einkäufe { get; set; }
        public virtual List<Verbrauch> Verbrauche { get; set; }
        public virtual Abrechnung AusgangsBestandAbrechnung { get; set; }
        public DateTime Startzeitpunkt { get; set; }
        public DateTime Endzeitpunkt { get; set; }
        public bool Gebucht { get; set; }
        public int Schritt { get; set; } = 1;
        // stepcontroller

        [NotMapped]
        public IEnumerable<Produkt> Produkte => Verkaufsprodukte.Select(p => p.Produkt);

        public Abrechnung()
        {
            Verkaufsprodukte = new List<Verkaufsprodukt>();
            Zahlungen = new List<Zahlung>();
            Benutzer = new List<Benutzer>();
            Einkäufe = new List<Einkauf>();
            Verbrauche = new List<Verbrauch>();
        }

        public void Verifiziere()
        {
            var produkte = Verkaufsprodukte.ToDictionary(vk => vk.Produkt);

            if (produkte.Count != Verkaufsprodukte.Count)
                throw new InvalidOperationException("In dieser Abrechung kommen doppelte Produkte vor.");

            if (!Einkäufe.SelectMany(e => e.Positionen).Select(p => p.Kastengröße.Produkt).Distinct().All(p => produkte.ContainsKey(p)))
                throw new InvalidOperationException("In den Einkäufen dieser Abrechnung kommt ein Produkt vor, das nicht Teil der Abrechnung ist.");

            var paare = Verbrauche.Select(v => new { v.Benutzer, v.Verkaufsprodukt}).ToHashSet();
            if (!Benutzer.SelectMany(b => Verkaufsprodukte.Select(p => new { Benutzer = b, Verkaufsprodukt = p })).All(p => paare.Contains(p)))
                throw new InvalidOperationException("Diese Abrechnung hat keinen Verbrauch für jeden Benutzer und jedes Produkt");
        }

        public List<Zahlung> Buche()
        {
            if (Gebucht)
                throw new InvalidOperationException("Diese Abrechnung ist bereits gebucht.");

            Verifiziere();

            var verlustumlage = BerechneVerlustumlage();

            var getränkekosten = BerechneKostenProBenutzer();

            Zahlungen.Clear();
            Zahlungen.AddRange(Benutzer.Where(b => -verlustumlage[b] - getränkekosten[b] > 0).Select(benutzer => new Zahlung()
            {
                Benutzer = benutzer, // Untypisch, erleichtert aber die Zuweisung
                Betrag = -verlustumlage[benutzer] - getränkekosten[benutzer],
                Buchungszeitpunkt = Endzeitpunkt,
                Beschreibung = "Abrechnung: " + Name,
                Abrechnung = this,
                Löschbar = false
            }));

            Zahlungen.ForEach(z => z.Benutzer.Buche(z));

            Gebucht = true;

            return Zahlungen;
        }

        public Dictionary<Benutzer, double> BerechneKostenProBenutzer()
        {
            var getränkekosten = Benutzer.ToDictionary(b => b, b => 0.0);
            Verbrauche.ForEach(v => getränkekosten[v.Benutzer] += v.AnzahlFlaschen * v.Verkaufsprodukt.Verkaufspreis);
            return getränkekosten;
        }

        public Dictionary<Produkt, int> BerecheVerluste()
        {
            var beständeSoll = Verkaufsprodukte.ToDictionary(p => p.Produkt, p => 0);

            if (AusgangsBestandAbrechnung != null)
                AusgangsBestandAbrechnung.Verkaufsprodukte.Where(p => beständeSoll.ContainsKey(p.Produkt)).ToList().ForEach(b => beständeSoll[b.Produkt] += b.Bestand);

            foreach (var position in Einkäufe.SelectMany(e => e.Positionen))
                beständeSoll[position.Kastengröße.Produkt] += position.AnzahlKästen * position.Kastengröße.Größe;

            foreach (var verbrauch in Verbrauche)
                beständeSoll[verbrauch.Verkaufsprodukt.Produkt] -= verbrauch.AnzahlFlaschen;

            var beständeIst = Verkaufsprodukte.ToDictionary(p => p.Produkt, p => p.Bestand);

            return Verkaufsprodukte.ToDictionary(p => p.Produkt, p => beständeSoll[p.Produkt] - beständeIst[p.Produkt]);
        }

        public Dictionary<Benutzer, double> BerechneVerlustumlage()
        {
            var verluste = BerecheVerluste();

            var verbrauchProProdukt = Verkaufsprodukte.ToDictionary(p => p.Produkt, p => Verbrauche.Where(v => v.Verkaufsprodukt == p).Select(v => v.AnzahlFlaschen).Sum());

            var verbrauche = Verbrauche.ToDictionary(v => new { v.Benutzer, v.Verkaufsprodukt }, v => v.AnzahlFlaschen);

            // Jeder Benutzer beteiligt sich an den Verlusten anteilig entsprechend seinem Anteil am gesamten Verbrauch dieses Produkts
            return Benutzer.ToDictionary(b => b,
                b => Verkaufsprodukte.Select(p => verbrauchProProdukt[p.Produkt] != 0 ? verluste[p.Produkt] * p.Verkaufspreis * verbrauche[new { Benutzer = b, Verkaufsprodukt = p }] / verbrauchProProdukt[p.Produkt] : 0.0).Sum());
        }
    }
}
