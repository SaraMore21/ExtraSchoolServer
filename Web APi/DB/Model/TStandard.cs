using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class TStandard
    {
        public TStandard()
        {
            AppEasementPerStandards = new HashSet<AppEasementPerStandard>();
            AppStandardPerStudents = new HashSet<AppStandardPerStudent>();
        }

        public int Idstandard { get; set; }
        public string StandardName { get; set; }

        public virtual ICollection<AppEasementPerStandard> AppEasementPerStandards { get; set; }
        public virtual ICollection<AppStandardPerStudent> AppStandardPerStudents { get; set; }
    }
}
