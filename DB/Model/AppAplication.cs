using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppAplication
    {
        public int Idaplication { get; set; }
        public int? StudentId { get; set; }
        public int? CategoryId { get; set; }
        public string Massege { get; set; }
        public int? StatusId { get; set; }
        public int? AttendantId { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdate { get; set; }

        public virtual AppAttendant Attendant { get; set; }
        public virtual TCategory Category { get; set; }
        public virtual TStatusAplication Status { get; set; }
        public virtual AppStudent Student { get; set; }
        public virtual AppUserPerSchool UserCreated { get; set; }
        public virtual AppUserPerSchool UserUpdated { get; set; }
    }
}
