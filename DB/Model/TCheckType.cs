using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class TCheckType
    {
        public TCheckType()
        {
            AppTasks = new HashSet<AppTask>();
        }

        public int IdcheckType { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AppTask> AppTasks { get; set; }
    }
}
