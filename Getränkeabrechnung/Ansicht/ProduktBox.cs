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
        private Produktsteuerung produktsteuerung;

        [Browsable(false)]
        public Produktsteuerung Produktsteuerung
        {
            get
            {
                return produktsteuerung;
            }

            set
            {
                if (produktsteuerung != null)
                {
                    Items.Clear();
                    produktsteuerung.ProduktHinzugefügt -= ProduktHinzugefügt;
                    produktsteuerung.ProduktVerändert -= ProduktVerändert;
                }
                produktsteuerung = value;
                if (produktsteuerung != null)
                {
                    produktsteuerung.ProduktHinzugefügt += ProduktHinzugefügt;
                    produktsteuerung.ProduktVerändert += ProduktVerändert;
                    Fülle();
                }
            }
        }

        [Browsable(false)]
        public Produkt Produkt
        {
            get
            {
                return (Produkt)SelectedItem;
            }
            set
            {
                SelectedItem = Produkt;
            }
        }

        public delegate bool ProduktFilter(Produkt k);

        [NonSerialized]
        private ProduktFilter filter;
        [Browsable(false)]
        public ProduktFilter Filter
        {
            get
            {
                return filter;
            }
            set
            {
                filter = value;
                if (produktsteuerung != null)
                    Fülle();
            }
        }

        private void Fülle()
        {
            if (produktsteuerung != null)
            {
                Items.Clear();
                var prod = produktsteuerung.Produkte;
                if (filter == null)
                    prod = prod.Where(p => !p.Versteckt);
                else
                    prod = prod.Where(p => filter(p));
                Items.AddRange(prod.OrderBy(p => p.Name).Cast<object>().ToArray());
                if (Items.Count > 0)
                    SelectedIndex = 0;
            }
        }

        public ProduktBox()
        {
            InitializeComponent();
            DisplayMember = "Name";
        }

        private void ProduktHinzugefügt(Produkt konto)
        {
            Fülle();
        }

        private void ProduktVerändert(Produkt konto)
        {
            Fülle();
        }
    }
}
