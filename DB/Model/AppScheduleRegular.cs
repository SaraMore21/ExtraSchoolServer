using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppScheduleRegular
    {
        public AppScheduleRegular()
        {
            AppDailySchedules = new HashSet<AppDailySchedule>();
        }

        public int IdscheduleRegular { get; set; }
        public int? CourseId { get; set; }
        public int? SchoolId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int? LessonPerGroupId { get; set; }

        public virtual AppGroupSemesterPerCourse Course { get; set; }
        public virtual AppLessonPerGroup LessonPerGroup { get; set; }
        public virtual AppSchool School { get; set; }
        public virtual AppUserPerSchool UserCreated { get; set; }
        public virtual AppUserPerSchool UserUpdated { get; set; }
        public virtual ICollection<AppDailySchedule> AppDailySchedules { get; set; }
    }
}
