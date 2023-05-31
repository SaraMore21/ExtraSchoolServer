using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppPresence
    {
        public int Idpresence { get; set; }
        public int DailyScheduleId { get; set; }
        public int StudentId { get; set; }
        public short? TypePresenceId { get; set; }
        public short? Writeby { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdated { get; set; }

        public virtual AppDailySchedule DailySchedule { get; set; }
        public virtual AppStudent Student { get; set; }
        public virtual TTypePresence TypePresence { get; set; }
        public virtual AppUserPerSchool UserCreated { get; set; }
        public virtual AppUserPerSchool UserUpdated { get; set; }
    }
}
