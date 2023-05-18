using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Classes
{
    
        public class AttendancePerLesson
        {
            public AppPresenceDTO presence { get; set; }
            public LessonDTO lesson { get; set; }



            public AttendancePerLesson(LessonDTO lesson, AppPresenceDTO presence)
            {
                this.presence = presence;
           
                this.lesson = lesson;
            }
        }
    
}
