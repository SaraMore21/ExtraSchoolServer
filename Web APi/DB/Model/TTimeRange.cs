using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class TTimeRange
    {
        public TTimeRange()
        {
            TabAttendanceSummaryCalculations = new HashSet<TabAttendanceSummaryCalculation>();
        }

        public int IdtimeRange { get; set; }
        public string NameTimeRange { get; set; }

        public virtual ICollection<TabAttendanceSummaryCalculation> TabAttendanceSummaryCalculations { get; set; }
    }
}
