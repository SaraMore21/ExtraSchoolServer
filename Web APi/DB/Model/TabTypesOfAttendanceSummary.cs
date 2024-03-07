using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class TabTypesOfAttendanceSummary
    {
        public TabTypesOfAttendanceSummary()
        {
            TabAttendanceSummaryCalculations = new HashSet<TabAttendanceSummaryCalculation>();
            TabAttendanceSummaryConnections = new HashSet<TabAttendanceSummaryConnection>();
        }

        public int IdtypesOfAttendanceSummaries { get; set; }
        public string TypesOfAttendanceSummariesName { get; set; }
        public int? SchoolId { get; set; }
        public int? GroupId { get; set; }
        public string VerbalExplanation { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdated { get; set; }

        public virtual AppGroupSemesterPerCourse Group { get; set; }
        public virtual AppSchool School { get; set; }
        public virtual ICollection<TabAttendanceSummaryCalculation> TabAttendanceSummaryCalculations { get; set; }
        public virtual ICollection<TabAttendanceSummaryConnection> TabAttendanceSummaryConnections { get; set; }
    }
}
