using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppEasementPerTestOfStudent
    {
        public int IdeasementPerTestOfStudent { get; set; }
        public int? StudentId { get; set; }
        public int? TestId { get; set; }
        public int? EasementId { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdated { get; set; }

        public virtual TEasement Easement { get; set; }
        public virtual AppStudent Student { get; set; }
        public virtual AppUserPerSchool UserCreated { get; set; }
        public virtual AppUserPerSchool UserUpdated { get; set; }
    }
}
