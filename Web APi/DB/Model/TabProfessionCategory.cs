using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class TabProfessionCategory
    {
        public TabProfessionCategory()
        {
            AppProfessions = new HashSet<AppProfession>();
        }

        public int IdProfessionCategory { get; set; }
        public string Name { get; set; }
        public int? SchoolId { get; set; }

        public virtual AppSchool School { get; set; }
        public virtual ICollection<AppProfession> AppProfessions { get; set; }
    }
}
