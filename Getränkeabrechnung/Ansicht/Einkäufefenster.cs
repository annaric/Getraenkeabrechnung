using Getränkeabrechnung.Modell;
using Getränkeabrechnung.Steuerung;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Getränkeabrechnung.Ansicht
{
    internal partial class Einkäufefenster : GetränkeabrechnungFenster
    {
        private Einkaufsteuerung einkaufsteuerung;
        private Einkaufspositionssteuerung positionssteuerung;
        private Abrechnungssteuerung abrechnungssteuerung;

        private Einkauf Einkauf => (Einkauf)Einkäufeliste.SelectedObject;

        public Einkäufefenster()
        {
            InitializeComponent();
        }

        public Einkäufefenster(Hauptfenster hauptfenster) : this()
        {
            Hauptfenster = hauptfenster;
            einkaufsteuerung = hauptfenster.Steuerung.Einkaufsteuerung;
            positionssteuerung = hauptfenster.Steuerung.Einkaufspositionssteuerung;
            abrechnungssteuerung = hauptfenster.Steuerung.Abrechnungssteuerung;

            AbrechnungSpalte.AspectToStringConverter = (a => ((Abrechnung)a)?.Name);
            EinkaufLöschenSpalte.AspectToStringConverter = (a => (a == null || !((Abrechnung)a).Gebucht) ? "Löschen" : null);
            PositionLöschenSpalte.AspectToStringConverter = (e => "Löschen");
            KontoSpalte.AspectToStringConverter = (ü => ((Überweisung)ü).Konto.Name);
            ProduktSpalte.AspectToStringConverter = (p => ((Kastengröße)p).Anzeigename);

            KontoBox.Kontosteuerung = hauptfenster.Steuerung.Kontosteuerung;
            ProduktBox.Kastengrößensteuerung = hauptfenster.Steuerung.Kastengrößensteuerung;
        }

        private void Einkäufefenster_Load(object sender, EventArgs e)
        {
            einkaufsteuerung.EinkaufVerändert += FülleEinkäufe;
            einkaufsteuerung.EinkaufHinzugefügt += NeuerEinkauf;
            einkaufsteuerung.EinkaufGelöscht += EinkaufGelöscht;

            positionssteuerung.EinkaufspositionHinzugefügt += NeuePosition;
            positionssteuerung.EinkaufspositionVerändert += PositionVerändert;
            positionssteuerung.EinkaufspositionGelöscht += PositionGelöscht;

            abrechnungssteuerung.AbrechnungVerändert += Abrechnungssteuerung_AbrechnungVerändert;
            Fülle();
        }

        private void Einkäufefenster_FormClosing(object sender, FormClosingEventArgs e)
        {
            einkaufsteuerung.EinkaufVerändert -= FülleEinkäufe;
            einkaufsteuerung.EinkaufHinzugefügt -= NeuerEinkauf;
            einkaufsteuerung.EinkaufGelöscht -= EinkaufGelöscht;
        }

        public override void Fülle()
        {
            FülleEinkäufe();
        }

        private void FülleEinkäufe(Einkauf einkauf = null)
        {
            if (einkauf == null)
            {
                Einkäufeliste.SetObjects(einkaufsteuerung.Einkäufe.ToList());
                Einkäufeliste.Sort(DatumSpalte, SortOrder.Descending);
            }
            else
                Einkäufeliste.RefreshObject(einkauf);
        }

        private void FüllePositionen()
        {
            if (Einkauf == null)
            {
                Positionenliste.ClearObjects();
                Positionenliste.Enabled = false;
            }
            else
            {
                Positionenliste.Enabled = einkaufsteuerung.IstLöschbar(Einkauf);
                PositionLöschenSpalte.IsVisible = Positionenliste.Enabled;
                NeuePositonPanel.Enabled = Positionenliste.Enabled;
                Positionenliste.RebuildColumns();
                Positionenliste.SetObjects(Einkauf.Positionen.ToList());
                Positionenliste.Sort(ProduktSpalte);
            }
        }

        private void Abrechnungssteuerung_AbrechnungVerändert(Abrechnung abrechnung)
        {
            Einkäufeliste.RefreshObjects(abrechnung.Einkäufe);
        }

        private void PositionVerändert(Einkaufsposition position)
        {
            if (position.Einkauf == Einkauf)
                Positionenliste.RefreshObject(position);
        }

        private void NeuePosition(Einkaufsposition position)
        {
            if (position.Einkauf == Einkauf)
                Positionenliste.AddObject(position);
        }

        private void PositionGelöscht(Einkaufsposition position)
        {
            // if (position.Einkauf == Einkauf)
            // position ist schon null
            Positionenliste.RemoveObject(position);
        }

        private void NeuerEinkauf(Einkauf einkauf)
        {
            Einkäufeliste.AddObject(einkauf);
            Einkäufeliste.EnsureModelVisible(einkauf);
        }

        private void EinkaufGelöscht(Einkauf einkauf)
        {
            Einkäufeliste.RemoveObject(einkauf);
        }

        private void Einkäufeliste_CellEditFinished(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
            if (e.Cancel)
                return;
            var einkauf = (Einkauf)e.RowObject;
            einkaufsteuerung.BearbeiteEinkauf(einkauf);
        }

        private void Einkäufeliste_CellEditStarting(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
            var einkauf = (Einkauf)e.RowObject;
            if (!einkaufsteuerung.IstLöschbar(einkauf))
                e.Cancel = true;
        }

        private void Einkäufeliste_SelectionChanged(object sender, EventArgs e)
        {
            FüllePositionen();
        }

        private void Einkäufeliste_ButtonClick(object sender, BrightIdeasSoftware.CellClickEventArgs e)
        {
            var einkauf = (Einkauf)e.Model;
            einkaufsteuerung.LöscheEinkauf(einkauf);
        }

        private void NeuerEinkaufKnopf_Click(object sender, EventArgs e)
        {
            var betrag = BetragBox.Betrag;
            if (betrag == null)
                return;

            var einkauf = new Einkauf()
            {
                Zeitpunkt = DatumBox.Value,
                Rechnungsnummer = RechnungsnummberBox.Text,
                Betrag = betrag.Value
            };

            einkaufsteuerung.NeuerEinkauf(einkauf, KontoBox.Konto);
        }

        private void NeuePositionKnopf_Click(object sender, EventArgs e)
        {
            if (Einkauf == null)
                return;

            int anzahl = (int)AnzahlBox.Value;

            var position = new Einkaufsposition
            {
                Kastengröße = ProduktBox.Kastengröße,
                AnzahlKästen = anzahl
            };

            positionssteuerung.NeuePosition(position, Einkauf);
        }

        private void Positionenliste_CellEditStarting(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
            if (e.Value is Produkt)
            {
                var produktBox = new ProduktBox() { Kastengrößensteuerung = Hauptfenster.Steuerung.Kastengrößensteuerung };
                produktBox.Bounds = e.CellBounds;
                produktBox.Kastengröße = (Kastengröße)e.Value;
                e.Control = produktBox;
            }
        }

        private void Positionenliste_ButtonClick(object sender, BrightIdeasSoftware.CellClickEventArgs e)
        {
            var position = (Einkaufsposition)e.Model;
            positionssteuerung.LöschePosition(position);
        }
    }
}
