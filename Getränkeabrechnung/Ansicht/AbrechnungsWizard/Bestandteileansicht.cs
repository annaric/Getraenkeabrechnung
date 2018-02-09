using Getränkeabrechnung.Steuerung;
using Getränkeabrechnung.Modell;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BrightIdeasSoftware;
using System.Linq;

namespace Getränkeabrechnung.Ansicht.AbrechnungsWizard
{
    public partial class Bestandteileansicht : AbrechnungsWizardAnsicht
    {
        private Abrechnungssteuerung abrechnungssteuerung;
        private Benutzersteuerung benutzersteuerung;
        private Einkaufsteuerung einkaufsteuerung;
        private Produktsteuerung produktsteuerung;
        private Einkaufspositionssteuerung positionssteuerung;

        private List<Produkt> ErzwungeneProdukte;

        public Bestandteileansicht()
        {
            InitializeComponent();

            Benutzerliste.BooleanCheckStateGetter = (b => Abrechnung.Benutzer.Contains((Benutzer)b));
            Benutzerliste.BooleanCheckStatePutter = ((o, b) => SetzeBenutzer((Benutzer)o, b));
            Benutzerliste.ModelFilter = new ModelFilter(b => ((Benutzer)b).Aktiv || Abrechnung.Benutzer.Contains((Benutzer)b));

            Einkaufliste.BooleanCheckStateGetter = (e => ((Einkauf)e).Abrechnung == Abrechnung);
            Einkaufliste.BooleanCheckStatePutter = ((o, b) => SetzeEinkauf((Einkauf)o, b));
            Einkaufliste.ModelFilter = new ModelFilter(e => ((Einkauf)e).Abrechnung == null || ((Einkauf)e).Abrechnung == Abrechnung);

            Produktliste.BooleanCheckStateGetter = (p => Abrechnung.Produkte.Contains((Produkt)p));
            Produktliste.BooleanCheckStatePutter = ((o, b) => SetzeProdukt((Produkt)o, b));
            Produktliste.ModelFilter = new ModelFilter(p => !((Produkt)p).Versteckt);

            ErzwungeneProdukte = new List<Produkt>();
        }

        public Bestandteileansicht(Hauptfenster hauptfenster) : this()
        {
            Hauptfenster = hauptfenster;
            abrechnungssteuerung = hauptfenster.Steuerung.Abrechnungssteuerung;
            benutzersteuerung = hauptfenster.Steuerung.Benutzersteuerung;
            einkaufsteuerung = hauptfenster.Steuerung.Einkaufsteuerung;
            produktsteuerung = hauptfenster.Steuerung.Produktsteuerung;
            positionssteuerung = hauptfenster.Steuerung.Einkaufspositionssteuerung;


            // Listeners
            benutzersteuerung.BenutzerVerändert += Benutzersteuerung_BenutzerVerändert;
            benutzersteuerung.BenutzerHinzugefügt += Benutzersteuerung_BenutzerHinzugefügt;

            einkaufsteuerung.EinkaufHinzugefügt += Einkaufsteuerung_EinkaufHinzugefügt;
            einkaufsteuerung.EinkaufVerändert += Einkaufsteuerung_EinkaufVerändert;
            einkaufsteuerung.EinkaufGelöscht += Einkaufsteuerung_EinkaufGelöscht;

            produktsteuerung.ProduktHinzugefügt += Produktsteuerung_ProduktHinzugefügt;
            produktsteuerung.ProduktVerändert += Produktsteuerung_ProduktVerändert;

            positionssteuerung.EinkaufspositionHinzugefügt += Positionssteuerung_EinkaufspositionHinzugefügt;
            positionssteuerung.EinkaufspositionVerändert += Positionssteuerung_EinkaufspositionVerändert;
            positionssteuerung.EinkaufspositionGelöscht += Positionssteuerung_EinkaufspositionGelöscht;
        }

        private void Positionssteuerung_EinkaufspositionGelöscht(Einkaufsposition einkaufsposition)
        {
            // einkaufsposition.Einkauf ist schon null
            AktualisiereErzwungeneProdukte();
        }

        private void Positionssteuerung_EinkaufspositionVerändert(Einkaufsposition einkaufsposition)
        {
            if (einkaufsposition.Einkauf.Abrechnung == Abrechnung)
                AktualisiereErzwungeneProdukte();
        }

        private void Positionssteuerung_EinkaufspositionHinzugefügt(Einkaufsposition einkaufsposition)
        {
            if (einkaufsposition.Einkauf.Abrechnung == Abrechnung)
                AktualisiereErzwungeneProdukte();
        }

        private void Produktsteuerung_ProduktVerändert(Produkt produkt)
        {
            Produktliste.UpdateObject(produkt);
        }

        private void Produktsteuerung_ProduktHinzugefügt(Produkt produkt)
        {
            Produktliste.AddObject(produkt);
        }

        private void Einkaufsteuerung_EinkaufGelöscht(Einkauf einkauf)
        {
            Einkaufliste.RemoveObject(einkauf);
            AktualisiereErzwungeneProdukte();
        }

        private void Einkaufsteuerung_EinkaufVerändert(Einkauf einkauf)
        {
            Einkaufliste.UpdateObject(einkauf);
        }

        private void Einkaufsteuerung_EinkaufHinzugefügt(Einkauf einkauf)
        {
            Einkaufliste.AddObject(einkauf);
        }

        private void Benutzersteuerung_BenutzerHinzugefügt(Benutzer benutzer)
        {
            Benutzerliste.AddObject(benutzer);
        }

        private void Benutzersteuerung_BenutzerVerändert(Benutzer benutzer)
        {
            Benutzerliste.UpdateObject(benutzer);
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            if (disposing)
            {
                benutzersteuerung.BenutzerHinzugefügt -= Benutzersteuerung_BenutzerHinzugefügt;
                benutzersteuerung.BenutzerVerändert -= Benutzersteuerung_BenutzerVerändert;

                einkaufsteuerung.EinkaufHinzugefügt -= Einkaufsteuerung_EinkaufHinzugefügt;
                einkaufsteuerung.EinkaufVerändert -= Einkaufsteuerung_EinkaufVerändert;
                einkaufsteuerung.EinkaufGelöscht -= Einkaufsteuerung_EinkaufGelöscht;

                produktsteuerung.ProduktHinzugefügt -= Produktsteuerung_ProduktHinzugefügt;
                produktsteuerung.ProduktVerändert -= Produktsteuerung_ProduktVerändert;

                positionssteuerung.EinkaufspositionHinzugefügt -= Positionssteuerung_EinkaufspositionHinzugefügt;
                positionssteuerung.EinkaufspositionVerändert -= Positionssteuerung_EinkaufspositionVerändert;
                positionssteuerung.EinkaufspositionGelöscht -= Positionssteuerung_EinkaufspositionGelöscht;
            }
            base.Dispose(disposing);
        }

        public override void Fülle()
        {
            Benutzerliste.SetObjects(benutzersteuerung.Benutzer.ToList());
            Benutzerliste.Sort(Zimmerspalte);

            Einkaufliste.SetObjects(einkaufsteuerung.Einkäufe.ToList());
            Einkaufliste.Sort(DatumSpalte, SortOrder.Descending);

            Produktliste.SetObjects(produktsteuerung.Produkte.ToList());
            Produktliste.Sort(NameSpalteProdukt);

            AktualisiereErzwungeneProdukte();
        }

        private bool SetzeBenutzer(Benutzer benutzer, bool enthalten)
        {
            if (enthalten)
                Abrechnung.Benutzer.Add(benutzer);
            else
                Abrechnung.Benutzer.Remove(benutzer);
            abrechnungssteuerung.BearbeiteAbrechnung(Abrechnung);
            return enthalten;
        }

        private bool SetzeEinkauf(Einkauf einkauf, bool enthalten)
        {
            if (enthalten)
                abrechnungssteuerung.FügeHinzu(Abrechnung, einkauf);
            else
                abrechnungssteuerung.Entferne(Abrechnung, einkauf);
            AktualisiereErzwungeneProdukte();

            return enthalten;
        }

        private void AktualisiereErzwungeneProdukte()
        {
            var erzwungeneProdukteBackup = ErzwungeneProdukte.ToList();
            ErzwungeneProdukte = Abrechnung.Einkäufe.SelectMany(e => e.Positionen).Select(p => p.Produkt).ToList();
            Produktliste.DisabledObjects = ErzwungeneProdukte.ToList();
            Produktliste.UpdateObjects(erzwungeneProdukteBackup);
        }

        private bool SetzeProdukt(Produkt produkt, bool enthalten)
        {
            if (enthalten)
                abrechnungssteuerung.FügeHinzu(Abrechnung, produkt);
            else
                abrechnungssteuerung.Entferne(Abrechnung, produkt);

            return enthalten;
        }

        private void Benutzerliste_HeaderCheckBoxChanging(object sender, HeaderCheckBoxChangingEventArgs e)
        {
            if (e.NewCheckState == CheckState.Checked)
                Abrechnung.Benutzer.AddRange(benutzersteuerung.Benutzer.Where(b => b.Aktiv).Except(Abrechnung.Benutzer));
            else
                Abrechnung.Benutzer.Clear();
            abrechnungssteuerung.BearbeiteAbrechnung(Abrechnung);
            Benutzerliste.BuildList();
        }

        private void Einkaufliste_HeaderCheckBoxChanging(object sender, HeaderCheckBoxChangingEventArgs e)
        {
            if (e.NewCheckState == CheckState.Checked)
                abrechnungssteuerung.FügeHinzu(Abrechnung, einkaufsteuerung.Einkäufe.Where(ein => ein.Abrechnung == null).ToList());
            else
                abrechnungssteuerung.Entferne(Abrechnung, Abrechnung.Einkäufe.ToList()); // Besser vorher kopieren, sonst modifizieren wir die Liste während iteration
            Einkaufliste.BuildList();
        }

        private void Produktliste_HeaderCheckBoxChanging(object sender, HeaderCheckBoxChangingEventArgs e)
        {
            if (e.NewCheckState == CheckState.Checked)
                abrechnungssteuerung.FügeHinzu(Abrechnung, produktsteuerung.Produkte.Where(p => !p.Versteckt).Except(Abrechnung.Produkte).ToList());
            else
                abrechnungssteuerung.Entferne(Abrechnung, produktsteuerung.Produkte.Where(p => !p.Versteckt).Except(ErzwungeneProdukte).ToList());
            Produktliste.BuildList();
        }
    }
}
