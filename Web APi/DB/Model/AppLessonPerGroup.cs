using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppLessonPerGroup
    {
        public AppLessonPerGroup()
        {
            AppScheduleRegulars = new HashSet<AppScheduleRegular>();
        }

        public int IdlessonPerGroup { get; set; }
        public int? GroupId { get; set; }
        public short? DayOfWeek { get; set; }
        public short? NumLesson { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdated { get; set; }

        public virtual AppGroupPerYearbook Group { get; set; }
        public virtual AppUserPerSchool UserCreated { get; set; }
        public virtual AppUserPerSchool UserUpdated { get; set; }
        public virtual ICollection<AppScheduleRegular> AppScheduleRegulars { get; set; }
    }
}
