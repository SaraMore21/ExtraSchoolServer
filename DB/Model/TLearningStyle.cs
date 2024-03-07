using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class TLearningStyle
    {
        public TLearningStyle()
        {
            AppCourses = new HashSet<AppCourse>();
            AppDailySchedules = new HashSet<AppDailySchedule>();
        }

        public int IdlearningStyle { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AppCourse> AppCourses { get; set; }
        public virtual ICollection<AppDailySchedule> AppDailySchedules { get; set; }
    }
}
