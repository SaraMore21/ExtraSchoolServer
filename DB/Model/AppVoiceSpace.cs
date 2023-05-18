using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppVoiceSpace
    {
        public AppVoiceSpace()
        {
            AppGroups = new HashSet<AppGroup>();
        }

        public int IdvoiseSpace { get; set; }
        public bool? IsPrivate { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdated { get; set; }

        public virtual AppUserPerSchool UserCreated { get; set; }
        public virtual AppUserPerSchool UserUpdated { get; set; }
        public virtual ICollection<AppGroup> AppGroups { get; set; }
    }
}
