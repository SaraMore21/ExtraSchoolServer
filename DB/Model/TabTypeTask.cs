using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class TabTypeTask
    {
        public TabTypeTask()
        {
            AppTasks = new HashSet<AppTask>();
        }

        public int IdtypeTask { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdated { get; set; }

        public virtual AppUserPerSchool UserCreated { get; set; }
        public virtual AppUserPerSchool UserUpdated { get; set; }
        public virtual ICollection<AppTask> AppTasks { get; set; }
    }
}
