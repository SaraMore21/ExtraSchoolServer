using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class TStatus
    {
        public TStatus()
        {
            AppStatusStudentPerGroups = new HashSet<AppStatusStudentPerGroup>();
            AppStudents = new HashSet<AppStudent>();
            AppUserPerSchools = new HashSet<AppUserPerSchool>();
        }

        public int Idstatus { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AppStatusStudentPerGroup> AppStatusStudentPerGroups { get; set; }
        public virtual ICollection<AppStudent> AppStudents { get; set; }
        public virtual ICollection<AppUserPerSchool> AppUserPerSchools { get; set; }
    }
}
