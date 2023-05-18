using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Classes
{
    public class TypeAttendanceMarkingDTO
    {
        public int IdtypeAttendanceMarking { get; set; }
        public string TypeAttendanceName { get; set; }
        public double? AttendancePercentage { get; set; }
        public int? SchoolId { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
