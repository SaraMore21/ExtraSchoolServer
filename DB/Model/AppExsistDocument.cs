using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppExsistDocument
    {
        public AppExsistDocument()
        {
            AppDocumentPerCourses = new HashSet<AppDocumentPerCourse>();
            AppDocumentPerFatherCourses = new HashSet<AppDocumentPerFatherCourse>();
            AppDocumentPerGroups = new HashSet<AppDocumentPerGroup>();
            AppDocumentPerProfessions = new HashSet<AppDocumentPerProfession>();
            AppDocumentPerSchools = new HashSet<AppDocumentPerSchool>();
            AppDocumentPerStudents = new HashSet<AppDocumentPerStudent>();
            AppDocumentPerTaskExsists = new HashSet<AppDocumentPerTaskExsist>();
            AppDocumentPerTasks = new HashSet<AppDocumentPerTask>();
            AppDocumentPerUsers = new HashSet<AppDocumentPerUser>();
        }

        public int IdexsistDocument { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdated { get; set; }

        public virtual AppUserPerSchool UserCreated { get; set; }
        public virtual AppUserPerSchool UserUpdated { get; set; }
        public virtual ICollection<AppDocumentPerCourse> AppDocumentPerCourses { get; set; }
        public virtual ICollection<AppDocumentPerFatherCourse> AppDocumentPerFatherCourses { get; set; }
        public virtual ICollection<AppDocumentPerGroup> AppDocumentPerGroups { get; set; }
        public virtual ICollection<AppDocumentPerProfession> AppDocumentPerProfessions { get; set; }
        public virtual ICollection<AppDocumentPerSchool> AppDocumentPerSchools { get; set; }
        public virtual ICollection<AppDocumentPerStudent> AppDocumentPerStudents { get; set; }
        public virtual ICollection<AppDocumentPerTaskExsist> AppDocumentPerTaskExsists { get; set; }
        public virtual ICollection<AppDocumentPerTask> AppDocumentPerTasks { get; set; }
        public virtual ICollection<AppDocumentPerUser> AppDocumentPerUsers { get; set; }
    }
}
