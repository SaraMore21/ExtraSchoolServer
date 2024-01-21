using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Classes
{
    public class AppScheduleRegularDTO
    {
        public int IdscheduleRegular { get; set; }
        public int? CourseId { get; set; }
        public int? SchoolId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int? LessonPerGroupId { get; set; }

        public short? DayOfWeek { get; set; }
        public short? NumLesson { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public string TeacherName { get; set; }
        public string CourseName { get; set; }



    }
}
