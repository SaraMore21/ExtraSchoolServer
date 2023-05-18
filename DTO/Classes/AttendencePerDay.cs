using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Classes
{
    public class AttendencePerDay
        {
            public List<AttendancePerLesson> NochecotPerLesson { get; set; }
            public DateTime date { get; set; }
            public string nameStudent { get; set; }
            public string tz { get; set; }
            public int idStudent { get; set; }

        }
   
}
