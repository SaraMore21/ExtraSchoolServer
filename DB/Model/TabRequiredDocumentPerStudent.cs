﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class TabRequiredDocumentPerStudent
    {
        public TabRequiredDocumentPerStudent()
        {
            AppDocumentPerStudents = new HashSet<AppDocumentPerStudent>();
        }

        public int IdrequiredDocumentPerStudent { get; set; }
        public string Name { get; set; }
        public int? SchoolId { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdated { get; set; }

        public virtual AppSchool School { get; set; }
        public virtual AppUserPerSchool UserCreated { get; set; }
        public virtual AppUserPerSchool UserUpdated { get; set; }
        public virtual ICollection<AppDocumentPerStudent> AppDocumentPerStudents { get; set; }
    }
}
