using Getränkeabrechnung.Modell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getränkeabrechnung.Steuerung
{
    public class Verkaufsproduktsteuerung : Steuerung
    {
        public delegate void VerkaufsproduktHandler(Verkaufsprodukt p);
        public event VerkaufsproduktHandler VerkaufsproduktHinzugefügt;
        public event VerkaufsproduktHandler VerkaufsproduktVerändert;
        public event VerkaufsproduktHandler VerkaufsproduktGelöscht;

        internal Verkaufsproduktsteuerung(Datenbanksteuerung datenbanksteuerung) : base(datenbanksteuerung)
        {
        }

        public void BearbeiteVerkaufsprodukt(Verkaufsprodukt verkaufsprodukt)
        {
            if (verkaufsprodukt.Abrechnung.Gebucht)
                throw new InvalidOperationException("Bestände von gebuchten Abrechnungen können nicht mehr verändert werden.");

            Kontext.SaveChanges();
            VerkaufsproduktVerändert?.Invoke(verkaufsprodukt);
        }

        internal void NeuesVerkaufsprodukt(Abrechnung abrechnung, Verkaufsprodukt verkaufsprodukt)
        {
            if (abrechnung.Gebucht)
                throw new InvalidOperationException("Zu gebuchten Abrechnungen können keine Bestände mehr hinzugefügt werden.");

            verkaufsprodukt.Abrechnung = abrechnung;
            abrechnung.Verkaufsprodukte.Add(verkaufsprodukt);
            Kontext.SaveChanges();
            VerkaufsproduktHinzugefügt?.Invoke(verkaufsprodukt);
        }

        internal void NeueVerkaufsprodukte(Abrechnung abrechnung, ICollection<Verkaufsprodukt> verkaufsprodukte)
        {
            if (abrechnung.Gebucht)
                throw new InvalidOperationException("Zu gebuchten Abrechnungen können keine Bestände mehr hinzugefügt werden.");

            foreach (var verkaufsprodukt in verkaufsprodukte)
            {
                verkaufsprodukt.Abrechnung = abrechnung;
                abrechnung.Verkaufsprodukte.Add(verkaufsprodukt);
                VerkaufsproduktHinzugefügt?.Invoke(verkaufsprodukt);
            }
            Kontext.SaveChanges();
        }

        internal void LöscheVerkaufsprodukt(Verkaufsprodukt verkaufsprodukt)
        {
            if (verkaufsprodukt.Abrechnung.Gebucht)
                throw new InvalidOperationException("Aus gebuchten Abrechnungen können keine Bestände mehr gelöscht werden.");

            verkaufsprodukt.Abrechnung.Verkaufsprodukte.Remove(verkaufsprodukt);
            VerkaufsproduktGelöscht?.Invoke(verkaufsprodukt);
            verkaufsprodukt.Abrechnung = null;
            Kontext.Verkaufsprodukte.Remove(verkaufsprodukt);
            Kontext.SaveChanges();
        }

        internal void LöscheVerkaufsprodukte(ICollection<Verkaufsprodukt> verkaufsprodukte)
        {
            foreach (var verkaufsprodukt in verkaufsprodukte)
            {
                if (verkaufsprodukt.Abrechnung.Gebucht)
                    throw new InvalidOperationException("Zu gebuchten Abrechnungen können keine Bestände mehr hinzugefügt werden.");
                verkaufsprodukt.Abrechnung.Verkaufsprodukte.Remove(verkaufsprodukt);
                VerkaufsproduktGelöscht?.Invoke(verkaufsprodukt);
                verkaufsprodukt.Abrechnung = null;
                Kontext.Verkaufsprodukte.Remove(verkaufsprodukt);
            }
            Kontext.SaveChanges();
        }
    }
}
