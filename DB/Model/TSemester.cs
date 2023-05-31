using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class TSemester
    {
        public TSemester()
        {
            AppCourses = new HashSet<AppCourse>();
        }

        public int Idsemester { get; set; }
        public string Name0 { get; set; }

        public virtual ICollection<AppCourse> AppCourses { get; set; }
    }
}
