using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Model
{
    internal class Book
    {
        [Key]
        public int BookID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int ISBN { get; set; }
        [Required]
        public int PublicationYear { get; set; }
        [Range(1, 10)]
        public int Rating { get; set; }
        public bool IsBorrowed { get; set; }

        [ForeignKey("Author")]
        public int AuthorID { get ; set; }
        public virtual Author Author { get; set; }

        public virtual ICollection<BookAuthor> BookAuthors { get; set; }

    }
}
