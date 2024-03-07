using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class TabAttendanceMarkingsPermission
    {
        public int IdAttendanceMarkingsPermissions { get; set; }
        public string TypeAttedanceMarkingid { get; set; }
        public int? Permissionsid { get; set; }
        public int? SchoolId { get; set; }
        public int? GroupId { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdated { get; set; }

        public virtual AppGroupSemesterPerCourse Group { get; set; }
        public virtual AppSchool School { get; set; }
    }
}
