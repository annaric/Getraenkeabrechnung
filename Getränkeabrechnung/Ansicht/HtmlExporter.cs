using Getränkeabrechnung.Modell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getränkeabrechnung.Ansicht
{
    public static class HtmlExporter
    {
        public static string NachHtml(this Abrechnung Abrechnung)
        {
            var bauer = new StringBuilder();
            bauer.Append("<html><head><title>");
            bauer.Append(Abrechnung.Name);
            bauer.Append(
@"</title><style>
div {
   font-family: ""Helvetica Neue"", Helvetica, Arial, sans-serif;
   margin: 30px auto 0 auto;
   display: table;
}
h1 {
  display: inline;
  text-rendering: optimizeLegibility;
  -webkit-margin-before: 0.67em;
  -webkit-margin-after: 0.67em;
  -webkit-margin-start: 0px;
  -webkit-margin-end: 0px;
  font-size: 30px;
  line-height: 36px;
}
table {
  color: #333333;
  border: 1px solid #dddddd;
  border-collapse: separate;
  border-left: 0;
  border-radius: 4px;
  margin-top: 18px;
  font-size: 13px;
  background-color: transparent;
  border-spacing: 0;
}
.alignRight {
  text-align: right;
}
th, td {
  border-top: 1px solid #dddddd;
  border-left: 1px solid #dddddd;
  line-height: 18px;
  text-align: left;
  vertical-align: top;
  padding: 4px;
}
tbody:first-child tr:first-child th, tbody:first-child tr:first-child td
{
    border-top: 0;
}
tr:nth-child(odd)
{
    background-color: #f9f9f9;
}");
            bauer.Append("</style></head>\n<body><div><h1>");
            bauer.Append(Abrechnung.Name);
            bauer.Append("</h1>\n<table><tr>\n<td></td>\n");
            foreach (var produkt in Abrechnung.Verkaufsprodukte)
                bauer.Append(string.Format("<th>{0}<br><center>{1:C}</center></th>\n", produkt.Produkt.Name, produkt.Verkaufspreis));
            bauer.Append("<td></td>\n<td></td>\n<td></td>\n<td></td>\n</tr>\n<tr><th class=\"alignRight\">Bestand Vorher</th>\n");
            var altbestände = Abrechnung.BerechneAltbestände();
            foreach (var produkt in Abrechnung.Produkte)
                bauer.Append(string.Format("<td>{0}</td>\n", altbestände[produkt]));
            bauer.Append("<td></td>\n<td></td>\n<td></td>\n<td></td>\n</tr>\n<tr><th class=\"alignRight\">Einkauf</th>\n");
            var einkäufe = Abrechnung.BerechneEinkäufe();
            foreach (var produkt in Abrechnung.Produkte)
                bauer.Append(string.Format("<td>{0}</td>\n", einkäufe[produkt]));
            bauer.Append("<th class=\"alignRight\">Aktuell</th>\n<th class=\"alignRight\">Verlustumlage</th>\n");
            bauer.Append("<th class=\"alignRight\">Altes Guthaben</th>\n<th class=\"alignRight\">Neues Guthaben</th>\n</tr>\n");
            var verlustUmlage = Abrechnung.BerechneVerlustumlage();
            double gesamtGuthaben = 0.0;
            foreach (var benutzer in Abrechnung.Benutzer.OrderBy(b => b.Zimmernummer))
            {
                bauer.Append(string.Format("<tr>\n<td>{0}</td>\n", benutzer.Anzeigename));
                var verbrauche = Abrechnung.Verbrauche.Where(v => v.Benutzer == benutzer).ToDictionary(v => v.Verkaufsprodukt.Produkt, v => v);
                foreach (var produkt in Abrechnung.Verkaufsprodukte)
                    bauer.Append(string.Format("<td>{0}</td>\n", verbrauche[produkt.Produkt].AnzahlFlaschen));
                double aktuell = verbrauche.Values.Select(v => v.AnzahlFlaschen * v.Verkaufsprodukt.Verkaufspreis).Sum();
                bauer.Append(string.Format("<td class=\"alignRight\">{0:C}</td>\n", aktuell));
                double verlustumlage = verlustUmlage[benutzer];
                bauer.Append(string.Format("<td class=\"alignRight\">{0:C}</td>\n", verlustumlage));
                var zahlung = Abrechnung.Zahlungen.Single(z => z.Benutzer == benutzer);
                bauer.Append(string.Format("<td class=\"alignRight\">{0:C}</td>\n", zahlung.AltesGuthaben));
                bauer.Append(string.Format("<td class=\"alignRight\">{0:C}</td>\n", zahlung.NeuesGuthaben));
                bauer.Append("</tr>\n");
                gesamtGuthaben += zahlung.NeuesGuthaben;
            }
            bauer.Append("<tr><th class=\"alignRight\">Einkauf</th>\n");
            var verkauf = Abrechnung.BerechneVerbrauche();
            foreach (var produkt in Abrechnung.Produkte)
                bauer.Append(string.Format("<td>{0}</td>\n", verkauf[produkt]));
            var gesamtAktuell = Abrechnung.Verbrauche.Select(v => v.Verkaufsprodukt.Verkaufspreis * v.AnzahlFlaschen).Sum();
            bauer.Append(string.Format("<td class=\"alignRight\"><b>{0:C}</b></td>\n", gesamtAktuell));
            bauer.Append("<td></td>\n<td></td>\n");
            bauer.Append(string.Format("<td class=\"alignRight\"><b>{0:C}</b></td>\n</tr>\n", gesamtGuthaben));
            bauer.Append("<tr><th class=\"alignRight\">Bestand</th>");
            foreach (var produkt in Abrechnung.Verkaufsprodukte)
                bauer.Append(string.Format("<td>{0}</td>\n", produkt.Bestand));
            bauer.Append("<td></td>\n<td></td>\n<td></td>\n<td></td>\n</tr>\n<tr><th class=\"alignRight\">Verlust</th>\n");
            var verluste = Abrechnung.BerechneVerluste();
            foreach (var produkt in Abrechnung.Produkte)
                bauer.Append(string.Format("<td>{0}</td>\n", verluste[produkt]));
            bauer.Append("<td></td>\n<td></td>\n<td></td>\n<td></td>\n</tr>\n<tr><th class=\"alignRight\">Verlustwert</th>\n");
            var verlustWerte = Abrechnung.Verkaufsprodukte.ToDictionary(vk => vk.Produkt, vk => verluste[vk.Produkt] * vk.Verkaufspreis);
            foreach (var produkt in Abrechnung.Produkte)
                bauer.Append(string.Format("<td class=\"alignRight\">{0:C}</td>\n", verlustWerte[produkt]));
            bauer.Append(string.Format("<td class=\"alignRight\"><b>{0:C}</b></td>\n", verlustWerte.Values.Sum()));
            bauer.Append("<td></td>\n<td></td>\n<td></td>\n</tr>\n<tr><th class=\"alignRight\">Verlustzuschlag/Flasche</th>\n");
            var verlustUmlagen = Abrechnung.Produkte.ToDictionary(p => p, p => verkauf[p] != 0 ? verlustWerte[p] / verkauf[p] : 0.0);
            foreach (var produkt in Abrechnung.Produkte)
                bauer.Append(string.Format("<td class=\"alignRight\">{0:C}</td>\n", verlustUmlagen[produkt]));
            bauer.Append("<td></td>\n<td></td>\n<td></td>\n<td></td>\n</tr>\n</table></div></body></html>");
            return bauer.ToString();
        }
    }
}
