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
    public partial class KontoBox : ComboBox
    {
        private Kontosteuerung kontosteuerung;

        [Browsable(false)]
        public Kontosteuerung Kontosteuerung
        {
            get
            {
                return kontosteuerung;
            }
    
            set
            {
                if (kontosteuerung != null)
                {
                    Items.Clear();
                    kontosteuerung.KontoHinzugefügt -= KontoHinzugefügt;
                    kontosteuerung.KontoVerändert -= KontoVerändert;
                }
                kontosteuerung = value;
                if (kontosteuerung != null)
                {
                    kontosteuerung.KontoHinzugefügt += KontoHinzugefügt;
                    kontosteuerung.KontoVerändert += KontoVerändert;
                    Fülle();
                }
            }
        }

        [Browsable(false)]
        public Konto Konto => (Konto)SelectedItem;

        public delegate bool KontoFilter(Konto k);

        private KontoFilter filter;
        [Browsable(false)]
        public KontoFilter Filter
        {
            get
            {
                return filter;
            }
            set
            {
                filter = value;
                if (kontosteuerung != null)
                    Fülle();
            }
        }

        private void Fülle()
        {
            if (kontosteuerung != null)
            {
                Items.Clear();
                if (filter == null)
                    Items.AddRange(kontosteuerung.Konten.Cast<Object>().ToArray());
                else
                    Items.AddRange(kontosteuerung.Konten.Where(x => filter(x)).Cast<Object>().ToArray());
                if (Items.Count > 0)
                    SelectedIndex = 0;
            }
        }

        public KontoBox()
        {
            InitializeComponent();
            DisplayMember = "Name";
        }

        private void KontoHinzugefügt(Konto konto)
        {
            Fülle();
        }

        private void KontoVerändert(Konto konto)
        {
            Fülle();
        }

        private void KontoGelöscht(Konto konto)
        {
            Fülle();
        }
    }
}
