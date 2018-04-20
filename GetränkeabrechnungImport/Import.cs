using Getränkeabrechnung.Modell;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data.SQLite.Linq;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Collections;
using System.Linq.Expressions;
using System.Data;

namespace Getränkeabrechnung
{
    public static class Import
    {
        public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> keyValuePair)
        {
            return keyValuePair.ToDictionary(kv => kv.Key, kv => kv.Value);
        }

        public static IEnumerable<T> Peek<T>(this IEnumerable<T> source, Action<T> action)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (action == null) throw new ArgumentNullException(nameof(action));

            return Iterator();

            IEnumerable<T> Iterator() // C# 7 Local Function
            {
                foreach (var item in source)
                {
                    action(item);
                    yield return item;
                }
            }
        }

        public static void Main(string[] args)
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("de-DE");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("de-DE");
            Console.Out.WriteLine("Reading Database...");
            var connection = new SQLiteConnection(@"Data Source=D:\Project\Getränkeabrechnung\Getränkeabrechnung\drinkaccounting.sqlite");
            connection.Open();
            Console.Out.WriteLine("Read Database...");
            
            var command = connection.CreateCommand();
            command.CommandText = "select * from cgross_drinkaccounting_domain_model_statement";
            var result = command.ExecuteReader();
            var statements = result.Cast<IDataRecord>()
                .Select(r => new
                {
                    id = r["persistence_object_identifier"] as string,
                    title = r["title"] as string,
                    datestart = (DateTime)r["datestart"],
                    datestop = (DateTime)r["datestop"],
                    billed = ((byte)r["billed"]) > 0,
                    step = (int)r["step"],
                    initialstockstatement = r["initialstockstatement"] as string
                })
                .ToDictionary(r => r.id);

            command = connection.CreateCommand();
            command.CommandText = "select * from cgross_drinkaccounting_domain_model_product";
            result = command.ExecuteReader();
            var products = result.Cast<IDataRecord>()
                .Select(r => new
                {
                    id = r["persistence_object_identifier"] as string,
                    parent = r["parent"] as string,
                    name = r["name"] as string,
                    price = (double)r["price"],
                    cratesize = (int)r["cratesize"],
                    purchaseprice = (double)r["purchaseprice"],
                    deposit = (double)r["deposit"],
                    active = ((byte)r["active"]) > 0,
                    position = (int)r["position"],
                    hidden = ((byte)r["hidden"]) > 0,
                    ancestor = r["ancestor"] as string
                })
                .ToDictionary(r => r.id);

            command = connection.CreateCommand();
            command.CommandText = "select * from cgross_drinkaccounting_domain_model_account";
            result = command.ExecuteReader();
            var accounts = result.Cast<IDataRecord>()
                .Select(r => new
                {
                    id = r["persistence_object_identifier"] as string,
                    name = r["name"] as string,
                    balance = (double)r["balance"]
                })
                .ToDictionary(r => r.id);

            command = connection.CreateCommand();
            command.CommandText = "select * from cgross_drinkaccounting_domain_model_transaction";
            result = command.ExecuteReader();
            var transactions = result.Cast<IDataRecord>()
                .Select(r => new
                {
                    id = r["persistence_object_identifier"] as string,
                    account_id = r["account"] as string,
                    transactiondate = (DateTime)r["transactiondate"],
                    creationdate = (DateTime)r["creationdate"],
                    sum = (double)r["sum"],
                    balanceold = (double)r["balanceold"],
                    balancenew = (double)r["balancenew"],
                    transactiondesc = r["transactiondesc"] as string,
                    deletable = ((byte)r["deletable"]) > 0
                }).ToDictionary(r => r.id);

            command = connection.CreateCommand();
            command.CommandText = "select * from cgross_drinkaccounting_domain_model_user";
            result = command.ExecuteReader();
            var users = result.Cast<IDataRecord>()
                .Select(r => new
                {
                    id = r["persistence_object_identifier"] as string,
                    name = r["name"] as string,
                    surname = r["surname"] as string,
                    roomnumber = (int)r["roomnumber"],
                    nickname = r["nickname"] as string,
                    balance = (double)r["balance"],
                    active = ((byte)r["active"]) > 0,
                    deposit = (double)r["deposit"]
                }).ToDictionary(r => r.id);

            command = connection.CreateCommand();
            command.CommandText = "select * from cgross_drinkaccounting_domain_model_payment";
            result = command.ExecuteReader();
            var payments = result.Cast<IDataRecord>()
                .Select(r => new
                {
                    id = r["persistence_object_identifier"] as string,
                    user_id = r["user"] as string,
                    statement_id = r["statement"] as string,
                    transaction_id = r["transaction"] as string,
                    paymentdate = (DateTime)r["paymentdate"],
                    creationdate = (DateTime)r["creationdate"],
                    sum = (double)r["sum"],
                    balanceold = (double)r["balanceold"],
                    balancenew = (double)r["balancenew"],
                    paymentdesc = r["paymentdesc"] as string,
                    deletable = ((byte)r["deletable"]) > 0
            }).ToDictionary(r => r.id);

            command = connection.CreateCommand();
            command.CommandText = "select * from cgross_drinkaccounting_domain_model_consumption";
            result = command.ExecuteReader();
            var consumptions = result.Cast<IDataRecord>()
                .Select(r => new
                {
                    id = r["persistence_object_identifier"] as string,
                    statement_id = r["statement"] as string,
                    consumptiondate = (DateTime)r["consumptiondate"],
                    user_id = r["user"] as string,
                    product_id = r["product"] as string,
                    bottleamount = (int)r["bottleamount"]
            }).ToList();
            
            command = connection.CreateCommand();
            command.CommandText = "select * from cgross_drinkaccounting_domain_model_stock";
            result = command.ExecuteReader();
            var stocks = result.Cast<IDataRecord>()
                .Select(r => new
                {
                    id = r["persistence_object_identifier"] as string,
                    statement_id = r["statement"] as string,
                    product_id = r["product"] as string,
                    bottleamount = (int)r["bottleamount"]
                }).ToList();
            
            command = connection.CreateCommand();
            command.CommandText = "select * from cgross_drinkaccounting_domain_model_purchase";
            result = command.ExecuteReader();
            var purchases = result.Cast<IDataRecord>()
                .Select(r => new
                {
                    id = r["persistence_object_identifier"] as string,
                    purchasedate = (DateTime)r["purchasedate"],
                    invoicetext = r["invoictext"] as string, // ja stimmt so
                    sum = (double)r["sum"],
                    transaction_id = r["transaction"] as string,
                    statement_id = r["statement"] as string
                }).ToDictionary(r => r.id);
            
            command = connection.CreateCommand();
            command.CommandText = "select * from cgross_drinkaccounting_domain_model_purchaseposition";
            result = command.ExecuteReader();
            var purchasepositions = result.Cast<IDataRecord>()
                .Select(r => new
                {
                    id = r["persistence_object_identifier"] as string,
                    product_id = r["product"] as string,
                    purchase_id = r["purchase"] as string,
                    crateamount = (int)r["crateamount"]
                }).ToDictionary(r => r.id);
            
            command = connection.CreateCommand();
            command.CommandText = "select * from cgross_drinkaccounting_domain_model_statement_products_join";
            result = command.ExecuteReader();
            var statement_products_join = result.Cast<IDataRecord>()
                .Select(r => new
                {
                    statement_id = r["drinkaccounting_statement"] as string,
                    product_id = r["drinkaccounting_product"] as string,
                }).ToList();
            
            command = connection.CreateCommand();
            command.CommandText = "select * from cgross_drinkaccounting_domain_model_statement_users_join";
            result = command.ExecuteReader();
            var statement_users_join = result.Cast<IDataRecord>()
                .Select(r => new
                {
                    statement_id = r["drinkaccounting_statement"] as string,
                    user_id = r["drinkaccounting_user"] as string,
                }).ToList();

            connection.Close();

            var abrechnungen = statements.Select(kv => new KeyValuePair<string, Abrechnung>(kv.Key,
                new Abrechnung
                {
                    Name = kv.Value.title,
                    Startzeitpunkt = kv.Value.datestart,
                    Endzeitpunkt = kv.Value.datestop,
                    Gebucht = kv.Value.billed,
                    Schritt = kv.Value.step,
                })).ToDictionary(kv => kv.Key, kv => kv.Value);
            foreach (var statement in statements.Values.Where(s => s.initialstockstatement != null))
                abrechnungen[statement.id].AusgangsBestandAbrechnung = abrechnungen[statement.initialstockstatement];
                

            var konten = accounts.Select(kv => new KeyValuePair<string, Konto>(kv.Key,
                new Konto
                {
                    Name = kv.Value.name,
                    Kontostand = kv.Value.balance
                })).ToDictionary();

            var überweisungen = transactions.Select(kv => new KeyValuePair<string, Überweisung>(kv.Key,
                new Überweisung
                {
                    Konto = konten[kv.Value.account_id],
                    AlterKontostand = kv.Value.balanceold,
                    NeuerKontostand = kv.Value.balancenew,
                    Betrag = kv.Value.sum,
                    Beschreibung = ÜbersetzeBeschreibung(kv.Value.transactiondesc),
                    Buchungszeitpunkt = kv.Value.transactiondate,
                    Erstellungszeitpunkt = kv.Value.creationdate,
                    Löschbar = kv.Value.deletable,
                })).ToDictionary();
            foreach (var überweisung in überweisungen.Values)
                überweisung.Konto.Überweisungen.Add(überweisung);

            var benutzer = users.Select(kv => new KeyValuePair<string, Benutzer>( kv.Key,
                new Benutzer()
                {
                    Vorname = kv.Value.surname, // stimmt so
                    Nachname = kv.Value.name,
                    Rufname = kv.Value.nickname,
                    Zimmernummer = kv.Value.roomnumber,
                    Guthaben = kv.Value.balance,
                    Kaution = kv.Value.deposit,
                    Aktiv = kv.Value.active,
                }
            )).ToDictionary();
            foreach (var v in statement_users_join)
                abrechnungen[v.statement_id].Benutzer.Add(benutzer[v.user_id]);

            var zahlungen = payments.Select(kv => new KeyValuePair<string, Zahlung>(kv.Key,
                new Zahlung
                {
                    Abrechnung = kv.Value.statement_id != null ? abrechnungen[kv.Value.statement_id] : null,
                    AltesGuthaben = kv.Value.balanceold,
                    NeuesGuthaben = kv.Value.balancenew,
                    Benutzer = benutzer[kv.Value.user_id],
                    Beschreibung = ÜbersetzeBeschreibung(kv.Value.paymentdesc),
                    Erstellungszeitpunkt = kv.Value.creationdate,
                    Buchungszeitpunkt = kv.Value.paymentdate,
                    Betrag = kv.Value.sum,
                    Löschbar = kv.Value.deletable,
                    Überweisung = kv.Value.transaction_id != null ? überweisungen[kv.Value.transaction_id] : null
                })).ToDictionary();

            var productChildren = products.Values.Where(p => p.ancestor != null).ToDictionary(p => p.ancestor, p => p.id); // Es gibt keine Produkte mit mehreren Kindern
            string LetztesProdukt (string id)
            {
                string key = id;
                while (productChildren.ContainsKey(key))
                    key = productChildren[key];
                return products[key].id;
            }

            var produkte = products
                .Where(kv => !productChildren.ContainsKey(kv.Value.id) && kv.Value.parent == null)
                .Select(kv => new KeyValuePair<string, Produkt>(kv.Key,
                new Produkt
                {
                    Name = kv.Value.name,
                    Listenposition = kv.Value.position,
                    AktuellerVerkaufspreis = kv.Value.price,
                    Versteckt = kv.Value.hidden || !kv.Value.active
                })).ToDictionary();

            foreach (var prod in products.Values)
            {
                if (produkte.ContainsKey(prod.id))
                    continue;

                string id = LetztesProdukt(prod.parent ?? prod.id);
                produkte[prod.id] = produkte[id];
            }
            
            var kastengrößen = products
                .Select(kv => kv.Value)
                .Select(p => new Kastengröße
                {
                    Produkt = produkte[p.id],
                    Größe = p.cratesize,
                    Einkaufspreis = p.purchaseprice,
                    Pfand = p.deposit,
                    Versteckt = p.hidden || !p.active
                }).GroupBy(p => new { p.Produkt, p.Größe })
                .Peek(group => group.First().Versteckt = group.All(kg => kg.Versteckt))
                .Select(group => group.First())
                .ToDictionary(p => new { p.Produkt, p.Größe }); // Filtert auch produktvarianten, die sich nicht in Größe unterscheiden
            foreach (var kastengröße in kastengrößen.Values)
                kastengröße.Produkt.Kastengrößen.Add(kastengröße);

            var einkäufe = purchases
                .Select(kv => new KeyValuePair<string, Einkauf>(kv.Key,
                new Einkauf
                {
                    Rechnungsnummer = kv.Value.invoicetext,
                    Betrag = kv.Value.sum,
                    Abrechnung = kv.Value.statement_id != null ? abrechnungen[kv.Value.statement_id] : null,
                    Überweisung = überweisungen[kv.Value.transaction_id],
                    Zeitpunkt = kv.Value.purchasedate
                })).ToDictionary();
            foreach (var einkauf in einkäufe.Values.Where(e => e.Abrechnung != null))
                einkauf.Abrechnung.Einkäufe.Add(einkauf);

            var einkaufspositionen = purchasepositions.Select(kv => kv.Value)
                .Select(pp => new Einkaufsposition
                {
                    Einkauf = einkäufe[pp.purchase_id],
                    Kastengröße = kastengrößen[new { Produkt = produkte[pp.product_id], Größe = products[pp.product_id].cratesize }],
                    AnzahlKästen = pp.crateamount,
                }).ToList();
            foreach (var einkaufsposition in einkaufspositionen)
                einkaufsposition.Einkauf.Positionen.Add(einkaufsposition);

            var verkaufsprodukte = stocks.Select(s =>
                new Verkaufsprodukt
                {
                    Produkt = produkte[s.product_id],
                    Bestand = s.bottleamount,
                    Abrechnung = abrechnungen[s.statement_id],
                    Verkaufspreis = products[s.product_id].price
                }).ToList();
            foreach (var v in verkaufsprodukte)
                v.Abrechnung.Verkaufsprodukte.Add(v);

            var verbrauche = consumptions.Select(c =>
                new Verbrauch
                {
                    Abrechnung = abrechnungen[c.statement_id],
                    Verkaufsprodukt = abrechnungen[c.statement_id].Verkaufsprodukte.Single(vk => vk.Produkt == produkte[c.product_id]),
                    Benutzer = benutzer[c.user_id],
                    AnzahlFlaschen = c.bottleamount
                }).ToList();
            foreach (var v in verbrauche)
                v.Abrechnung.Verbrauche.Add(v);

            foreach (var abrechnung in abrechnungen.Values)
            {
                if (abrechnung.Name.StartsWith("Initial Stock"))
                    continue;
                abrechnung.Verifiziere();
            }

            using (var kontext = new GetränkeabrechnungKontext(@"D:\Project\Getränkeabrechnung\Getränkeabrechnung\RSH4.sqlite") { Erstellen = true })
            {
                kontext.SaveChanges();
                kontext.Abrechnungen.AddRange(abrechnungen.Values);
                kontext.Konten.AddRange(konten.Values);
                kontext.Überweisungen.AddRange(überweisungen.Values);
                kontext.Benutzer.AddRange(benutzer.Values);
                kontext.Zahlungen.AddRange(zahlungen.Values);
                kontext.Produkte.AddRange(produkte.Values.Distinct());
                kontext.Kastengrößen.AddRange(kastengrößen.Values);
                kontext.Einkäufe.AddRange(einkäufe.Values);
                kontext.Einkaufspositionen.AddRange(einkaufspositionen);
                kontext.Verkaufsprodukte.AddRange(verkaufsprodukte);
                kontext.Verbrauche.AddRange(verbrauche);
                kontext.SaveChanges();
            }
        }

        private static Regex Storno = new Regex(@"^<b>CANCELED \(([\d-]*)\)</b> - (.*)$");
        private static Regex StornoB = new Regex(@"^<b>CANCELED</b> - (.*)$");
        private static Regex Purchase = new Regex(@"^<b>Purchase:</b> (.*)$");
        private static Regex Deposit = new Regex(@"^<b>(\d\d\d) - (.*):</b> <b>Deposit</b>$");
        private static Regex DepositB = new Regex(@"^<b>Deposit</b>$");
        private static Regex RebookFrom = new Regex(@"^<b>Rebook</b> from (.*)$");
        private static Regex RebookTo = new Regex(@"^<b>Rebook<b> to (.*)$"); // stimmt so
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
