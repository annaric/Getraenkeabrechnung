using BrightIdeasSoftware;
using Getränkeabrechnung.Modell;
using Getränkeabrechnung.Steuerung;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;

namespace Getränkeabrechnung.Ansicht
{
    partial class BenutzerListefenster : Getränkeabrechnung.Ansicht.GetränkeabrechnungFenster
    {
        private Benutzersteuerung benutzersteuerung;

        public BenutzerListefenster()
        {
            // Nur für Designer
            InitializeComponent();
            AktivListe.ModelFilter = new ModelFilter(x => ((Benutzer)x).Aktiv);
            InaktivListe.ModelFilter = new ModelFilter(x => !((Benutzer)x).Aktiv);
        }

        public BenutzerListefenster(Hauptfenster hauptfenster) : this()
        {
            Hauptfenster = hauptfenster;
            benutzersteuerung = hauptfenster.Steuerung.Benutzersteuerung;
        }

        public override void Fülle()
        {
            FülleBenutzer();
        }

        private void FülleBenutzer(Benutzer benutzer = null)
        {
            if (benutzer == null)
            {
                AktivListe.SetObjects(benutzersteuerung.Benutzer.ToList());
                AktivListe.Sort(ZimmerAktiv, SortOrder.Ascending);
                InaktivListe.SetObjects(benutzersteuerung.Benutzer.ToList());
                InaktivListe.Sort(ZimmerInaktiv, SortOrder.Ascending);
            } else
            {
                AktivListe.UpdateObject(benutzer);
                InaktivListe.UpdateObject(benutzer);
                var liste = benutzer.Aktiv ? AktivListe : InaktivListe;
                liste.EnsureModelVisible(benutzer);
                liste.SelectedObjects.Add(benutzer);
            }
        }

        private void NeuerBenutzer(Benutzer benutzer)
        {
            AktivListe.AddObject(benutzer);
            InaktivListe.AddObject(benutzer);

            var liste = benutzer.Aktiv ? AktivListe : InaktivListe;
            liste.EnsureModelVisible(benutzer);
            liste.SelectedObject = benutzer;
        }

        private void BenutzerListefenster_Load(object sender, EventArgs e)
        {
            benutzersteuerung.BenutzerVerändert += FülleBenutzer;
            benutzersteuerung.BenutzerHinzugefügt += NeuerBenutzer;
            Fülle();
        }

        private void BenutzerListefenster_FormClosing(object sender, FormClosingEventArgs e)
        {
            benutzersteuerung.BenutzerVerändert -= FülleBenutzer;
            benutzersteuerung.BenutzerHinzugefügt -= NeuerBenutzer;
        }

        private void AktivierenKnopf_Click(object sender, EventArgs e)
        {
            benutzersteuerung.SetzeAktiv(InaktivListe.SelectedObjects.Cast<Benutzer>().ToList(), true);
        }

        private void DeaktivierenKnopf_Click(object sender, EventArgs e)
        {
            benutzersteuerung.SetzeAktiv(AktivListe.SelectedObjects.Cast<Benutzer>().ToList(), false);
        }

        private void HinzufügenKnopf_Click(object sender, EventArgs e)
        {
            var benutzer = new Benutzer()
            {
                Vorname = "Vorname",
                Nachname = "Nachname",
                Zimmernummer = 320,
                Aktiv = true,
                Guthaben = 0.0
            };
            benutzersteuerung.NeuerBenutzer(benutzer);
        }

        private void InaktivListe_CellEditFinished(object sender, CellEditEventArgs e)
        {
            var benutzer = (Benutzer)e.RowObject;
            benutzersteuerung.BearbeiteBenutzer(benutzer);
        }

        private void AktivListe_CellEditFinished(object sender, CellEditEventArgs e)
        {
            var benutzer = (Benutzer)e.RowObject;
            benutzersteuerung.BearbeiteBenutzer(benutzer);
        }

        private void AnzeigenOptionAktiv_Click(object sender, EventArgs e)
        {
            Hauptfenster.ÖffneBenutzerfenster((Benutzer)AktivListe.SelectedObject);
        }

        private void AnzeigenOptionInaktiv_Click(object sender, EventArgs e)
        {
            Hauptfenster.ÖffneBenutzerfenster((Benutzer)InaktivListe.SelectedObject);
        }
    }
}
