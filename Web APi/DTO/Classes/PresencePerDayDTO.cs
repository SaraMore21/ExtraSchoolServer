using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Classes
{
    public class PresencePerDayDTO
    {
        public LessonDTO Lesson { get; set; }
        public AppPresenceDTO Presence { get; set; }
        public string CourseName { get; set; }
        public int GroupId { get; set; }
        public int IdStudent { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Tz { get; set; }
        public string TypePresenceDec { get; set; }

    }
}
