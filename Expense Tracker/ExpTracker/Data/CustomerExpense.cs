using System;
using System.Collections.Generic;

namespace ExpTracker.Data
{
    public partial class CustomerExpense
    {
        public long CeId { get; set; }
        public long? CeCustId { get; set; }
        public long? CeEcId { get; set; }

        public virtual Customer CeCust { get; set; }
        public virtual ExpenseCategory CeEc { get; set; }
    }
}
