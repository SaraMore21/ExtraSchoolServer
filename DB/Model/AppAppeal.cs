using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppAppeal
    {
        public int Idappeal { get; set; }
        public int? StudentAssingmentId { get; set; }
        public int? StatusAppealId { get; set; }
        public int? DocumentId { get; set; }
        public string Massege { get; set; }
        public int? SchoolId { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreate { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdate { get; set; }

        public virtual AppSchool School { get; set; }
        public virtual TStatusAppel StatusAppeal { get; set; }
        public virtual AppStudentAssingment StudentAssingment { get; set; }
        public virtual AppUserPerSchool UserCreated { get; set; }
        public virtual AppUserPerSchool UserUpdated { get; set; }
    }
}
