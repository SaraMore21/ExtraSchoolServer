using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.Classes
{

    public class AttendancePerLesson
    {
        public Presence presence { get; set; }
        public Lesson lesson { get; set; }

    }

}