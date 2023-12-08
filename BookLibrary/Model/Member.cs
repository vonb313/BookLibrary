using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Model
{
    internal class Member
    {
        [Key]
        public int MemberID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int LoanCard { get; set; }
        [Required]
        public int LoanCardPIN { get; set; }

        public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();

    }
}
