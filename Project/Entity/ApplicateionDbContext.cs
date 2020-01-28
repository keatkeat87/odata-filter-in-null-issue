using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string name { get; set; } // nullable
    }

    public class CustomerOrderContext : DbContext
    {
        private readonly ILoggerFactory LoggerFactory;

        public CustomerOrderContext(
            DbContextOptions<CustomerOrderContext> options,
            ILoggerFactory loggerFactory
        )
            : base(options)
        {
            LoggerFactory = loggerFactory;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseLoggerFactory(LoggerFactory);
        }

        public DbSet<Product> Products { get; set; }
 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(p => p.name).IsRequired(false).HasMaxLength(128);
        }
    }
}
