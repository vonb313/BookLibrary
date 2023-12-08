using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Model
{
    internal class BookAuthor
    {
        //Fick ta bort Key attribut från BookID och AuthorID och göra en OnModelCreating Metod i Context som förklarar relationen.
        public int BookID { get; set; }

        public int AuthorID { get; set; }

        [ForeignKey("BookID")]
        public virtual Book Book { get; set; }
        [ForeignKey("AuthorID")]
        public virtual Author Author { get; set; }
    }
}
