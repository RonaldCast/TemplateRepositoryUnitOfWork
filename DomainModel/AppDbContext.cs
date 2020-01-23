using DomainModel.Mapping;
using DomainModel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel
{
    public class AppDbContext : DbContext
    {

        public DbSet<User> User { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<UserProduct> UserProduct { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new UserProductMapping());
            modelBuilder.ApplyConfiguration(new ProductMapping());
        }
    }
}
