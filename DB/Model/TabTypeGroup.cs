using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class TabTypeGroup
    {
        public TabTypeGroup()
        {
            AppGroups = new HashSet<AppGroup>();
        }

        public int IdtypeGroup { get; set; }
        public string Name { get; set; }
        public int? SchoolId { get; set; }
        public bool? IsMultiple { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int? CoordinationTypeId { get; set; }

        public virtual AppCoordinationType CoordinationType { get; set; }
        public virtual AppSchool School { get; set; }
        public virtual AppUserPerSchool UserCreated { get; set; }
        public virtual AppUserPerSchool UserUpdated { get; set; }
        public virtual ICollection<AppGroup> AppGroups { get; set; }
    }
}
