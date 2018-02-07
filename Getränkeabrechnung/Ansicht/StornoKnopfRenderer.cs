using BrightIdeasSoftware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Getränkeabrechnung.Ansicht
{
    class StornoKnopfRenderer : ColumnButtonRenderer
    {

        protected override Size CalculateContentSize(Graphics g, Rectangle r)
        {
            return new Size(60, 20);
        }
    }
}
