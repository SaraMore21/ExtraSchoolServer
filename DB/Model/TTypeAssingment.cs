using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class TTypeAssingment
    {
        public TTypeAssingment()
        {
            AppCourseAssignments = new HashSet<AppCourseAssignment>();
        }

        public int IdtypeAssingment { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<AppCourseAssignment> AppCourseAssignments { get; set; }
    }
}
