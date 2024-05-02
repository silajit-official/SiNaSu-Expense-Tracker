using System;
using System.Collections.Generic;

namespace ExpTracker.Data
{
    public partial class Customer
    {
        public Customer()
        {
            CustomerExpense = new HashSet<CustomerExpense>();
        }

        public long CustId { get; set; }
        public string CustFname { get; set; }
        public string CustLname { get; set; }
        public string CustEmail { get; set; }
        public string CustPassword { get; set; }
        public string CustImageUrl { get; set; }

        public virtual ICollection<CustomerExpense> CustomerExpense { get; set; }
    }
}
