using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class TabAttendanceMarking
    {
        public TabAttendanceMarking()
        {
            AppAttendanceHistories = new HashSet<AppAttendanceHistory>();
            AppPresences = new HashSet<AppPresence>();
            AppStudentAttendances = new HashSet<AppStudentAttendance>();
        }

        public int IdattendanceMarkings { get; set; }
        public string MarkingName { get; set; }
        public int? MarkingTypeId { get; set; }
        public string MarkupDisplay { get; set; }
        public int? SchoolId { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int? GroupId { get; set; }

        public virtual AppGroupSemesterPerCourse Group { get; set; }
        public virtual TabTypeAttendanceMarking MarkingType { get; set; }
        public virtual AppSchool School { get; set; }
        public virtual AppUserPerSchool UserCreated { get; set; }
        public virtual AppUserPerSchool UserUpdated { get; set; }
        public virtual ICollection<AppAttendanceHistory> AppAttendanceHistories { get; set; }
        public virtual ICollection<AppPresence> AppPresences { get; set; }
        public virtual ICollection<AppStudentAttendance> AppStudentAttendances { get; set; }
    }
}
