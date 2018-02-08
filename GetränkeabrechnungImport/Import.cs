using Getränkeabrechnung.Modell;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Getränkeabrechnung
{
    class Import
    {
        public static void Main(string[] args)
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("de-DE");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("de-DE");
            Console.Out.WriteLine("Reading Database...");
            var connection = new SQLiteConnection(@"Data Source=D:\Project\Getränkeabrechnung\Getränkeabrechnung\drinkaccounting.sqlite");
            connection.Open();
            Console.Out.WriteLine("Read Database...");
            
            var produkte = new Dictionary<string, Produkt>();
            var konten = new Dictionary<string, Konto>();
            var überweisungen = new Dictionary<string, Überweisung>();
            var benutzer = new Dictionary<string, Benutzer>();
            var zahlungen = new Dictionary<string, Zahlung>();
            var verbrauche = new Dictionary<string, Verbrauch>();
            var bestände = new Dictionary<string, Bestand>();
            var einkäufe = new Dictionary<string, Einkauf>();
            var einkaufspositionen = new Dictionary<string, Einkaufsposition>();
            var abrechnungen = new Dictionary<string, Abrechnung>();

            var command = connection.CreateCommand();
            command.CommandText = "select * from cgross_drinkaccounting_domain_model_statement";
            var result = command.ExecuteReader();
            while (result.Read())
            {
                string id = result["persistence_object_identifier"] as string;
                string title = result["title"] as string;
                DateTime datestart = (DateTime)result["datestart"];
                DateTime datestop = (DateTime)result["datestop"];
                bool billed = ((byte)result["billed"]) > 0;
                int step = (int)result["step"];

                var abrechnung = new Abrechnung()
                {
                    Name = title,
                    Startzeitpunkt = datestart,
                    Endzeitpunkt = datestop,
                    Abgerechnet = billed,
                    Schritt = step
                };
                abrechnungen[id] = abrechnung;
            }
            command = connection.CreateCommand();
            command.CommandText = "select * from cgross_drinkaccounting_domain_model_statement";
            result = command.ExecuteReader();
            while (result.Read())
            {
                string id = result["persistence_object_identifier"] as string;
                string initialstock_id = result["initialstockstatement"] as string;
                if (initialstock_id == null)
                    continue;
                abrechnungen[id].AusgangsBestandAbrechnung = abrechnungen[initialstock_id];
            }

            command = connection.CreateCommand();
            command.CommandText = "select * from cgross_drinkaccounting_domain_model_product";
            result = command.ExecuteReader();
            while (result.Read())
            {
                string id = result["persistence_object_identifier"] as string;
                string name = result["name"] as string;
                double price = (double)result["price"];
                int cratesize = (int)result["cratesize"];
                double purchaseprice = (double)result["purchaseprice"];
                double deposit = (double)result["deposit"];
                bool active = ((byte)result["active"]) > 0;
                int position = (int)result["position"];
                bool hidden = ((byte)result["hidden"]) > 0;
                var produkt = new Produkt() {
                    Name = name,
                    Einkaufspreis = purchaseprice,
                    // Aktiv = active,
                    Kastengröße = cratesize,
                    // ListenPosition = position,
                    // Pfand = deposit,
                    Preis = price,
                    Versteckt = hidden || !active
                };
                produkte[id] = produkt;
            }
            command = connection.CreateCommand();
            command.CommandText = "select * from cgross_drinkaccounting_domain_model_product";
            result = command.ExecuteReader();
            while (result.Read())
            {
                string ancestor = result["ancestor"] as string;
                string id = result["persistence_object_identifier"] as string;
                if (ancestor == null)
                {
                    continue;
                }
                produkte[id].Elternprodukt = produkte[ancestor];
            }

            command = connection.CreateCommand();
            command.CommandText = "select * from cgross_drinkaccounting_domain_model_account";
            result = command.ExecuteReader();
            while (result.Read())
            {
                string id = result["persistence_object_identifier"] as string;
                string name = result["name"] as string;
                double balance = (double)result["balance"];
                var konto = new Konto()
                {
                    Name = name,
                    Kontostand = balance
                };
                konten[id] = konto;
            }

            command = connection.CreateCommand();
            command.CommandText = "select * from cgross_drinkaccounting_domain_model_transaction";
            result = command.ExecuteReader();
            while (result.Read())
            {
                string id = result["persistence_object_identifier"] as string;
                string account_id = result["account"] as string;
                DateTime transactiondate = (DateTime)result["transactiondate"];
                DateTime creationdate = (DateTime)result["creationdate"];
                double sum = (double)result["sum"];
                double balanceold = (double)result["balanceold"];
                double balancenew = (double)result["balancenew"];
                string transactiondesc = result["transactiondesc"] as string;
                bool deletable = ((byte)result["deletable"]) > 0;

                var überweisung = new Überweisung()
                {
                    Konto = konten[account_id],
                    Buchungszeitpunkt = transactiondate,
                    Erstellungszeitpunkt = creationdate,
                    Betrag = sum,
                    AlterKontostand = balanceold,
                    NeuerKontostand = balancenew,
                    Beschreibung = ÜbersetzeBeschreibung(transactiondesc),
                    Löschbar = deletable
                };
                überweisungen[id] = überweisung;
                konten[account_id].Überweisungen.Add(überweisung);
            }
            foreach (var konto in konten.Values)
            {
                konto.Überweisungen.Sort((a, b) => -a.Erstellungszeitpunkt.CompareTo(b.Erstellungszeitpunkt));
            }

            command = connection.CreateCommand();
            command.CommandText = "select * from cgross_drinkaccounting_domain_model_user";
            result = command.ExecuteReader();
            while (result.Read())
            {
                string id = result["persistence_object_identifier"] as string;
                string name = result["name"] as string;
                string surname = result["surname"] as string;
                int roomnumber = (int)result["roomnumber"];
                string nickname = result["nickname"] as string;
                double balance = (double)result["balance"];
                bool active = ((byte)result["active"]) > 0;
                double deposit = (double)result["deposit"];

                var ben = new Benutzer()
                {
                    Vorname = surname, // ja stimmt so
                    Nachname = name,
                    Zimmernummer = roomnumber,
                    Rufname = nickname,
                    Guthaben = balance,
                    Aktiv = active,
                    Kaution = deposit
                };
                benutzer[id] = ben;
            }

            command = connection.CreateCommand();
            command.CommandText = "select * from cgross_drinkaccounting_domain_model_payment";
            result = command.ExecuteReader();
            while (result.Read())
            {
                string id = result["persistence_object_identifier"] as string;
                string user_id = result["user"] as string;
                string statement_id = result["statement"] as string;
                Abrechnung abrechnung = statement_id != null ? abrechnungen[statement_id] : null;
                string transaction_id = result["transaction"] as string;
                Überweisung überweisung = transaction_id != null ? überweisungen[transaction_id] : null;
                DateTime paymentdate = (DateTime)result["paymentdate"];
                DateTime creationdate = (DateTime)result["creationdate"];
                double sum = (double)result["sum"];
                double balanceold = (double)result["balanceold"];
                double balancenew = (double)result["balancenew"];
                string paymentdesc = result["paymentdesc"] as string;
                bool deletable = ((byte)result["deletable"]) > 0;

                var zahlung = new Zahlung()
                {
                    Benutzer = benutzer[user_id],
                    Überweisung = überweisung,
                    Buchungszeitpunkt = paymentdate,
                    Erstellungszeitpunkt = creationdate,
                    Betrag = sum,
                    AltesGuthaben = balanceold,
                    NeuesGuthaben = balancenew,
                    Beschreibung = ÜbersetzeBeschreibung(paymentdesc),
                    Löschbar = deletable,
                    Abrechnung = abrechnung
                };
                zahlungen[id] = zahlung;
                benutzer[user_id].Zahlungen.Add(zahlung);
                if (abrechnung != null)
                    abrechnung.Zahlungen.Add(zahlung);
            }
            /*foreach (var ben in benutzer.Values)
            {
                ben.Zahlungen.OrderBy(a => a.Erstellungszeitpunkt);
            }*/

            command = connection.CreateCommand();
            command.CommandText = "select * from cgross_drinkaccounting_domain_model_consumption";
            result = command.ExecuteReader();
            while (result.Read())
            {
                string id = result["persistence_object_identifier"] as string;
                string statement_id = result["statement"] as string;
                // DateTime consumptiondate = (DateTime)result["consumptiondate"];
                string user_id = result["user"] as string;
                string product_id = result["product"] as string;
                int bottleamount = (int)result["bottleamount"];

                var verbrauch = new Verbrauch()
                {
                    Benutzer = benutzer[user_id],
                    Produkt = produkte[product_id],
                    AnzahlFlaschen = bottleamount,
                    Abrechnung = abrechnungen[statement_id]
                };
                verbrauche[id] = verbrauch;
                abrechnungen[statement_id].Verbrauche.Add(verbrauch);
            }

            command = connection.CreateCommand();
            command.CommandText = "select * from cgross_drinkaccounting_domain_model_stock";
            result = command.ExecuteReader();
            while (result.Read())
            {
                string id = result["persistence_object_identifier"] as string;
                string statement_id = result["statement"] as string;
                string product_id = result["product"] as string;
                int bottleamount = (int)result["bottleamount"];

                var bestand = new Bestand()
                {
                    Abrechnung = abrechnungen[statement_id],
                    Produkt = produkte[product_id],
                    AnzahlFlaschen = bottleamount
                };
                bestände[id] = bestand;
                abrechnungen[statement_id].Bestände.Add(bestand);
            }

            command = connection.CreateCommand();
            command.CommandText = "select * from cgross_drinkaccounting_domain_model_purchase";
            result = command.ExecuteReader();
            while (result.Read())
            {
                string id = result["persistence_object_identifier"] as string;
                DateTime purchasedate = (DateTime)result["purchasedate"];
                string invoicetext = result["invoictext"] as string; // ja stimmt so
                double sum = (double)result["sum"];
                string transaction_id = result["transaction"] as string;
                string statement_id = result["statement"] as string;

                var einkauf = new Einkauf()
                {
                    Abrechnung = abrechnungen[statement_id],
                    Überweisung = überweisungen[transaction_id],
                    Zeitpunkt = purchasedate,
                    Rechnungsnummer = invoicetext,
                    Betrag = sum
                };
                einkäufe[id] = einkauf;
                abrechnungen[statement_id].Einkäufe.Add(einkauf);
            }

            command = connection.CreateCommand();
            command.CommandText = "select * from cgross_drinkaccounting_domain_model_purchaseposition";
            result = command.ExecuteReader();
            while (result.Read())
            {
                string id = result["persistence_object_identifier"] as string;
                string product_id = result["product"] as string;
                string purchase_id = result["purchase"] as string;
                int crateamount = (int)result["crateamount"];

                var einkaufsposition = new Einkaufsposition()
                {
                    Produkt = produkte[product_id],
                    Einkauf = einkäufe[purchase_id],
                    AnzahlKästen = crateamount
                };
                einkaufspositionen[id] = einkaufsposition;
                einkäufe[purchase_id].Positionen.Add(einkaufsposition);
            }

            command = connection.CreateCommand();
            command.CommandText = "select * from cgross_drinkaccounting_domain_model_statement_products_join";
            result = command.ExecuteReader();
            while (result.Read())
            {
                string statement_id = result["drinkaccounting_statement"] as string;
                string product_id = result["drinkaccounting_product"] as string;

                abrechnungen[statement_id].Produkte.Add(produkte[product_id]);
                produkte[product_id].Abrechnungen.Add(abrechnungen[statement_id]);
            }

            command = connection.CreateCommand();
            command.CommandText = "select * from cgross_drinkaccounting_domain_model_statement_users_join";
            result = command.ExecuteReader();
            while (result.Read())
            {
                string statement_id = result["drinkaccounting_statement"] as string;
                string user_id = result["drinkaccounting_user"] as string;

                abrechnungen[statement_id].Benutzer.Add(benutzer[user_id]);
                benutzer[user_id].Abrechnungen.Add(abrechnungen[statement_id]);
            }

            connection.Close();

            using (var kontext = new GetränkeabrechnungKontext(@"D:\Project\Getränkeabrechnung\Getränkeabrechnung\RSH4.sqlite") { Erstellen = true })
            {
                kontext.SaveChanges();

                kontext.Abrechnungen.AddRange(abrechnungen.Values);
                kontext.Benutzer.AddRange(benutzer.Values);
                kontext.Bestände.AddRange(bestände.Values);
                kontext.Einkäufe.AddRange(einkäufe.Values);
                kontext.Einkaufspositionen.AddRange(einkaufspositionen.Values);
                kontext.Konten.AddRange(konten.Values);
                kontext.Produkte.AddRange(produkte.Values);
                kontext.Überweisungen.AddRange(überweisungen.Values);
                kontext.Verbrauche.AddRange(verbrauche.Values);
                kontext.Zahlungen.AddRange(zahlungen.Values);

                kontext.SaveChanges();
            }
        }

        private static Regex Storno = new Regex(@"^<b>CANCELED \(([\d-]*)\)</b> - (.*)$");
        private static Regex StornoB = new Regex(@"^<b>CANCELED</b> - (.*)$");
        private static Regex Purchase = new Regex(@"^<b>Purchase:</b> (.*)$");
        private static Regex Deposit = new Regex(@"^<b>(\d\d\d) - (.*):</b> <b>Deposit</b>$");
        private static Regex DepositB = new Regex(@"^<b>Deposit</b>$");
        private static Regex RebookFrom = new Regex(@"^<b>Rebook</b> from (.*)$");
        private static Regex RebookTo = new Regex(@"^<b>Rebook<b> to (.*)$"); // Schöner html Fehler
        private static Regex General = new Regex(@"^<b>(\d\d\d) - (.*):</b> (.*)$");
        private static Regex Statement = new Regex(@"^<b>Statement:</b> (.*)$");

        public static string ÜbersetzeBeschreibung(string original)
        {
            var match = Storno.Match(original);
            if (match.Success)
            {
                var übersetzung = ÜbersetzeBeschreibung(match.Groups[2].Value);
                return match.Result("STORNO - ($1) - ") + übersetzung;
            }
            match = StornoB.Match(original);
            if (match.Success)
            {
                var übersetzung = ÜbersetzeBeschreibung(match.Groups[2].Value);
                return "STORNIERT - " + übersetzung;
            }
            match = Statement.Match(original);
            if (match.Success)
                return match.Result("Abrechnung: $1");
            match = Purchase.Match(original);
            if (match.Success)
                return match.Result("Einkauf: $1");
            match = Deposit.Match(original);
            if (match.Success)
                return match.Result("$1 - $2: Kaution");
            match = DepositB.Match(original);
            if (match.Success)
                return "Kaution";
            match = General.Match(original);
            if (match.Success)
                return match.Result("$1 - $2: $3");
            match = RebookFrom.Match(original);
            if (match.Success)
                return match.Result("Umbuchung von $1");
            match = RebookTo.Match(original);
            if (match.Success)
                return match.Result("Umbuchung nach $1");
            return original;
        }
    }
}
