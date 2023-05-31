using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class TSchoolType
    {
        public TSchoolType()
        {
            AppDynamicDetailsPerTypeSchools = new HashSet<AppDynamicDetailsPerTypeSchool>();
            AppSchools = new HashSet<AppSchool>();
        }

        public int IdtypeSchool { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AppDynamicDetailsPerTypeSchool> AppDynamicDetailsPerTypeSchools { get; set; }
        public virtual ICollection<AppSchool> AppSchools { get; set; }
    }
}
