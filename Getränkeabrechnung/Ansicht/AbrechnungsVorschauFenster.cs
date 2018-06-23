using Getränkeabrechnung.Modell;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BrightIdeasSoftware;
using Getränkeabrechnung.Steuerung;
using System.Drawing.Printing;

namespace Getränkeabrechnung.Ansicht
{
    public partial class AbrechnungsVorschauFenster : GetränkeabrechnungFenster
    {
        private Zahlungssteuerung zahlungssteuerung;
        private Abrechnungssteuerung abrechnungssteuerung;
        private Benutzersteuerung benutzersteuerung;

        private Dictionary<Benutzer, BenutzerProxy> benutzerProxies;
        private AltBestandProxy altBestandProxy;
        private BestandProxy bestandProxy;
        private VerkaufProxy verbrauchProxy;
        private EinkaufProxy einkaufProxy;
        private VerlustProxy verlustProxy;
        private VerlustWertProxy verlustWertProxy;
        private VerlustUmlageProxy verlustUmlageProxy;

        private abstract class Proxy
        {
            public abstract string Name { get; }
            public abstract string VerbrauchKosten { get; }
            public abstract string VerlustKosten { get; }
            public abstract string AltesGuthaben { get; }
            public abstract string NeuesGuthaben { get; }
            public abstract string Get(Produkt produkt);

            public virtual bool FormatCells => false;
            public virtual void Format(FormatCellEventArgs e) { }
        }

        private class BenutzerProxy : Proxy
        {
            private Abrechnung abrechnung;
            private Dictionary<Produkt, Verbrauch> verbrauche;
            private Benutzer benutzer;
            private Zahlung zahlung;
            private double verbrauchKosten;
            private double verlustKosten;

            public override string Name => benutzer.Anzeigename;
            public override string VerbrauchKosten => verbrauchKosten.ToString("C");
            public override string VerlustKosten => verlustKosten.ToString("C");
            public double NeuesGuthabenDouble => abrechnung.Gebucht ? zahlung.NeuesGuthaben : benutzer.Guthaben - verbrauchKosten - verlustKosten;
            public double AltesGuthabenDouble => abrechnung.Gebucht ? zahlung.AltesGuthaben : benutzer.Guthaben;
            public override string NeuesGuthaben => NeuesGuthabenDouble.ToString("C");
            public override string AltesGuthaben => AltesGuthabenDouble.ToString("C");

            public BenutzerProxy(Abrechnung abrechnung, Benutzer benutzer, double verluste)
            {
                this.abrechnung = abrechnung;
                this.benutzer = benutzer;
                verbrauche = abrechnung.Verkaufsprodukte.ToDictionary(p => p.Produkt, p => abrechnung.Verbrauche.Single(v => v.Verkaufsprodukt == p && v.Benutzer == benutzer));
                verbrauchKosten = verbrauche.Values.Select(v => v.AnzahlFlaschen * v.Verkaufsprodukt.Verkaufspreis).Sum();
                zahlung = abrechnung.Gebucht ? abrechnung.Zahlungen.Single(z => z.Benutzer == benutzer) : null;
                verlustKosten = verluste;
            }

            public override string Get(Produkt produkt)
            {
                return verbrauche[produkt].AnzahlFlaschen.ToString("d");
            }
        }

        private abstract class FettProxy : Proxy
        {
            public override bool FormatCells => true;

            public override string VerbrauchKosten => "";
            public override string VerlustKosten => "";
            public override string AltesGuthaben => "";
            public override string NeuesGuthaben => "";

            public override void Format(FormatCellEventArgs e)
            {
                if (e.ColumnIndex == 0)
                    e.SubItem.Font = new Font(e.SubItem.Font, FontStyle.Bold);
            }
        }

        private class BestandProxy : FettProxy
        {
            protected Dictionary<Produkt, int> bestände;

            public override string Name => "Bestand nachher";

            public BestandProxy(Abrechnung abrechnung)
            {
                bestände = abrechnung.Verkaufsprodukte.ToDictionary(p => p.Produkt, p => p.Bestand);
            }

            public override string Get(Produkt produkt)
            {
                return bestände[produkt].ToString("d");
            }
        }
        
        private class AltBestandProxy : FettProxy
        {
            protected Dictionary<Produkt, int> bestände;

            public override string Name => "Bestand vorher";

            public AltBestandProxy(Abrechnung abrechnung)
            {
                bestände = abrechnung.BerechneAltbestände();
            }

            public override string Get(Produkt produkt)
            {
                return bestände[produkt].ToString("d");
            }
        }

        private class VerkaufProxy : FettProxy
        {
            private Abrechnung abrechnung;
            public Dictionary<Produkt, int> verkäufe;
            private double verbrauchPreisTotal;
            private double gesamtSchulden;

            public override string Name => "Verkauf";
            public override string VerbrauchKosten => verbrauchPreisTotal.ToString("C");
            public override string NeuesGuthaben => gesamtSchulden.ToString("C");

            public VerkaufProxy(Abrechnung abrechnung, ICollection<BenutzerProxy> proxies)
            {
                this.abrechnung = abrechnung;
                verkäufe = abrechnung.BerechneVerbrauche();
                verbrauchPreisTotal = abrechnung.Verbrauche.Select(v => v.Verkaufsprodukt.Verkaufspreis * v.AnzahlFlaschen).Sum();
                gesamtSchulden = proxies.Select(p => p.NeuesGuthabenDouble).Sum();
            }

            public override string Get(Produkt produkt)
            {
                return verkäufe[produkt].ToString("d");
            }

            public override void Format(FormatCellEventArgs e)
            {
                base.Format(e);
                if (e.ColumnIndex > abrechnung.Verkaufsprodukte.Count)
                    e.SubItem.Font = new Font(e.SubItem.Font, FontStyle.Bold);
            }
        }

        private class EinkaufProxy : FettProxy
        {
            private Dictionary<Produkt, int> einkäufe;

            public override string Name => "Einkauf";

            public EinkaufProxy(Abrechnung abrechnung)
            {
                einkäufe = abrechnung.BerechneEinkäufe();
            }

            public override string Get(Produkt produkt)
            {
                return einkäufe[produkt].ToString("d");
            }
        }

        private class VerlustProxy : FettProxy
        {
            public Dictionary<Produkt, int> verluste;

            public override string Name => "Verluste";

            public VerlustProxy(Abrechnung abrechnung)
            {
                verluste = abrechnung.BerechneVerluste();
            }

            public override string Get(Produkt produkt)
            {
                return verluste[produkt].ToString("d");
            }
        }

        private class VerlustWertProxy : FettProxy
        {
            private Abrechnung abrechnung;
            public Dictionary<Produkt, double> verlustwerte;
            private double total;

            public override string Name => "Verlustwert";
            public override string VerbrauchKosten => total.ToString("C");

            public VerlustWertProxy(Abrechnung abrechnung, VerlustProxy proxy)
            {
                this.abrechnung = abrechnung;
                verlustwerte = abrechnung.Verkaufsprodukte.ToDictionary(p => p.Produkt, p => proxy.verluste[p.Produkt] * p.Verkaufspreis);
                total = verlustwerte.Values.Sum();
            }

            public override string Get(Produkt produkt)
            {
                return verlustwerte[produkt].ToString("C");
            }

            public override void Format(FormatCellEventArgs e)
            {
                base.Format(e);
                if (e.ColumnIndex > abrechnung.Verkaufsprodukte.Count)
                    e.SubItem.Font = new Font(e.SubItem.Font, FontStyle.Bold);
            }
        }

        private class VerlustUmlageProxy : FettProxy
        {
            private Dictionary<Produkt, double> verlustUmlagen;

            public override string Name => "Verlustzuschlag";

            public VerlustUmlageProxy(Abrechnung abrechnung, VerkaufProxy verbrauch, VerlustWertProxy wert)
            {
                verlustUmlagen = verbrauch.verkäufe.Keys.ToDictionary(p => p, p => verbrauch.verkäufe[p] != 0 ? wert.verlustwerte[p] / verbrauch.verkäufe[p] : 0.0);
            }

            public override string Get(Produkt produkt)
            {
                return verlustUmlagen[produkt].ToString("C");
            }
        }

        private Abrechnung _abrechnung;
        public Abrechnung Abrechnung
        {
            get => _abrechnung;
            set
            {
                _abrechnung = value;
                Fülle();
            }
        }

        public AbrechnungsVorschauFenster()
        {
            InitializeComponent();

            benutzerProxies = new Dictionary<Benutzer, BenutzerProxy>();
        }

        public AbrechnungsVorschauFenster(Hauptfenster hauptfenster) : this()
        {
            Hauptfenster = hauptfenster;

            zahlungssteuerung = hauptfenster.Steuerung.Zahlungssteuerung;
            abrechnungssteuerung = hauptfenster.Steuerung.Abrechnungssteuerung;
            benutzersteuerung = hauptfenster.Steuerung.Benutzersteuerung;
        }

        private void AktualisiereBenutzer(Benutzer benutzer)
        {
            if (!benutzerProxies.ContainsKey(benutzer))
                return;

            Tabelle.UpdateObject(benutzerProxies[benutzer]);
        }

        public override void Fülle()
        {
            if (Abrechnung != null)
            {
                if (Abrechnung.Gebucht)
                {
                    Text = Abrechnung.Name;
                    Knopf.Text = "Exportieren...";
                } else
                {
                    Text = Abrechnung.Name + " - Vorschau";
                    Knopf.Text = "Buchen...";
                }
            }

            Knopf.Enabled = Abrechnung != null;
            

            benutzerProxies.Clear();

            Tabelle.Clear();
            Tabelle.AllColumns.Clear();
            NameSpalte.DisplayIndex = 0;
            NameSpalte.Text = Abrechnung.Name + (Abrechnung.Gebucht ? "" : " - Vorschau");
            Tabelle.AllColumns.Add(NameSpalte);
            if (Abrechnung != null)
            {
                for (int i = 0; i < Abrechnung.Verkaufsprodukte.Count; i++)
                {
                    var produkt = Abrechnung.Verkaufsprodukte[i].Produkt;
                    Tabelle.AllColumns.Add(new OLVColumn
                    {
                        DisplayIndex = i + 1,
                        IsHeaderVertical = true,
                        AspectGetter = (o => ((Proxy)o).Get(produkt)),
                        IsEditable = false,
                        Text = produkt.Name,
                        Width = 55,
                        TextAlign = HorizontalAlignment.Right
                    });
                }
                var verluste = Abrechnung.BerechneVerlustumlage();

                foreach (var benutzer in Abrechnung.Benutzer)
                {
                    benutzerProxies[benutzer] = new BenutzerProxy(Abrechnung, benutzer, verluste[benutzer]);
                }
            }

            Tabelle.AllColumns.Add(VerbrauchKostenSpalte);
            Tabelle.AllColumns.Add(VerlustKostenSpalte);
            Tabelle.AllColumns.Add(AltGuthabenSpalte);
            Tabelle.AllColumns.Add(NeuGuthabenSpalte);
            Tabelle.RebuildColumns();

            if (Abrechnung != null)
            {
                VerbrauchKostenSpalte.DisplayIndex = Abrechnung.Verkaufsprodukte.Count + 4;
                VerlustKostenSpalte.DisplayIndex = Abrechnung.Verkaufsprodukte.Count + 4;
                AltGuthabenSpalte.DisplayIndex = Abrechnung.Verkaufsprodukte.Count + 4;
                NeuGuthabenSpalte.DisplayIndex = Abrechnung.Verkaufsprodukte.Count + 4;

                Tabelle.SetObjects(new List<Proxy>());
                altBestandProxy = new AltBestandProxy(Abrechnung);
                Tabelle.AddObject(altBestandProxy);
                einkaufProxy = new EinkaufProxy(Abrechnung);
                Tabelle.AddObject(einkaufProxy);
                Tabelle.AddObjects(Abrechnung.Benutzer.OrderBy(b => b.Zimmernummer).Select(b => benutzerProxies[b]).ToList());
                verbrauchProxy = new VerkaufProxy(Abrechnung, benutzerProxies.Values);
                Tabelle.AddObject(verbrauchProxy);
                bestandProxy = new BestandProxy(Abrechnung);
                Tabelle.AddObject(bestandProxy);
                verlustProxy = new VerlustProxy(Abrechnung);
                Tabelle.AddObject(verlustProxy);
                verlustWertProxy = new VerlustWertProxy(Abrechnung, verlustProxy);
                Tabelle.AddObject(verlustWertProxy);
                verlustUmlageProxy = new VerlustUmlageProxy(Abrechnung, verbrauchProxy, verlustWertProxy);
                Tabelle.AddObject(verlustUmlageProxy);
            }
        }

        private void Tabelle_FormatRow(object sender, FormatRowEventArgs e)
        {
            e.UseCellFormatEvents = ((Proxy)e.Model).FormatCells;
            e.Item.UseItemStyleForSubItems = !((Proxy)e.Model).FormatCells;
        }

        private void Tabelle_FormatCell(object sender, FormatCellEventArgs e)
        {
            ((Proxy)e.Model).Format(e);
            e.SubItem.BackColor = e.Item.BackColor;
        }

        private void Knopf_Click(object sender, EventArgs e)
        {
            if (Abrechnung == null)
                return;

            if (Abrechnung.Gebucht)
            {
                speichernDialog.ShowDialog();
            } else
            {
                DialogResult dialogResult = MessageBox.Show(this, "Bist du sicher, dass du die Abrechnung buchen willst? Diese Aktion kann nicht rückgängig gemacht werden.", "Abrechnung buchen", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    var zahlungen = Abrechnung.Buche();
                    foreach (var zahlung in zahlungen)
                        zahlungssteuerung.NeueZahlung(zahlung);
                    abrechnungssteuerung.BearbeiteAbrechnung(Abrechnung);
                    Fülle();
                }
            }
        }

        private void PrintDokument_PrintPage(object sender, PrintPageEventArgs e)
        {
            ZeichneListeAufGraphics(e.Graphics, e.MarginBounds);
        }

        private void ZeichneListeAufGraphics(Graphics graphics, Rectangle bounds)
        {
            Bitmap bitmap = new Bitmap(Tabelle.Width, Tabelle.Height);
            Tabelle.DrawToBitmap(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height));
            Rectangle target = new Rectangle(0, 0, bounds.Width, bounds.Height);
            double xScale = (double)bitmap.Width / bounds.Width;
            double yScale = (double)bitmap.Height / bounds.Height;
            if (xScale < yScale)
                target.Width = (int)(xScale * target.Width / yScale);
            else
                target.Height = (int)(yScale * target.Height / xScale);
            graphics.PageUnit = GraphicsUnit.Display;
            graphics.DrawImage(bitmap, target);
        }

        private void AbrechnungsVorschauFenster_Load(object sender, EventArgs e)
        {
            benutzersteuerung.BenutzerVerändert += AktualisiereBenutzer;
        }

        private void AbrechnungsVorschauFenster_FormClosing(object sender, FormClosingEventArgs e)
        {
            benutzersteuerung.BenutzerVerändert -= AktualisiereBenutzer;
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            using (var file = new System.IO.StreamWriter(speichernDialog.OpenFile()))
            {
                file.WriteLine(Abrechnung.NachHtml());
            }
        }
    }
}
