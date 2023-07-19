using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class TPaymentMethod
    {
        public TPaymentMethod()
        {
            AppStudentAssingments = new HashSet<AppStudentAssingment>();
            AppTaskToStudents = new HashSet<AppTaskToStudent>();
        }

        public int IdpaymentMethod { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AppStudentAssingment> AppStudentAssingments { get; set; }
        public virtual ICollection<AppTaskToStudent> AppTaskToStudents { get; set; }
    }
}
