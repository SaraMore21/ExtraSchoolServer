using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppStudent
    {
        public AppStudent()
        {
            AppAplications = new HashSet<AppAplication>();
            AppContactPerStudents = new HashSet<AppContactPerStudent>();
            AppDocumentPerStudents = new HashSet<AppDocumentPerStudent>();
            AppDynamicDetailsSchoolPerStudents = new HashSet<AppDynamicDetailsSchoolPerStudent>();
            AppEasementPerTestOfStudents = new HashSet<AppEasementPerTestOfStudent>();
            AppNotes = new HashSet<AppNote>();
            AppPresences = new HashSet<AppPresence>();
            AppStandardPerStudents = new HashSet<AppStandardPerStudent>();
            AppStudentAttendances = new HashSet<AppStudentAttendance>();
            AppStudentDailySchedules = new HashSet<AppStudentDailySchedule>();
            AppStudentPerGroups = new HashSet<AppStudentPerGroup>();
            AppStudentPerYearbooks = new HashSet<AppStudentPerYearbook>();
            AppTaskToStudents = new HashSet<AppTaskToStudent>();
        }

        public int Idstudent { get; set; }
        public string Tz { get; set; }
        public int? TypeIdentityId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? BirthId { get; set; }
        public string Code { get; set; }
        public short? GenderId { get; set; }
        public string PassportPicture { get; set; }
        public string ForeignLastName { get; set; }
        public string ForeignFirstName { get; set; }
        public string PreviusName { get; set; }
        public string FatherTz { get; set; }
        public string MotherTz { get; set; }
        public int? FatherTypeIdentityId { get; set; }
        public int? MotherTypeIdentityId { get; set; }
        public string Note { get; set; }
        public string AnatherDetails { get; set; }
        public int? StatusId { get; set; }
        public int? StatusStudentId { get; set; }
        public int? ReasonForLeavingId { get; set; }
        public int? AddressId { get; set; }
        public bool? IsActive { get; set; }
        public string Field1 { get; set; }
        public string Field2 { get; set; }
        public string Field3 { get; set; }
        public string Field4 { get; set; }
        public string Field5 { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string ApotropusTz { get; set; }
        public int? ApotropusTypeIdentityId { get; set; }
        public int? ContactInformationId { get; set; }
        public int? PreviousSchoolId { get; set; }
        public int? SchoolId { get; set; }

        public virtual AppAddress Address { get; set; }
        public virtual TTypeIdentity ApotropusTypeIdentity { get; set; }
        public virtual AppBirth Birth { get; set; }
        public virtual AppContactInformation ContactInformation { get; set; }
        public virtual TTypeIdentity FatherTypeIdentity { get; set; }
        public virtual TGender Gender { get; set; }
        public virtual TTypeIdentity MotherTypeIdentity { get; set; }
        public virtual AppSchool PreviousSchool { get; set; }
        public virtual TReasonForLeaving ReasonForLeaving { get; set; }
        public virtual AppSchool School { get; set; }
        public virtual TStatus Status { get; set; }
        public virtual TStatusStudent StatusStudent { get; set; }
        public virtual TTypeIdentity TypeIdentity { get; set; }
        public virtual AppUserPerSchool UserCreated { get; set; }
        public virtual AppUserPerSchool UserUpdated { get; set; }
        public virtual ICollection<AppAplication> AppAplications { get; set; }
        public virtual ICollection<AppContactPerStudent> AppContactPerStudents { get; set; }
        public virtual ICollection<AppDocumentPerStudent> AppDocumentPerStudents { get; set; }
        public virtual ICollection<AppDynamicDetailsSchoolPerStudent> AppDynamicDetailsSchoolPerStudents { get; set; }
        public virtual ICollection<AppEasementPerTestOfStudent> AppEasementPerTestOfStudents { get; set; }
        public virtual ICollection<AppNote> AppNotes { get; set; }
        public virtual ICollection<AppPresence> AppPresences { get; set; }
        public virtual ICollection<AppStandardPerStudent> AppStandardPerStudents { get; set; }
        public virtual ICollection<AppStudentAttendance> AppStudentAttendances { get; set; }
        public virtual ICollection<AppStudentDailySchedule> AppStudentDailySchedules { get; set; }
        public virtual ICollection<AppStudentPerGroup> AppStudentPerGroups { get; set; }
        public virtual ICollection<AppStudentPerYearbook> AppStudentPerYearbooks { get; set; }
        public virtual ICollection<AppTaskToStudent> AppTaskToStudents { get; set; }
    }
}
