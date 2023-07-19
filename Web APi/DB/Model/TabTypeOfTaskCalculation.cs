using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class TabTypeOfTaskCalculation
    {
        public TabTypeOfTaskCalculation()
        {
            AppTasks = new HashSet<AppTask>();
        }

        public int IdtypeOfTaskCalculation { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AppTask> AppTasks { get; set; }
    }
}
