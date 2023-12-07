using BookLibrary.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helpers;

namespace BookLibrary.Data
{
    internal class DataAccess
    {
        private readonly Context _context;

        public DataAccess(Context context)
        {
            _context = context;
        }
        public void CreateFiveRandom()
        {
            var rnd = new csSeedGenerator();

            var author1 = new Author { FirstName = rnd.AuthorFirstName, LastName = rnd.AuthorLastName };
            var author2 = new Author { FirstName = rnd.AuthorFirstName, LastName = rnd.AuthorLastName };
            var author3 = new Author { FirstName = rnd.AuthorFirstName, LastName = rnd.AuthorLastName };
            var author4 = new Author { FirstName = rnd.AuthorFirstName, LastName = rnd.AuthorLastName };
            var author5 = new Author { FirstName = rnd.AuthorFirstName, LastName = rnd.AuthorLastName };

            _context.Authors.AddRange(author1, author2, author3, author4, author5);
            _context.SaveChanges();

            var book1 = new Book { Title = rnd.BookTitles, ISBN = rnd.Next(100000, 999999), PublicationYear = rnd.Next(1970, 2022), Rating = rnd.Next(1, 11), IsBorrowed = false, AuthorID = author1.AuthorID };
            var book2 = new Book { Title = rnd.BookTitles, ISBN = rnd.Next(100000, 999999), PublicationYear = rnd.Next(1970, 2022), Rating = rnd.Next(1, 11), IsBorrowed = false, AuthorID = author2.AuthorID };
            var book3 = new Book { Title = rnd.BookTitles, ISBN = rnd.Next(100000, 999999), PublicationYear = rnd.Next(1970, 2022), Rating = rnd.Next(1, 11), IsBorrowed = false, AuthorID = author2.AuthorID };
            var book4 = new Book { Title = rnd.BookTitles, ISBN = rnd.Next(100000, 999999), PublicationYear = rnd.Next(1970, 2022), Rating = rnd.Next(1, 11), IsBorrowed = false, AuthorID = author2.AuthorID };
            var book5 = new Book { Title = rnd.BookTitles, ISBN = rnd.Next(100000, 999999), PublicationYear = rnd.Next(1970, 2022), Rating = rnd.Next(1, 11), IsBorrowed = false, AuthorID = author2.AuthorID };

            _context.Books.AddRange(book1, book2, book3, book4, book5);
            _context.SaveChanges();

            var member1 = new Member { FirstName = rnd.FirstName, LastName = rnd.LastName, LoanCard = rnd.Next(100, 999), LoanCardPIN = rnd.Next(100, 999) };
            var member2 = new Member { FirstName = rnd.FirstName, LastName = rnd.LastName, LoanCard = rnd.Next(100,999), LoanCardPIN = rnd.Next(100, 999) };
            var member3 = new Member { FirstName = rnd.FirstName, LastName = rnd.LastName, LoanCard = rnd.Next(100, 999), LoanCardPIN = rnd.Next(100, 999) };
            var member4 = new Member { FirstName = rnd.FirstName, LastName = rnd.LastName, LoanCard = rnd.Next(100, 999), LoanCardPIN = rnd.Next(100, 999) };
            var member5 = new Member { FirstName = rnd.FirstName, LastName = rnd.LastName, LoanCard = rnd.Next(100, 999), LoanCardPIN = rnd.Next(100, 999) };

            _context.Members.AddRange(member1, member2, member3, member4, member5);
            _context.SaveChanges();


        }
    }
}
