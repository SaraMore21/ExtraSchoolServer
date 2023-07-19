using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppContact
    {
        public AppContact()
        {
            AppContactPerStudents = new HashSet<AppContactPerStudent>();
            AppSchools = new HashSet<AppSchool>();
        }

        public int Idcontact { get; set; }
        public int? ContactInformationId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string Tz { get; set; }
        public int? TypeIdentityId { get; set; }
        public int? SchoolId { get; set; }

        public virtual AppContactInformation ContactInformation { get; set; }
        public virtual AppSchool School { get; set; }
        public virtual TTypeIdentity TypeIdentity { get; set; }
        public virtual AppUserPerSchool UserCreated { get; set; }
        public virtual AppUserPerSchool UserUpdated { get; set; }
        public virtual ICollection<AppContactPerStudent> AppContactPerStudents { get; set; }
        public virtual ICollection<AppSchool> AppSchools { get; set; }
    }
}
