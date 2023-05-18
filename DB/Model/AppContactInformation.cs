using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppContactInformation
    {
        public AppContactInformation()
        {
            AppContacts = new HashSet<AppContact>();
            AppSchools = new HashSet<AppSchool>();
            AppStudents = new HashSet<AppStudent>();
            AppUserPerSchools = new HashSet<AppUserPerSchool>();
        }

        public int IdcontactInformation { get; set; }
        public string TelephoneNumber1 { get; set; }
        public string TelephoneNumber2 { get; set; }
        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }
        public string PhoneNumber3 { get; set; }
        public string FaxNumber { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string IsMobile { get; set; }
        public string Job { get; set; }
        public int? AddressId { get; set; }

        public virtual AppAddress Address { get; set; }
        public virtual AppUserPerSchool UserCreated { get; set; }
        public virtual AppUserPerSchool UserUpdated { get; set; }
        public virtual ICollection<AppContact> AppContacts { get; set; }
        public virtual ICollection<AppSchool> AppSchools { get; set; }
        public virtual ICollection<AppStudent> AppStudents { get; set; }
        public virtual ICollection<AppUserPerSchool> AppUserPerSchools { get; set; }
    }
}
