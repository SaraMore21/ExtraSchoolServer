using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppDynamicDetailsPerTypeSchool
    {
        public int IddynamicDetailsPerTypeSchool { get; set; }
        public int? TypeSchoolId { get; set; }
        public int? DynamicDetailsId { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdate { get; set; }

        public virtual TDynamicDetailsForTypeSchool DynamicDetails { get; set; }
        public virtual TSchoolType TypeSchool { get; set; }
        public virtual AppUserPerSchool UserCreated { get; set; }
        public virtual AppUserPerSchool UserUpdated { get; set; }
    }
}
