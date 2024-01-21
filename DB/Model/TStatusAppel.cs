using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class TStatusAppel
    {
        public TStatusAppel()
        {
            AppAppeals = new HashSet<AppAppeal>();
        }

        public int IdstatusAppel { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AppAppeal> AppAppeals { get; set; }
    }
}
