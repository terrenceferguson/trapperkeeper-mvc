using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using trapperkeeper_mvc.Models;

namespace trapperkeeper_mvc.Models
{
    public class FinancesContext : DbContext
    {
        public FinancesContext(DbContextOptions<FinancesContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var accounts = new[]
            {
                "Discover",
                "Arrival Plus",
                "Uber",
                "Chase",
                "Ally Checking"
             };

            var categories = new[]
            {
                "Fixed",
                "Flexible",
                "Variable",
                "Debt"
             };

            var subcats = new[]
            {
                "Entertainment",
                "Restaurants",
                "Groceries",
                "Gasoline",
                "Booze",
                "Professional",
                "Health",
                "Clothing",
                "Gifts",
                "Car",
                "Home",
                "Fees",
                "Dog",
                "Subscriptions"
            };

            modelBuilder.Entity<Account>().HasData(accounts.Select(a => new Account
            {
                AccountID = accounts.ToList().IndexOf(a) + 1,
                Description = a
            }));

            modelBuilder.Entity<Category>().HasData(categories.Select(c => new Category
            {
                CategoryID = categories.ToList().IndexOf(c) + 1,
                Description = c
            }));

            modelBuilder.Entity<Subcategory>().HasData(subcats.Select(s => new Subcategory
            {
                SubcategoryID = subcats.ToList().IndexOf(s) + 1,
                Description = s
            }));

            modelBuilder.Entity<TransactionLedger>(entity =>
            {
                entity.HasKey(e => e.TransactionLedgerID);
                entity.Property(e => e.Date).IsRequired();
            });

            modelBuilder.Entity<TransactionEntry>(entity =>
            {
                entity.HasKey(e => e.TransactionEntryID);
                entity.Property(e => e.Date).IsRequired();

                entity.HasOne(d => d.TransactionLedger);
            });
        }

        public DbSet<TransactionLedger> TransactionLedger { get; set; }
        public DbSet<TransactionEntry> TransactionEntry { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Subcategory> Subcategory { get; set; }
    }

    public class TransactionLedger
    {
        public int TransactionLedgerID { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int Total { get; set; }

        public ICollection<TransactionEntry> Transactions { get; set; }
    }

    public class TransactionEntry
    {
        public int TransactionEntryID { get; set; }
        public DateTime Date { get; set; }

        public Account Account { get; set; }
        public Category Category { get; set; }
        public Subcategory Subcategory { get; set; }

        public string Description { get; set; }
        public decimal Amount { get; set; }

        public TransactionLedger TransactionLedger { get; set; }
    }

    public class Account
    {
        public int AccountID { get; set; }
        public string Description { get; set; }

        public ICollection<TransactionEntry> TransactionEntries { get; set; }
    }

    public class Category
    {
        public int CategoryID { get; set; }
        public string Description { get; set; }

        public ICollection<TransactionEntry> TransactionEntries { get; set; }
    }

    public class Subcategory
    {
        public int SubcategoryID { get; set; }
        public string Description { get; set; }

        public ICollection<TransactionEntry> TransactionEntries { get; set; }
    }

    // Beginning FluentValidation. I'll integrate it later. -TF
    public class TransactionLedgerValidator : AbstractValidator<TransactionLedger>
    {

    }
}
