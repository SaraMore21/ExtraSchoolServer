using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class TDynamicDetailsForTypeSchool
    {
        public TDynamicDetailsForTypeSchool()
        {
            AppDynamicDetailsPerTypeSchools = new HashSet<AppDynamicDetailsPerTypeSchool>();
        }

        public int IddynamicDetailsForTypeSchool { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AppDynamicDetailsPerTypeSchool> AppDynamicDetailsPerTypeSchools { get; set; }
    }
}
