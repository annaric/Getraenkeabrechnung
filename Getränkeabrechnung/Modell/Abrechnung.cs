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
        public virtual List<Produkt> Produkte { get; set; }
        public virtual List<Zahlung> Zahlungen { get; set; }
        public virtual List<Benutzer> Benutzer { get; set; }
        public virtual List<Bestand> Bestände { get; set; }
        public virtual List<Einkauf> Einkäufe { get; set; }
        public virtual List<Verbrauch> Verbrauche { get; set; }
        public virtual Abrechnung AusgangsBestandAbrechnung { get; set; }
        public DateTime Startzeitpunkt { get; set; }
        public DateTime Endzeitpunkt { get; set; }
        public bool Gebucht { get; set; }
        public int Schritt { get; set; } = 1;
        // stepcontroller

        public Abrechnung()
        {
            Produkte = new List<Produkt>();
            Zahlungen = new List<Zahlung>();
            Benutzer = new List<Benutzer>();
            Bestände = new List<Bestand>();
            Einkäufe = new List<Einkauf>();
            Verbrauche = new List<Verbrauch>();
        }

        public bool Verifiziere()
        {
            var produkte = Produkte.ToHashSet();

            // Keine Doppelten Produkte
            if (produkte.Count != Produkte.Count)
                return false;

            // Alle in Einkäufen enthaltenen Produkte sind Teil der Abrechnung
            if (Einkäufe.SelectMany(e => e.Positionen).Select(p => p.Produkt).Distinct().Any(p => !produkte.Contains(p)))
                return false;

            // Für jedes enthaltene Produkt existiert (genau) ein Bestand
            if (Bestände.Count != produkte.Count || Bestände.Select(b => b.Produkt).Distinct().Intersect(produkte).Count() != Bestände.Count)
                return false;

            // Für jeden Benutzer und Produkt existiert (genau) ein Verbrauch
            var paare = Verbrauche.Select(v => new { Benutzer = v.Benutzer, Produkt = v.Produkt}).ToHashSet();
            if (paare.Count != Verbrauche.Count || paare.Count != Benutzer.Count * produkte.Count)
                return false;

            if (Benutzer.SelectMany(b => Produkte.Select(p => new { Benutzer = b, Produkt = p })).Any(p => !paare.Contains(p)))
                return false;

            return true;
        }

        public List<Zahlung> Buche()
        {
            if (Gebucht)
                throw new InvalidOperationException("Diese Abrechnung ist bereits gebucht.");

            if (Verifiziere()) // Sollte eigentlich nicht nötig sein
                throw new InvalidOperationException("Diese Abrechnung ist nicht valide.");

            var verlustumlage = BerechneVerlustumlage();

            var getränkekosten = Benutzer.ToDictionary(b => b, b => 0.0);
            Verbrauche.ForEach(v => getränkekosten[v.Benutzer] += v.AnzahlFlaschen * v.Produkt.Preis);

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

        public Dictionary<Benutzer, double> BerechneVerlustumlage()
        {
            Dictionary<Produkt, int> beständeSoll = Produkte.ToDictionary(p => p, p => 0);

            if (AusgangsBestandAbrechnung != null)
                AusgangsBestandAbrechnung.Bestände.ForEach(b => beständeSoll[b.Produkt] += b.AnzahlFlaschen);

            foreach (var position in Einkäufe.SelectMany(e => e.Positionen))
                beständeSoll[position.Produkt] += position.AnzahlKästen * position.Produkt.Kastengröße;

            var beständeIst = Bestände.ToDictionary(b => b.Produkt, b => b.AnzahlFlaschen);

            var verbrauchSoll = Produkte.ToDictionary(p => p, p => beständeSoll[p] - beständeIst[p]);

            var verbrauchIst = Produkte.ToDictionary(p => p, p => 0);
            Verbrauche.ForEach(v => verbrauchIst[v.Produkt] += v.AnzahlFlaschen);

            var verlusteFlaschen = Produkte.ToDictionary(p => p, p => verbrauchSoll[p] - verbrauchIst[p]);

            var verbrauche = Verbrauche.ToDictionary(v => new { v.Benutzer, v.Produkt }, v => v.AnzahlFlaschen);

            // Jeder Benutzer beteiligt sich an den Verlusten anteilig entsprechend seinem Anteil am gesamten Verbrauch dieses Produkts
            return Benutzer.ToDictionary(b => b,
                b => Produkte.Select(p => verlusteFlaschen[p] * p.Preis * verbrauche[new { Benutzer = b, Produkt = p }] / verbrauchIst[p]).Sum());
        }
    }
}
