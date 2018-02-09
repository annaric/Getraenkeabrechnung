using Getränkeabrechnung.Modell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getränkeabrechnung.Steuerung
{
    public class Bestandsteuerung : Steuerung
    {
        public delegate void BestandHandler(Bestand b);
        public event BestandHandler BestandHinzugefügt;
        public event BestandHandler BestandVerändert;
        public event BestandHandler BestandGelöscht;

        internal Bestandsteuerung(Datenbanksteuerung datenbanksteuerung) : base(datenbanksteuerung)
        {
        }

        public void BearbeiteBestand(Bestand bestand)
        {
            if (bestand.Abrechnung.Gebucht)
                throw new InvalidOperationException("Bestände von gebuchten Abrechnungen können nicht mehr verändert werden.");

            Kontext.SaveChanges();
            BestandVerändert?.Invoke(bestand);
        }

        internal void NeuerBestand(Abrechnung abrechnung, Bestand bestand)
        {
            if (bestand.Abrechnung.Gebucht)
                throw new InvalidOperationException("Zu gebuchten Abrechnungen können keine Bestände mehr hinzugefügt werden.");

            bestand.Abrechnung = abrechnung;
            abrechnung.Bestände.Add(bestand);
            Kontext.SaveChanges();
            BestandHinzugefügt?.Invoke(bestand);
        }

        internal void NeueBestände(Abrechnung abrechnung, ICollection<Bestand> bestände)
        {
            if (abrechnung.Gebucht)
                throw new InvalidOperationException("Zu gebuchten Abrechnungen können keine Bestände mehr hinzugefügt werden.");

            foreach (var bestand in bestände)
            {
                bestand.Abrechnung = abrechnung;
                abrechnung.Bestände.Add(bestand);
                BestandHinzugefügt?.Invoke(bestand);
            }
            Kontext.SaveChanges();
        }

        internal void LöscheBestand(Bestand bestand)
        {
            if (bestand.Abrechnung.Gebucht)
                throw new InvalidOperationException("Aus gebuchten Abrechnungen können keine Bestände mehr gelöscht werden.");

            bestand.Abrechnung.Bestände.Remove(bestand);
            bestand.Abrechnung = null;
            Kontext.SaveChanges();
            BestandGelöscht?.Invoke(bestand);
        }

        internal void LöscheBestände(ICollection<Bestand> bestände)
        {
            foreach (var bestand in bestände)
            {
                if (bestand.Abrechnung.Gebucht)
                    throw new InvalidOperationException("Zu gebuchten Abrechnungen können keine Bestände mehr hinzugefügt werden.");
                bestand.Abrechnung.Bestände.Remove(bestand);
                bestand.Abrechnung = null;
                BestandGelöscht?.Invoke(bestand);
            }
        }
    }
}
