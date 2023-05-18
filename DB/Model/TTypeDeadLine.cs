using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class TTypeDeadLine
    {
        public TTypeDeadLine()
        {
            AppStudentAssingments = new HashSet<AppStudentAssingment>();
        }

        public int IdtypeDeadline0 { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AppStudentAssingment> AppStudentAssingments { get; set; }
    }
}
