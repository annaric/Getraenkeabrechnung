using Getränkeabrechnung.Modell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getränkeabrechnung.Steuerung
{
    class Abrechnungssteuerung : Steuerung
    {
        public delegate void AbrechnungVerändertHandler(Abrechnung abrechnung);
        public event AbrechnungVerändertHandler AbrechnungVerändert;

        internal Abrechnungssteuerung(Datenbanksteuerung datenbanksteuerung) : base(datenbanksteuerung)
        {
        }

        public IEnumerable<Abrechnung> Abrechnungen { get { return Kontext.Abrechnungen.AsEnumerable(); } }

        public void BearbeiteAbrechnung(Abrechnung abrechnung)
        {
            Kontext.SaveChanges();
            AbrechnungVerändert?.Invoke(abrechnung);
        }
    }
}
