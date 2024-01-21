using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppUniqueCode
    {
        public AppUniqueCode()
        {
            AppCourses = new HashSet<AppCourse>();
            AppDocumentPerFatherCourses = new HashSet<AppDocumentPerFatherCourse>();
            AppDocumentPerProfessions = new HashSet<AppDocumentPerProfession>();
            AppDocumentPerSchools = new HashSet<AppDocumentPerSchool>();
            AppDocumentPerTasks = new HashSet<AppDocumentPerTask>();
            AppDocumentPerUsers = new HashSet<AppDocumentPerUser>();
            AppProfessions = new HashSet<AppProfession>();
            AppQuestionsOfTasks = new HashSet<AppQuestionsOfTask>();
            AppTasks = new HashSet<AppTask>();
            AppUserPerSchools = new HashSet<AppUserPerSchool>();
            TabRequiredDocumentPerFatherCourses = new HashSet<TabRequiredDocumentPerFatherCourse>();
            TabRequiredDocumentPerProfessions = new HashSet<TabRequiredDocumentPerProfession>();
            TabRequiredDocumentPerSchools = new HashSet<TabRequiredDocumentPerSchool>();
            TabRequiredDocumentPerTasks = new HashSet<TabRequiredDocumentPerTask>();
            TabRequiredDocumentPerUsers = new HashSet<TabRequiredDocumentPerUser>();
        }

        public int IduniqueCode { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int? UserUpdatedId { get; set; }
        public int? UserCreatedId { get; set; }

        public virtual AppUserPerCustomer Customer { get; set; }
        public virtual AppUserPerSchool UserCreated { get; set; }
        public virtual AppUserPerSchool UserUpdated { get; set; }
        public virtual ICollection<AppCourse> AppCourses { get; set; }
        public virtual ICollection<AppDocumentPerFatherCourse> AppDocumentPerFatherCourses { get; set; }
        public virtual ICollection<AppDocumentPerProfession> AppDocumentPerProfessions { get; set; }
        public virtual ICollection<AppDocumentPerSchool> AppDocumentPerSchools { get; set; }
        public virtual ICollection<AppDocumentPerTask> AppDocumentPerTasks { get; set; }
        public virtual ICollection<AppDocumentPerUser> AppDocumentPerUsers { get; set; }
        public virtual ICollection<AppProfession> AppProfessions { get; set; }
        public virtual ICollection<AppQuestionsOfTask> AppQuestionsOfTasks { get; set; }
        public virtual ICollection<AppTask> AppTasks { get; set; }
        public virtual ICollection<AppUserPerSchool> AppUserPerSchools { get; set; }
        public virtual ICollection<TabRequiredDocumentPerFatherCourse> TabRequiredDocumentPerFatherCourses { get; set; }
        public virtual ICollection<TabRequiredDocumentPerProfession> TabRequiredDocumentPerProfessions { get; set; }
        public virtual ICollection<TabRequiredDocumentPerSchool> TabRequiredDocumentPerSchools { get; set; }
        public virtual ICollection<TabRequiredDocumentPerTask> TabRequiredDocumentPerTasks { get; set; }
        public virtual ICollection<TabRequiredDocumentPerUser> TabRequiredDocumentPerUsers { get; set; }
    }
}
