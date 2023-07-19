using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppCourseAssignment
    {
        public AppCourseAssignment()
        {
            AppCourseRequirments = new HashSet<AppCourseRequirment>();
            AppStudentAssingments = new HashSet<AppStudentAssingment>();
        }

        public int IdcourseAssignments { get; set; }
        public int? CourseId { get; set; }
        public int? TypeAssignmentId { get; set; }
        public DateTime? Adeadline { get; set; }
        public DateTime? Bdeadline { get; set; }
        public DateTime? Cdeadline { get; set; }
        public double? PartOfGrade { get; set; }
        public DateTime? DateSubmissionQuestionnaireToTheTeacher { get; set; }
        public DateTime? ActualDateSubmissionQuestionnaireToTheTeacher { get; set; }
        public double? PassingGrade { get; set; }
        public double? Cost { get; set; }
        public int? SchoolId { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdate { get; set; }

        public virtual AppCourse Course { get; set; }
        public virtual AppSchool School { get; set; }
        public virtual TTypeAssingment TypeAssignment { get; set; }
        public virtual AppUserPerSchool UserCreated { get; set; }
        public virtual AppUserPerSchool UserUpdated { get; set; }
        public virtual ICollection<AppCourseRequirment> AppCourseRequirments { get; set; }
        public virtual ICollection<AppStudentAssingment> AppStudentAssingments { get; set; }
    }
}
