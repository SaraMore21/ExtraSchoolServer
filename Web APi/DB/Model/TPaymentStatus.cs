using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class TPaymentStatus
    {
        public TPaymentStatus()
        {
            AppStudentAssingments = new HashSet<AppStudentAssingment>();
            AppTaskToStudents = new HashSet<AppTaskToStudent>();
        }

        public int IdpaymentStatus { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AppStudentAssingment> AppStudentAssingments { get; set; }
        public virtual ICollection<AppTaskToStudent> AppTaskToStudents { get; set; }
    }
}
