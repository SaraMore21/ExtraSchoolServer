using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class TabAttendanceSummaryConnection
    {
        public int IdattendanceSummaryConnection { get; set; }
        public int? IdtypesOfAttendanceSummaries { get; set; }
        public int? IdattendanceSummaryCalculations { get; set; }
    }
}
