using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppBuildingCurriculum
    {
        public AppBuildingCurriculum()
        {
            AppBuildingCurriculumContents = new HashSet<AppBuildingCurriculumContent>();
            AppBuildingCurriculumDays = new HashSet<AppBuildingCurriculumDay>();
            AppBuildingCurriculumPurposeStudies = new HashSet<AppBuildingCurriculumPurposeStudy>();
            AppBuildingCurriculumTimes = new HashSet<AppBuildingCurriculumTime>();
            AppBuildingCurriculumTypeLearns = new HashSet<AppBuildingCurriculumTypeLearn>();
        }

        public int BuildingCurriculumId { get; set; }
        public string BuildingCurriculumName { get; set; }
        public DateTime? InsertDate { get; set; }
        public float? MaxHours { get; set; }
        public float? MaxPrice { get; set; }
        public float? MinHours { get; set; }
        public float? MinPrice { get; set; }
        public float? Payment { get; set; }
        public float? PercentageDiscount { get; set; }
        public int? RoomId { get; set; }
        public int SchoolId { get; set; }
        public float? SumDiscount { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UserCreated { get; set; }
        public int? UserUpdate { get; set; }
        public int? LocationId { get; set; }

        public virtual AppLocation Location { get; set; }
        public virtual ICollection<AppBuildingCurriculumContent> AppBuildingCurriculumContents { get; set; }
        public virtual ICollection<AppBuildingCurriculumDay> AppBuildingCurriculumDays { get; set; }
        public virtual ICollection<AppBuildingCurriculumPurposeStudy> AppBuildingCurriculumPurposeStudies { get; set; }
        public virtual ICollection<AppBuildingCurriculumTime> AppBuildingCurriculumTimes { get; set; }
        public virtual ICollection<AppBuildingCurriculumTypeLearn> AppBuildingCurriculumTypeLearns { get; set; }
    }
}
