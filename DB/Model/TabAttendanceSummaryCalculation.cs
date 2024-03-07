using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class TabAttendanceSummaryCalculation
    {
        public int IdattendanceSummaryCalculations { get; set; }
        public int? AttendencMarkingId { get; set; }
        public int? Amount { get; set; }
        public int? TypesOfAmountId { get; set; }
        public int? AmountidConditional { get; set; }
        public int? SpecificLesson { get; set; }
        public int? SpecificCondition { get; set; }
        public int? TimeRangeId { get; set; }
        public int? OutOfId { get; set; }
        public int? TypesOfAttendanceSummariesId { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int? LessonConditionId { get; set; }

        public virtual TCondition AmountidConditionalNavigation { get; set; }
        public virtual TabAttendanceMarking AttendencMarking { get; set; }
        public virtual TCondition SpecificConditionNavigation { get; set; }
        public virtual TTimeRange TimeRange { get; set; }
        public virtual TTypesOfAmount TypesOfAmount { get; set; }
        public virtual TabTypesOfAttendanceSummary TypesOfAttendanceSummaries { get; set; }
    }
}
