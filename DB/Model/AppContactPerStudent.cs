using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppContactPerStudent
    {
        public int IdcontactPerStudent { get; set; }
        public int? StudentId { get; set; }
        public int? ContactId { get; set; }
        public int? TypeContactId { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdated { get; set; }

        public virtual AppContact Contact { get; set; }
        public virtual AppStudent Student { get; set; }
        public virtual TTypeContact TypeContact { get; set; }
        public virtual AppUserPerSchool UserCreated { get; set; }
        public virtual AppUserPerSchool UserUpdated { get; set; }
    }
}
