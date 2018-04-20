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
        private class Proxy
        {
            public Produkt Produkt { get; set; }
            public Kastengröße Kastengröße { get; set; }
            public bool IstKastengröße => Kastengröße != null;
            public string Name
            {
                get => IstKastengröße ? Kastengröße.Anzeigename : Produkt.Name;
                set => Produkt.Name = value;
            }
            public int? Größe
            {
                get => Kastengröße?.Größe;
                set
                {
                    if (Kastengröße != null && value.HasValue)
                        Kastengröße.Größe = value.Value;
                }
            }
            public bool Versteckt => Kastengröße?.Versteckt ?? Produkt.Versteckt;
            public double? Einkaufspreis
            {
                get => Kastengröße?.Einkaufspreis;
                set
                {
                    if (Kastengröße != null && value.HasValue)
                        Kastengröße.Einkaufspreis = value.Value;
                }
            }
            public double? Pfand
            {
                get => Kastengröße?.Pfand;
                set
                {
                    if (Kastengröße != null && value.HasValue)
                        Kastengröße.Pfand = value.Value;
                }
            }
            public double? Verkaufspreis
            {
                get => IstKastengröße ? (double?)null : Produkt.AktuellerVerkaufspreis;
                set
                {
                    if (Kastengröße == null && value.HasValue)
                        Produkt.AktuellerVerkaufspreis = value.Value;
                }
            }
            public int? Listenposition
            {
                get => IstKastengröße ? (int?)null : Produkt.Listenposition;
                set
                {
                    if (Kastengröße == null && value.HasValue)
                        Produkt.Listenposition = value.Value;
                }
            }
        }

        private Produktsteuerung produktsteuerung;
        private Einkaufspositionssteuerung positionssteuerung;
        private Abrechnungssteuerung abrechnungssteuerung;
        private Kastengrößensteuerung kastengrößensteuerung;
        private Verkaufsproduktsteuerung verkaufsproduktsteuerung;

        private ISet<Produkt> benutzteProdukte;
        private ISet<Kastengröße> benutzteKastengrößen;
        private Dictionary<Produkt, Proxy> proxies;

        public Produktfenster()
        {
            InitializeComponent();
            ProduktListe.ModelFilter = new ModelFilter(x => !((Proxy)x).Versteckt);
            ProduktListe.CanExpandGetter = (p => !((Proxy)p).Versteckt && !((Proxy)p).IstKastengröße && ((Proxy)p).Produkt.Kastengrößen.Any(k => !k.Versteckt));
            ProduktListe.ChildrenGetter = (p => ((Proxy)p).Produkt.Kastengrößen.Where(k => !k.Versteckt).Select(k => new Proxy() { Produkt = ((Proxy)p).Produkt, Kastengröße = k }));
            VerstecktSpalte.AspectGetter = (x => x);
            VerstecktSpalte.AspectToStringConverter = (x =>
            {
                var proxy = (Proxy)x;
                var kannGelöschtWerden = proxy.IstKastengröße ? !benutzteKastengrößen.Contains(proxy.Kastengröße) : !benutzteProdukte.Contains(proxy.Produkt);
                return kannGelöschtWerden ? "Löschen" : null;
            });

            benutzteProdukte = new HashSet<Produkt>();
            benutzteKastengrößen = new HashSet<Kastengröße>();
            proxies = new Dictionary<Produkt, Proxy>();
        }

        public Produktfenster(Hauptfenster hauptfenster) : this()
        {
            Hauptfenster = hauptfenster;
            produktsteuerung = hauptfenster.Steuerung.Produktsteuerung;
            positionssteuerung = hauptfenster.Steuerung.Einkaufspositionssteuerung;
            abrechnungssteuerung = hauptfenster.Steuerung.Abrechnungssteuerung;
            kastengrößensteuerung = hauptfenster.Steuerung.Kastengrößensteuerung;
            verkaufsproduktsteuerung = hauptfenster.Steuerung.Verkaufsproduktsteuerung;
        }

        public override void Fülle()
        {
            FülleProdukte();
        }
        
        private void FülleProdukte(Produkt produkt = null)
        {
            if (produkt == null)
            {
                benutzteProdukte = produktsteuerung.BenutzteProdukte.ToHashSet();
                benutzteKastengrößen = kastengrößensteuerung.UnlöschbareKastengrößen.ToHashSet();
                proxies = produktsteuerung.Produkte.Select(p => new Proxy() { Produkt = p }).ToDictionary(p => p.Produkt);
                ProduktListe.Roots = proxies.Values.ToList();
                ProduktListe.ExpandAll();
                ProduktListe.Sort(KastengrößeSpalte, SortOrder.Descending);
                ProduktListe.Sort(NameSpalte, SortOrder.Ascending);
            } else
            {
                ProduktListe.UpdateObject(proxies[produkt]);
            }
        }

        private void NeuePosition(Einkaufsposition position)
        {
            // Eine neue Position ist garantiert Teil eines noch nicht abgerechneten Einkaufs.
            // Abgerechnete Einkäufe (und ihre Positionen) dürfen nicht modifiziert werden.
            benutzteProdukte.Add(position.Kastengröße.Produkt);
            benutzteKastengrößen.Add(position.Kastengröße);
            var proxy = proxies[position.Kastengröße.Produkt];
            ProduktListe.UpdateObject(proxy);
            if (ProduktListe.IsExpanded(proxy))
            {
                var child = ProduktListe.GetChildren(proxy).Cast<Proxy>().Single(p => p.Kastengröße == position.Kastengröße);
                ProduktListe.UpdateObject(child);
            }
        }

        private void PositionBearbeitet(Einkaufsposition position)
        {
            benutzteKastengrößen = kastengrößensteuerung.UnlöschbareKastengrößen.ToHashSet();
            benutzteProdukte = benutzteKastengrößen.Select(k => k.Produkt).ToHashSet();
            if (position.Kastengröße != null)
            {
                var proxy = proxies[position.Kastengröße.Produkt];
                ProduktListe.UpdateObject(proxy);
                if (ProduktListe.IsExpanded(proxy))
                {
                    var child = ProduktListe.GetChildren(proxy).Cast<Proxy>().Single(p => p.Kastengröße == position.Kastengröße);
                    ProduktListe.UpdateObject(child);
                }
            }
            else // TODO: Wenn eine Position gelöscht wird, ist position.Produkt an dieser Stelle schon null
                ProduktListe.BuildList();
        }

        private void AbrechnungGebucht(Abrechnung abrechnung)
        {
            benutzteKastengrößen = kastengrößensteuerung.UnlöschbareKastengrößen.ToHashSet();
            benutzteProdukte = benutzteKastengrößen.Select(k => k.Produkt).ToHashSet();
            ProduktListe.BuildList();
        }

        private void NeuesProdukt(Produkt produkt)
        {
            var proxy = new Proxy() { Produkt = produkt };
            proxies[produkt] = proxy;
            ProduktListe.AddObject(proxy);
            ProduktListe.SelectedObject = proxy;
            ProduktListe.EditSubItem(ProduktListe.ModelToItem(proxy), NameSpalte.Index);
        }

        private void Produktfenster_Load(object sender, EventArgs e)
        {
            produktsteuerung.ProduktVerändert += FülleProdukte;
            produktsteuerung.ProduktHinzugefügt += NeuesProdukt;
            positionssteuerung.EinkaufspositionHinzugefügt += NeuePosition;
            positionssteuerung.EinkaufspositionVerändert += PositionBearbeitet;
            positionssteuerung.EinkaufspositionGelöscht += PositionBearbeitet;
            abrechnungssteuerung.AbrechnungGebucht += AbrechnungGebucht;
            kastengrößensteuerung.KastengrößeHinzugefügt += Kastengrößensteuerung_KastengrößeHinzugefügt;
            kastengrößensteuerung.KastengrößeBearbeitet += Kastengrößensteuerung_KastengrößeBearbeitet;
            verkaufsproduktsteuerung.VerkaufsproduktHinzugefügt += Verkaufsproduktsteuerung_VerkaufsproduktHinzugefügt;
            verkaufsproduktsteuerung.VerkaufsproduktGelöscht += Verkaufsproduktsteuerung_VerkaufsproduktGelöscht;
            Fülle();
        }

        private void Produktfenster_FormClosing(object sender, FormClosingEventArgs e)
        {
            produktsteuerung.ProduktVerändert -= FülleProdukte;
            produktsteuerung.ProduktHinzugefügt -= NeuesProdukt;
            positionssteuerung.EinkaufspositionHinzugefügt -= NeuePosition;
            positionssteuerung.EinkaufspositionVerändert -= PositionBearbeitet;
            positionssteuerung.EinkaufspositionGelöscht -= PositionBearbeitet;
            abrechnungssteuerung.AbrechnungGebucht -= AbrechnungGebucht;
            kastengrößensteuerung.KastengrößeHinzugefügt -= Kastengrößensteuerung_KastengrößeHinzugefügt;
            kastengrößensteuerung.KastengrößeBearbeitet -= Kastengrößensteuerung_KastengrößeBearbeitet;
            verkaufsproduktsteuerung.VerkaufsproduktHinzugefügt -= Verkaufsproduktsteuerung_VerkaufsproduktHinzugefügt;
            verkaufsproduktsteuerung.VerkaufsproduktGelöscht -= Verkaufsproduktsteuerung_VerkaufsproduktGelöscht;
            Hauptfenster.Focus();
        }

        private void Verkaufsproduktsteuerung_VerkaufsproduktGelöscht(Verkaufsprodukt p)
        {
            // TODO: schlecht, wenn viele Produkte auf einmal entfernt werden
            benutzteProdukte = produktsteuerung.BenutzteProdukte.ToHashSet();
            ProduktListe.BuildList();
        }

        private void Verkaufsproduktsteuerung_VerkaufsproduktHinzugefügt(Verkaufsprodukt p)
        {
            benutzteProdukte.Add(p.Produkt);
            ProduktListe.UpdateObject(proxies[p.Produkt]);
        }

        private void Kastengrößensteuerung_KastengrößeHinzugefügt(Kastengröße kastengröße)
        {
            var proxy = proxies[kastengröße.Produkt];
            ProduktListe.UpdateObject(proxy);
            ProduktListe.Expand(proxy);
            var child = ProduktListe.GetChildren(proxy).Cast<Proxy>().Single(p => p.Kastengröße == kastengröße);
            ProduktListe.SelectedObject = child;
            ProduktListe.EditSubItem(ProduktListe.ModelToItem(child), KastengrößeSpalte.Index);
        }

        private void Kastengrößensteuerung_KastengrößeBearbeitet(Kastengröße kastengröße)
        {
            var proxy = proxies[kastengröße.Produkt];
            ProduktListe.UpdateObject(proxy);
            if (ProduktListe.IsExpanded(proxy))
            {
                var child = ProduktListe.GetChildren(proxy).Cast<Proxy>().Single(p => p.Kastengröße == kastengröße);
                ProduktListe.UpdateObject(child);
            }
        }

        private void ProduktListe_CellEditFinished(object sender, CellEditEventArgs e)
        {
            if (e.Cancel)
                return;

            var proxy = (Proxy)e.RowObject;
            if (proxy.IstKastengröße)
                kastengrößensteuerung.BearbeiteKastengröße(proxy.Kastengröße);
            else
                produktsteuerung.BearbeiteProdukt(proxy.Produkt);
        }

        private void ProduktListe_ButtonClick(object sender, CellClickEventArgs e)
        {
            var proxy = (Proxy)e.Model;
            if (proxy.IstKastengröße)
                kastengrößensteuerung.Lösche(proxy.Kastengröße);
            else
                produktsteuerung.Lösche(proxy.Produkt);
        }

        private void NeuesProduktKnopf_Click(object sender, EventArgs e)
        {
            var produkt = new Produkt()
            {
                Name = "Neues Produkt",
                Versteckt = false
            };
            produktsteuerung.NeuesProdukt(produkt);
        }

        private void UnterproduktKnopf_Click(object sender, EventArgs e)
        {
            if (ProduktListe.SelectedObject == null)
                return;

            var proxy = (Proxy)ProduktListe.SelectedObject;
            kastengrößensteuerung.FügeHinzu(proxy.Produkt, new Kastengröße { Produkt = proxy.Produkt });
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            UnterproduktKnopf.Enabled = ProduktListe.SelectedObject != null;   
        }

        private void ProduktListe_CellEditStarting(object sender, CellEditEventArgs e)
        {
            var proxy = (Proxy)e.RowObject;
            if (proxy.IstKastengröße && !e.Cancel)
                e.Cancel = (e.Column == NameSpalte || e.Column == PreisSpalte || e.Column == PositionSpalte)
                    || (e.Column == KastengrößeSpalte && !kastengrößensteuerung.KannBearbeitetWerden(proxy.Kastengröße));
            else if (!e.Cancel)
                e.Cancel = (e.Column == KastengrößeSpalte || e.Column == EinkaufspreisSpalte || e.Column == PfandSpalte);
        }

        private void ProduktListe_CellToolTipShowing(object sender, ToolTipShowingEventArgs e)
        {
            var proxy = (Proxy)e.Model;
            bool löschbar = proxy.IstKastengröße ? !benutzteKastengrößen.Contains(proxy.Kastengröße) : !benutzteProdukte.Contains(proxy.Produkt);
            if (!löschbar && e.Column == VerstecktSpalte)
                e.Text = "Dieses Produkt kann nicht gelöscht werden, weil es in noch nicht abgerechneten Einkäufen vorkommt.";
        }
    }
}
