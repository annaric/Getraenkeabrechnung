using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getränkeabrechnung.Modell
{
    [Table("Verkaufsprodukte")]
    public class Verkaufsprodukt
    {
        public int Id { get; set; }
        public virtual Abrechnung Abrechnung { get; set; }
        public virtual Produkt Produkt { get; set; }
        public int Bestand { get; set; }
        public double Verkaufspreis { get; set; }
    }
}
