using Getränkeabrechnung.Steuerung;
using Getränkeabrechnung.Modell;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Getränkeabrechnung.Ansicht.AbrechnungsWizard
{
    internal partial class Abrechnungsfenster : Getränkeabrechnung.Ansicht.GetränkeabrechnungFenster
    {
        private Abrechnungssteuerung abrechnungssteuerung;
        private Abrechnung abrechnung;

        public Abrechnung Abrechnung
        {
            get
            {
                return abrechnung;
            }

            set
            {
                abrechnung = value;
                Fülle();
            }
        }

        private AbrechnungsWizardAnsicht ansicht;

        public Abrechnungsfenster()
        {
            InitializeComponent();
        }

        public Abrechnungsfenster(Hauptfenster hauptfenster) : this()
        {
            Hauptfenster = hauptfenster;
            abrechnungssteuerung = hauptfenster.Steuerung.Abrechnungssteuerung;
        }

        public override void Fülle()
        {
            if (ansicht != null)
            {
                TableLayout.Controls.Remove(ansicht);
                ansicht.Dispose();
            }

            switch (abrechnung.Schritt)
            {
                case 1:
                    ansicht = new Konfigurationsansicht(Hauptfenster);
                    break;
                case 2:
                    ansicht = new Bestandteileansicht(Hauptfenster);
                    break;
                case 3:
                    ansicht = new Verbrauchansicht(Hauptfenster);
                    break;
            }

            ansicht.Abrechnung = Abrechnung;
            TableLayout.Controls.Add(ansicht, 0, 0);
            ansicht.Dock = DockStyle.Fill;

            Aktualisiere();
        }

        private void Aktualisiere(Abrechnung abrechnung = null)
        {
            if (abrechnung != null && abrechnung != Abrechnung)
                return;

            FülleKnöpfe();

            Text = Abrechnung.Name;
        }

        private void FülleKnöpfe()
        {
            ZurückKnopf.Text = abrechnung.Schritt == 1 ? "Löschen" : "Zurück";
            WeiterKnopf.Text = abrechnung.Schritt == 3 ? "Vorschau" : "Weiter";
        }

        private void ZurückKnopf_Click(object sender, EventArgs e)
        {
            if (abrechnung.Schritt == 1)
            {
                abrechnungssteuerung.LöscheAbrechnung(abrechnung);
                Close();
            } else
            {
                abrechnung.Schritt -= 1;
                abrechnungssteuerung.BearbeiteAbrechnung(abrechnung);
                Fülle();
            }
        }

        private void WeiterKnopf_Click(object sender, EventArgs e)
        {
            if (abrechnung.Schritt == 3)
            {
                Hauptfenster.AbrechnungsVorschauFenster.Abrechnung = abrechnung;
                Hauptfenster.AbrechnungsVorschauFenster.Show();
                Close();
                Hauptfenster.AbrechnungsVorschauFenster.Focus();
            } else
            {
                abrechnung.Schritt += 1;
                abrechnungssteuerung.BearbeiteAbrechnung(abrechnung);
                Fülle();
            }
        }

        private void Abrechnungsfenster_Load(object sender, EventArgs e)
        {
            abrechnungssteuerung.AbrechnungVerändert += Aktualisiere;
        }

        private void Abrechnungsfenster_FormClosing(object sender, FormClosingEventArgs e)
        {
            abrechnungssteuerung.AbrechnungVerändert -= Aktualisiere;
            Hauptfenster.Focus();
        }
    }
}
