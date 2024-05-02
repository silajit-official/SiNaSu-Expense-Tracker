using System;
using System.Collections.Generic;

namespace ExpTracker.Data
{
    public partial class ExpenseCategory
    {
        public ExpenseCategory()
        {
            CustomerExpense = new HashSet<CustomerExpense>();
        }

        public long EcId { get; set; }
        public string EcExpenseName { get; set; }

        public virtual ICollection<CustomerExpense> CustomerExpense { get; set; }
    }
}
