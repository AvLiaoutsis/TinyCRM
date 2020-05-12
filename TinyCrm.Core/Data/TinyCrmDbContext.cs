using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using TinyCrm.Core.Model;

namespace TinyCrm.Core.Data
{
    public class TinyCrmDbContext : DbContext
    {
        public TinyCrmDbContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server=AVRAAM-LAPTOP\\SQLEXPRESS;Database=TinyCrmDb;Trusted_Connection=True;MultipleActiveResultSets=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<Customer>()
                .ToTable("Customer");

            modelBuilder
                .Entity<Product>()
                .ToTable("Product");

            modelBuilder
                .Entity<Order>()
                .ToTable("Order");

            modelBuilder
                .Entity<OrderProduct>()
                .ToTable("OrderProduct")
                .HasKey(op => new { op.ProductId, op.OrderId });
        }
    }
}
