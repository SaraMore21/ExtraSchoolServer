using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class TCondition
    {
        public TCondition()
        {
            TabAttendanceSummaryCalculationAmountidConditionalNavigations = new HashSet<TabAttendanceSummaryCalculation>();
            TabAttendanceSummaryCalculationSpecificConditionNavigations = new HashSet<TabAttendanceSummaryCalculation>();
        }

        public int Idcondition { get; set; }
        public string NameCondition { get; set; }

        public virtual ICollection<TabAttendanceSummaryCalculation> TabAttendanceSummaryCalculationAmountidConditionalNavigations { get; set; }
        public virtual ICollection<TabAttendanceSummaryCalculation> TabAttendanceSummaryCalculationSpecificConditionNavigations { get; set; }
    }
}
