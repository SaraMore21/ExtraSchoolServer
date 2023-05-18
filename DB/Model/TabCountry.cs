using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class TabCountry
    {
        public TabCountry()
        {
            AppBirthBirthCountries = new HashSet<AppBirth>();
            AppBirthCitizenships = new HashSet<AppBirth>();
            AppBirthCountryIdofImmigrationNavigations = new HashSet<AppBirth>();
        }

        public int Idcountry { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AppBirth> AppBirthBirthCountries { get; set; }
        public virtual ICollection<AppBirth> AppBirthCitizenships { get; set; }
        public virtual ICollection<AppBirth> AppBirthCountryIdofImmigrationNavigations { get; set; }
    }
}
