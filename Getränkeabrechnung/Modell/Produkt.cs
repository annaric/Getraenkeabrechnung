using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getränkeabrechnung.Modell
{
    [Table("Produkte")]
    public class Produkt
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Preis { get; set; }
        public int Kastengröße { get; set; }
        public double Einkaufspreis { get; set; }
        // public double Pfand { get; set; }
        // public bool Aktiv { get; set; }
        public bool Versteckt { get; set; }
        public virtual List<Abrechnung> Abrechnungen { get; set; }
        public virtual Produkt Elternprodukt { get; set; }
        // public int ListenPosition { get; set; }

        public Produkt()
        {
            Abrechnungen = new List<Abrechnung>();
        }

        public Produkt Klone()
        {
            return new Produkt()
            {
                Name = Name,
                Preis = Preis,
                Kastengröße = Kastengröße,
                Einkaufspreis = Einkaufspreis,
                Elternprodukt = this
                // Pfand = Pfand
            };
        }
    }
}
