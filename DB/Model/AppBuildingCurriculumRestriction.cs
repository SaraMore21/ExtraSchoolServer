using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppBuildingCurriculumRestriction
    {
        public int BuildingCurriculumRestrictionsId { get; set; }
        public int BuildingCurriculumId { get; set; }
        public float? Min { get; set; }
        public float? Max { get; set; }
        public bool? Required { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? BiggerThan { get; set; }
        public int? SmallerThan { get; set; }
        public int? Equal { get; set; }
        public short? FieldId { get; set; }
        public short? Percentage { get; set; }
    }
}
