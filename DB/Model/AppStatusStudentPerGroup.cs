using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppStatusStudentPerGroup
    {
        public int IdstatusStudentPerGroup { get; set; }
        public int? StudentPerGroupId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? StatusId { get; set; }
        public int? ReasonForLeavingId { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdate { get; set; }

        public virtual TReasonForLeaving ReasonForLeaving { get; set; }
        public virtual TStatus Status { get; set; }
        public virtual AppStudentPerGroup StudentPerGroup { get; set; }
        public virtual AppUserPerSchool UserCreated { get; set; }
        public virtual AppUserPerSchool UserUpdated { get; set; }
    }
}
