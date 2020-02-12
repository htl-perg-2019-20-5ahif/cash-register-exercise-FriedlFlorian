using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CashRegister.WebApi
{
    public class CashRegisterDataContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<ReceiptLine> ReceiptLines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(p => p.ProductName).IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.UnitPrice).IsRequired();

            modelBuilder.Entity<ReceiptLine>().Property(rl => rl.Amount).IsRequired();
            modelBuilder.Entity<ReceiptLine>().Property(rl => rl.TotalPrice).IsRequired();

            modelBuilder.Entity<Receipt>().Property(r => r.ReceiptTimestamp).IsRequired();
            modelBuilder.Entity<Receipt>().Property(r => r.TotalPrice).IsRequired();
        }
    }
}
