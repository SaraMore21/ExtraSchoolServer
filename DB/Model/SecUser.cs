using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class SecUser
    {
        public SecUser()
        {
            AppUserPerSchools = new HashSet<AppUserPerSchool>();
        }

        public int Iduser { get; set; }
        public string Tz { get; set; }
        public int? TypeIdentityId { get; set; }
        public string UserPassword { get; set; }
        public string UserCode { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdated { get; set; }

        public virtual TTypeIdentity TypeIdentity { get; set; }
        public virtual AppUserPerSchool UserCreated { get; set; }
        public virtual AppUserPerSchool UserUpdated { get; set; }
        public virtual AppUserPerCustomer AppUserPerCustomer { get; set; }
        public virtual ICollection<AppUserPerSchool> AppUserPerSchools { get; set; }
    }
}
