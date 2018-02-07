using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getränkeabrechnung.Modell
{
    [Table("Verbrauche")]
    public class Verbrauch
    {
        public int Id { get; set; }

        public virtual Abrechnung Abrechnung { get; set; }
        public virtual Benutzer Benutzer { get; set; }
        public virtual Produkt Produkt { get; set; }
        public int AnzahlFlaschen { get; set; }
    }
}
