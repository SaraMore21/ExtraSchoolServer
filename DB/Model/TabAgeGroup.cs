using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class TabAgeGroup
    {
        public TabAgeGroup()
        {
            AppGroups = new HashSet<AppGroup>();
        }

        public int IdageGroup { get; set; }
        public string Name { get; set; }
        public int? SchoolId { get; set; }
        public string CoordinationCode { get; set; }

        public virtual AppSchool School { get; set; }
        public virtual ICollection<AppGroup> AppGroups { get; set; }
    }
}
