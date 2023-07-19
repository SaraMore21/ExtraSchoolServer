using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppUserPerCourse
    {
        public int IduserPerCourse { get; set; }
        public int? GroupSemesterPerCourseId { get; set; }
        public int? UserId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? UserCreatedId { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdated { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual AppGroupSemesterPerCourse GroupSemesterPerCourse { get; set; }
        public virtual AppUserPerSchool User { get; set; }
        public virtual AppUserPerSchool UserCreated { get; set; }
        public virtual AppUserPerSchool UserUpdated { get; set; }
    }
}
