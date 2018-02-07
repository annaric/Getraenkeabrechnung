using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getränkeabrechnung.Modell
{
    [Table("Überweisungen")]
    public class Überweisung
    {
        public int Id { get; set; }
        public virtual Konto Konto { get; set; }
        public DateTime Buchungszeitpunkt { get; set; }
        public DateTime Erstellungszeitpunkt { get; set; }
        public double Betrag { get; set; }
        public double AlterKontostand { get; set; }
        public double NeuerKontostand { get; set; }
        public string Beschreibung { get; set; }
        public bool Löschbar { get; set; } = true;

        public Überweisung()
        {
            Erstellungszeitpunkt = DateTime.Now;
        }

        public Überweisung Storniere()
        {
            var stornoÜberweisung = new Überweisung()
            {
                Buchungszeitpunkt = DateTime.Now,
                Betrag = -Betrag,
                Beschreibung = String.Format("STORNO ({0:d}) - {1}", Buchungszeitpunkt, Beschreibung),
                Löschbar = false
            };
            Beschreibung = String.Format("STORNIERT - {0}", Beschreibung);
            Löschbar = false;

            Konto.Buche(stornoÜberweisung);
            return stornoÜberweisung;
        }
    }
}
