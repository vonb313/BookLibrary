using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Model
{
    internal class Book
    {
        public int BookID { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int PublicationYear { get; set; }
        public int Rating { get; set; }
        public bool IsBorrowed { get; set; }
        public int AuthorID { get; set; }

        public virtual Author Author { get; set; }

    }
}
