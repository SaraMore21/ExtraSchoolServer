using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppUserPerGroup
    {
        public int IduserPerGroup { get; set; }
        public int? UserId { get; set; }
        public int? GroupId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdated { get; set; }

        public virtual AppGroupPerYearbook Group { get; set; }
        public virtual AppUserPerSchool User { get; set; }
        public virtual AppUserPerSchool UserCreated { get; set; }
        public virtual AppUserPerSchool UserUpdated { get; set; }
    }
}
