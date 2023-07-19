using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class TStatusStudent
    {
        public TStatusStudent()
        {
            AppStudents = new HashSet<AppStudent>();
        }

        public int IdstatusStudent { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AppStudent> AppStudents { get; set; }
    }
}
