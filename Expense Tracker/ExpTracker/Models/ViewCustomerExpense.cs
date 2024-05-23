using System;
using System.ComponentModel.DataAnnotations;

namespace ExpTracker.Models
{
    public class ViewCustomerExpense
    {
        [Required]
        public int EC_ID { get; set; }
        [Required]
        public DateTime START_DATE { get; set; }
        [Required]
        public DateTime END_DATE { get; set; }
        public int CUST_ID { get; set; }
    }
}
