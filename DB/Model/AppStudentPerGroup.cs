using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppStudentPerGroup
    {
        public AppStudentPerGroup()
        {
            AppStatusStudentPerGroups = new HashSet<AppStatusStudentPerGroup>();
        }

        public int IdstudentPerGroup { get; set; }
        public int? StudentId { get; set; }
        public int? GroupId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdated { get; set; }

        public virtual AppGroupPerYearbook Group { get; set; }
        public virtual AppStudent Student { get; set; }
        public virtual AppUserPerSchool UserCreated { get; set; }
        public virtual AppUserPerSchool UserUpdated { get; set; }
        public virtual ICollection<AppStatusStudentPerGroup> AppStatusStudentPerGroups { get; set; }
    }
}
