using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppNote
    {
        public int Idnote { get; set; }
        public int? Idstudent { get; set; }
        public string ControlName { get; set; }
        public string FormName { get; set; }
        public string NoteDes { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdate { get; set; }

        public virtual AppStudent IdstudentNavigation { get; set; }
        public virtual AppUserPerSchool UserCreated { get; set; }
        public virtual AppUserPerSchool UserUpdated { get; set; }
    }
}
