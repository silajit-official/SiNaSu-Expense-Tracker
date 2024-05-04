using System.ComponentModel.DataAnnotations;

namespace ExpTracker.Models
{
    public class ExpenseCategory
    {
        public long SNO { get; set; }
        public long EcId { get; set; }
        [Required(ErrorMessage ="Please add the Expense")]
        public string EcExpenseName { get; set; }
    }
}
