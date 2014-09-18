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
            : base("name=Products")
        {
            Database.CreateIfNotExists();
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public DbSet<Products> Products { get; set; }
        public DbSet<Producers> Producers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producers>()
                .HasKey(p => p.ID);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

    public class Products
    {
        [Key]
        public int Itemnumber { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public int Price { get; set; }
        public int ProducerID { get; set; }
        public virtual Producers Producers { get; set; }
    }

    public class Producers
    {
        public int ID { get; set; }
        public String Name { get; set; }
    }
}