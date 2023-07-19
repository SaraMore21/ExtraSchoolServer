using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppCourseRequirment
    {
        public int IdcourseRequirements { get; set; }
        public int? CourseId { get; set; }
        public int? CourseRequiredId { get; set; }
        public int? AssingmentId { get; set; }
        public int? YearBookPerSchoolId { get; set; }
        public double? PassingGrade { get; set; }
        public int? SchoolId { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreate { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdate { get; set; }

        public virtual AppCourseAssignment Assingment { get; set; }
        public virtual AppCourse Course { get; set; }
        public virtual AppCourse CourseRequired { get; set; }
        public virtual AppSchool School { get; set; }
        public virtual AppUserPerSchool UserCreated { get; set; }
        public virtual AppUserPerSchool UserUpdated { get; set; }
        public virtual AppYearbookPerSchool YearBookPerSchool { get; set; }
    }
}
