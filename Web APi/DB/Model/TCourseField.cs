using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class TCourseField
    {
        public short CourseFieldId { get; set; }
        public string CourseFieldDes { get; set; }
        public string TableName { get; set; }
        public int RestrictionTypeId { get; set; }
    }
}
