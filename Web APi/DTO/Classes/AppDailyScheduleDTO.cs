using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Classes
{
    public class AppDailyScheduleDTO
    {
        public int IddailySchedule { get; set; }
        public int? TeacherId { get; set; }
        public int? ScheduleRegularId { get; set; }
        public int? CourseId { get; set; }
        public int? SchoolId { get; set; }
        public bool? IsChange { get; set; }
        public DateTime? ScheduleDate { get; set; }
        public short? LearningStyleId { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int NumLesson { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }

        public string TeacherName { get; set; }
        public string CourseName { get; set; }
        public string LearningStyleName { get; set; }


    }
}
