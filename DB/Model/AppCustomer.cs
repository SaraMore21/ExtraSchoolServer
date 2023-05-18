using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppCustomer
    {
        public AppCustomer()
        {
            AppSchools = new HashSet<AppSchool>();
            AppUserPerCustomers = new HashSet<AppUserPerCustomer>();
        }

        public int Idcustomer { get; set; }
        public string Name { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdate { get; set; }

        public virtual AppUserPerSchool UserCreated { get; set; }
        public virtual AppUserPerSchool UserUpdated { get; set; }
        public virtual ICollection<AppSchool> AppSchools { get; set; }
        public virtual ICollection<AppUserPerCustomer> AppUserPerCustomers { get; set; }
    }
}
