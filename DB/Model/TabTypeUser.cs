using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class TabTypeUser
    {
        public TabTypeUser()
        {
            AppUserPerSchools = new HashSet<AppUserPerSchool>();
        }

        public int IdtypeUser { get; set; }
        public string Name { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdated { get; set; }

        public virtual AppUserPerSchool UserCreated { get; set; }
        public virtual AppUserPerSchool UserUpdated { get; set; }
        public virtual ICollection<AppUserPerSchool> AppUserPerSchools { get; set; }
    }
}
