using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppBuildingCurriculumTime
    {
        public int BuildingCurriculumTimeId { get; set; }
        public int BuildingCurriculumId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public DateTime? InsertDate { get; set; }
        public int? UserCreated { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UserUpdate { get; set; }
        public int? AppBuildingCurriculumBuildingCurriculumId { get; set; }

        public virtual AppBuildingCurriculum AppBuildingCurriculumBuildingCurriculum { get; set; }
    }
}
