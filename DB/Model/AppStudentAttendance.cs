using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppStudentAttendance
    {
        public AppStudentAttendance()
        {
            AppAttendanceHistories = new HashSet<AppAttendanceHistory>();
        }

        public int IdstudentAttendance { get; set; }
        public int? StudentId { get; set; }
        public int? AttendanceId { get; set; }
        public int? DailyScheduleId { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdated { get; set; }

        public virtual TabAttendanceMarking Attendance { get; set; }
        public virtual AppDailySchedule DailySchedule { get; set; }
        public virtual AppStudent Student { get; set; }
        public virtual AppUserPerSchool UserCreated { get; set; }
        public virtual AppUserPerSchool UserUpdated { get; set; }
        public virtual ICollection<AppAttendanceHistory> AppAttendanceHistories { get; set; }
    }
}
