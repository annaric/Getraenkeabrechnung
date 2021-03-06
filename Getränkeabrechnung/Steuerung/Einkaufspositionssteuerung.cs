﻿using Getränkeabrechnung.Modell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getränkeabrechnung.Steuerung
{
    public class Einkaufspositionssteuerung : Steuerung
    {
        public delegate void EinkaufspositionHandler(Einkaufsposition einkaufsposition);
        public event EinkaufspositionHandler EinkaufspositionHinzugefügt;
        public event EinkaufspositionHandler EinkaufspositionVerändert;
        public event EinkaufspositionHandler EinkaufspositionGelöscht;

        internal Einkaufspositionssteuerung(Datenbanksteuerung datenbanksteuerung) : base(datenbanksteuerung)
        {
        }

        public void NeuePosition(Einkaufsposition position, Einkauf einkauf)
        {
            if (!Einkaufsteuerung.IstLöschbar(einkauf))
                throw new InvalidOperationException("Zu diesem Einkauf kann keine Position mehr hinzugefügt werden.");

            position.Einkauf = einkauf;
            einkauf.Positionen.Add(position);
            if (einkauf.Abrechnung != null && !einkauf.Abrechnung.Produkte.Contains(position.Kastengröße.Produkt))
                Abrechnungssteuerung.FügeHinzu(einkauf.Abrechnung, position.Kastengröße.Produkt);

            Kontext.SaveChanges();
            EinkaufspositionHinzugefügt?.Invoke(position);
        }

        public void LöschePosition(Einkaufsposition position, bool erzwinge = false)
        {
            if (!erzwinge && !Einkaufsteuerung.IstLöschbar(position.Einkauf))
                throw new InvalidOperationException("Aus diesem Einkauf kann keine Position mehr gelöscht werden.");

            Kontext.Einkaufspositionen.Remove(position); // Nebeneffekt: Wird aus Einkauf gelöscht
            Kontext.SaveChanges();
            EinkaufspositionGelöscht?.Invoke(position);
        }

        public void LöschePositionen(ICollection<Einkaufsposition> positionen, bool erzwinge = false)
        {
            if (!erzwinge && positionen.Any(p => !Einkaufsteuerung.IstLöschbar(p.Einkauf)))
                throw new InvalidOperationException("Aus diesem Einkauf kann keine Position mehr gelöscht werden.");

            Kontext.Einkaufspositionen.RemoveRange(positionen);
            Kontext.SaveChanges();
            foreach (var position in positionen)
                EinkaufspositionGelöscht?.Invoke(position);
        }

        public void BearbeitePosition(Einkaufsposition position)
        {
            if (!Einkaufsteuerung.IstLöschbar(position.Einkauf))
                throw new InvalidOperationException("Die Position dieses Einkaufs kann nicht mehr bearbeitet werden.");

            Kontext.SaveChanges();
            EinkaufspositionVerändert?.Invoke(position);
        }
    }
}
