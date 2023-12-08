using BookLibrary.Data;
using BookLibrary.Model;
using Helpers;
using System.Reflection;

namespace BookLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Context())
            {
                var dataAccess = new DataAccess(context);
                var rnd = new csSeedGenerator();

                while (true)
                {
                    dataAccess.ShowMenu();

                    string choice = Console.ReadLine();

                    switch (choice) 
                    {
                        case "1":
                            dataAccess.CreateFiveRandom();
                            break;

                        case "2":
                            dataAccess.AddAuthor();
                            break;

                        case "3":
                            dataAccess.AddBook();
                            break;

                        case "4":
                            dataAccess.AddMember();
                            break;

                        case "5":
                            dataAccess.BorrowBook();
                            break;

                        case "6":
                            dataAccess.ShowAllBooks();
                            break;

                        case "7":
                            dataAccess.ReturnBook();
                            break;

                        case "8": //delete authhor
                            dataAccess.ShowAuthors();
                            Console.Write("Enter the AuthorID you want to remove.");
                            int authorIdDelete = int.Parse(Console.ReadLine());
                            
                            dataAccess.DeleteAuthor(authorIdDelete);
                            break;

                    }
                }

                
            }
        }
    }
}