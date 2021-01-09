using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EcommerceApp.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Database
{
    public class EcommerceDb : DbContext
    {
        public DbSet<SlideShow> SlideShows { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductPhoto> ProductPhotos { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleAccount> RoleAccounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"Data Source = DESKTOP-H9G6ICD\SQLEXPRESS;
                                      Initial Catalog = EcommerceDbOffice;
                                      Integrated Security = True;";
            optionsBuilder.UseSqlServer(connectionString);     
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>().HasIndex(b => b.Name).IsUnique();

            modelBuilder.Entity<Category>().HasIndex(c => c.Name).IsUnique();

            modelBuilder.Entity<Product>().HasIndex(p => p.Name).IsUnique();

            modelBuilder.Entity<ProductPhoto>().HasIndex(p => p.Photo).IsUnique();

            modelBuilder.Entity<Account>().HasIndex(a => a.UserName).IsUnique();
            modelBuilder.Entity<Account>().HasIndex(a => a.Email).IsUnique();
            modelBuilder.Entity<Account>().HasIndex(a => a.Phone).IsUnique();

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
