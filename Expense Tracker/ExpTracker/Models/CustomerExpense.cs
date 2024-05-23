using System;
using System.ComponentModel.DataAnnotations;

namespace ExpTracker.Models
{
    public class CustomerExpense
    {
        public long CE_ID { get; set; }
        public long CE_CUST_ID { get; set; }
        [Required]
        public long CE_EC_ID { get; set; }
        [Required]
        public DateTime CE_ADDED_ON { get; set; }
        [Required]
        public int AMOUNT { get; set; }
    }
}
