using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppAttendant
    {
        public AppAttendant()
        {
            AppAplications = new HashSet<AppAplication>();
        }

        public int Idattendant { get; set; }
        public string Name { get; set; }
        public string Massege { get; set; }
        public DateTime? Date { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdateId { get; set; }
        public DateTime? DateUpdate { get; set; }

        public virtual AppUserPerSchool UserCreated { get; set; }
        public virtual AppUserPerSchool UserUpdate { get; set; }
        public virtual ICollection<AppAplication> AppAplications { get; set; }
    }
}
