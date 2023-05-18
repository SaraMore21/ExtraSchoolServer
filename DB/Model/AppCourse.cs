using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppCourse
    {
        public AppCourse()
        {
            AppCourseAssignments = new HashSet<AppCourseAssignment>();
            AppCourseRequirmentCourseRequireds = new HashSet<AppCourseRequirment>();
            AppCourseRequirmentCourses = new HashSet<AppCourseRequirment>();
            AppDocumentPerFatherCourses = new HashSet<AppDocumentPerFatherCourse>();
            AppGroupSemesterPerCourses = new HashSet<AppGroupSemesterPerCourse>();
            AppLecturerPerCourses = new HashSet<AppLecturerPerCourse>();
        }

        public int Idcourse { get; set; }
        public string Name { get; set; }
        public int? ProfessionId { get; set; }
        public int? HoursPerWeek { get; set; }
        public int? Hours { get; set; }
        public double? Credits { get; set; }
        public int? Cost { get; set; }
        public double? MinimumScore { get; set; }
        public int? LearningStyleId { get; set; }
        public int? SchoolId { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreate { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdate { get; set; }
        public int? UniqueCodeId { get; set; }
        public int? YearbookId { get; set; }
        public string Code { get; set; }
        public string CoordinationCode { get; set; }

        public virtual TLearningStyle LearningStyle { get; set; }
        public virtual AppProfession Profession { get; set; }
        public virtual AppSchool School { get; set; }
        public virtual AppUniqueCode UniqueCode { get; set; }
        public virtual AppUserPerSchool UserCreated { get; set; }
        public virtual AppUserPerSchool UserUpdated { get; set; }
        public virtual AppYearbookPerSchool Yearbook { get; set; }
        public virtual ICollection<AppCourseAssignment> AppCourseAssignments { get; set; }
        public virtual ICollection<AppCourseRequirment> AppCourseRequirmentCourseRequireds { get; set; }
        public virtual ICollection<AppCourseRequirment> AppCourseRequirmentCourses { get; set; }
        public virtual ICollection<AppDocumentPerFatherCourse> AppDocumentPerFatherCourses { get; set; }
        public virtual ICollection<AppGroupSemesterPerCourse> AppGroupSemesterPerCourses { get; set; }
        public virtual ICollection<AppLecturerPerCourse> AppLecturerPerCourses { get; set; }
    }
}
