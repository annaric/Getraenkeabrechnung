using Getränkeabrechnung.Modell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getränkeabrechnung.Steuerung
{
    public class Einkaufsteuerung : Steuerung
    {
        public delegate void EinkaufHandler(Einkauf einkauf);
        public event EinkaufHandler EinkaufVerändert;
        public event EinkaufHandler EinkaufHinzugefügt;
        public event EinkaufHandler EinkaufGelöscht;

        internal Einkaufsteuerung(Datenbanksteuerung datenbanksteuerung) : base(datenbanksteuerung)
        {
        }

        public IEnumerable<Einkauf> Einkäufe => Kontext.Einkäufe.AsEnumerable();

        public bool IstLöschbar(Einkauf einkauf) => einkauf.Abrechnung == null || !einkauf.Abrechnung.Gebucht;

        public void BearbeiteEinkauf(Einkauf einkauf)
        {
            Kontext.SaveChanges();
            EinkaufVerändert?.Invoke(einkauf);
        }

        public void NeuerEinkauf(Einkauf einkauf)
        {
            Kontext.Einkäufe.Add(einkauf);
            Kontext.SaveChanges();
            EinkaufHinzugefügt?.Invoke(einkauf);
        }

        public void NeuerEinkauf(Einkauf einkauf, Konto konto)
        {
            var überweisung = einkauf.RechneAb(konto);
            Überweisungssteuerung.NeueÜberweisung(überweisung);
            NeuerEinkauf(einkauf);
        }

        public void LöscheEinkauf(Einkauf einkauf)
        {
            if (!IstLöschbar(einkauf))
                throw new InvalidOperationException("Dieser Einkauf ist nicht löschbar, er ist Teil einer schon abgerechneten Abrechnung.");

            using (var transaktion = Kontext.Database.BeginOrReuseTransaction())
            {
                if (einkauf.Abrechnung != null)
                    Abrechnungssteuerung.Entferne(einkauf.Abrechnung, einkauf);

                Einkaufspositionssteuerung.LöschePositionen(einkauf.Positionen, erzwinge: true);

                var überweisung = einkauf.Überweisung;
                Überweisungssteuerung.StorniereÜberweisung(überweisung, erzwinge: true);
                einkauf.Überweisung = null;

                Kontext.Einkäufe.Remove(einkauf);
                Kontext.SaveChanges();
                transaktion?.Commit();
            }
            EinkaufGelöscht?.Invoke(einkauf);
        }
    }
}
