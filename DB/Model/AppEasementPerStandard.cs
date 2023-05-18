using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppEasementPerStandard
    {
        public int IdeasementPerStandard { get; set; }
        public int? StandardId { get; set; }
        public int? EasementId { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdate { get; set; }

        public virtual TEasement Easement { get; set; }
        public virtual TStandard Standard { get; set; }
        public virtual AppUserPerSchool UserCreated { get; set; }
        public virtual AppUserPerSchool UserUpdated { get; set; }
    }
}
