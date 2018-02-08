using BrightIdeasSoftware;
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
    internal partial class Produktfenster : GetränkeabrechnungFenster
    {
        private Produktsteuerung produktsteuerung;
        private Einkaufspositionssteuerung positionssteuerung;

        private ISet<Produkt> benutzteProdukte;

        public Produktfenster()
        {
            InitializeComponent();
            ProduktListe.ModelFilter = new ModelFilter(x => !((Produkt)x).Versteckt);
            VerstecktSpalte.AspectGetter = (x => x);
            VerstecktSpalte.AspectToStringConverter = (x => benutzteProdukte.Contains((Produkt)x) ? null : "Löschen");

            benutzteProdukte = new HashSet<Produkt>();
        }

        public Produktfenster(Hauptfenster hauptfenster) : this()
        {
            Hauptfenster = hauptfenster;
            produktsteuerung = hauptfenster.Steuerung.Produktsteuerung;
            positionssteuerung = hauptfenster.Steuerung.Einkaufspositionssteuerung;
        }

        public override void Fülle()
        {
            FülleProdukt();
        }
        
        private void FülleProdukt(Produkt produkt = null)
        {
            if (produkt == null)
            {
                benutzteProdukte = new HashSet<Produkt>(produktsteuerung.BenutzteProdukte);
                ProduktListe.SetObjects(produktsteuerung.Produkte);
                ProduktListe.Sort(NameSpalte, SortOrder.Ascending);
            } else
            {
                ProduktListe.UpdateObject(produkt);
            }
        }

        private void NeuePosition(Einkaufsposition position)
        {
            // Eine neue Position ist garantiert Teil eines noch nicht abgerechneten Einkaufs.
            // Abgerechnete Einkäufe (und ihre Positionen) dürfen nicht modifiziert werden.
            benutzteProdukte.Add(position.Produkt);
            ProduktListe.RefreshObject(position.Produkt);
        }

        private void AktualisiereBenutzteProdukte(Einkaufsposition position)
        {
            benutzteProdukte = new HashSet<Produkt>(produktsteuerung.BenutzteProdukte);
            ProduktListe.RefreshObject(position.Produkt);  // TODO: Wenn eine Position gelöscht wird, ist position.Produkt an dieser Stelle schon null
        }

        private void NeuesProdukt(Produkt produkt)
        {
            benutzteProdukte.Add(produkt);
            ProduktListe.AddObject(produkt);
        }

        private void Produktfenster_Load(object sender, EventArgs e)
        {
            produktsteuerung.ProduktVerändert += FülleProdukt;
            produktsteuerung.ProduktHinzugefügt += NeuesProdukt;
            positionssteuerung.EinkaufspositionHinzugefügt += NeuePosition;
            positionssteuerung.EinkaufspositionVerändert += AktualisiereBenutzteProdukte;
            positionssteuerung.EinkaufspositionGelöscht += AktualisiereBenutzteProdukte;
            Fülle();
        }

        private void Produktfenster_FormClosing(object sender, FormClosingEventArgs e)
        {
            produktsteuerung.ProduktVerändert -= FülleProdukt;
            produktsteuerung.ProduktHinzugefügt -= NeuesProdukt;
            positionssteuerung.EinkaufspositionHinzugefügt -= NeuePosition;
            positionssteuerung.EinkaufspositionVerändert -= AktualisiereBenutzteProdukte;
            positionssteuerung.EinkaufspositionGelöscht -= AktualisiereBenutzteProdukte;
            Hauptfenster.Focus();
        }

        private void ProduktListe_CellEditFinishing(object sender, CellEditEventArgs e)
        {
            if (e.Cancel)
                return;

            var produkt = (Produkt)e.RowObject;
            var bearbeitbaresProdukt = produktsteuerung.BearbeitbaresProdukt(produkt);
            if (produkt != bearbeitbaresProdukt)
            {
                e.Cancel = true;
                e.Column.PutAspectByName(bearbeitbaresProdukt, e.NewValue);
                produktsteuerung.BearbeiteProdukt(bearbeitbaresProdukt);
            }
        }

        private void ProduktListe_CellEditFinished(object sender, CellEditEventArgs e)
        {
            if (e.Cancel)
                return;

            var produkt = (Produkt)e.RowObject;
            produktsteuerung.BearbeiteProdukt(produkt);
        }

        private void ProduktListe_ButtonClick(object sender, CellClickEventArgs e)
        {
            var produkt = (Produkt)e.Model;
            produkt.Versteckt = true;
            produktsteuerung.BearbeiteProdukt(produkt);
        }

        private void NeuesProduktKnopf_Click(object sender, EventArgs e)
        {
            var produkt = new Produkt()
            {
                Name = "Neues Produkt",
                Kastengröße = 20,
                Preis = 0.0,
                Einkaufspreis = 0.0,
                Versteckt = false
            };
            produktsteuerung.NeuesProdukt(produkt);
        }

        private void ProduktListe_CellEditStarting(object sender, CellEditEventArgs e)
        {
            var produkt = (Produkt)e.RowObject;
            if (benutzteProdukte.Contains(produkt))
                e.Cancel = true;
        }

        private void ProduktListe_CellToolTipShowing(object sender, ToolTipShowingEventArgs e)
        {
            if (benutzteProdukte.Contains((Produkt)e.Model))
            {
                e.Text = "Dieses Produkt kann nicht bearbeitet werden, weil es Teil eines noch nicht abgerechneten Einkaufs ist.";
            }
        }
    }
}
