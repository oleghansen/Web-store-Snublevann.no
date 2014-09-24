using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace Nettbutikk.Models
{
    public class DatabaseContext : DbContext
    {
        // Your context has been configured to use a 'DbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Nettbutikk.Models.DbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'DbContext' 
        // connection string in the application configuration file.
        public DatabaseContext()
            : base("name=Nettbutikk")
        {
            Database.CreateIfNotExists();
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public DbSet<Products> Products { get; set; }
        public DbSet<Producers> Producers { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<OrderLines> OrderLines { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Postalareas> Postalareas { get; set; }
        public DbSet<Users> Users { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
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
        public int ProducersID { get; set; }
        public virtual Producers Producers { get; set; }
        public int CategoriesID { get; set; }
        public virtual Categories Categories { get; set; }
        public virtual List<OrderLines> Orderlines { get; set; }
    }

    public class Producers
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public virtual List<Products> Products { get; set; }
    }

    public class ProductContext : DbContext
    {
        public ProductContext()
            : base("name=Nettbutikk")
        {
            Database.CreateIfNotExists();
        }

        public DbSet<Products> Products { get; set; }
    }

    public class Categories
    {
        public int ID { get; set; }
        public String Name { get; set; }

        public virtual List<Products> Products { get; set; } 

    }

    public class OrderLines //noen som har et bedre ord for ordrelinje?! 
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public int OrderID { get; set; }
        public Products Product { get; set; }
        public Orders Order { get; set; }
    }

    public class Orders
    {
        public int ID { get; set; }
        public DateTime OrderDate { get; set; }
        public virtual List<OrderLines> OrderLines { get; set; }
        public int CustomerID { get; set; }


    }


    public class Customers
    {
        public int ID { get; set; }
        public String Firstname { get; set; }
        public String Lastname { get; set; }
        public String Email { get; set; }
        public String Phonenumber { get; set; }
        public String Address { get; set; }
        public int Postalcode { get; set; }
        public Postalareas Postalareas { get; set; }
        public virtual List<Orders> Orders { get; set; }
    }

    public class Postalareas
    {
        [Key]
        public int Postalcode { get; set; }
        public String Postalarea { get; set; }
    }

    public class Users
    {
        public Customer Customer { get; set; }
        public String UserName { get; set; }
        public byte[] Passoword { get; set; }
    }

}