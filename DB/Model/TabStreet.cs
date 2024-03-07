using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class TabStreet
    {
        public TabStreet()
        {
            AppAddresses = new HashSet<AppAddress>();
        }

        public int Idstreet { get; set; }
        public int CodeStreet { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }

        public virtual TabCity City { get; set; }
        public virtual ICollection<AppAddress> AppAddresses { get; set; }
    }
}
