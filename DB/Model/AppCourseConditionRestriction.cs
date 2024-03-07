using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppCourseConditionRestriction
    {
        public int CourseRestrictionsId { get; set; }
        public int Course1 { get; set; }
        public int Course2 { get; set; }
        public int SchoolId { get; set; }
        public short ConditionId { get; set; }
        public short? CourseFieldId { get; set; }
        public DateTime? InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UserCreated { get; set; }
        public int? UserUpdate { get; set; }
    }
}
