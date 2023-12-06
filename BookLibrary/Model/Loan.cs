using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Model
{
    internal class Loan
    {
        [Key]
        public int LoanId { get; set; }
        [Required]
        public int BookID { get; set; }
        [Required]
        public int MemberID { get; set; }
        [Required]
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
