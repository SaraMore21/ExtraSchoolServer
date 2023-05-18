using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class TabExecutionTypeOfTask
    {
        public TabExecutionTypeOfTask()
        {
            AppTasks = new HashSet<AppTask>();
        }

        public int IdexecutionTypeOfTask { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AppTask> AppTasks { get; set; }
    }
}
