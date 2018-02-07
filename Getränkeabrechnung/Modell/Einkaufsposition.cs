using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getränkeabrechnung.Modell
{
    [Table("Einkaufspositionen")]
    public class Einkaufsposition
    {
        public int Id { get; set; }
        public virtual Einkauf Einkauf { get; set; }
        public virtual Produkt Produkt { get; set; }
        public int AnzahlKästen { get; set; }
    }
}
