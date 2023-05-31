using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppAttendanceHistory
    {
        public int IdattendanceHistory { get; set; }
        public int? StudentAttendanceId { get; set; }
        public int? AttendanceId { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdated { get; set; }

        public virtual TabAttendanceMarking Attendance { get; set; }
        public virtual AppStudentAttendance StudentAttendance { get; set; }
        public virtual AppUserPerSchool UserCreated { get; set; }
        public virtual AppUserPerSchool UserUpdated { get; set; }
    }
}
