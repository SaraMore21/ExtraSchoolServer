using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppLocation
    {
        public AppLocation()
        {
            AppBuildingCurricula = new HashSet<AppBuildingCurriculum>();
        }

        public int Idlocation { get; set; }
        public string NameLocation { get; set; }
        public string Building { get; set; }
        public string Floor { get; set; }
        public int? Country { get; set; }
        public string Wing { get; set; }
        public int? AddressId { get; set; }
        public int? AppAddressIdaddress { get; set; }

        public virtual AppAddress AppAddressIdaddressNavigation { get; set; }
        public virtual ICollection<AppBuildingCurriculum> AppBuildingCurricula { get; set; }
    }
}
