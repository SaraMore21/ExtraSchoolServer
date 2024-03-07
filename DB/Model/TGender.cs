using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class TGender
    {
        public TGender()
        {
            AppStudents = new HashSet<AppStudent>();
            AppUserPerSchools = new HashSet<AppUserPerSchool>();
        }

        public short Idgender { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AppStudent> AppStudents { get; set; }
        public virtual ICollection<AppUserPerSchool> AppUserPerSchools { get; set; }
    }
}
