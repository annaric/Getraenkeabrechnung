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
    partial class Hauptfenster : Getränkeabrechnung.Ansicht.GetränkeabrechnungFenster
    {
        public Datenbanksteuerung Steuerung { get; private set; }
        private Kontosteuerung kontosteuerung;
        private Abrechnungssteuerung abrechnungssteuerung;
        private Benutzersteuerung benutzersteuerung;

        private Benutzerfenster benutzerfenster;
        private Kontofenster kontofenster;

        public Hauptfenster()
        {
            InitializeComponent();
            Steuerung = new Datenbanksteuerung();

            kontosteuerung = Steuerung.Kontosteuerung;
            abrechnungssteuerung = Steuerung.Abrechnungssteuerung;
            benutzersteuerung = Steuerung.Benutzersteuerung;

            StatusSpalte.AspectToStringConverter = Util.AbrechnungZustandZuString;
        }

        private void Hauptfenster_Load(object sender, EventArgs e)
        {
            string letzteDatenbank = Properties.Settings.Default.Datenbankpfad;
            ÖffneDatenbank(letzteDatenbank);

            kontosteuerung.KontoVerändert += FülleKonten;
            abrechnungssteuerung.AbrechnungVerändert += FülleAbrechnungen;
            benutzersteuerung.BenutzerVerändert += FülleBenutzer;
        }

        private void ÖffneDatenbank(string dateiname)
        {
            Steuerung.Öffne(dateiname);
            if (!Steuerung.Geöffnet)
            {
                MessageBox.Show(string.Format("Datenbank {0} konnte nicht geladen werden.", dateiname),
                    "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                Fülle();
            }
        }

        public override void Fülle()
        {
            FülleKonten();
            FülleAbrechnungen();
            FülleBenutzer();
        }

        private void FülleKonten(Konto konto = null)
        {
            if (konto == null)
                Kontenliste.SetObjects(kontosteuerung.Konten);
            else
                Kontenliste.RefreshObject(konto);
        }

        private void FülleBenutzer(Benutzer benutzer = null)
        {
            if (benutzer == null || benutzer.Aktiv)
            {
                Benutzerliste.SetObjects(benutzersteuerung.Benutzer.Where(b => b.Aktiv));
                Benutzerliste.Sort(GuthabenSpalte, SortOrder.Ascending);
                GuthabenSpalte.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            else
                Benutzerliste.RemoveObject(benutzer);

        }

        private void FülleAbrechnungen(Abrechnung abrechnung = null)
        {
            if (abrechnung == null)
                Abrechnungsliste.SetObjects(abrechnungssteuerung.Abrechnungen.OrderByDescending(x => x.Startzeitpunkt).Take(5));
            else
                Abrechnungsliste.RefreshObject(abrechnung);
            StatusSpalte.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void Hauptfenster_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Andere Fenster schließen
            Steuerung.Schließe();
        }

        private void Benutzerliste_FormatCell(object sender, BrightIdeasSoftware.FormatCellEventArgs e)
        {
            if (e.ColumnIndex == GuthabenSpalte.Index)
            {
                Util.KontostandFormatieren(e);
            }
        }

        private void Abrechnungsliste_FormatCell(object sender, BrightIdeasSoftware.FormatCellEventArgs e)
        {
            if (e.ColumnIndex == StatusSpalte.Index)
            {
                Util.AbrechnungFormatieren(e);
            }
        }

        private void Benutzerliste_ItemActivate(object sender, EventArgs e)
        {
            if (benutzerfenster == null || benutzerfenster.IsDisposed)
                benutzerfenster = new Benutzerfenster(this);
            benutzerfenster.Benutzer = (Benutzer)Benutzerliste.GetModelObject(Benutzerliste.SelectedIndex);
            benutzerfenster.Show();
            benutzerfenster.Focus();
        }

        private void Kontenliste_ItemActivate(object sender, EventArgs e)
        {
            if (kontofenster == null || kontofenster.IsDisposed)
                kontofenster = new Kontofenster(this);
            kontofenster.Konto = (Konto)Kontenliste.GetModelObject(Kontenliste.SelectedIndex);
            kontofenster.Show();
            kontofenster.Focus();
        }

        private void neuesKontoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
