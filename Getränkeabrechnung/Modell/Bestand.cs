using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getränkeabrechnung.Modell
{
    [Table("Bestände")]
    public class Bestand
    {
        public int Id { get; set; }
        public virtual Produkt Produkt { get; set; }
        public int AnzahlFlaschen { get; set; }
        public virtual Abrechnung Abrechnung { get; set; }
    }
}
