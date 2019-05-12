using System;
using Microsoft.EntityFrameworkCore;

namespace trapperkeeper_mvc.Models.Finances
{
    public class FinancesContext : DbContext
    {
        public FinancesContext() => Database.EnsureCreated();

        public DbSet<TransactionLedger> TransactionLedgers { get; set; }

        public DbSet<TransactionEntry> TransactionEntries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=finances;user=trapperkeeper;password=Hudson666!");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TransactionLedger>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.Date).IsRequired();
            });

            modelBuilder.Entity<TransactionEntry>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.Date).IsRequired();
                entity.Property(e => e.AccountID).IsRequired();
                entity.Property(e => e.CategoryID).IsRequired();
                entity.HasOne(d => d.TransactionLedger)
                  .WithMany(p => p.Transactions);
            });
        }
    }
}
