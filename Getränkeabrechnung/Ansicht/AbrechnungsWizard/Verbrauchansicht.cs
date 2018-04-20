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

namespace Getränkeabrechnung.Ansicht.AbrechnungsWizard
{
    public partial class Verbrauchansicht : AbrechnungsWizardAnsicht
    {
        private Verbrauchsteuerung verbrauchsteuerung;
        private Verkaufsproduktsteuerung bestandsteuerung;
        private Abrechnungssteuerung abrechnungssteuerung;

        private Dictionary<Benutzer, VerbrauchProxy> verbrauchProxies;
        private BestandProxy bestandProxy;

        private abstract class Proxy
        {
            public abstract string Titel { get; }
            public abstract int Get(Produkt produkt);
            public abstract void Set(Produkt produkt, int wert);
        }

        private class VerbrauchProxy : Proxy
        {
            private Dictionary<Produkt, Verbrauch> verbrauche;
            private Benutzer benutzer;

            public VerbrauchProxy(Abrechnung abrechnung, Benutzer benutzer)
            {
                this.benutzer = benutzer;
                verbrauche = abrechnung.Verkaufsprodukte.ToDictionary(p => p.Produkt, p => abrechnung.Verbrauche.Single(v => v.Verkaufsprodukt == p && v.Benutzer == benutzer));
            }

            public override string Titel => benutzer.Anzeigename;

            public override int Get(Produkt produkt)
            {
                return verbrauche[produkt].AnzahlFlaschen;
            }

            public override void Set(Produkt produkt, int wert)
            {
                verbrauche[produkt].AnzahlFlaschen = wert;
            }

            public Verbrauch GetVerbrauch(Produkt produkt) => verbrauche[produkt];
        }

        private class BestandProxy : Proxy
        {
            private Dictionary<Produkt, Verkaufsprodukt> bestände;

            public BestandProxy(Abrechnung abrechnung)
            {
                bestände = abrechnung.Verkaufsprodukte.ToDictionary(vk => vk.Produkt);
            }

            public override string Titel => "Bestand";

            public override int Get(Produkt produkt)
            {
                return bestände[produkt].Bestand;
            }

            public override void Set(Produkt produkt, int wert)
            {
                bestände[produkt].Bestand = wert;
            }

            public Verkaufsprodukt GetBestand(Produkt produkt) => bestände[produkt];
        }

        public Verbrauchansicht()
        {
            InitializeComponent();

            verbrauchProxies = new Dictionary<Benutzer, VerbrauchProxy>();
        }

        public Verbrauchansicht(Hauptfenster hauptfenster) : this()
        {
            Hauptfenster = hauptfenster;
            verbrauchsteuerung = hauptfenster.Steuerung.Verbrauchsteuerung;
            bestandsteuerung = hauptfenster.Steuerung.Verkaufsproduktsteuerung;
            abrechnungssteuerung = hauptfenster.Steuerung.Abrechnungssteuerung;

            abrechnungssteuerung.AbrechnungVerändert += Abrechnungssteuerung_AbrechnungVerändert;
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
                abrechnungssteuerung.AbrechnungVerändert -= Abrechnungssteuerung_AbrechnungVerändert;
            }
            base.Dispose(disposing);
        }

        private void Abrechnungssteuerung_AbrechnungVerändert(Abrechnung abrechnung)
        {
            if (abrechnung != Abrechnung)
                return;

            Fülle();
        }

        public override void Fülle()
        {
            verbrauchProxies.Clear();
            // Verbrauchliste.Freeze();
            Verbrauchliste.Clear();
            Verbrauchliste.AllColumns.Clear();
            Verbrauchliste.AllColumns.Add(NameSpalte);
            if (Abrechnung != null)
            {
                for (int i = 0; i < Abrechnung.Verkaufsprodukte.Count; i++)
                {
                    var produkt = Abrechnung.Verkaufsprodukte[i].Produkt;
                    Verbrauchliste.AllColumns.Add(new OLVColumn
                    {
                        DisplayIndex = i + 1,
                        IsHeaderVertical = true,
                        AspectGetter = (o => ((Proxy)o).Get(produkt)),
                        AspectPutter = ((o, v) => ((Proxy)o).Set(produkt, (int)v)),
                        Text = produkt.Name,
                        Width = 35,
                        MinimumWidth = 35,
                        MaximumWidth = 35,
                        CellEditUseWholeCell = true
                    });
                }
                foreach (var benutzer in Abrechnung.Benutzer)
                {
                    verbrauchProxies[benutzer] = new VerbrauchProxy(Abrechnung, benutzer);
                }
                bestandProxy = new BestandProxy(Abrechnung);
                Verbrauchliste.SetObjects(new List<Proxy>());
                Verbrauchliste.AddObjects(Abrechnung.Benutzer.OrderBy(b => b.Zimmernummer).Select(b => verbrauchProxies[b]).ToList());
                Verbrauchliste.AddObject(bestandProxy);
            }
            Verbrauchliste.RebuildColumns();
            // Verbrauchliste.Unfreeze();
            // Verbrauchliste.Sort(NameSpalte);
        }

        private void Verbrauchliste_CellEditFinished(object sender, CellEditEventArgs e)
        {
            var produkt = Abrechnung.Verkaufsprodukte[e.Column.Index].Produkt;
            if (e.RowObject is VerbrauchProxy)
                verbrauchsteuerung.BearbeiteVerbrauch(((VerbrauchProxy)e.RowObject).GetVerbrauch(produkt));
            else
                bestandsteuerung.BearbeiteVerkaufsprodukt(((BestandProxy)e.RowObject).GetBestand(produkt));
        }

        private void Verbrauchliste_CellEditStarting(object sender, CellEditEventArgs e)
        {
            if (e.Control is NumericUpDown)
            {
                var upd = (UpDownBase)e.Control;
                upd.Select(0, upd.Text.Length);
            }
        }

        private void Verbrauchliste_FormatCell(object sender, FormatCellEventArgs e)
        {
            // Im Augenblick nicht aktiv
            if (e.Model is BestandProxy && e.ColumnIndex == 0)
                e.SubItem.Font = new Font(e.SubItem.Font, FontStyle.Bold);
        }

        private void Verbrauchliste_FormatRow(object sender, FormatRowEventArgs e)
        {
            if (e.Model is BestandProxy)
                e.Item.Font = new Font(e.Item.Font, FontStyle.Bold);
        }
    }
}
