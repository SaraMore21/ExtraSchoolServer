using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppYearbookPerSchool
    {
        public AppYearbookPerSchool()
        {
            AppCourseRequirments = new HashSet<AppCourseRequirment>();
            AppCourses = new HashSet<AppCourse>();
            AppGroupPerYearbooks = new HashSet<AppGroupPerYearbook>();
            AppSemesters = new HashSet<AppSemester>();
            AppStudentPerYearbooks = new HashSet<AppStudentPerYearbook>();
            AppTaskExsists = new HashSet<AppTaskExsist>();
            AppTaskToStudents = new HashSet<AppTaskToStudent>();
            AppTasks = new HashSet<AppTask>();
            AppUserPerYearbooks = new HashSet<AppUserPerYearbook>();
        }

        public int IdyearbookPerSchool { get; set; }
        public string Name { get; set; }
        public int? SchoolId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdete { get; set; }
        public int? YearbookId { get; set; }

        public virtual AppSchool School { get; set; }
        public virtual AppUserPerSchool UserCreated { get; set; }
        public virtual AppUserPerSchool UserUpdated { get; set; }
        public virtual AppYearbook Yearbook { get; set; }
        public virtual ICollection<AppCourseRequirment> AppCourseRequirments { get; set; }
        public virtual ICollection<AppCourse> AppCourses { get; set; }
        public virtual ICollection<AppGroupPerYearbook> AppGroupPerYearbooks { get; set; }
        public virtual ICollection<AppSemester> AppSemesters { get; set; }
        public virtual ICollection<AppStudentPerYearbook> AppStudentPerYearbooks { get; set; }
        public virtual ICollection<AppTaskExsist> AppTaskExsists { get; set; }
        public virtual ICollection<AppTaskToStudent> AppTaskToStudents { get; set; }
        public virtual ICollection<AppTask> AppTasks { get; set; }
        public virtual ICollection<AppUserPerYearbook> AppUserPerYearbooks { get; set; }
    }
}
