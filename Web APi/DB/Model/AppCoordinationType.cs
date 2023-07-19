using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppCoordinationType
    {
        public AppCoordinationType()
        {
            AppCourses = new HashSet<AppCourse>();
            AppGroups = new HashSet<AppGroup>();
            AppProfessions = new HashSet<AppProfession>();
            AppSemesters = new HashSet<AppSemester>();
            AppTasks = new HashSet<AppTask>();
            TabAgeGroups = new HashSet<TabAgeGroup>();
        }

        public int IdCoordinationType { get; set; }
        public int? IdCoordinationPerSchool { get; set; }
        public string CoordinationType { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdated { get; set; }

        public virtual AppCoordinationPerSchool IdCoordinationPerSchoolNavigation { get; set; }
        public virtual ICollection<AppCourse> AppCourses { get; set; }
        public virtual ICollection<AppGroup> AppGroups { get; set; }
        public virtual ICollection<AppProfession> AppProfessions { get; set; }
        public virtual ICollection<AppSemester> AppSemesters { get; set; }
        public virtual ICollection<AppTask> AppTasks { get; set; }
        public virtual ICollection<TabAgeGroup> TabAgeGroups { get; set; }
    }
}
