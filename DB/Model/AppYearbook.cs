using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppYearbook
    {
        public AppYearbook()
        {
            AppYearbookPerSchools = new HashSet<AppYearbookPerSchool>();
        }

        public int Idyearbook { get; set; }
        public string Name { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdated { get; set; }

        public virtual AppUserPerSchool UserCreated { get; set; }
        public virtual AppUserPerSchool UserUpdated { get; set; }
        public virtual ICollection<AppYearbookPerSchool> AppYearbookPerSchools { get; set; }
    }
}
