using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Getränkeabrechnung.Modell
{
    public class GetränkeabrechnungKontext : DbContext
    {
        public bool Erstellen { get; set; } = false;

        public GetränkeabrechnungKontext(string dateiname)
            : base(new SQLiteConnection() { ConnectionString =
                    new SQLiteConnectionStringBuilder()
                    { DataSource = dateiname }.ConnectionString }, true) { }

        public DbSet<Abrechnung> Abrechnungen { get; set; }
        public DbSet<Benutzer> Benutzer { get; set; }
        public DbSet<Einkauf> Einkäufe { get; set; }
        public DbSet<Einkaufsposition> Einkaufspositionen { get; set; }
        public DbSet<Kastengröße> Kastengrößen { get; set; }
        public DbSet<Konto> Konten { get; set; }
        public DbSet<Produkt> Produkte { get; set; }
        public DbSet<Überweisung> Überweisungen { get; set; }
        public DbSet<Verbrauch> Verbrauche { get; set; }
        public DbSet<Verkaufsprodukt> Verkaufsprodukte { get; set; }
        public DbSet<Zahlung> Zahlungen { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            if (Erstellen)
            {
                IDatabaseInitializer<GetränkeabrechnungKontext> initializer;
                initializer = new SqliteDropCreateDatabaseAlways<GetränkeabrechnungKontext>(modelBuilder);
                Database.SetInitializer(initializer);
            }

            modelBuilder.Entity<Abrechnung>()
                .HasMany(s => s.Benutzer)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("Abrechnung_Id");
                    m.MapRightKey("Benutzer_Id");
                    m.ToTable("AbrechnungBenutzer");
                });

            /*modelBuilder.Entity<Produkt>()
                .HasOptional(p => p.Elternprodukt)
                .WithMany(p => p.Kinder);*/
        }
    }
}
