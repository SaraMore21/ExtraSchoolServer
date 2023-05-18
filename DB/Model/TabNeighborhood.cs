using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class TabNeighborhood
    {
        public TabNeighborhood()
        {
            AppAddresses = new HashSet<AppAddress>();
        }

        public int Idneighborhood { get; set; }
        public string Name { get; set; }
        public int? CityId { get; set; }

        public virtual TabCity City { get; set; }
        public virtual ICollection<AppAddress> AppAddresses { get; set; }
    }
}
