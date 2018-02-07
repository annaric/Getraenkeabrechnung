using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getränkeabrechnung.Modell
{
    [Table("Konten")]
    public class Konto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Kontostand { get; set; } = 0;
        public virtual List<Überweisung> Überweisungen { get; set; }

        public Konto()
        {
            Überweisungen = new List<Überweisung>();
        }

        public void Buche(Überweisung überweisung)
        {
            überweisung.AlterKontostand = Kontostand;
            überweisung.NeuerKontostand = Kontostand + überweisung.Betrag;
            Kontostand = Kontostand + überweisung.Betrag;

            überweisung.Konto = this;
            Überweisungen.Add(überweisung);
        }

        public void BucheUm(Konto nachKonto, double betrag, out Überweisung vonÜberweisung, out Überweisung nachÜberweisung)
        {
            nachÜberweisung = new Überweisung()
            {
                Buchungszeitpunkt = DateTime.Now,
                Betrag = -betrag,
                Beschreibung = "Umbuchung nach " + nachKonto.Name,
                Löschbar = false
            };

            vonÜberweisung = new Überweisung()
            {
                Buchungszeitpunkt = nachÜberweisung.Buchungszeitpunkt,
                Betrag = betrag,
                Beschreibung = "Umbuchung von " + Name,
                Löschbar = false
            };

            nachKonto.Buche(vonÜberweisung);
            Buche(nachÜberweisung);
        }
    }
}
