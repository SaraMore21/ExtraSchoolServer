using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class TStatusTaskPerformance
    {
        public TStatusTaskPerformance()
        {
            AppTaskToStudents = new HashSet<AppTaskToStudent>();
        }

        public int Id { get; set; }
        public string Status { get; set; }
        public string DisplayName { get; set; }
        public int MosadId { get; set; }
        public bool IsDefault { get; set; }

        public virtual AppSchool Mosad { get; set; }
        public virtual ICollection<AppTaskToStudent> AppTaskToStudents { get; set; }
    }
}
