using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppDailySchedule
    {
        public AppDailySchedule()
        {
            AppPresences = new HashSet<AppPresence>();
            AppStudentAttendances = new HashSet<AppStudentAttendance>();
            AppStudentDailySchedules = new HashSet<AppStudentDailySchedule>();
        }

        public int IddailySchedule { get; set; }
        public int? TeacherId { get; set; }
        public int? ScheduleRegularId { get; set; }
        public int? CourseId { get; set; }
        public int? SchoolId { get; set; }
        public bool? IsChange { get; set; }
        public DateTime? ScheduleDate { get; set; }
        public int? LearningStyleId { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdated { get; set; }
        public short? NumLesson { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public bool? IsTackPlace { get; set; }

        public virtual AppGroupSemesterPerCourse Course { get; set; }
        public virtual TLearningStyle LearningStyle { get; set; }
        public virtual AppScheduleRegular ScheduleRegular { get; set; }
        public virtual AppSchool School { get; set; }
        public virtual AppUserPerSchool Teacher { get; set; }
        public virtual AppUserPerSchool UserCreated { get; set; }
        public virtual AppUserPerSchool UserUpdated { get; set; }
        public virtual ICollection<AppPresence> AppPresences { get; set; }
        public virtual ICollection<AppStudentAttendance> AppStudentAttendances { get; set; }
        public virtual ICollection<AppStudentDailySchedule> AppStudentDailySchedules { get; set; }
    }
}
