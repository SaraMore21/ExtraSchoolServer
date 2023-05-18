using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppGroupPerYearbook
    {
        public AppGroupPerYearbook()
        {
            AppDocumentPerGroups = new HashSet<AppDocumentPerGroup>();
            AppGroupSemesterPerCourses = new HashSet<AppGroupSemesterPerCourse>();
            AppLessonPerGroups = new HashSet<AppLessonPerGroup>();
            AppStudentPerGroups = new HashSet<AppStudentPerGroup>();
            AppUserPerGroups = new HashSet<AppUserPerGroup>();
        }

        public int IdgroupPerYearbook { get; set; }
        public int? GroupId { get; set; }
        public int? YearbookId { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdated { get; set; }

        public virtual AppGroup Group { get; set; }
        public virtual AppUserPerSchool UserCreated { get; set; }
        public virtual AppUserPerSchool UserUpdated { get; set; }
        public virtual AppYearbookPerSchool Yearbook { get; set; }
        public virtual ICollection<AppDocumentPerGroup> AppDocumentPerGroups { get; set; }
        public virtual ICollection<AppGroupSemesterPerCourse> AppGroupSemesterPerCourses { get; set; }
        public virtual ICollection<AppLessonPerGroup> AppLessonPerGroups { get; set; }
        public virtual ICollection<AppStudentPerGroup> AppStudentPerGroups { get; set; }
        public virtual ICollection<AppUserPerGroup> AppUserPerGroups { get; set; }
    }
}
