using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppStudentPerAttendanceSummaryCalculation
    {
        public int IdstudentPerAttendanceSummaryCalculations { get; set; }
        public int? StudentId { get; set; }
        public int? AttendanceSummaryCalculationsId { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }

        public virtual TabAttendanceSummaryCalculation AttendanceSummaryCalculations { get; set; }
        public virtual AppStudent Student { get; set; }
    }
}
