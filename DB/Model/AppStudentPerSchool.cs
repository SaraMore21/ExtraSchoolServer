using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppStudentPerSchool
    {
        public int IdstudentPerSchool { get; set; }
        public int? StudentId { get; set; }
        public int? SchoolId { get; set; }

        public virtual AppStudent Student { get; set; }
    }
}
