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
    internal partial class Produktfenster : Getränkeabrechnung.Ansicht.GetränkeabrechnungFenster
    {
        private Produktsteuerung produktsteuerung;

        public Produktfenster()
        {
            InitializeComponent();
            ProduktListe.ModelFilter = new ModelFilter(x => !((Produkt)x).Versteckt);
            VerstecktSpalte.AspectToStringConverter = (x => "Löschen");
        }

        public Produktfenster(Hauptfenster hauptfenster) : this()
        {
            Hauptfenster = hauptfenster;
            produktsteuerung = hauptfenster.Steuerung.Produktsteuerung;
        }

        public override void Fülle()
        {
            FülleProdukt();
        }
        
        private void FülleProdukt(Produkt produkt = null)
        {
            if (produkt == null)
            {
                ProduktListe.SetObjects(produktsteuerung.Produkte);
                ProduktListe.Sort(NameSpalte, SortOrder.Ascending);
            } else
            {
                ProduktListe.UpdateObject(produkt);
            }
        }

        private void NeuesProdukt(Produkt produkt)
        {
            ProduktListe.AddObject(produkt);
        }

        private void Produktfenster_Load(object sender, EventArgs e)
        {
            produktsteuerung.ProduktVerändert += FülleProdukt;
            produktsteuerung.ProduktHinzugefügt += NeuesProdukt;
            Fülle();
        }

        private void Produktfenster_FormClosing(object sender, FormClosingEventArgs e)
        {
            produktsteuerung.ProduktVerändert -= FülleProdukt;
            produktsteuerung.ProduktHinzugefügt -= NeuesProdukt;
            Hauptfenster.Focus();
        }

        private void ProduktListe_CellEditFinishing(object sender, CellEditEventArgs e)
        {
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
    }
}
