using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class TTypeIdentity
    {
        public TTypeIdentity()
        {
            AppContacts = new HashSet<AppContact>();
            AppStudentApotropusTypeIdentities = new HashSet<AppStudent>();
            AppStudentFatherTypeIdentities = new HashSet<AppStudent>();
            AppStudentMotherTypeIdentities = new HashSet<AppStudent>();
            AppStudentTypeIdentities = new HashSet<AppStudent>();
            SecUsers = new HashSet<SecUser>();
        }

        public int IdtypeIdentity { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AppContact> AppContacts { get; set; }
        public virtual ICollection<AppStudent> AppStudentApotropusTypeIdentities { get; set; }
        public virtual ICollection<AppStudent> AppStudentFatherTypeIdentities { get; set; }
        public virtual ICollection<AppStudent> AppStudentMotherTypeIdentities { get; set; }
        public virtual ICollection<AppStudent> AppStudentTypeIdentities { get; set; }
        public virtual ICollection<SecUser> SecUsers { get; set; }
    }
}
