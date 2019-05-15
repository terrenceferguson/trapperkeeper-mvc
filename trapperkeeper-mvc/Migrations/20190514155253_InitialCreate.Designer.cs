﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using trapperkeeper_mvc.Models;

namespace trapperkeeper_mvc.Migrations
{
    [DbContext(typeof(TrapperKeeperContext))]
    [Migration("20190514155253_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("trapperkeeper_mvc.Models.Finances.TransactionEntry", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccountID");

                    b.Property<decimal>("Amount");

                    b.Property<int>("CategoryID");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<int>("SubcategoryID");

                    b.Property<int?>("TransactionLedgerID");

                    b.HasKey("ID");

                    b.HasIndex("TransactionLedgerID");

                    b.ToTable("TransactionEntries");
                });

            modelBuilder.Entity("trapperkeeper_mvc.Models.Finances.TransactionLedger", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<int>("Total");

                    b.HasKey("ID");

                    b.ToTable("TransactionLedgers");
                });

            modelBuilder.Entity("trapperkeeper_mvc.Models.Finances.TransactionEntry", b =>
                {
                    b.HasOne("trapperkeeper_mvc.Models.Finances.TransactionLedger", "TransactionLedger")
                        .WithMany("Transactions")
                        .HasForeignKey("TransactionLedgerID");
                });
#pragma warning restore 612, 618
        }
    }
}
