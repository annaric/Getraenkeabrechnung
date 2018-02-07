using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getränkeabrechnung.Modell
{
    [Table("Zahlungen")]
    public class Zahlung
    {
        public int Id { get; set; }
        public virtual Benutzer Benutzer { get; set; }
        public DateTime Buchungszeitpunkt { get; set; }
        public string Beschreibung { get; set; }
        public double Betrag { get; set; }
        public double AltesGuthaben { get; set; }
        public double NeuesGuthaben { get; set; }
        public virtual Überweisung Überweisung { get; set; }
        public virtual Abrechnung Abrechnung { get; set; }
        public DateTime Erstellungszeitpunkt { get; set; }
        public bool Löschbar { get; set; } = true;

        public Zahlung()
        {
            Erstellungszeitpunkt = DateTime.Now;
        }

        public Zahlung Storniere()
        {
            var stornoÜberweisung = Überweisung.Storniere();

            var stornoZahlung = new Zahlung()
            {
                Buchungszeitpunkt = DateTime.Now,
                Betrag = -Betrag,
                Beschreibung = String.Format("STORNO ({0:d}) - {1}", Buchungszeitpunkt, Beschreibung),
                Überweisung = stornoÜberweisung,
                Löschbar = false
            };
            Beschreibung = "STORNIERT - " + Beschreibung;
            Löschbar = false;
            Benutzer.Buche(stornoZahlung);

            return stornoZahlung;
        }
    }
}
