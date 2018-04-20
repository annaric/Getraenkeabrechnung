using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        public virtual Einkauf Einkauf { get; set; }
        [Required]
        public virtual Kastengröße Kastengröße { get; set; }
        public int AnzahlKästen { get; set; }
    }
}
