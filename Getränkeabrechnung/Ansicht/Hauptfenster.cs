using BrightIdeasSoftware;
using Getränkeabrechnung.Ansicht.AbrechnungsWizard;
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
    public partial class Hauptfenster : GetränkeabrechnungFenster
    {
        public Datenbanksteuerung Steuerung { get; private set; }
        private Kontosteuerung kontosteuerung;
        private Abrechnungssteuerung abrechnungssteuerung;
        private Benutzersteuerung benutzersteuerung;

        private Benutzerfenster _benutzerfenster;
        private Kontofenster _kontofenster;
        private BenutzerListefenster _benutzerListefenster;
        private Produktfenster _produktfenster;
        private Einkäufefenster _einkäufefenster;
        private Abrechnungsfenster _abrechnungsfenster;

        Benutzerfenster Benutzerfenster
        {
            get
            {
                if (_benutzerfenster == null || _benutzerfenster.IsDisposed)
                    _benutzerfenster = new Benutzerfenster(this);
                return _benutzerfenster;
            }
        }

        Kontofenster Kontofenster
        {
            get
            {
                if (_kontofenster == null || _kontofenster.IsDisposed)
                    _kontofenster = new Kontofenster(this);
                return _kontofenster;
            }
        }

        BenutzerListefenster BenutzerListefenster
        {
            get
            {
                if (_benutzerListefenster == null || _benutzerListefenster.IsDisposed)
                    _benutzerListefenster = new BenutzerListefenster(this);
                return _benutzerListefenster;
            }
        }

        Produktfenster Produktfenster
        {
            get
            {
                if (_produktfenster == null || _produktfenster.IsDisposed)
                    _produktfenster = new Produktfenster(this);
                return _produktfenster;
            }
        }

        Einkäufefenster Einkäufefenster
        {
            get
            {
                if (_einkäufefenster == null || _einkäufefenster.IsDisposed)
                    _einkäufefenster = new Einkäufefenster(this);
                return _einkäufefenster;
            }
        }

        Abrechnungsfenster Abrechnungsfenster
        {
            get
            {
                if (_abrechnungsfenster == null || _abrechnungsfenster.IsDisposed)
                    _abrechnungsfenster = new Abrechnungsfenster(this);
                return _abrechnungsfenster;
            }
        }

        public Hauptfenster()
        {
            InitializeComponent();
            Steuerung = new Datenbanksteuerung();

            kontosteuerung = Steuerung.Kontosteuerung;
            abrechnungssteuerung = Steuerung.Abrechnungssteuerung;
            benutzersteuerung = Steuerung.Benutzersteuerung;

            StatusSpalte.AspectToStringConverter = Util.AbrechnungZustandZuString;

            Benutzerliste.ModelFilter = new ModelFilter(x => ((Benutzer)x).Aktiv);
        }

        private void Hauptfenster_Load(object sender, EventArgs e)
        {
            string letzteDatenbank = Properties.Settings.Default.Datenbankpfad;
            ÖffneDatenbank(letzteDatenbank);

            kontosteuerung.KontoVerändert += FülleKonten;
            abrechnungssteuerung.AbrechnungHinzugefügt += Abrechnungssteuerung_AbrechnungenVerändert;
            abrechnungssteuerung.AbrechnungVerändert += FülleAbrechnungen;
            abrechnungssteuerung.AbrechnungGebucht += FülleAbrechnungen;
            abrechnungssteuerung.AbrechnungGelöscht += Abrechnungssteuerung_AbrechnungenVerändert;
            benutzersteuerung.BenutzerVerändert += FülleBenutzer;
            benutzersteuerung.BenutzerHinzugefügt += Benutzersteuerung_BenutzerHinzugefügt;
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
                Kontenliste.SetObjects(kontosteuerung.Konten.ToList());
            else
                Kontenliste.RefreshObject(konto);
        }

        private void FülleBenutzer(Benutzer benutzer = null)
        {
            if (benutzer == null)
            {
                Benutzerliste.SetObjects(benutzersteuerung.Benutzer.ToList());
                Benutzerliste.Sort(GuthabenSpalte, SortOrder.Ascending);
                GuthabenSpalte.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            else
                Benutzerliste.UpdateObject(benutzer);
        }

        private void FülleAbrechnungen(Abrechnung abrechnung = null)
        {
            if (abrechnung == null)
                Abrechnungsliste.SetObjects(abrechnungssteuerung.Abrechnungen.OrderByDescending(x => x.Startzeitpunkt).Take(8).ToList());
            else
                Abrechnungsliste.RefreshObject(abrechnung);
            StatusSpalte.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);

            NeueAbrechnungKnopf.Enabled = !abrechnungssteuerung.Abrechnungen.Any(a => !a.Gebucht);
        }

        private void Benutzersteuerung_BenutzerHinzugefügt(Benutzer benutzer)
        {
            Benutzerliste.AddObject(benutzer);
        }

        private void Abrechnungssteuerung_AbrechnungenVerändert(Abrechnung abrechnung)
        {
            FülleAbrechnungen();
        }

        private void Hauptfenster_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Andere Fenster schließen?
            Steuerung.Schließe();
        }

        private void Benutzerliste_FormatCell(object sender, FormatCellEventArgs e)
        {
            if (e.ColumnIndex == GuthabenSpalte.Index)
            {
                Util.KontostandFormatieren(e);
            }
        }

        private void Abrechnungsliste_FormatCell(object sender, FormatCellEventArgs e)
        {
            if (e.ColumnIndex == StatusSpalte.Index)
            {
                Util.AbrechnungFormatieren(e);
            }
        }

        private void Benutzerliste_ItemActivate(object sender, EventArgs e)
        {
            Benutzerfenster.Benutzer = (Benutzer)Benutzerliste.GetModelObject(Benutzerliste.SelectedIndex);
            Benutzerfenster.Show();
            Benutzerfenster.Focus();
        }

        private void Kontenliste_ItemActivate(object sender, EventArgs e)
        {
            Kontofenster.Konto = (Konto)Kontenliste.GetModelObject(Kontenliste.SelectedIndex);
            Kontofenster.Show();
            Kontofenster.Focus();
        }

        private void neuesKontoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void BenutzerKnopf_Click(object sender, EventArgs e)
        {
            BenutzerListefenster.Show();
            BenutzerListefenster.Focus();
        }

        private void ProduktKnopf_Click(object sender, EventArgs e)
        {
            Produktfenster.Show();
            Produktfenster.Focus();
        }

        private void EinkäufeKnopf_Click(object sender, EventArgs e)
        {
            Einkäufefenster.Show();
            Einkäufefenster.Focus();
        }

        private void NeueAbrechnungKnopf_Click(object sender, EventArgs e)
        {
            var letzteGebuchte = abrechnungssteuerung.Abrechnungen.Where(a => a.Gebucht).OrderByDescending(a => a.Endzeitpunkt).FirstOrDefault();

            var jetzt = DateTime.Now;

            var abrechnung = new Abrechnung
            {
                Startzeitpunkt = letzteGebuchte?.Endzeitpunkt ?? jetzt,
                Endzeitpunkt = jetzt,
                Name = "Abrechnung " + jetzt.ToString("MMMM"),
            };
            abrechnung.AusgangsBestandAbrechnung = abrechnungssteuerung.AusgangsBestandAbrechnungen(abrechnung).OrderByDescending(a => a.Endzeitpunkt).FirstOrDefault();
            abrechnung.Benutzer.AddRange(abrechnungssteuerung.Benutzersteuerung.Benutzer.Where(b => b.Aktiv));

            abrechnungssteuerung.NeueAbrechnung(abrechnung);

            Abrechnungsfenster.Abrechnung = abrechnung;
            Abrechnungsfenster.Show();
            Abrechnungsfenster.Focus();
        }

        private void Abrechnungsliste_ItemActivate(object sender, EventArgs e)
        {
            var abrechnung = (Abrechnung)Abrechnungsliste.SelectedObject;

            if (!abrechnung.Gebucht)
            {
                Abrechnungsfenster.Abrechnung = abrechnung;
                Abrechnungsfenster.Show();
                Abrechnungsfenster.Focus();
            } else
            {
                // TODO
            }
        }

        public void ÖffneBenutzerfenster(Benutzer benutzer)
        {
            Benutzerfenster.Benutzer = benutzer;
            Benutzerfenster.Show();
            Benutzerfenster.Focus();
        }
    }
}
