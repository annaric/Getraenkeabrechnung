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
    public partial class Konfigurationsansicht : AbrechnungsWizardAnsicht
    {
        private Abrechnungssteuerung abrechnungssteuerung;

        private Abrechnung DummyAbrechnung;

        public Konfigurationsansicht()
        {
            InitializeComponent();

            AbrechnungBox.DisplayMember = "Name";
            DummyAbrechnung = new Abrechnung() { Name = "(keine)" };
        }

        public Konfigurationsansicht(Hauptfenster hauptfenster) : this()
        {
            Hauptfenster = hauptfenster;
            abrechnungssteuerung = hauptfenster.Steuerung.Abrechnungssteuerung;

            // Rein technisch gesehen müssten wir auf AbrechnungVerändert hören, um die Felder aktuell zu halten, sowie die Liste der
            // Ausgansbestände zu aktualisieren. Aber eine Abrechnung kann nicht außerhalb dieses Fensters bearbeitet werden.
            // abrechnungssteuerung.AbrechnungVerändert += AbrechnungBearbeitet;
        }

        public override void Fülle()
        {
            StartzeitBox.ValueChanged -= StartzeitBox_ValueChanged;
            EndzeitBox.ValueChanged -= EndzeitBox_ValueChanged;
            AbrechnungBox.SelectedIndexChanged -= AbrechnungBox_SelectedIndexChanged;

            
            AbrechnungBox.Items.Clear();
            AbrechnungBox.Items.Add(DummyAbrechnung);
            if (Abrechnung.AusgangsBestandAbrechnung != null)
                AbrechnungBox.Items.Add(Abrechnung.AusgangsBestandAbrechnung);
            AbrechnungBox.Items.AddRange(abrechnungssteuerung.AusgangsBestandAbrechnungen(Abrechnung).ToArray());

            NameBox.Text = Abrechnung.Name;
            StartzeitBox.Value = Abrechnung.Startzeitpunkt;
            EndzeitBox.Value = Abrechnung.Endzeitpunkt;
            if (Abrechnung.AusgangsBestandAbrechnung != null)
                AbrechnungBox.SelectedIndex = AbrechnungBox.Items.IndexOf(Abrechnung.AusgangsBestandAbrechnung);
            else
                AbrechnungBox.SelectedIndex = 0; // Auf (keine)

            StartzeitBox.ValueChanged += StartzeitBox_ValueChanged;
            EndzeitBox.ValueChanged += EndzeitBox_ValueChanged;
            AbrechnungBox.SelectedIndexChanged += AbrechnungBox_SelectedIndexChanged;
        }

        private void AbrechnungBearbeitet(Abrechnung abrechnung)
        {
            if (abrechnung != Abrechnung)
                return;

            Fülle();
        }

        private void NameBox_Leave(object sender, EventArgs e)
        {
            Abrechnung.Name = NameBox.Text;
            abrechnungssteuerung.BearbeiteAbrechnung(Abrechnung);
        }

        private void StartzeitBox_ValueChanged(object sender, EventArgs e)
        {
            Abrechnung.Startzeitpunkt = StartzeitBox.Value;
            abrechnungssteuerung.BearbeiteAbrechnung(Abrechnung);
        }

        private void EndzeitBox_ValueChanged(object sender, EventArgs e)
        {
            Abrechnung.Endzeitpunkt = EndzeitBox.Value;
            abrechnungssteuerung.BearbeiteAbrechnung(Abrechnung);
        }

        private void AbrechnungBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var abrechnung = (Abrechnung)AbrechnungBox.SelectedItem;
            if (abrechnung == DummyAbrechnung)
                Abrechnung.AusgangsBestandAbrechnung = null;
            else
                Abrechnung.AusgangsBestandAbrechnung = abrechnung;
            abrechnungssteuerung.BearbeiteAbrechnung(Abrechnung);
        }
    }
}
