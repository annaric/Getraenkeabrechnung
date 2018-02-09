using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Getränkeabrechnung.Modell;

namespace Getränkeabrechnung.Ansicht.AbrechnungsWizard
{
    public partial class AbrechnungsWizardAnsicht : UserControl
    {
        public Hauptfenster Hauptfenster { get; set; }

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

        public AbrechnungsWizardAnsicht()
        {
            InitializeComponent();
        }

        public virtual void Fülle()
        {

        }
    }
}
