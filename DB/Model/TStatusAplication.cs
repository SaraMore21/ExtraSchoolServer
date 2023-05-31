using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class TStatusAplication
    {
        public TStatusAplication()
        {
            AppAplications = new HashSet<AppAplication>();
        }

        public int IdstatusApp { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AppAplication> AppAplications { get; set; }
    }
}
