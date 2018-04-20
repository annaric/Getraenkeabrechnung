using Getränkeabrechnung.Modell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getränkeabrechnung.Steuerung
{
    public class Kastengrößensteuerung : Steuerung
    {
        public delegate void KastengrößenHandler(Kastengröße kastengröße);
        public event KastengrößenHandler KastengrößeHinzugefügt;
        public event KastengrößenHandler KastengrößeBearbeitet;

        internal Kastengrößensteuerung(Datenbanksteuerung datenbanksteuerung) : base(datenbanksteuerung)
        {
        }

        public IEnumerable<Kastengröße> Kastengrößen => Kontext.Kastengrößen.AsEnumerable();

        public bool KannBearbeitetWerden(Kastengröße kastengröße) => BenutzteKastengrößen.All(k => k.Id != kastengröße.Id);

        public bool KannGelöschtWerden(Kastengröße kastengröße) => UnlöschbareKastengrößen.All(k => k.Id != kastengröße.Id);

        public IEnumerable<Kastengröße> BenutzteKastengrößen => Kontext.Einkäufe.SelectMany(e => e.Positionen).Select(p => p.Kastengröße).Distinct();

        public IEnumerable<Kastengröße> UnlöschbareKastengrößen => Kontext.Einkäufe.Where(e => e.Abrechnung == null || !e.Abrechnung.Gebucht).SelectMany(e => e.Positionen).Select(p => p.Kastengröße).Distinct();

        public void BearbeiteKastengröße(Kastengröße kastengröße)
        {
            if (!KannBearbeitetWerden(kastengröße))
                throw new InvalidOperationException("Diese Kastengröße kann nicht gelöscht werden.");

            Kontext.SaveChanges();
            KastengrößeBearbeitet?.Invoke(kastengröße);
        }

        public void FügeHinzu(Produkt produkt, Kastengröße kastengröße)
        {
            produkt.Kastengrößen.Add(kastengröße);
            kastengröße.Produkt = produkt;
            Kontext.SaveChanges();
            KastengrößeHinzugefügt?.Invoke(kastengröße);
        }

        public void Lösche(Kastengröße kastengröße)
        {
            if (!KannGelöschtWerden(kastengröße))
                throw new InvalidOperationException("Diese Kastengröße kann nicht gelöscht werden, sie ist Teil eines noch nicht abgerechneten Einkaufs.");

            kastengröße.Versteckt = true;
            Kontext.SaveChanges();
            KastengrößeBearbeitet?.Invoke(kastengröße);
        }
    }
}
