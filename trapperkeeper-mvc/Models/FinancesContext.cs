﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using trapperkeeper_mvc.Models;

namespace trapperkeeper_mvc.Models
{
    public class FinancesContext : DbContext
    {
        public FinancesContext(DbContextOptions<FinancesContext> options) : base(options) {}

        public DbSet<TransactionLedger> TransactionLedger { get; set; }
        public DbSet<TransactionEntry> TransactionEntry { get; set; }
    }

    public class TransactionLedger
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int Total { get; set; }

        public virtual ICollection<TransactionEntry> Transactions { get; set; }
    }

    public class TransactionEntry
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int AccountID { get; set; }
        public int CategoryID { get; set; }
        public int SubcategoryID { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }

        public virtual TransactionLedger TransactionLedger { get; set; }
    }
}