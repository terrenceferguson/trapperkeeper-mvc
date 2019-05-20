﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using trapperkeeper_mvc.Models;

namespace trapperkeeper_mvc.Migrations
{
    [DbContext(typeof(LibraryContext))]
    partial class LibraryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("trapperkeeper_mvc.Models.Author", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("trapperkeeper_mvc.Models.Book", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AuthorID");

                    b.Property<DateTime>("DateAdded");

                    b.Property<string>("Description");

                    b.Property<string>("ISBN");

                    b.Property<string>("Title");

                    b.Property<decimal?>("Value");

                    b.HasKey("ID");

                    b.HasIndex("AuthorID");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("trapperkeeper_mvc.Models.Book", b =>
                {
                    b.HasOne("trapperkeeper_mvc.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorID");
                });
#pragma warning restore 612, 618
        }
    }
}