using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppSchool
    {
        public AppSchool()
        {
            AppAppeals = new HashSet<AppAppeal>();
            AppContacts = new HashSet<AppContact>();
            AppCoordinationPerSchools = new HashSet<AppCoordinationPerSchool>();
            AppCourseAssignments = new HashSet<AppCourseAssignment>();
            AppCourseRequirments = new HashSet<AppCourseRequirment>();
            AppCourses = new HashSet<AppCourse>();
            AppDailySchedules = new HashSet<AppDailySchedule>();
            AppDocumentPerCourses = new HashSet<AppDocumentPerCourse>();
            AppDocumentPerFatherCourses = new HashSet<AppDocumentPerFatherCourse>();
            AppDocumentPerGroups = new HashSet<AppDocumentPerGroup>();
            AppDocumentPerProfessions = new HashSet<AppDocumentPerProfession>();
            AppDocumentPerSchools = new HashSet<AppDocumentPerSchool>();
            AppDocumentPerStudents = new HashSet<AppDocumentPerStudent>();
            AppDocumentPerTaskExsists = new HashSet<AppDocumentPerTaskExsist>();
            AppDocumentPerTasks = new HashSet<AppDocumentPerTask>();
            AppDocumentPerUsers = new HashSet<AppDocumentPerUser>();
            AppFolders = new HashSet<AppFolder>();
            AppGroups = new HashSet<AppGroup>();
            AppLecturerPerCourses = new HashSet<AppLecturerPerCourse>();
            AppPresences = new HashSet<AppPresence>();
            AppProfessions = new HashSet<AppProfession>();
            AppScheduleRegulars = new HashSet<AppScheduleRegular>();
            AppStudentAssingments = new HashSet<AppStudentAssingment>();
            AppStudentPreviousSchools = new HashSet<AppStudent>();
            AppStudentSchools = new HashSet<AppStudent>();
            AppTaskExsists = new HashSet<AppTaskExsist>();
            AppTasks = new HashSet<AppTask>();
            AppUserPerSchools = new HashSet<AppUserPerSchool>();
            AppYearbookPerSchools = new HashSet<AppYearbookPerSchool>();
            TReasonForLeavings = new HashSet<TReasonForLeaving>();
            TStatusTaskPerformances = new HashSet<TStatusTaskPerformance>();
            TTypeContacts = new HashSet<TTypeContact>();
            TabAgeGroups = new HashSet<TabAgeGroup>();
            TabAttendanceMarkings = new HashSet<TabAttendanceMarking>();
            TabProfessionCategories = new HashSet<TabProfessionCategory>();
            TabRequiredDocumentPerCourses = new HashSet<TabRequiredDocumentPerCourse>();
            TabRequiredDocumentPerFatherCourses = new HashSet<TabRequiredDocumentPerFatherCourse>();
            TabRequiredDocumentPerGroups = new HashSet<TabRequiredDocumentPerGroup>();
            TabRequiredDocumentPerProfessions = new HashSet<TabRequiredDocumentPerProfession>();
            TabRequiredDocumentPerSchools = new HashSet<TabRequiredDocumentPerSchool>();
            TabRequiredDocumentPerStudents = new HashSet<TabRequiredDocumentPerStudent>();
            TabRequiredDocumentPerTaskExsists = new HashSet<TabRequiredDocumentPerTaskExsist>();
            TabRequiredDocumentPerTasks = new HashSet<TabRequiredDocumentPerTask>();
            TabRequiredDocumentPerUsers = new HashSet<TabRequiredDocumentPerUser>();
            TabTaskExecutionStatuses = new HashSet<TabTaskExecutionStatus>();
            TabTypeAttendanceMarkings = new HashSet<TabTypeAttendanceMarking>();
            TabTypeGroups = new HashSet<TabTypeGroup>();
        }

        public int Idschool { get; set; }
        public string Name { get; set; }
        public int? UserContactId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int? AdressId { get; set; }
        public int? ContactInformationId { get; set; }
        public string Logo { get; set; }
        public int? SchoolTypeId { get; set; }
        public int? NumStudents { get; set; }
        public string Field1 { get; set; }
        public string Field2 { get; set; }
        public string Field3 { get; set; }
        public string Field4 { get; set; }
        public string Field5 { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int? CustomerId { get; set; }
        public string CoordinationCode { get; set; }

        public virtual AppAddress Adress { get; set; }
        public virtual AppContactInformation ContactInformation { get; set; }
        public virtual AppCustomer Customer { get; set; }
        public virtual TSchoolType SchoolType { get; set; }
        public virtual AppContact UserContact { get; set; }
        public virtual AppUserPerSchool UserCreated { get; set; }
        public virtual AppUserPerSchool UserUpdated { get; set; }
        public virtual ICollection<AppAppeal> AppAppeals { get; set; }
        public virtual ICollection<AppContact> AppContacts { get; set; }
        public virtual ICollection<AppCoordinationPerSchool> AppCoordinationPerSchools { get; set; }
        public virtual ICollection<AppCourseAssignment> AppCourseAssignments { get; set; }
        public virtual ICollection<AppCourseRequirment> AppCourseRequirments { get; set; }
        public virtual ICollection<AppCourse> AppCourses { get; set; }
        public virtual ICollection<AppDailySchedule> AppDailySchedules { get; set; }
        public virtual ICollection<AppDocumentPerCourse> AppDocumentPerCourses { get; set; }
        public virtual ICollection<AppDocumentPerFatherCourse> AppDocumentPerFatherCourses { get; set; }
        public virtual ICollection<AppDocumentPerGroup> AppDocumentPerGroups { get; set; }
        public virtual ICollection<AppDocumentPerProfession> AppDocumentPerProfessions { get; set; }
        public virtual ICollection<AppDocumentPerSchool> AppDocumentPerSchools { get; set; }
        public virtual ICollection<AppDocumentPerStudent> AppDocumentPerStudents { get; set; }
        public virtual ICollection<AppDocumentPerTaskExsist> AppDocumentPerTaskExsists { get; set; }
        public virtual ICollection<AppDocumentPerTask> AppDocumentPerTasks { get; set; }
        public virtual ICollection<AppDocumentPerUser> AppDocumentPerUsers { get; set; }
        public virtual ICollection<AppFolder> AppFolders { get; set; }
        public virtual ICollection<AppGroup> AppGroups { get; set; }
        public virtual ICollection<AppLecturerPerCourse> AppLecturerPerCourses { get; set; }
        public virtual ICollection<AppPresence> AppPresences { get; set; }
        public virtual ICollection<AppProfession> AppProfessions { get; set; }
        public virtual ICollection<AppScheduleRegular> AppScheduleRegulars { get; set; }
        public virtual ICollection<AppStudentAssingment> AppStudentAssingments { get; set; }
        public virtual ICollection<AppStudent> AppStudentPreviousSchools { get; set; }
        public virtual ICollection<AppStudent> AppStudentSchools { get; set; }
        public virtual ICollection<AppTaskExsist> AppTaskExsists { get; set; }
        public virtual ICollection<AppTask> AppTasks { get; set; }
        public virtual ICollection<AppUserPerSchool> AppUserPerSchools { get; set; }
        public virtual ICollection<AppYearbookPerSchool> AppYearbookPerSchools { get; set; }
        public virtual ICollection<TReasonForLeaving> TReasonForLeavings { get; set; }
        public virtual ICollection<TStatusTaskPerformance> TStatusTaskPerformances { get; set; }
        public virtual ICollection<TTypeContact> TTypeContacts { get; set; }
        public virtual ICollection<TabAgeGroup> TabAgeGroups { get; set; }
        public virtual ICollection<TabAttendanceMarking> TabAttendanceMarkings { get; set; }
        public virtual ICollection<TabProfessionCategory> TabProfessionCategories { get; set; }
        public virtual ICollection<TabRequiredDocumentPerCourse> TabRequiredDocumentPerCourses { get; set; }
        public virtual ICollection<TabRequiredDocumentPerFatherCourse> TabRequiredDocumentPerFatherCourses { get; set; }
        public virtual ICollection<TabRequiredDocumentPerGroup> TabRequiredDocumentPerGroups { get; set; }
        public virtual ICollection<TabRequiredDocumentPerProfession> TabRequiredDocumentPerProfessions { get; set; }
        public virtual ICollection<TabRequiredDocumentPerSchool> TabRequiredDocumentPerSchools { get; set; }
        public virtual ICollection<TabRequiredDocumentPerStudent> TabRequiredDocumentPerStudents { get; set; }
        public virtual ICollection<TabRequiredDocumentPerTaskExsist> TabRequiredDocumentPerTaskExsists { get; set; }
        public virtual ICollection<TabRequiredDocumentPerTask> TabRequiredDocumentPerTasks { get; set; }
        public virtual ICollection<TabRequiredDocumentPerUser> TabRequiredDocumentPerUsers { get; set; }
        public virtual ICollection<TabTaskExecutionStatus> TabTaskExecutionStatuses { get; set; }
        public virtual ICollection<TabTypeAttendanceMarking> TabTypeAttendanceMarkings { get; set; }
        public virtual ICollection<TabTypeGroup> TabTypeGroups { get; set; }
    }
}
