using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class TEasement
    {
        public TEasement()
        {
            AppEasementPerStandards = new HashSet<AppEasementPerStandard>();
            AppEasementPerTestOfStudents = new HashSet<AppEasementPerTestOfStudent>();
        }

        public int Ideasement { get; set; }
        public string EasementName { get; set; }

        public virtual ICollection<AppEasementPerStandard> AppEasementPerStandards { get; set; }
        public virtual ICollection<AppEasementPerTestOfStudent> AppEasementPerTestOfStudents { get; set; }
    }
}
