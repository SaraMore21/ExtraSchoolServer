using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class TTypePresence
    {
        public TTypePresence()
        {
            AppPresences = new HashSet<AppPresence>();
        }

        public short IdtypePresence { get; set; }
        public string TypePresenceDes { get; set; }

        public virtual ICollection<AppPresence> AppPresences { get; set; }
    }
}
