using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class TabPaymentStatus
    {
        public TabPaymentStatus()
        {
            AppTaskToStudents = new HashSet<AppTaskToStudent>();
        }

        public int IdpaymentStatus { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AppTaskToStudent> AppTaskToStudents { get; set; }
    }
}
