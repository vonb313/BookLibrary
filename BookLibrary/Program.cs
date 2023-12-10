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

                        case "8":
                            Console.WriteLine("What do you want to delete?");
                            Console.WriteLine("1. Delete Book.");
                            Console.WriteLine("2. Delete Author.");
                            Console.WriteLine("3. Delete Member.");
                            Console.Write("Enter: ");

                            string deletechoice = Console.ReadLine();
                            switch (deletechoice)
                            {
                                case "1":
                                    dataAccess.DeleteBook();
                                break;

                                case "2":
                                        dataAccess.DeleteAuthor();
                                break;

                                case "3":
                                    dataAccess.DeleteMember();
                                break;    
                            }
                            break;
                    }
                }

                
            }
        }
    }
}