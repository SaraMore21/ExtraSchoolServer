using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppStudentPerYearbook
    {
        public int IdstudentPerYearbook { get; set; }
        public int? StudentId { get; set; }
        public int? YearbookId { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdate { get; set; }

        public virtual AppStudent Student { get; set; }
        public virtual AppUserPerSchool UserCreated { get; set; }
        public virtual AppUserPerSchool UserUpdated { get; set; }
        public virtual AppYearbookPerSchool Yearbook { get; set; }
    }
}
