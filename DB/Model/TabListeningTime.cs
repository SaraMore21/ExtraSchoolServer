using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class TabListeningTime
    {
        public TabListeningTime()
        {
            AppGroups = new HashSet<AppGroup>();
        }

        public int IdlisteningTime { get; set; }
        public int? NumDays { get; set; }

        public virtual ICollection<AppGroup> AppGroups { get; set; }
    }
}
