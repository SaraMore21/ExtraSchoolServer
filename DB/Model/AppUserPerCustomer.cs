using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppUserPerCustomer
    {
        public AppUserPerCustomer()
        {
            AppUniqueCodes = new HashSet<AppUniqueCode>();
        }

        public int IduserPerCustomer { get; set; }
        public int? UserId { get; set; }
        public int? CustomerId { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdated { get; set; }

        public virtual AppCustomer Customer { get; set; }
        public virtual SecUser User { get; set; }
        public virtual AppUserPerSchool UserCreated { get; set; }
        public virtual AppUserPerSchool UserUpdated { get; set; }
        public virtual ICollection<AppUniqueCode> AppUniqueCodes { get; set; }
    }
}
