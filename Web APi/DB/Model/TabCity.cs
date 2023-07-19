using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class TabCity
    {
        public TabCity()
        {
            AppAddresses = new HashSet<AppAddress>();
            TabNeighborhoods = new HashSet<TabNeighborhood>();
            TabStreets = new HashSet<TabStreet>();
        }

        public int Idcity { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AppAddress> AppAddresses { get; set; }
        public virtual ICollection<TabNeighborhood> TabNeighborhoods { get; set; }
        public virtual ICollection<TabStreet> TabStreets { get; set; }
    }
}
