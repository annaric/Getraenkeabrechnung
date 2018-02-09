using Getränkeabrechnung.Modell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getränkeabrechnung.Steuerung
{
    public class Verbrauchsteuerung : Steuerung
    {
        public delegate void VerbrauchHandler(Verbrauch verbrauch);
        public event VerbrauchHandler VerbrauchHinzugefügt;
        public event VerbrauchHandler VerbrauchBearbeitet;
        public event VerbrauchHandler VerbrauchGelöscht;

        internal Verbrauchsteuerung(Datenbanksteuerung datenbanksteuerung) : base(datenbanksteuerung)
        {
        }

        internal void NeuerVerbrauch(Abrechnung abrechnung, Verbrauch verbrauch)
        {
            abrechnung.Verbrauche.Add(verbrauch);
            verbrauch.Abrechnung = abrechnung;
            Kontext.SaveChanges();
            VerbrauchHinzugefügt?.Invoke(verbrauch);
        }

        internal void NeueVerbrauche(Abrechnung abrechnung, ICollection<Verbrauch> verbrauche)
        {
            abrechnung.Verbrauche.AddRange(verbrauche);
            foreach (var verbrauch in verbrauche)
            {
                verbrauch.Abrechnung = abrechnung;
                VerbrauchHinzugefügt?.Invoke(verbrauch);
            }
            Kontext.SaveChanges();
        }

        internal void LöscheVerbrauch(Verbrauch verbrauch)
        {
            verbrauch.Abrechnung.Verbrauche.Remove(verbrauch);
            verbrauch.Abrechnung = null;
            Kontext.SaveChanges();
            VerbrauchGelöscht?.Invoke(verbrauch);
        }

        internal void LöscheVerbrauche(ICollection<Verbrauch> verbrauche)
        {
            foreach (var verbrauch in verbrauche)
            {
                verbrauch.Abrechnung.Verbrauche.Remove(verbrauch);
                verbrauch.Abrechnung = null;
                VerbrauchGelöscht?.Invoke(verbrauch);
            }
            Kontext.SaveChanges();
        }

        public void BearbeiteVerbrauch(Verbrauch verbrauch)
        {
            Kontext.SaveChanges();
            VerbrauchBearbeitet?.Invoke(verbrauch);
        }
    }
}
