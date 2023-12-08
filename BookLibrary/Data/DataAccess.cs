using BookLibrary.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helpers;
using System.Net;

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

            Console.WriteLine("Random data inserted to database\n\n\n");
        }

        public void AddAuthor()
        {
            Console.Write("Enter author's first name: ");
            string authorFirstName = Console.ReadLine();
            Console.Write("Enter author's last name: ");
            string authorLastName = Console.ReadLine();

            var newAuthor = new Author { FirstName = authorFirstName, LastName = authorLastName };
            _context.Authors.Add(newAuthor);
            _context.SaveChanges();

            Console.WriteLine($"{authorFirstName} {authorLastName} added to the library.\n");
        }

        public void AddBook()
        {
            var rnd = new csSeedGenerator();
            Console.Write("Enter book title: ");
            string title = Console.ReadLine();
            Console.Write("\nEnter publication year: ");
            int publicationYear = int.Parse(Console.ReadLine());
            Console.Write("\nEnter rating: ");
            int rating = int.Parse(Console.ReadLine());
            ShowAuthors();
            Console.Write("\nEnter author ID: ");
            int authorID = int.Parse(Console.ReadLine());
            int isbn = rnd.Next(100000, 999999);

            var existingAuthor = _context.Authors.Find(authorID);

            if (existingAuthor == null)
            {
                Console.WriteLine("Invalid author ID. Book cannot be added.");
                return;
            }

            var newBook = new Book
            {
                Title = title,
                ISBN = isbn,
                PublicationYear = publicationYear,
                Rating = rating,
                IsBorrowed = false,
                AuthorID = existingAuthor.AuthorID,
                Author = existingAuthor
            };

            _context.Books.Add(newBook);
            _context.SaveChanges();

            Console.WriteLine("Book added successfully!");
        }

        public void AddMember()
        {
            var rnd = new csSeedGenerator();
            Console.Write("Enter your firstname: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter your lastname: ");
            string lastName = Console.ReadLine();

            int pinCode;
            int loanCard;

            while (true)
            {
                Console.Write("Choose 3 digit PIN code: ");
                string input = Console.ReadLine();
                if (input.Length == 3 && int.TryParse(input, out pinCode))
                {
                    loanCard = rnd.Next(100, 999);
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input, Please enter a valid 3 digit PIN code.");
                }
            }
            var newMember = new Member
            {
                FirstName = firstName,
                LastName = lastName,
                LoanCardPIN = pinCode,
                LoanCard = loanCard
            };
            
            _context.Members.Add(newMember);
            _context.SaveChanges();

            Console.WriteLine($"Member created. Welcome to the library {firstName} {lastName}");
            Console.WriteLine($"\nYour login information is your memberId: {loanCard} and your chosen PIN code: {pinCode}\n");
        }

        public void BorrowBook()
        {
            Console.Write("Enter your loan card number: ");
            int loanCard = int.Parse(Console.ReadLine());

            Console.Write("Enter your PIN code: ");
            int pinCode = int.Parse(Console.ReadLine());

            var member = _context.Members.Include(m => m.Loans).FirstOrDefault(m => m.LoanCard == loanCard && m.LoanCardPIN == pinCode);

            if (member != null)
            {
                Console.WriteLine($"\nWelcome, {member.FirstName} {member.LastName}!\n");
                Thread.Sleep(3000);
                Console.WriteLine($"Available books for borrow\n");
                Thread.Sleep(2000);
                GetAvailableBooks();

                Console.Write("Enter the book ID you want to borrow: ");
                int bookId = int.Parse(Console.ReadLine());

                var bookToBorrow = _context.Books.FirstOrDefault(b => b.BookID == bookId && !b.IsBorrowed);

                if (bookToBorrow != null )
                {
                    var loan = new Loan
                    {
                        BookID = bookToBorrow.BookID,
                        MemberID = member.MemberID,
                        LoanDate = DateTime.Now,
                        ReturnDate = null
                    };

                    bookToBorrow.IsBorrowed = true;
                    _context.Loans.Add(loan);
                    _context.SaveChanges();

                    Console.WriteLine($"Book: {bookToBorrow.Title} has been borrowed by {member.FirstName} {member.LastName}");
                }
                else
                {
                    Console.WriteLine("Invalid bookID, please try again.");
                }

            }
            else
            {
                Console.WriteLine("Invalid loan card or PIN code.");
            }
        }

        public void ReturnBook()
        {
            Console.Write("Enter your loan card number: ");
            int loanCard = int.Parse(Console.ReadLine());

            Console.Write("Enter your PIN code: ");
            int pinCode = int.Parse(Console.ReadLine());

            var member = _context.Members.Include(m => m.Loans).FirstOrDefault(m => m.LoanCard == loanCard && m.LoanCardPIN == pinCode);

            if (member != null)
            {
                Console.WriteLine($"\nWelcome, {member.FirstName} {member.LastName}!\n");
                Thread.Sleep(3000);

                Console.WriteLine($"Lånade böcker: \n");
                ShowMemberLoans(member.MemberID);

                Console.Write("Enter the Loan ID of the book you want to return: ");
                int loanId = int.Parse(Console.ReadLine());

                var loan = member.Loans.FirstOrDefault(l => l.LoanId == loanId);

                if (loan != null)
                {
                    var book = _context.Books.FirstOrDefault(b => b.BookID == loan.BookID);

                    if (book != null)
                    {
                        book.IsBorrowed = false;

                        loan.ReturnDate = DateTime.Now;

                        _context.SaveChanges();

                        Console.WriteLine($"Book '{book.Title}' has been successfully returned.");
                    }
                    else
                    {
                        Console.WriteLine("Book not found.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Loan ID. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid loan card number or PIN code. Please try again.");
            }
        }

        public void DeleteAuthor(int authorId)
        {
            var authorToDelete = _context.Authors.Include(a => a.BookAuthors).FirstOrDefault(a => a.AuthorID == authorId);

            if (authorToDelete != null)
            {
                foreach (var bookAuthor in authorToDelete.BookAuthors)
                {
                    var book = _context.Books.FirstOrDefault(b => b.BookID == bookAuthor.BookID);
                    if (book != null)
                    {
                        _context.Books.Remove(book);
                    }
                }
                _context.Authors.Remove(authorToDelete);
                _context.SaveChanges();

                Console.WriteLine($"Author with ID {authorId} and associated books have been deleted.\n");
            }
            else
            {
                Console.WriteLine($"Author with ID {authorId} not found.");
            }
        }

        public void ShowMemberLoans(int memberId)
        {
            var member = _context.Members.Include(m => m.Loans).FirstOrDefault(m => m.MemberID == memberId);

            if (member != null)
            {
                Console.WriteLine($"Loans for {member.FirstName} {member.LastName} (Member ID: {member.MemberID}):");

                foreach (var loan in member.Loans)
                {
                    var book = _context.Books.FirstOrDefault(b => b.BookID == loan.BookID);

                    if (book != null)
                    {
                        Console.WriteLine($"Loan ID: {loan.LoanId}, Book Title: {book.Title}, Loan Date: {loan.LoanDate}, Return Date: {loan.ReturnDate}");
                    }
                    else
                    {
                        Console.WriteLine($"Loan ID: {loan.LoanId}, Book not found");
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid member ID. Please try again.");
            }
        }

        public void ShowMenu()
        {
            Console.WriteLine("Choose an alternative");
            Console.WriteLine("1. Create five randomised data");
            Console.WriteLine("2. Insert a Author");
            Console.WriteLine("3. Insert a new book");
            Console.WriteLine("4. Create a new member");
            Console.WriteLine("5. Loan a book");
            Console.WriteLine("6. Show all books");
            Console.WriteLine("7. Return book");
            Console.WriteLine("8. Delete a author");
            Console.Write("Make a choice: ");

        }

        public void ShowAuthors()
        {
            var authors = _context.Authors.ToList();

            Console.WriteLine("List of Authors");

            foreach (var author in authors)
            {
                Console.WriteLine($"AuthorID: {author.AuthorID} Name: {author.FirstName} {author.LastName}");
            }
        }

        public void ShowMembers()
        {
            var members = _context.Members.ToList();

            Console.WriteLine("List of Members");

            foreach(var member in members)
            {
                Console.WriteLine($"MemberID: {member.MemberID} Loancard: {member.LoanCard} Name: {member.FirstName} {member.LastName}");
            }
        }

        public List<Book> GetAvailableBooks()
        {
            var availableBooks = _context.Books
                .Where(book => !book.IsBorrowed)
                .Include(book => book.Author)
                .ToList();

                foreach (var book in availableBooks)
                {
                    Console.WriteLine($"Book ID: {book.BookID}");
                    Console.WriteLine($"Title: {book.Title}");
                    Console.WriteLine($"Author: {book.Author.FirstName} {book.Author.LastName}");
                    Console.WriteLine("------------------------");
                }

                return availableBooks;
        }

        public List<Book> ShowAllBooks()
        {
            var allBooks = _context.Books
                .Include(book => book.Author)
                .ToList();

            Console.WriteLine("All Books:\n\n");
            foreach (var book in allBooks)
            {
                Console.WriteLine($"Book ID: {book.BookID}");
                Console.WriteLine($"Title: {book.Title}");
                Console.WriteLine($"Author: {book.Author.FirstName} {book.Author.LastName}");
                Console.WriteLine("------------------------");
            }

            return allBooks;
        }




    }
}
