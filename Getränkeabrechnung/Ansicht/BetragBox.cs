using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Getränkeabrechnung.Ansicht
{
    public partial class BetragBox : TextBox
    {
        public double? Betrag
        {
            get
            {
                if (Double.TryParse(Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out double betrag))
                    return betrag;
                else
                    return null;
            }
        }

        public BetragBox()
        {
            InitializeComponent();
        }

        private void BetragBox_Leave(object sender, EventArgs e)
        {
            Util.BetragBoxFormatieren(this);
        }
    }
}
