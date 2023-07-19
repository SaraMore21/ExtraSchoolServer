using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppUserPerYearbook
    {
        public int IduserPerYearbook { get; set; }
        public int? UserId { get; set; }
        public int? YearbookId { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdated { get; set; }

        public virtual AppUserPerSchool User { get; set; }
        public virtual AppUserPerSchool UserCreated { get; set; }
        public virtual AppUserPerSchool UserUpdated { get; set; }
        public virtual AppYearbookPerSchool Yearbook { get; set; }
    }
}
