using Getränkeabrechnung.Modell;
using Getränkeabrechnung.Steuerung;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Getränkeabrechnung.Ansicht
{
    public partial class ProduktBox : ComboBox
    {
        private Kastengrößensteuerung kastengrößensteuerung;

        [Browsable(false)]
        public Kastengrößensteuerung Kastengrößensteuerung
        {
            get
            {
                return kastengrößensteuerung;
            }

            set
            {
                if (kastengrößensteuerung != null)
                {
                    Items.Clear();
                    kastengrößensteuerung.KastengrößeHinzugefügt -= KastengrößeHinzugefügt;
                    kastengrößensteuerung.KastengrößeBearbeitet -= KastengrößeVerändert;
                }
                kastengrößensteuerung = value;
                if (kastengrößensteuerung != null)
                {
                    kastengrößensteuerung.KastengrößeHinzugefügt += KastengrößeHinzugefügt;
                    kastengrößensteuerung.KastengrößeBearbeitet += KastengrößeVerändert;
                    Fülle();
                }
            }
        }

        [Browsable(false)]
        public Kastengröße Kastengröße
        {
            get
            {
                return (Kastengröße)SelectedItem;
            }
            set
            {
                SelectedItem = Kastengröße;
            }
        }

        public delegate bool KastengrößeFilter(Kastengröße k);

        [NonSerialized]
        private KastengrößeFilter filter;
        [Browsable(false)]
        public KastengrößeFilter Filter
        {
            get
            {
                return filter;
            }
            set
            {
                filter = value;
                if (kastengrößensteuerung != null)
                    Fülle();
            }
        }

        private void Fülle()
        {
            if (kastengrößensteuerung != null)
            {
                Items.Clear();
                var größen = kastengrößensteuerung.Kastengrößen;
                if (filter == null)
                    größen = größen.Where(p => !p.Versteckt && !p.Produkt.Versteckt);
                else
                    größen = größen.Where(p => filter(p));
                Items.AddRange(größen.OrderBy(p => p.Produkt.Name).ThenBy(p => p.Größe).Cast<object>().ToArray());
                if (Items.Count > 0)
                    SelectedIndex = 0;
            }
        }

        public ProduktBox()
        {
            InitializeComponent();
            DisplayMember = "Anzeigename";
        }

        private void KastengrößeHinzugefügt(Kastengröße größe)
        {
            Fülle();
        }

        private void KastengrößeVerändert(Kastengröße größe)
        {
            Fülle();
        }
    }
}
