using Getränkeabrechnung.Modell;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Getränkeabrechnung.Ansicht
{
    class Util
    {
        public static void KontostandFormatieren(BrightIdeasSoftware.FormatCellEventArgs e)
        {
            var benutzer = (Benutzer)e.Model;
            if (benutzer.Guthaben < 0.0)
            {
                e.SubItem.ForeColor = Color.Red;
            }
        }

        public static String AbrechnungZustandZuString(object cellValue)
        {
            return ((bool)cellValue) ? "Abgerechnet" : "Nicht Abgerechnet";
        }

        public static void AbrechnungFormatieren(BrightIdeasSoftware.FormatCellEventArgs e)
        {
            var abrechnung = (Abrechnung)e.Model;
            if (abrechnung.Abgerechnet)
            {
                e.SubItem.ForeColor = Color.Green;
            } else
            {
                e.SubItem.ForeColor = Color.Red;
            }
        }

        public static void BetragBoxFormatieren(TextBox textBox)
        {
            if (Double.TryParse(textBox.Text, out double value))
                textBox.Text = String.Format(CultureInfo.CurrentCulture, "{0:C}", value);
            else if (!Double.TryParse(textBox.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out value))
                textBox.Text = String.Empty;
        }
    }
}
