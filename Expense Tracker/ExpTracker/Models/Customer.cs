using ExpTracker.Helper.Validations;
using System.ComponentModel.DataAnnotations;

namespace ExpTracker.Models
{
    public class Customer
    {
        public long CustId { get; set; }
        [Required(ErrorMessage ="Please Enter the First Name")]
        public string CustFname { get; set; }
        [Required(ErrorMessage = "Please Enter the Last Name")]
        public string CustLname { get; set; }
        [Required(ErrorMessage = "Please Enter the Email ID")]
        [EmailValidation]
        public string CustEmail { get; set; }
        [Required]
        public string CustPassword { get; set; }
        public string CustImageUrl { get; set; }
    }
}
