using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class TabDegree
    {
        public TabDegree()
        {
            AppUserPerSchools = new HashSet<AppUserPerSchool>();
        }

        public int Iddegree { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AppUserPerSchool> AppUserPerSchools { get; set; }
    }
}
