using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppBuildingCurriculumContent
    {
        public int BuildingCurriculumContentsId { get; set; }
        public int BuildingCurriculumId { get; set; }
        public float? MinimumContentPercentage { get; set; }
        public float? MinimumContentHours { get; set; }
        public DateTime? InsertDate { get; set; }
        public int? UserCreated { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UserUpdate { get; set; }
        public int ContentsNum { get; set; }
        public int? AppBuildingCurriculumBuildingCurriculumId { get; set; }

        public virtual AppBuildingCurriculum AppBuildingCurriculumBuildingCurriculum { get; set; }
    }
}
