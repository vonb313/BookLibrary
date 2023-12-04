using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLibrary.Model;
using Microsoft.EntityFrameworkCore;

namespace BookLibrary.Data
{
    internal class Context : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Member> Members { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"
                Server=localhost;
                Database=NewtonLibraryJoakimBerg;
                Trusted_Connection=True;
                Trust Server Certificate=Yes;
                User Id=NewtonLibrary;
                password=NewtonLibrary;");
        }
    }
}
