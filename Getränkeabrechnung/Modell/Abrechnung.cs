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
        public bool Abgerechnet { get; set; }
        public int Schritt { get; set; }
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
    }
}
