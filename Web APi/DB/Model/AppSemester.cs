using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppSemester
    {
        public AppSemester()
        {
            AppGroupSemesterPerCourses = new HashSet<AppGroupSemesterPerCourse>();
        }

        public int Idsemester { get; set; }
        public string Name { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? YearbookId { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int? CoordinationTypeId { get; set; }

        public virtual AppCoordinationType CoordinationType { get; set; }
        public virtual AppUserPerSchool UserCreated { get; set; }
        public virtual AppUserPerSchool UserUpdated { get; set; }
        public virtual AppYearbookPerSchool Yearbook { get; set; }
        public virtual ICollection<AppGroupSemesterPerCourse> AppGroupSemesterPerCourses { get; set; }
    }
}
