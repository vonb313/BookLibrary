using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Model
{
    internal class BookAuthor
    {
        public int BookID { get; set; }
        public int AuthorID { get; set; }

        public virtual Book Book { get; set; }
        public virtual Author Author { get; set; }
    }
}
