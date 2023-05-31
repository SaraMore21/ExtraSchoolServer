using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class TCategory
    {
        public TCategory()
        {
            AppAplications = new HashSet<AppAplication>();
        }

        public int Idcategory { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AppAplication> AppAplications { get; set; }
    }
}
