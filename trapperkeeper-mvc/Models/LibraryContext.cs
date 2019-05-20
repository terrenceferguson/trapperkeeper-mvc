using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace trapperkeeper_mvc.Models
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) {}

        public DbSet<Author> Author { get; set; }
        public DbSet<Book> Book { get; set; }
    }

    public class Author
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }

        public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ISBN { get; set; }
        public decimal? Value { get; set; }
        public DateTime DateAdded { get; set; }

        public virtual Author Author { get; set; }
    }
}