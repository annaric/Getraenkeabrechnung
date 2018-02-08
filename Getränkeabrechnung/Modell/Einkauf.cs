using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getränkeabrechnung.Modell
{
    [Table("Einkäufe")]
    public class Einkauf
    {
        public int Id { get; set; }
        public virtual Abrechnung Abrechnung { get; set; }
        public DateTime Zeitpunkt { get; set; }
        public string Rechnungsnummer { get; set; }
        public virtual List<Einkaufsposition> Positionen { get; set; }
        public virtual Überweisung Überweisung { get; set; }
        public double Betrag { get; set; }

        public Einkauf()
        {
            Positionen = new List<Einkaufsposition>();
        }

        public Überweisung RechneAb(Konto konto)
        {
            var überweisung = new Überweisung
            {
                Buchungszeitpunkt = Zeitpunkt,
                Betrag = -Betrag,
                Beschreibung = "Einkauf: " + Rechnungsnummer
            };
            Überweisung = überweisung;

            konto.Buche(überweisung);
            return überweisung;
        }
    }
}
