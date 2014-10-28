﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace Nettbutikk.DAL
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
           // Database.SetInitializer<DatabaseContext>(new CreateDatabaseIfNotExists<DatabaseContext>());
        }

        public override int SaveChanges()
        {
            throw new InvalidOperationException("Username must be provided"); 
        }
        public int SaveChanges(int userId)
        {
            // Get all Added/Deleted/Modified entities (not Unmodified or Detached)
            foreach (var ent in this.ChangeTracker.Entries().Where(p => p.State == EntityState.Added || p.State == EntityState.Deleted || p.State == EntityState.Modified))
            {
                // For each changed record, get the audit record entries and add them
                foreach (AuditLog x in GetAuditRecordsForChange(ent, userId))
                {
                    this.AuditLogs.Add(x);
                }
            }

            // Call the original SaveChanges(), which will save both the changes made and the audit records
            return base.SaveChanges();
        }

        private List<AuditLog> GetAuditRecordsForChange(DbEntityEntry dbEntry, int userId)
        {
            List<AuditLog> result = new List<AuditLog>();

            DateTime changeTime = DateTime.UtcNow;

            // Get the Table() attribute, if one exists
            //TableAttribute tableAttr = dbEntry.Entity.GetType().GetCustomAttributes(typeof(TableAttribute), false).SingleOrDefault() as TableAttribute;

            TableAttribute tableAttr = dbEntry.Entity.GetType().GetCustomAttributes(typeof(TableAttribute), true).SingleOrDefault() as TableAttribute;

            // Get table name (if it has a Table attribute, use that, otherwise get the pluralized name)
            string tableName = tableAttr != null ? tableAttr.Name : dbEntry.Entity.GetType().Name;

            // Get primary key value (If you have more than one key column, this will need to be adjusted)
            //var keyNames = dbEntry.Entity.GetType().GetProperties().Where(p => p.GetCustomAttributes(typeof(KeyAttribute), false).Count() > 0).ToList();

            string keyName = dbEntry.Entity.GetType().GetProperties().Single(p => p.GetCustomAttributes(typeof(KeyAttribute), false).Count() > 0).Name;

            if (dbEntry.State == EntityState.Added)
            {
                // For Inserts, just add the whole record
                // If the entity implements IDescribableEntity, use the description from Describe(), otherwise use ToString()

                foreach (string propertyName in dbEntry.CurrentValues.PropertyNames)
                {
                    result.Add(new AuditLog()
                    {
                        UserId = userId,
                        Changed = changeTime,
                        EventType = "A",    // Added
                        TableName = tableName,
                        RecordId = dbEntry.CurrentValues.GetValue<object>(keyName).ToString(),
                        ColumnName = propertyName,
                        NewValue = dbEntry.CurrentValues.GetValue<object>(propertyName) == null ? null : dbEntry.CurrentValues.GetValue<object>(propertyName).ToString()
                    }
                            );
                }
            }
            else if (dbEntry.State == EntityState.Deleted)
            {
                // Same with deletes, do the whole record, and use either the description from Describe() or ToString()
                result.Add(new AuditLog()
                {
                    UserId = userId,
                    Changed = changeTime,
                    EventType = "D", // Deleted
                    TableName = tableName,
                    RecordId = dbEntry.OriginalValues.GetValue<object>(keyName).ToString(),
                    ColumnName = "*ALL",
                    NewValue = dbEntry.OriginalValues.ToObject().ToString()
                }
                    );
            }
            else if (dbEntry.State == EntityState.Modified)
            {
                foreach (string propertyName in dbEntry.OriginalValues.PropertyNames)
                {
                    // For updates, we only want to capture the columns that actually changed
                    if (!object.Equals(dbEntry.OriginalValues.GetValue<object>(propertyName), dbEntry.CurrentValues.GetValue<object>(propertyName)))
                    {
                        result.Add(new AuditLog()
                        {
                            UserId = userId,
                            Changed = changeTime,
                            EventType = "M",    // Modified
                            TableName = tableName,
                            RecordId = dbEntry.OriginalValues.GetValue<object>(keyName).ToString(),
                            ColumnName = propertyName,
                            OriginalValue = dbEntry.OriginalValues.GetValue<object>(propertyName) == null ? null : dbEntry.OriginalValues.GetValue<object>(propertyName).ToString(),
                            NewValue = dbEntry.CurrentValues.GetValue<object>(propertyName) == null ? null : dbEntry.CurrentValues.GetValue<object>(propertyName).ToString()
                        }
                            );
                    }
                }
            }
            // Otherwise, don't do anything, we don't care about Unchanged or Detached entities

            return result;
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
        public DbSet<SubCategories> SubCategories { get; set; }
        public DbSet<Countries> Countries { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }

    public class AuditLog
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Changed { get; set; }
        public String EventType { get; set;}
        public String TableName { get; set; }
        public String RecordId { get; set; }
        public String ColumnName { get; set; }
        public String OriginalValue { get; set; }
        public String NewValue { get; set; }
    }
    public class Products
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String LongDescription { get; set; }
        public int Price { get; set; }
        public double Volum { get; set; }
        public int ProducersId { get; set; }
        public virtual Producers Producers { get; set; }
        public int SubCategoriesId { get; set; }
        public virtual SubCategories SubCategories { get; set; }
        public int CountriesId { get; set; }
        public virtual Countries Countries { get; set; }
        public virtual List<OrderLines> OrderLines { get; set; }
    }

    public class Producers
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public virtual List<Products> Products { get; set; }
    }

    public class Categories
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
        public List<SubCategories> SubCategories { get; set; }
    }

    public class OrderLines
    {
        [Key]
        public int Id { get; set; }
        public int ProductsId { get; set; }
        public Products Products { get; set; }
        public int Quantity { get; set; }
        public int OrdersId { get; set; }
        public Orders Orders { get; set; }
    }

    public class Orders
    {

        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public virtual List<OrderLines> OrderLines { get; set; }
        public int CustomersId { get; set; }
        public Customers Customers { get; set; }


    }


    public class Customers
    {
        public int Id { get; set; }
        public String Firstname { get; set; }
        public String Lastname { get; set; }
        public String Email { get; set; }
        public String Phonenumber { get; set; }
        public String Address { get; set; }
        public int PostalareasId { get; set; }
        public Postalareas Postalareas { get; set; }
        public byte[] Password { get; set; }
        public virtual List<Orders> Orders { get; set; }
        public bool Admin { get; set; }
    }

    public class Postalareas
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PostalareasId { get; set; }
        public String Postalarea { get; set; }
    }

    public class SubCategories
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int CategoriesId { get; set; }
        public Categories Categories { get; set; }
        public List<Products> Products { get; set; }
    }

    public class Countries
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public List<Products> Products { get; set; }
    }


}