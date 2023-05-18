using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppGroupSemesterPerCourse
    {
        public AppGroupSemesterPerCourse()
        {
            AppDailySchedules = new HashSet<AppDailySchedule>();
            AppDocumentPerCourses = new HashSet<AppDocumentPerCourse>();
            AppScheduleRegulars = new HashSet<AppScheduleRegular>();
            AppTaskExsists = new HashSet<AppTaskExsist>();
            AppUserPerCourses = new HashSet<AppUserPerCourse>();
        }

        public int IdgroupSemesterPerCourse { get; set; }
        public int? SemesterId { get; set; }
        public int? CourseId { get; set; }
        public int? GroupId { get; set; }
        public string Code { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdate { get; set; }

        public virtual AppCourse Course { get; set; }
        public virtual AppGroupPerYearbook Group { get; set; }
        public virtual AppSemester Semester { get; set; }
        public virtual AppUserPerSchool UserCreated { get; set; }
        public virtual AppUserPerSchool UserUpdated { get; set; }
        public virtual ICollection<AppDailySchedule> AppDailySchedules { get; set; }
        public virtual ICollection<AppDocumentPerCourse> AppDocumentPerCourses { get; set; }
        public virtual ICollection<AppScheduleRegular> AppScheduleRegulars { get; set; }
        public virtual ICollection<AppTaskExsist> AppTaskExsists { get; set; }
        public virtual ICollection<AppUserPerCourse> AppUserPerCourses { get; set; }
    }
}
