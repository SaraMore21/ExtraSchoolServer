using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Classes
{
    public class TabAttendanceMarkingDTO
    {
        public int IdattendanceMarkings { get; set; }
        public string MarkingName { get; set; }
        public int? MarkingTypeId { get; set; }
        public string MarkupDisplay { get; set; }
        public int? SchoolId { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
