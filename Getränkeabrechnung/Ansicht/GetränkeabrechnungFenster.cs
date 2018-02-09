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
    public partial class GetränkeabrechnungFenster : Form
    {
        public Hauptfenster Hauptfenster { get; set; }

        public GetränkeabrechnungFenster()
        {
            InitializeComponent();
        }

        public virtual void Fülle()
        {

        }
    }
}
