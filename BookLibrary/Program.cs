using BookLibrary.Data;

namespace BookLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Context())
            {
                var dataAccess = new DataAccess(context);

                dataAccess.CreateFiveRandom();
            }
        }
    }
}