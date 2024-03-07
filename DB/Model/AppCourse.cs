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
        public int? CoordinationTypeId { get; set; }
        public int AlternateCode { get; set; }
        public short AssociateAcademicDegree { get; set; }
        public int Capacity { get; set; }
        public int CapacityArmorForWaiting { get; set; }
        public short EducatEnglishLevelRequired { get; set; }
        public short Education { get; set; }
        public DateTime EndDate { get; set; }
        public short FetalAttendancePercentage { get; set; }
        public short FinalGradeEducation { get; set; }
        public short HebrewLevelRequired { get; set; }
        public short LearningPoints { get; set; }
        public short Money { get; set; }
        public bool? NoObligationAttend { get; set; }
        public bool? OpeningConditionalOnNumberOfRegistrants { get; set; }
        public short OrganizationalAffiliation { get; set; }
        public short PassingGradeGivesAlevelOfHebrew { get; set; }
        public int PlannedNumberOfRegistrants { get; set; }
        public DateTime Season { get; set; }
        public DateTime StartDate { get; set; }
        public short SubjectFurtherEducation { get; set; }
        public string Color { get; set; }
        public int BuildingCurriculumContentsId { get; set; }

        public virtual AppCoordinationType CoordinationType { get; set; }
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
