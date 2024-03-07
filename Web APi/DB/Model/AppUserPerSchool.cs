using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppUserPerSchool
    {
        public AppUserPerSchool()
        {
            AppAddressUserCreateds = new HashSet<AppAddress>();
            AppAddressUserUpdateds = new HashSet<AppAddress>();
            AppAplicationUserCreateds = new HashSet<AppAplication>();
            AppAplicationUserUpdateds = new HashSet<AppAplication>();
            AppAppealUserCreateds = new HashSet<AppAppeal>();
            AppAppealUserUpdateds = new HashSet<AppAppeal>();
            AppAttendanceHistoryUserCreateds = new HashSet<AppAttendanceHistory>();
            AppAttendanceHistoryUserUpdateds = new HashSet<AppAttendanceHistory>();
            AppAttendantUserCreateds = new HashSet<AppAttendant>();
            AppAttendantUserUpdates = new HashSet<AppAttendant>();
            AppBirthUserCreateds = new HashSet<AppBirth>();
            AppBirthUserUpdateds = new HashSet<AppBirth>();
            AppContactInformationUserCreateds = new HashSet<AppContactInformation>();
            AppContactInformationUserUpdateds = new HashSet<AppContactInformation>();
            AppContactPerStudentUserCreateds = new HashSet<AppContactPerStudent>();
            AppContactPerStudentUserUpdateds = new HashSet<AppContactPerStudent>();
            AppContactUserCreateds = new HashSet<AppContact>();
            AppContactUserUpdateds = new HashSet<AppContact>();
            AppCourseAssignmentUserCreateds = new HashSet<AppCourseAssignment>();
            AppCourseAssignmentUserUpdateds = new HashSet<AppCourseAssignment>();
            AppCourseRequirmentUserCreateds = new HashSet<AppCourseRequirment>();
            AppCourseRequirmentUserUpdateds = new HashSet<AppCourseRequirment>();
            AppCourseUserCreateds = new HashSet<AppCourse>();
            AppCourseUserUpdateds = new HashSet<AppCourse>();
            AppCustomerUserCreateds = new HashSet<AppCustomer>();
            AppCustomerUserUpdateds = new HashSet<AppCustomer>();
            AppDailyScheduleTeachers = new HashSet<AppDailySchedule>();
            AppDailyScheduleUserCreateds = new HashSet<AppDailySchedule>();
            AppDailyScheduleUserUpdateds = new HashSet<AppDailySchedule>();
            AppDocumentPerCourseUserCreateds = new HashSet<AppDocumentPerCourse>();
            AppDocumentPerCourseUserUpdateds = new HashSet<AppDocumentPerCourse>();
            AppDocumentPerFatherCourseUserCreateds = new HashSet<AppDocumentPerFatherCourse>();
            AppDocumentPerFatherCourseUserUpdateds = new HashSet<AppDocumentPerFatherCourse>();
            AppDocumentPerGroupUserCreateds = new HashSet<AppDocumentPerGroup>();
            AppDocumentPerGroupUserUpdateds = new HashSet<AppDocumentPerGroup>();
            AppDocumentPerProfessionUserCreateds = new HashSet<AppDocumentPerProfession>();
            AppDocumentPerProfessionUserUpdateds = new HashSet<AppDocumentPerProfession>();
            AppDocumentPerSchoolUserCreateds = new HashSet<AppDocumentPerSchool>();
            AppDocumentPerSchoolUserUpdateds = new HashSet<AppDocumentPerSchool>();
            AppDocumentPerStudentUserCreateds = new HashSet<AppDocumentPerStudent>();
            AppDocumentPerStudentUserUpdateds = new HashSet<AppDocumentPerStudent>();
            AppDocumentPerTaskExsistUserCreateds = new HashSet<AppDocumentPerTaskExsist>();
            AppDocumentPerTaskExsistUserUpdateds = new HashSet<AppDocumentPerTaskExsist>();
            AppDocumentPerTaskUserCreateds = new HashSet<AppDocumentPerTask>();
            AppDocumentPerTaskUserUpdateds = new HashSet<AppDocumentPerTask>();
            AppDocumentPerUserUserCreateds = new HashSet<AppDocumentPerUser>();
            AppDocumentPerUserUserUpdateds = new HashSet<AppDocumentPerUser>();
            AppDocumentPerUserUsers = new HashSet<AppDocumentPerUser>();
            AppDynamicDetailsPerTypeSchoolUserCreateds = new HashSet<AppDynamicDetailsPerTypeSchool>();
            AppDynamicDetailsPerTypeSchoolUserUpdateds = new HashSet<AppDynamicDetailsPerTypeSchool>();
            AppDynamicDetailsSchoolPerStudentUserCreateds = new HashSet<AppDynamicDetailsSchoolPerStudent>();
            AppDynamicDetailsSchoolPerStudentUserUpdateds = new HashSet<AppDynamicDetailsSchoolPerStudent>();
            AppEasementPerStandardUserCreateds = new HashSet<AppEasementPerStandard>();
            AppEasementPerStandardUserUpdateds = new HashSet<AppEasementPerStandard>();
            AppEasementPerTestOfStudentUserCreateds = new HashSet<AppEasementPerTestOfStudent>();
            AppEasementPerTestOfStudentUserUpdateds = new HashSet<AppEasementPerTestOfStudent>();
            AppExcelToDownloadUserCreateds = new HashSet<AppExcelToDownload>();
            AppExcelToDownloadUserUpdateds = new HashSet<AppExcelToDownload>();
            AppExsistDocumentUserCreateds = new HashSet<AppExsistDocument>();
            AppExsistDocumentUserUpdateds = new HashSet<AppExsistDocument>();
            AppFolderUserCreateds = new HashSet<AppFolder>();
            AppFolderUserUpdateds = new HashSet<AppFolder>();
            AppGroupPerYearbookUserCreateds = new HashSet<AppGroupPerYearbook>();
            AppGroupPerYearbookUserUpdateds = new HashSet<AppGroupPerYearbook>();
            AppGroupSemesterPerCourseUserCreateds = new HashSet<AppGroupSemesterPerCourse>();
            AppGroupSemesterPerCourseUserUpdateds = new HashSet<AppGroupSemesterPerCourse>();
            AppGroupUserCreateds = new HashSet<AppGroup>();
            AppGroupUserUpdateds = new HashSet<AppGroup>();
            AppLecturerPerCourseTeachers = new HashSet<AppLecturerPerCourse>();
            AppLecturerPerCourseUserCreateds = new HashSet<AppLecturerPerCourse>();
            AppLecturerPerCourseUserUpdateds = new HashSet<AppLecturerPerCourse>();
            AppLessonPerGroupUserCreateds = new HashSet<AppLessonPerGroup>();
            AppLessonPerGroupUserUpdateds = new HashSet<AppLessonPerGroup>();
            AppNoteUserCreateds = new HashSet<AppNote>();
            AppNoteUserUpdateds = new HashSet<AppNote>();
            AppPresenceUserCreateds = new HashSet<AppPresence>();
            AppPresenceUserUpdateds = new HashSet<AppPresence>();
            AppProfessionCoordinators = new HashSet<AppProfession>();
            AppProfessionUserCreateds = new HashSet<AppProfession>();
            AppProfessionUserUpdateds = new HashSet<AppProfession>();
            AppQuestionsOfTaskUserCreateds = new HashSet<AppQuestionsOfTask>();
            AppQuestionsOfTaskUserUpdateds = new HashSet<AppQuestionsOfTask>();
            AppScheduleRegularUserCreateds = new HashSet<AppScheduleRegular>();
            AppScheduleRegularUserUpdateds = new HashSet<AppScheduleRegular>();
            AppSchoolUserCreateds = new HashSet<AppSchool>();
            AppSchoolUserUpdateds = new HashSet<AppSchool>();
            AppScoreStudentPerQuestionsOfTaskUserCreateds = new HashSet<AppScoreStudentPerQuestionsOfTask>();
            AppScoreStudentPerQuestionsOfTaskUserUpdateds = new HashSet<AppScoreStudentPerQuestionsOfTask>();
            AppSemesterUserCreateds = new HashSet<AppSemester>();
            AppSemesterUserUpdateds = new HashSet<AppSemester>();
            AppStandardPerStudentUserCreateds = new HashSet<AppStandardPerStudent>();
            AppStandardPerStudentUserUpdateds = new HashSet<AppStandardPerStudent>();
            AppStatusStudentPerGroupUserCreateds = new HashSet<AppStatusStudentPerGroup>();
            AppStatusStudentPerGroupUserUpdateds = new HashSet<AppStatusStudentPerGroup>();
            AppStudentAssingmentReceivingPayments = new HashSet<AppStudentAssingment>();
            AppStudentAssingmentUserCreateds = new HashSet<AppStudentAssingment>();
            AppStudentAssingmentUserUpdateds = new HashSet<AppStudentAssingment>();
            AppStudentAttendanceUserCreateds = new HashSet<AppStudentAttendance>();
            AppStudentAttendanceUserUpdateds = new HashSet<AppStudentAttendance>();
            AppStudentDailyScheduleUserCreateds = new HashSet<AppStudentDailySchedule>();
            AppStudentDailyScheduleUserUpdateds = new HashSet<AppStudentDailySchedule>();
            AppStudentPerGroupUserCreateds = new HashSet<AppStudentPerGroup>();
            AppStudentPerGroupUserUpdateds = new HashSet<AppStudentPerGroup>();
            AppStudentPerYearbookUserCreateds = new HashSet<AppStudentPerYearbook>();
            AppStudentPerYearbookUserUpdateds = new HashSet<AppStudentPerYearbook>();
            AppStudentUserCreateds = new HashSet<AppStudent>();
            AppStudentUserUpdateds = new HashSet<AppStudent>();
            AppStudentsPerCourseUserCreateds = new HashSet<AppStudentsPerCourse>();
            AppStudentsPerCourseUserUpdateds = new HashSet<AppStudentsPerCourse>();
            AppTaskCoordinators = new HashSet<AppTask>();
            AppTaskExsistCoordinators = new HashSet<AppTaskExsist>();
            AppTaskExsistUserCreateds = new HashSet<AppTaskExsist>();
            AppTaskExsistUserUpdateds = new HashSet<AppTaskExsist>();
            AppTaskToStudentReceivePayments = new HashSet<AppTaskToStudent>();
            AppTaskToStudentUserCreateds = new HashSet<AppTaskToStudent>();
            AppTaskToStudentUserUpdateds = new HashSet<AppTaskToStudent>();
            AppTaskUserCreateds = new HashSet<AppTask>();
            AppTaskUserUpdateds = new HashSet<AppTask>();
            AppUniqueCodeUserCreateds = new HashSet<AppUniqueCode>();
            AppUniqueCodeUserUpdateds = new HashSet<AppUniqueCode>();
            AppUserPerCourseUserCreateds = new HashSet<AppUserPerCourse>();
            AppUserPerCourseUserUpdateds = new HashSet<AppUserPerCourse>();
            AppUserPerCourseUsers = new HashSet<AppUserPerCourse>();
            AppUserPerCustomerUserCreateds = new HashSet<AppUserPerCustomer>();
            AppUserPerCustomerUserUpdateds = new HashSet<AppUserPerCustomer>();
            AppUserPerGroupUserCreateds = new HashSet<AppUserPerGroup>();
            AppUserPerGroupUserUpdateds = new HashSet<AppUserPerGroup>();
            AppUserPerGroupUsers = new HashSet<AppUserPerGroup>();
            AppUserPerYearbookUserCreateds = new HashSet<AppUserPerYearbook>();
            AppUserPerYearbookUserUpdateds = new HashSet<AppUserPerYearbook>();
            AppUserPerYearbookUsers = new HashSet<AppUserPerYearbook>();
            AppUserPremissionUserCreateds = new HashSet<AppUserPremission>();
            AppUserPremissionUserUpdateds = new HashSet<AppUserPremission>();
            AppUserPremissionUsers = new HashSet<AppUserPremission>();
            AppVoiceSpaceUserCreateds = new HashSet<AppVoiceSpace>();
            AppVoiceSpaceUserUpdateds = new HashSet<AppVoiceSpace>();
            AppYearbookPerSchoolUserCreateds = new HashSet<AppYearbookPerSchool>();
            AppYearbookPerSchoolUserUpdateds = new HashSet<AppYearbookPerSchool>();
            AppYearbookUserCreateds = new HashSet<AppYearbook>();
            AppYearbookUserUpdateds = new HashSet<AppYearbook>();
            InverseUserCreated = new HashSet<AppUserPerSchool>();
            InverseUserUpdeted = new HashSet<AppUserPerSchool>();
            SecUserUserCreateds = new HashSet<SecUser>();
            SecUserUserUpdateds = new HashSet<SecUser>();
            TabAttendanceMarkingUserCreateds = new HashSet<TabAttendanceMarking>();
            TabAttendanceMarkingUserUpdateds = new HashSet<TabAttendanceMarking>();
            TabRequiredDocumentPerCourseUserCreateds = new HashSet<TabRequiredDocumentPerCourse>();
            TabRequiredDocumentPerCourseUserUpdateds = new HashSet<TabRequiredDocumentPerCourse>();
            TabRequiredDocumentPerFatherCourseUserCreateds = new HashSet<TabRequiredDocumentPerFatherCourse>();
            TabRequiredDocumentPerFatherCourseUserUpdateds = new HashSet<TabRequiredDocumentPerFatherCourse>();
            TabRequiredDocumentPerGroupUserCreateds = new HashSet<TabRequiredDocumentPerGroup>();
            TabRequiredDocumentPerGroupUserUpdateds = new HashSet<TabRequiredDocumentPerGroup>();
            TabRequiredDocumentPerProfessionUserCreateds = new HashSet<TabRequiredDocumentPerProfession>();
            TabRequiredDocumentPerProfessionUserUpdateds = new HashSet<TabRequiredDocumentPerProfession>();
            TabRequiredDocumentPerSchoolUserCreateds = new HashSet<TabRequiredDocumentPerSchool>();
            TabRequiredDocumentPerSchoolUserUpdateds = new HashSet<TabRequiredDocumentPerSchool>();
            TabRequiredDocumentPerStudentUserCreateds = new HashSet<TabRequiredDocumentPerStudent>();
            TabRequiredDocumentPerStudentUserUpdateds = new HashSet<TabRequiredDocumentPerStudent>();
            TabRequiredDocumentPerTaskExsistUserCreateds = new HashSet<TabRequiredDocumentPerTaskExsist>();
            TabRequiredDocumentPerTaskExsistUserUpdateds = new HashSet<TabRequiredDocumentPerTaskExsist>();
            TabRequiredDocumentPerTaskUserCreateds = new HashSet<TabRequiredDocumentPerTask>();
            TabRequiredDocumentPerTaskUserUpdateds = new HashSet<TabRequiredDocumentPerTask>();
            TabRequiredDocumentPerUserUserCreateds = new HashSet<TabRequiredDocumentPerUser>();
            TabRequiredDocumentPerUserUserUpdateds = new HashSet<TabRequiredDocumentPerUser>();
            TabTaskExecutionStatusUserCreateds = new HashSet<TabTaskExecutionStatus>();
            TabTaskExecutionStatusUserUpdateds = new HashSet<TabTaskExecutionStatus>();
            TabTypeAttendanceMarkingUserCreateds = new HashSet<TabTypeAttendanceMarking>();
            TabTypeAttendanceMarkingUserUpdateds = new HashSet<TabTypeAttendanceMarking>();
            TabTypeGroupUserCreateds = new HashSet<TabTypeGroup>();
            TabTypeGroupUserUpdateds = new HashSet<TabTypeGroup>();
            TabTypeTaskUserCreateds = new HashSet<TabTypeTask>();
            TabTypeTaskUserUpdateds = new HashSet<TabTypeTask>();
            TabTypeUserUserCreateds = new HashSet<TabTypeUser>();
            TabTypeUserUserUpdateds = new HashSet<TabTypeUser>();
        }

        public int IduserPerSchool { get; set; }
        public int? UserId { get; set; }
        public int? SchoolId { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdetedId { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int? ContactInformationId { get; set; }
        public bool? IsActive { get; set; }
        public string Note { get; set; }
        public int? TypeUserId { get; set; }
        public int? UniqueCodeId { get; set; }
        public DateTime? DateOfStartWork { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public short? GenderId { get; set; }
        public int? BirthId { get; set; }
        public int? StatusId { get; set; }
        public string ForeignLastName { get; set; }
        public string ForeignFirstName { get; set; }
        public string PreviusName { get; set; }
        public int? YearsOfEducation { get; set; }
        public int? YearsOfSeniority { get; set; }
        public int? DegreeId { get; set; }
        public int? AddressId { get; set; }

        public virtual AppAddress Address { get; set; }
        public virtual AppBirth Birth { get; set; }
        public virtual AppContactInformation ContactInformation { get; set; }
        public virtual TabDegree Degree { get; set; }
        public virtual TGender Gender { get; set; }
        public virtual AppSchool School { get; set; }
        public virtual TStatus Status { get; set; }
        public virtual TabTypeUser TypeUser { get; set; }
        public virtual AppUniqueCode UniqueCode { get; set; }
        public virtual SecUser User { get; set; }
        public virtual AppUserPerSchool UserCreated { get; set; }
        public virtual AppUserPerSchool UserUpdeted { get; set; }
        public virtual ICollection<AppAddress> AppAddressUserCreateds { get; set; }
        public virtual ICollection<AppAddress> AppAddressUserUpdateds { get; set; }
        public virtual ICollection<AppAplication> AppAplicationUserCreateds { get; set; }
        public virtual ICollection<AppAplication> AppAplicationUserUpdateds { get; set; }
        public virtual ICollection<AppAppeal> AppAppealUserCreateds { get; set; }
        public virtual ICollection<AppAppeal> AppAppealUserUpdateds { get; set; }
        public virtual ICollection<AppAttendanceHistory> AppAttendanceHistoryUserCreateds { get; set; }
        public virtual ICollection<AppAttendanceHistory> AppAttendanceHistoryUserUpdateds { get; set; }
        public virtual ICollection<AppAttendant> AppAttendantUserCreateds { get; set; }
        public virtual ICollection<AppAttendant> AppAttendantUserUpdates { get; set; }
        public virtual ICollection<AppBirth> AppBirthUserCreateds { get; set; }
        public virtual ICollection<AppBirth> AppBirthUserUpdateds { get; set; }
        public virtual ICollection<AppContactInformation> AppContactInformationUserCreateds { get; set; }
        public virtual ICollection<AppContactInformation> AppContactInformationUserUpdateds { get; set; }
        public virtual ICollection<AppContactPerStudent> AppContactPerStudentUserCreateds { get; set; }
        public virtual ICollection<AppContactPerStudent> AppContactPerStudentUserUpdateds { get; set; }
        public virtual ICollection<AppContact> AppContactUserCreateds { get; set; }
        public virtual ICollection<AppContact> AppContactUserUpdateds { get; set; }
        public virtual ICollection<AppCourseAssignment> AppCourseAssignmentUserCreateds { get; set; }
        public virtual ICollection<AppCourseAssignment> AppCourseAssignmentUserUpdateds { get; set; }
        public virtual ICollection<AppCourseRequirment> AppCourseRequirmentUserCreateds { get; set; }
        public virtual ICollection<AppCourseRequirment> AppCourseRequirmentUserUpdateds { get; set; }
        public virtual ICollection<AppCourse> AppCourseUserCreateds { get; set; }
        public virtual ICollection<AppCourse> AppCourseUserUpdateds { get; set; }
        public virtual ICollection<AppCustomer> AppCustomerUserCreateds { get; set; }
        public virtual ICollection<AppCustomer> AppCustomerUserUpdateds { get; set; }
        public virtual ICollection<AppDailySchedule> AppDailyScheduleTeachers { get; set; }
        public virtual ICollection<AppDailySchedule> AppDailyScheduleUserCreateds { get; set; }
        public virtual ICollection<AppDailySchedule> AppDailyScheduleUserUpdateds { get; set; }
        public virtual ICollection<AppDocumentPerCourse> AppDocumentPerCourseUserCreateds { get; set; }
        public virtual ICollection<AppDocumentPerCourse> AppDocumentPerCourseUserUpdateds { get; set; }
        public virtual ICollection<AppDocumentPerFatherCourse> AppDocumentPerFatherCourseUserCreateds { get; set; }
        public virtual ICollection<AppDocumentPerFatherCourse> AppDocumentPerFatherCourseUserUpdateds { get; set; }
        public virtual ICollection<AppDocumentPerGroup> AppDocumentPerGroupUserCreateds { get; set; }
        public virtual ICollection<AppDocumentPerGroup> AppDocumentPerGroupUserUpdateds { get; set; }
        public virtual ICollection<AppDocumentPerProfession> AppDocumentPerProfessionUserCreateds { get; set; }
        public virtual ICollection<AppDocumentPerProfession> AppDocumentPerProfessionUserUpdateds { get; set; }
        public virtual ICollection<AppDocumentPerSchool> AppDocumentPerSchoolUserCreateds { get; set; }
        public virtual ICollection<AppDocumentPerSchool> AppDocumentPerSchoolUserUpdateds { get; set; }
        public virtual ICollection<AppDocumentPerStudent> AppDocumentPerStudentUserCreateds { get; set; }
        public virtual ICollection<AppDocumentPerStudent> AppDocumentPerStudentUserUpdateds { get; set; }
        public virtual ICollection<AppDocumentPerTaskExsist> AppDocumentPerTaskExsistUserCreateds { get; set; }
        public virtual ICollection<AppDocumentPerTaskExsist> AppDocumentPerTaskExsistUserUpdateds { get; set; }
        public virtual ICollection<AppDocumentPerTask> AppDocumentPerTaskUserCreateds { get; set; }
        public virtual ICollection<AppDocumentPerTask> AppDocumentPerTaskUserUpdateds { get; set; }
        public virtual ICollection<AppDocumentPerUser> AppDocumentPerUserUserCreateds { get; set; }
        public virtual ICollection<AppDocumentPerUser> AppDocumentPerUserUserUpdateds { get; set; }
        public virtual ICollection<AppDocumentPerUser> AppDocumentPerUserUsers { get; set; }
        public virtual ICollection<AppDynamicDetailsPerTypeSchool> AppDynamicDetailsPerTypeSchoolUserCreateds { get; set; }
        public virtual ICollection<AppDynamicDetailsPerTypeSchool> AppDynamicDetailsPerTypeSchoolUserUpdateds { get; set; }
        public virtual ICollection<AppDynamicDetailsSchoolPerStudent> AppDynamicDetailsSchoolPerStudentUserCreateds { get; set; }
        public virtual ICollection<AppDynamicDetailsSchoolPerStudent> AppDynamicDetailsSchoolPerStudentUserUpdateds { get; set; }
        public virtual ICollection<AppEasementPerStandard> AppEasementPerStandardUserCreateds { get; set; }
        public virtual ICollection<AppEasementPerStandard> AppEasementPerStandardUserUpdateds { get; set; }
        public virtual ICollection<AppEasementPerTestOfStudent> AppEasementPerTestOfStudentUserCreateds { get; set; }
        public virtual ICollection<AppEasementPerTestOfStudent> AppEasementPerTestOfStudentUserUpdateds { get; set; }
        public virtual ICollection<AppExcelToDownload> AppExcelToDownloadUserCreateds { get; set; }
        public virtual ICollection<AppExcelToDownload> AppExcelToDownloadUserUpdateds { get; set; }
        public virtual ICollection<AppExsistDocument> AppExsistDocumentUserCreateds { get; set; }
        public virtual ICollection<AppExsistDocument> AppExsistDocumentUserUpdateds { get; set; }
        public virtual ICollection<AppFolder> AppFolderUserCreateds { get; set; }
        public virtual ICollection<AppFolder> AppFolderUserUpdateds { get; set; }
        public virtual ICollection<AppGroupPerYearbook> AppGroupPerYearbookUserCreateds { get; set; }
        public virtual ICollection<AppGroupPerYearbook> AppGroupPerYearbookUserUpdateds { get; set; }
        public virtual ICollection<AppGroupSemesterPerCourse> AppGroupSemesterPerCourseUserCreateds { get; set; }
        public virtual ICollection<AppGroupSemesterPerCourse> AppGroupSemesterPerCourseUserUpdateds { get; set; }
        public virtual ICollection<AppGroup> AppGroupUserCreateds { get; set; }
        public virtual ICollection<AppGroup> AppGroupUserUpdateds { get; set; }
        public virtual ICollection<AppLecturerPerCourse> AppLecturerPerCourseTeachers { get; set; }
        public virtual ICollection<AppLecturerPerCourse> AppLecturerPerCourseUserCreateds { get; set; }
        public virtual ICollection<AppLecturerPerCourse> AppLecturerPerCourseUserUpdateds { get; set; }
        public virtual ICollection<AppLessonPerGroup> AppLessonPerGroupUserCreateds { get; set; }
        public virtual ICollection<AppLessonPerGroup> AppLessonPerGroupUserUpdateds { get; set; }
        public virtual ICollection<AppNote> AppNoteUserCreateds { get; set; }
        public virtual ICollection<AppNote> AppNoteUserUpdateds { get; set; }
        public virtual ICollection<AppPresence> AppPresenceUserCreateds { get; set; }
        public virtual ICollection<AppPresence> AppPresenceUserUpdateds { get; set; }
        public virtual ICollection<AppProfession> AppProfessionCoordinators { get; set; }
        public virtual ICollection<AppProfession> AppProfessionUserCreateds { get; set; }
        public virtual ICollection<AppProfession> AppProfessionUserUpdateds { get; set; }
        public virtual ICollection<AppQuestionsOfTask> AppQuestionsOfTaskUserCreateds { get; set; }
        public virtual ICollection<AppQuestionsOfTask> AppQuestionsOfTaskUserUpdateds { get; set; }
        public virtual ICollection<AppScheduleRegular> AppScheduleRegularUserCreateds { get; set; }
        public virtual ICollection<AppScheduleRegular> AppScheduleRegularUserUpdateds { get; set; }
        public virtual ICollection<AppSchool> AppSchoolUserCreateds { get; set; }
        public virtual ICollection<AppSchool> AppSchoolUserUpdateds { get; set; }
        public virtual ICollection<AppScoreStudentPerQuestionsOfTask> AppScoreStudentPerQuestionsOfTaskUserCreateds { get; set; }
        public virtual ICollection<AppScoreStudentPerQuestionsOfTask> AppScoreStudentPerQuestionsOfTaskUserUpdateds { get; set; }
        public virtual ICollection<AppSemester> AppSemesterUserCreateds { get; set; }
        public virtual ICollection<AppSemester> AppSemesterUserUpdateds { get; set; }
        public virtual ICollection<AppStandardPerStudent> AppStandardPerStudentUserCreateds { get; set; }
        public virtual ICollection<AppStandardPerStudent> AppStandardPerStudentUserUpdateds { get; set; }
        public virtual ICollection<AppStatusStudentPerGroup> AppStatusStudentPerGroupUserCreateds { get; set; }
        public virtual ICollection<AppStatusStudentPerGroup> AppStatusStudentPerGroupUserUpdateds { get; set; }
        public virtual ICollection<AppStudentAssingment> AppStudentAssingmentReceivingPayments { get; set; }
        public virtual ICollection<AppStudentAssingment> AppStudentAssingmentUserCreateds { get; set; }
        public virtual ICollection<AppStudentAssingment> AppStudentAssingmentUserUpdateds { get; set; }
        public virtual ICollection<AppStudentAttendance> AppStudentAttendanceUserCreateds { get; set; }
        public virtual ICollection<AppStudentAttendance> AppStudentAttendanceUserUpdateds { get; set; }
        public virtual ICollection<AppStudentDailySchedule> AppStudentDailyScheduleUserCreateds { get; set; }
        public virtual ICollection<AppStudentDailySchedule> AppStudentDailyScheduleUserUpdateds { get; set; }
        public virtual ICollection<AppStudentPerGroup> AppStudentPerGroupUserCreateds { get; set; }
        public virtual ICollection<AppStudentPerGroup> AppStudentPerGroupUserUpdateds { get; set; }
        public virtual ICollection<AppStudentPerYearbook> AppStudentPerYearbookUserCreateds { get; set; }
        public virtual ICollection<AppStudentPerYearbook> AppStudentPerYearbookUserUpdateds { get; set; }
        public virtual ICollection<AppStudent> AppStudentUserCreateds { get; set; }
        public virtual ICollection<AppStudent> AppStudentUserUpdateds { get; set; }
        public virtual ICollection<AppStudentsPerCourse> AppStudentsPerCourseUserCreateds { get; set; }
        public virtual ICollection<AppStudentsPerCourse> AppStudentsPerCourseUserUpdateds { get; set; }
        public virtual ICollection<AppTask> AppTaskCoordinators { get; set; }
        public virtual ICollection<AppTaskExsist> AppTaskExsistCoordinators { get; set; }
        public virtual ICollection<AppTaskExsist> AppTaskExsistUserCreateds { get; set; }
        public virtual ICollection<AppTaskExsist> AppTaskExsistUserUpdateds { get; set; }
        public virtual ICollection<AppTaskToStudent> AppTaskToStudentReceivePayments { get; set; }
        public virtual ICollection<AppTaskToStudent> AppTaskToStudentUserCreateds { get; set; }
        public virtual ICollection<AppTaskToStudent> AppTaskToStudentUserUpdateds { get; set; }
        public virtual ICollection<AppTask> AppTaskUserCreateds { get; set; }
        public virtual ICollection<AppTask> AppTaskUserUpdateds { get; set; }
        public virtual ICollection<AppUniqueCode> AppUniqueCodeUserCreateds { get; set; }
        public virtual ICollection<AppUniqueCode> AppUniqueCodeUserUpdateds { get; set; }
        public virtual ICollection<AppUserPerCourse> AppUserPerCourseUserCreateds { get; set; }
        public virtual ICollection<AppUserPerCourse> AppUserPerCourseUserUpdateds { get; set; }
        public virtual ICollection<AppUserPerCourse> AppUserPerCourseUsers { get; set; }
        public virtual ICollection<AppUserPerCustomer> AppUserPerCustomerUserCreateds { get; set; }
        public virtual ICollection<AppUserPerCustomer> AppUserPerCustomerUserUpdateds { get; set; }
        public virtual ICollection<AppUserPerGroup> AppUserPerGroupUserCreateds { get; set; }
        public virtual ICollection<AppUserPerGroup> AppUserPerGroupUserUpdateds { get; set; }
        public virtual ICollection<AppUserPerGroup> AppUserPerGroupUsers { get; set; }
        public virtual ICollection<AppUserPerYearbook> AppUserPerYearbookUserCreateds { get; set; }
        public virtual ICollection<AppUserPerYearbook> AppUserPerYearbookUserUpdateds { get; set; }
        public virtual ICollection<AppUserPerYearbook> AppUserPerYearbookUsers { get; set; }
        public virtual ICollection<AppUserPremission> AppUserPremissionUserCreateds { get; set; }
        public virtual ICollection<AppUserPremission> AppUserPremissionUserUpdateds { get; set; }
        public virtual ICollection<AppUserPremission> AppUserPremissionUsers { get; set; }
        public virtual ICollection<AppVoiceSpace> AppVoiceSpaceUserCreateds { get; set; }
        public virtual ICollection<AppVoiceSpace> AppVoiceSpaceUserUpdateds { get; set; }
        public virtual ICollection<AppYearbookPerSchool> AppYearbookPerSchoolUserCreateds { get; set; }
        public virtual ICollection<AppYearbookPerSchool> AppYearbookPerSchoolUserUpdateds { get; set; }
        public virtual ICollection<AppYearbook> AppYearbookUserCreateds { get; set; }
        public virtual ICollection<AppYearbook> AppYearbookUserUpdateds { get; set; }
        public virtual ICollection<AppUserPerSchool> InverseUserCreated { get; set; }
        public virtual ICollection<AppUserPerSchool> InverseUserUpdeted { get; set; }
        public virtual ICollection<SecUser> SecUserUserCreateds { get; set; }
        public virtual ICollection<SecUser> SecUserUserUpdateds { get; set; }
        public virtual ICollection<TabAttendanceMarking> TabAttendanceMarkingUserCreateds { get; set; }
        public virtual ICollection<TabAttendanceMarking> TabAttendanceMarkingUserUpdateds { get; set; }
        public virtual ICollection<TabRequiredDocumentPerCourse> TabRequiredDocumentPerCourseUserCreateds { get; set; }
        public virtual ICollection<TabRequiredDocumentPerCourse> TabRequiredDocumentPerCourseUserUpdateds { get; set; }
        public virtual ICollection<TabRequiredDocumentPerFatherCourse> TabRequiredDocumentPerFatherCourseUserCreateds { get; set; }
        public virtual ICollection<TabRequiredDocumentPerFatherCourse> TabRequiredDocumentPerFatherCourseUserUpdateds { get; set; }
        public virtual ICollection<TabRequiredDocumentPerGroup> TabRequiredDocumentPerGroupUserCreateds { get; set; }
        public virtual ICollection<TabRequiredDocumentPerGroup> TabRequiredDocumentPerGroupUserUpdateds { get; set; }
        public virtual ICollection<TabRequiredDocumentPerProfession> TabRequiredDocumentPerProfessionUserCreateds { get; set; }
        public virtual ICollection<TabRequiredDocumentPerProfession> TabRequiredDocumentPerProfessionUserUpdateds { get; set; }
        public virtual ICollection<TabRequiredDocumentPerSchool> TabRequiredDocumentPerSchoolUserCreateds { get; set; }
        public virtual ICollection<TabRequiredDocumentPerSchool> TabRequiredDocumentPerSchoolUserUpdateds { get; set; }
        public virtual ICollection<TabRequiredDocumentPerStudent> TabRequiredDocumentPerStudentUserCreateds { get; set; }
        public virtual ICollection<TabRequiredDocumentPerStudent> TabRequiredDocumentPerStudentUserUpdateds { get; set; }
        public virtual ICollection<TabRequiredDocumentPerTaskExsist> TabRequiredDocumentPerTaskExsistUserCreateds { get; set; }
        public virtual ICollection<TabRequiredDocumentPerTaskExsist> TabRequiredDocumentPerTaskExsistUserUpdateds { get; set; }
        public virtual ICollection<TabRequiredDocumentPerTask> TabRequiredDocumentPerTaskUserCreateds { get; set; }
        public virtual ICollection<TabRequiredDocumentPerTask> TabRequiredDocumentPerTaskUserUpdateds { get; set; }
        public virtual ICollection<TabRequiredDocumentPerUser> TabRequiredDocumentPerUserUserCreateds { get; set; }
        public virtual ICollection<TabRequiredDocumentPerUser> TabRequiredDocumentPerUserUserUpdateds { get; set; }
        public virtual ICollection<TabTaskExecutionStatus> TabTaskExecutionStatusUserCreateds { get; set; }
        public virtual ICollection<TabTaskExecutionStatus> TabTaskExecutionStatusUserUpdateds { get; set; }
        public virtual ICollection<TabTypeAttendanceMarking> TabTypeAttendanceMarkingUserCreateds { get; set; }
        public virtual ICollection<TabTypeAttendanceMarking> TabTypeAttendanceMarkingUserUpdateds { get; set; }
        public virtual ICollection<TabTypeGroup> TabTypeGroupUserCreateds { get; set; }
        public virtual ICollection<TabTypeGroup> TabTypeGroupUserUpdateds { get; set; }
        public virtual ICollection<TabTypeTask> TabTypeTaskUserCreateds { get; set; }
        public virtual ICollection<TabTypeTask> TabTypeTaskUserUpdateds { get; set; }
        public virtual ICollection<TabTypeUser> TabTypeUserUserCreateds { get; set; }
        public virtual ICollection<TabTypeUser> TabTypeUserUserUpdateds { get; set; }
    }
}
