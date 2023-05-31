using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppBirth
    {
        public AppBirth()
        {
            AppStudents = new HashSet<AppStudent>();
            AppUserPerSchools = new HashSet<AppUserPerSchool>();
        }

        public int Idbirth { get; set; }
        public int? BirthCountryId { get; set; }
        public DateTime? BirthDate { get; set; }
        public string BirthHebrewDate { get; set; }
        public int? CitizenshipId { get; set; }
        public DateTime? DateOfImmigration { get; set; }
        public int? CountryIdofImmigration { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdated { get; set; }

        public virtual TabCountry BirthCountry { get; set; }
        public virtual TabCountry Citizenship { get; set; }
        public virtual TabCountry CountryIdofImmigrationNavigation { get; set; }
        public virtual AppUserPerSchool UserCreated { get; set; }
        public virtual AppUserPerSchool UserUpdated { get; set; }
        public virtual ICollection<AppStudent> AppStudents { get; set; }
        public virtual ICollection<AppUserPerSchool> AppUserPerSchools { get; set; }
    }
}
