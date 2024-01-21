using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppAddress
    {
        public AppAddress()
        {
            AppContactInformations = new HashSet<AppContactInformation>();
            AppSchools = new HashSet<AppSchool>();
            AppStudents = new HashSet<AppStudent>();
            AppUserPerSchools = new HashSet<AppUserPerSchool>();
        }

        public int Idaddress { get; set; }
        public int? CityId { get; set; }
        public int? StreetId { get; set; }
        public string HouseNumber { get; set; }
        public string ApartmentNumber { get; set; }
        public int? PoBox { get; set; }
        public int? ZipCode { get; set; }
        public int? NeighborhoodId { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string Comment { get; set; }

        public virtual TabCity City { get; set; }
        public virtual TabNeighborhood Neighborhood { get; set; }
        public virtual TabStreet Street { get; set; }
        public virtual AppUserPerSchool UserCreated { get; set; }
        public virtual AppUserPerSchool UserUpdated { get; set; }
        public virtual ICollection<AppContactInformation> AppContactInformations { get; set; }
        public virtual ICollection<AppSchool> AppSchools { get; set; }
        public virtual ICollection<AppStudent> AppStudents { get; set; }
        public virtual ICollection<AppUserPerSchool> AppUserPerSchools { get; set; }
    }
}
