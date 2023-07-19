using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppLecturerPerCourse
    {
        public int Idlecturer { get; set; }
        public int? CourseId { get; set; }
        public int? TeacherId { get; set; }
        public int? ReplacingId { get; set; }
        public int? SchoolId { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdate { get; set; }

        public virtual AppCourse Course { get; set; }
        public virtual AppSchool School { get; set; }
        public virtual AppUserPerSchool Teacher { get; set; }
        public virtual AppUserPerSchool UserCreated { get; set; }
        public virtual AppUserPerSchool UserUpdated { get; set; }
    }
}
