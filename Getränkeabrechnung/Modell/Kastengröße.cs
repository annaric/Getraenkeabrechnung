using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getränkeabrechnung.Modell
{
    [Table("Kastengrößen")]
    public class Kastengröße
    {
        public int Id { get; set; }
        public virtual Produkt Produkt { get; set; }
        public int Größe { get; set; }
        public double Einkaufspreis { get; set; }
        public double Pfand { get; set; }
        public bool Versteckt { get; set; } = false;

        [NotMapped]
        public string Anzeigename => String.Format("{0} ({1:d})", Produkt.Name, Größe);
    }
}
