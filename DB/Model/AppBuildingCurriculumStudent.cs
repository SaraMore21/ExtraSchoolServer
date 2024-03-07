using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppBuildingCurriculumStudent
    {
        public int BuildingCurriculumStudentId { get; set; }
        public DateTime? InsertDate { get; set; }
        public int? UserCreated { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UserUpdate { get; set; }
        public int BuildingCurriculumId { get; set; }
        public int GroupSemesterPerCourseId { get; set; }
        public int StudentId { get; set; }
    }
}
