﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class TabRequiredDocumentPerTask
    {
        public TabRequiredDocumentPerTask()
        {
            AppDocumentPerTasks = new HashSet<AppDocumentPerTask>();
        }

        public int IdrequiredDocumentPerTask { get; set; }
        public string Name { get; set; }
        public int? SchoolId { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int? UniqueCodeId { get; set; }

        public virtual AppSchool School { get; set; }
        public virtual AppUniqueCode UniqueCode { get; set; }
        public virtual AppUserPerSchool UserCreated { get; set; }
        public virtual AppUserPerSchool UserUpdated { get; set; }
        public virtual ICollection<AppDocumentPerTask> AppDocumentPerTasks { get; set; }
    }
}
