using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getränkeabrechnung.Modell
{
    [Table("Benutzer")]
    public class Benutzer
    {
        public int Id { get; set; }
        // public virtual List<Abrechnung> Abrechnungen { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
        public int Zimmernummer { get; set; }
        public string Rufname { get; set; }
        public double Guthaben { get; set; }
        public double Kaution { get; set; }
        public virtual List<Zahlung> Zahlungen { get; set; }
        public bool Aktiv { get; set; }

        [NotMapped]
        public string Anzeigename { get {
                var name = Rufname == null || Rufname.Equals("") ? Vorname : Rufname;
                if (Kaution == 0)
                {
                    name += "*";
                }
                return String.Format("{0} - {1}", Zimmernummer, name);
            } }

        public Benutzer()
        {
            Zahlungen = new List<Zahlung>();
            // Abrechnungen = new List<Abrechnung>();
        }

        public void Buche(Zahlung zahlung)
        {
            zahlung.AltesGuthaben = Guthaben;
            zahlung.NeuesGuthaben = Guthaben + zahlung.Betrag;
            Guthaben = Guthaben + zahlung.Betrag;
            zahlung.Benutzer = this;
            Zahlungen.Add(zahlung);
        }

        public Zahlung SetzeKaution(double neueKaution, Konto konto)
        {
            double diff = Kaution - neueKaution;

            var zahlung = new Zahlung()
            {
                Buchungszeitpunkt = DateTime.Now,
                Betrag = diff,
                Beschreibung = "Kaution " + Vorname,
                Löschbar = false
            };

            if (diff < 0)
            {
                // Zahlt der Benutzer Kaution ein, erhält das Konto Geld, der Benutzer aber kein Guthaben.
                var überweisung = new Überweisung()
                {
                    Buchungszeitpunkt = zahlung.Buchungszeitpunkt,
                    Betrag = -zahlung.Betrag,
                    Beschreibung = zahlung.Beschreibung,
                    Löschbar = false
                };
                konto.Buche(überweisung);

                zahlung.Überweisung = überweisung;
                zahlung.AltesGuthaben = Guthaben;
                zahlung.NeuesGuthaben = Guthaben;
                zahlung.Benutzer = this;
                Zahlungen.Add(zahlung);
            } else
            {
                // Wird eine Kaution ausbezahlt, erhöht sich das Guthaben des Benutzers normal.
                Buche(zahlung);
            }

            Kaution = neueKaution;
            return zahlung;
        }
    }
}
