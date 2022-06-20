using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class BookLibraryContext
    : DbContext
    {
        public BookLibraryContext()
        {

        }
        public BookLibraryContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-DR145US\\SQLEXPRESS;Database=Izpit3DB;Trusted_Connection=True;");
            }
        }
        public DbSet<Books> Books { get; set; }

        public DbSet<Customers> Customers { get; set; }

        public DbSet<Library> Library { get; set; }



    }
}
