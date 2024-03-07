using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class TReasonForLeaving
    {
        public TReasonForLeaving()
        {
            AppStatusStudentPerGroups = new HashSet<AppStatusStudentPerGroup>();
            AppStudents = new HashSet<AppStudent>();
        }

        public int IdreasonForLeaving { get; set; }
        public string Name { get; set; }
        public int? SchoolId { get; set; }

        public virtual AppSchool School { get; set; }
        public virtual ICollection<AppStatusStudentPerGroup> AppStatusStudentPerGroups { get; set; }
        public virtual ICollection<AppStudent> AppStudents { get; set; }
    }
}
