using System.ComponentModel.DataAnnotations;

namespace ExpTracker.Models
{
    public class LoginCustomer
    {
        [Required]
        public string CustEmail { get; set; }
        [Required]
        public string CustPassword { get; set; }
    }
}
