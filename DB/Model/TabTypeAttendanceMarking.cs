using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class TabTypeAttendanceMarking
    {
        public TabTypeAttendanceMarking()
        {
            TabAttendanceMarkings = new HashSet<TabAttendanceMarking>();
        }

        public int IdtypeAttendanceMarking { get; set; }
        public string TypeAttendanceName { get; set; }
        public double? AttendancePercentage { get; set; }
        public int? SchoolId { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int? GroupId { get; set; }
        public int? TypePresenceId { get; set; }

        public virtual AppSchool School { get; set; }
        public virtual AppUserPerSchool UserCreated { get; set; }
        public virtual AppUserPerSchool UserUpdated { get; set; }
        public virtual ICollection<TabAttendanceMarking> TabAttendanceMarkings { get; set; }
    }
}
