using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class TTypesOfAmount
    {
        public TTypesOfAmount()
        {
            TabAttendanceSummaryCalculations = new HashSet<TabAttendanceSummaryCalculation>();
        }

        public int IdtypesOfAmount { get; set; }
        public string NameTypesOfAmount { get; set; }

        public virtual ICollection<TabAttendanceSummaryCalculation> TabAttendanceSummaryCalculations { get; set; }
    }
}
