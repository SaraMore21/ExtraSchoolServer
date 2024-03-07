using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class TTypeContact
    {
        public TTypeContact()
        {
            AppContactPerStudents = new HashSet<AppContactPerStudent>();
        }

        public int IdtypeContact { get; set; }
        public string Name { get; set; }
        public int? SchoolId { get; set; }

        public virtual AppSchool School { get; set; }
        public virtual ICollection<AppContactPerStudent> AppContactPerStudents { get; set; }
    }
}
