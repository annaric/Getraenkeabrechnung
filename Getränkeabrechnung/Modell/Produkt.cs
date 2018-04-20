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
        public string Name { get; set; } = "";
        public double AktuellerVerkaufspreis { get; set; }
        public virtual List<Kastengröße> Kastengrößen { get; set; }
        public int Listenposition { get; set; }
        public bool Versteckt { get; set; } = false;

        public Produkt()
        {
            Kastengrößen = new List<Kastengröße>();
        }
    }
}
