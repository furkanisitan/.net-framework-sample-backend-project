﻿using System.Data.Entity;
using Shop.DataAccess.Concrete.EntityFramework.Configuration.DatabaseInitializers;
using Shop.DataAccess.Concrete.EntityFramework.Mappings;
using Shop.Entities.Concrete;

namespace Shop.DataAccess.Concrete.EntityFramework.Configuration
{
    public class ShopContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        public ShopContext()
        {
            Database.SetInitializer(new ShopContextDbInitializer.DropCreateAlways());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MapProduct());
            modelBuilder.Configurations.Add(new MapCategory());
            modelBuilder.Configurations.Add(new MapRole());
            modelBuilder.Configurations.Add(new MapUser());
        }
    }
}
