using BookLibrary.Data;
using BookLibrary.Model;
using Helpers;

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
                            Console.WriteLine("You have created five randomised data\n\n\n");
                            break;

                        case "2":
                            Console.Write("Enter authors name: ");
                            string authorFirstName = Console.ReadLine();
                            Console.Write("\nEnter authors lastname: ");
                            string authorLastName = Console.ReadLine();

                            dataAccess.AddAuthor(authorFirstName, authorLastName);
                            Console.WriteLine("\nAuthor added!");
                            break;

                        case "3":
                            Console.Write("Enter book title: ");
                            string title = Console.ReadLine();
                            Console.Write("\nEnter publication year: ");
                            int publicationYear = int.Parse(Console.ReadLine());
                            Console.Write("\nEnter rating: ");
                            int rating = int.Parse(Console.ReadLine());
                            dataAccess.ShowAuthors();
                            Console.Write("\nEnter author ID: ");
                            int authorID = int.Parse(Console.ReadLine());
                            int isbn = rnd.Next(100000,999999);
                            //Console.WriteLine("Book added to the library");

                            dataAccess.AddBook(title, isbn, publicationYear, rating, authorID);
                            break;

                    }
                }

                
            }
        }
    }
}