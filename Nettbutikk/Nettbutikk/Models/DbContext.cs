namespace Nettbutikk.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Linq;

    public class DatabaseContext : DbContext
    {
        // Your context has been configured to use a 'DbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Nettbutikk.Models.DbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'DbContext' 
        // connection string in the application configuration file.
        public DatabaseContext()
            : base("name=Produkter")
        {
            Database.CreateIfNotExists();
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public DbSet<Produkter> Produkter { get; set; }
        public DbSet<Produsenter> Produsenter { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produsenter>()
                .HasKey(p => p.ID);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

    public class Produkter
    {
        [Key]
        public int Varenummer { get; set; }
        public String Navn { get; set; }
        public String Beskrivelse { get; set; }
        public int Pris { get; set; }
        public int Produsentnr { get; set; }
        public virtual Produsenter Produsenter { get; set; }
    }

    public class Produsenter
    {
        public int ID { get; set; }
        public String Navn { get; set; }
    }
}