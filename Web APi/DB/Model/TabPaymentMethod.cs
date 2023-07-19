using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class TabPaymentMethod
    {
        public TabPaymentMethod()
        {
            AppTaskToStudents = new HashSet<AppTaskToStudent>();
        }

        public int IdpaymentMethod { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AppTaskToStudent> AppTaskToStudents { get; set; }
    }
}
