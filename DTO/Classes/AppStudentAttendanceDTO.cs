using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Classes
{
    public class AppStudentAttendanceDTO
    {
        public int IdstudentAttendance { get; set; }
        public int? StudentId { get; set; }
        public int? AttendanceId { get; set; }
        public int? DailyScheduleId { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
