using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppMeetingTime
    {
        public int MeetingTimesId { get; set; }
        public int? GroupSemesterPerCourseId { get; set; }
        public short MeetingDay { get; set; }
        public string FromHour { get; set; }
        public string ToHour { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreate { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdate { get; set; }

        public virtual AppGroupSemesterPerCourse GroupSemesterPerCourse { get; set; }
    }
}
