using Getränkeabrechnung.Modell;
using Getränkeabrechnung.Steuerung;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace Getränkeabrechnung.Ansicht
{
    internal partial class Kontofenster : Getränkeabrechnung.Ansicht.GetränkeabrechnungFenster
    {
        private Überweisungssteuerung überweisungssteuerung;
        private Kontosteuerung kontosteuerung;
        private Konto konto;

        public Konto Konto {
            get
            {
                return konto;
            }

            set
            {
                if (value != null)
                {
                    konto = value;
                    Fülle();
                }
            }
        }

        public Kontofenster()
        {
            InitializeComponent();
            StornoSpalte.AspectToStringConverter = (x => (Boolean)x ? "Stornieren" : null);
            KontoAuswahl.DisplayMember = "Name";
        }

        public Kontofenster(Hauptfenster hauptfenster) : this()
        {
            Hauptfenster = hauptfenster;
            überweisungssteuerung = hauptfenster.Steuerung.Überweisungssteuerung;
            kontosteuerung = hauptfenster.Steuerung.Kontosteuerung;
        }

        public override void Fülle()
        {
            if (konto == null)
                return;

            FülleKonto();
            FülleÜberweisungen();
        }

        private void FülleKonto(Konto k = null)
        {
            KontoAuswahl.Items.Clear();
            KontoAuswahl.Items.AddRange(kontosteuerung.Konten.Where(kk => kk != konto).Cast<object>().ToArray());
            if (KontoAuswahl.Items.Count > 0)
                KontoAuswahl.SelectedIndex = 0;

            if (k != null && k != konto)
                return;

            Text = konto.Name;
            NameBox.Text = konto.Name;
            KontostandLabel.Text = konto.Kontostand.ToString("C");
        }

        private void FülleÜberweisungen(Überweisung überweisung = null)
        {
            if (überweisung != null && überweisung.Konto != konto)
                return;

            if (überweisung == null)
            {
                Überweisungsliste.SetObjects(konto.Überweisungen.ToList());
                Überweisungsliste.Sort(ErstellungSpalte, SortOrder.Ascending);
                Überweisungsliste.TopItemIndex = Überweisungsliste.Items.Count - 1;
            }
            else
                Überweisungsliste.RefreshObject(überweisung);
            
        }

        private void NeueÜberweisung(Überweisung überweisung)
        {
            if (überweisung.Konto != konto)
                return;

            Überweisungsliste.AddObject(überweisung);
            Überweisungsliste.Sort(ErstellungSpalte, SortOrder.Ascending);
            Überweisungsliste.TopItemIndex = Überweisungsliste.Items.Count - 1;
        }

        private void Kontofenster_Load(object sender, EventArgs e)
        {
            überweisungssteuerung.ÜberweisungVerändert += FülleÜberweisungen;
            überweisungssteuerung.ÜberweisungHinzugefügt += NeueÜberweisung;
            kontosteuerung.KontoVerändert += FülleKonto;
            kontosteuerung.KontoHinzugefügt += FülleKonto;
        }

        private void Kontofenster_FormClosing(object sender, FormClosingEventArgs e)
        {
            überweisungssteuerung.ÜberweisungVerändert -= FülleÜberweisungen;
            überweisungssteuerung.ÜberweisungHinzugefügt -= NeueÜberweisung;
            kontosteuerung.KontoVerändert -= FülleKonto;
            kontosteuerung.KontoHinzugefügt -= FülleKonto;
            Hauptfenster.Focus();
        }

        private void Überweisungsliste_CellEditFinished(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
            var überweisung = (Überweisung)e.RowObject;
            überweisungssteuerung.BearbeiteÜberweisung(überweisung);
        }

        private void Überweisungsliste_ButtonClick(object sender, BrightIdeasSoftware.CellClickEventArgs e)
        {
            var überweisung = (Überweisung)e.Model;
            überweisungssteuerung.StorniereÜberweisung(überweisung);
        }

        private void BetragBox_Leave(object sender, EventArgs e)
        {
            Util.BetragBoxFormatieren(BetragBox);
        }

        private void BetragBox2_Leave(object sender, EventArgs e)
        {
            Util.BetragBoxFormatieren(BetragBox2);
        }

        private void HinzufügenKnopf_Click(object sender, EventArgs e)
        {
            if (!Double.TryParse(BetragBox.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out double betrag))
                return; // TODO: Was schöneres hier.

            var überweisung = new Überweisung()
            {
                Buchungszeitpunkt = DatumBox.Value,
                Betrag = betrag,
                Beschreibung = BeschreibungBox.Text
            };

            überweisungssteuerung.NeueÜberweisung(konto, überweisung);
        }

        private void UmbuchenKnopf_Click(object sender, EventArgs e)
        {
            if (!Double.TryParse(BetragBox2.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out double betrag))
                return; // TODO: Was schöneres hier.

            if (KontoAuswahl.SelectedItem == null)
                return; // TODO: Was schöneres hier.

            var nachKonto = (Konto)KontoAuswahl.SelectedItem;

            kontosteuerung.BucheUm(konto, nachKonto, betrag);
        }

        private void NameBox_Leave(object sender, EventArgs e)
        {
            konto.Name = NameBox.Text;
            kontosteuerung.BearbeiteKonto(konto);
        }

        private void NameBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                SelectNextControl((Control)sender, true, true, true, true);
            }
        }
    }
}
