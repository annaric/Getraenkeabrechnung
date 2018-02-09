using Getränkeabrechnung.Modell;
using Getränkeabrechnung.Steuerung;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Getränkeabrechnung.Ansicht
{
    partial class Benutzerfenster : Getränkeabrechnung.Ansicht.GetränkeabrechnungFenster
    {
        private Benutzersteuerung benutzersteuerung;
        private Zahlungssteuerung zahlungssteuerung;
        private Kontosteuerung kontosteuerung;
        private Benutzer benutzer;

        public Benutzer Benutzer {
            get
            {
                return benutzer;
            }

            set
            {
                if (value != null)
                {
                    benutzer = value;
                    Fülle();
                }
            }
        }

        public Benutzerfenster()
        {
            // Do not use. Only for Designer
            InitializeComponent();
            KontoSpalte.AspectToStringConverter = (x => x != null ? ((Überweisung)x).Konto.Name : "");
            StornoSpalte.AspectToStringConverter = (x => (Boolean)x ? "Stornieren" : null);
            KontoAuswahl.DisplayMember = "Name";
            KontoAuswahl2.DisplayMember = "Name";
        }

        public Benutzerfenster(Hauptfenster hauptfenster) : this()
        {
            Hauptfenster = hauptfenster;
            benutzersteuerung = hauptfenster.Steuerung.Benutzersteuerung;
            zahlungssteuerung = hauptfenster.Steuerung.Zahlungssteuerung;
            kontosteuerung = hauptfenster.Steuerung.Kontosteuerung;
        }

        public override void Fülle()
        {
            if (benutzer == null)
                return;

            FülleBenutzer();
            FülleZahlungen();
            FülleKonto();
        }

        private void FülleZahlungen(Zahlung zahlung = null)
        {
            if (zahlung != null && zahlung.Benutzer != benutzer)
            {
                return;
            }

            if (zahlung == null)
            {
                Zahlungsliste.SetObjects(benutzer.Zahlungen.ToList());
                Zahlungsliste.Sort(DatumSpalte, SortOrder.Ascending);
                Zahlungsliste.TopItemIndex = Zahlungsliste.Items.Count - 1;
            }
            else
                Zahlungsliste.RefreshObject(zahlung);
        }

        private void NeueZahlung(Zahlung zahlung)
        {
            if (zahlung.Benutzer != benutzer)
                return;

            Zahlungsliste.AddObject(zahlung);
            Zahlungsliste.Sort(ErstellungSpalte, SortOrder.Ascending);
            Zahlungsliste.TopItemIndex = Zahlungsliste.Items.Count - 1;
        }

        private void FülleBenutzer(Benutzer b = null)
        {
            if (b != null && b != benutzer)
                return;

            Text = benutzer.Anzeigename;
            NameLabel.Text = benutzer.Anzeigename;
            GuthabenLabel.Text = benutzer.Guthaben.ToString("C");
            BetragBox2.Text = benutzer.Kaution.ToString("C");
        }

        private void FülleKonto(Konto konto = null)
        {
            KontoAuswahl.Items.Clear();
            KontoAuswahl.Items.AddRange(kontosteuerung.Konten.Cast<object>().ToArray());
            if (KontoAuswahl.Items.Count > 0)
                KontoAuswahl.SelectedIndex = 0;

            KontoAuswahl2.Items.Clear();
            KontoAuswahl2.Items.AddRange(kontosteuerung.Konten.Cast<object>().ToArray());
            if (KontoAuswahl2.Items.Count > 0)
                KontoAuswahl2.SelectedIndex = 0;
        }

        private void Benutzerfenster_Load(object sender, EventArgs e)
        {
            benutzersteuerung.BenutzerVerändert += FülleBenutzer;
            zahlungssteuerung.ZahlungVerändert += FülleZahlungen;
            zahlungssteuerung.ZahlungHinzugefügt += NeueZahlung;
            kontosteuerung.KontoVerändert += FülleKonto;
            kontosteuerung.KontoHinzugefügt += FülleKonto;
        }

        private void Benutzerfenster_FormClosing(object sender, FormClosingEventArgs e)
        {
            benutzersteuerung.BenutzerVerändert -= FülleBenutzer;
            zahlungssteuerung.ZahlungVerändert -= FülleZahlungen;
            zahlungssteuerung.ZahlungHinzugefügt -= NeueZahlung;
            kontosteuerung.KontoVerändert -= FülleKonto;
            kontosteuerung.KontoHinzugefügt -= FülleKonto;
            Hauptfenster.Focus();
        }

        private void Zahlungsliste_CellEditFinished(object sender, BrightIdeasSoftware.CellEditEventArgs e)
        {
            var zahlung = (Zahlung)e.RowObject;
            zahlungssteuerung.BearbeiteZahlung(zahlung);
        }

        private void Zahlungsliste_ButtonClick(object sender, BrightIdeasSoftware.CellClickEventArgs e)
        {
            var zahlung = (Zahlung)e.Model;
            zahlungssteuerung.StorniereZahlung(zahlung);
        }

        private void BetragBox_Leave(object sender, EventArgs e)
        {
            Util.BetragBoxFormatieren(BetragBox);
        }

        private void KautionKnopf_Leave(object sender, EventArgs e)
        {
            Util.BetragBoxFormatieren(BetragBox2);
        }

        private void HinzufügenKnopf_Click(object sender, EventArgs e)
        {
            if (!Double.TryParse(BetragBox.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out double betrag))
                return; // TODO: Was schöneres hier.

            if (KontoAuswahl.SelectedItem == null)
                return; // TODO: Was schöneres hier.

            var nachKonto = (Konto)KontoAuswahl.SelectedItem;

            var zahlung = new Zahlung()
            {
                Buchungszeitpunkt = DatumBox.Value,
                Betrag = betrag,
                Beschreibung = BeschreibungBox.Text,
            };
            zahlungssteuerung.NeueZahlung(benutzer, nachKonto, zahlung);
        }

        private void KautionKnopf_Click(object sender, EventArgs e)
        {
            if (!Double.TryParse(BetragBox2.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out double betrag))
                return; // TODO: Was schöneres hier.

            if (KontoAuswahl2.SelectedItem == null)
                return; // TODO: Was schöneres hier.

            var nachKonto = (Konto)KontoAuswahl2.SelectedItem;

            benutzersteuerung.SetzeKaution(benutzer, betrag, nachKonto);
        }
    }
}
