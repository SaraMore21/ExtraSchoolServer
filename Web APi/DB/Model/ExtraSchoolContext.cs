using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DB.Model
{
    public partial class ExtraSchoolContext : DbContext
    {
        public ExtraSchoolContext()
        {
        }

        public ExtraSchoolContext(DbContextOptions<ExtraSchoolContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AppAddress> AppAddresses { get; set; }
        public virtual DbSet<AppAplication> AppAplications { get; set; }
        public virtual DbSet<AppAppeal> AppAppeals { get; set; }
        public virtual DbSet<AppAttendanceHistory> AppAttendanceHistories { get; set; }
        public virtual DbSet<AppAttendant> AppAttendants { get; set; }
        public virtual DbSet<AppBirth> AppBirths { get; set; }
        public virtual DbSet<AppBuildingCurriculum> AppBuildingCurricula { get; set; }
        public virtual DbSet<AppBuildingCurriculumContent> AppBuildingCurriculumContents { get; set; }
        public virtual DbSet<AppBuildingCurriculumCourse> AppBuildingCurriculumCourses { get; set; }
        public virtual DbSet<AppBuildingCurriculumDay> AppBuildingCurriculumDays { get; set; }
        public virtual DbSet<AppBuildingCurriculumPurposeStudy> AppBuildingCurriculumPurposeStudies { get; set; }
        public virtual DbSet<AppBuildingCurriculumRestriction> AppBuildingCurriculumRestrictions { get; set; }
        public virtual DbSet<AppBuildingCurriculumStudent> AppBuildingCurriculumStudents { get; set; }
        public virtual DbSet<AppBuildingCurriculumTime> AppBuildingCurriculumTimes { get; set; }
        public virtual DbSet<AppBuildingCurriculumTypeLearn> AppBuildingCurriculumTypeLearns { get; set; }
        public virtual DbSet<AppContact> AppContacts { get; set; }
        public virtual DbSet<AppContactInformation> AppContactInformations { get; set; }
        public virtual DbSet<AppContactPerStudent> AppContactPerStudents { get; set; }
        public virtual DbSet<AppCoordination> AppCoordinations { get; set; }
        public virtual DbSet<AppCoordinationPerSchool> AppCoordinationPerSchools { get; set; }
        public virtual DbSet<AppCoordinationType> AppCoordinationTypes { get; set; }
        public virtual DbSet<AppCourse> AppCourses { get; set; }
        public virtual DbSet<AppCourseAssignment> AppCourseAssignments { get; set; }
        public virtual DbSet<AppCourseConditionRestriction> AppCourseConditionRestrictions { get; set; }
        public virtual DbSet<AppCourseRequirment> AppCourseRequirments { get; set; }
        public virtual DbSet<AppCourseRestriction> AppCourseRestrictions { get; set; }
        public virtual DbSet<AppCustomer> AppCustomers { get; set; }
        public virtual DbSet<AppDailySchedule> AppDailySchedules { get; set; }
        public virtual DbSet<AppDocumentPerCourse> AppDocumentPerCourses { get; set; }
        public virtual DbSet<AppDocumentPerFatherCourse> AppDocumentPerFatherCourses { get; set; }
        public virtual DbSet<AppDocumentPerGroup> AppDocumentPerGroups { get; set; }
        public virtual DbSet<AppDocumentPerProfession> AppDocumentPerProfessions { get; set; }
        public virtual DbSet<AppDocumentPerSchool> AppDocumentPerSchools { get; set; }
        public virtual DbSet<AppDocumentPerStudent> AppDocumentPerStudents { get; set; }
        public virtual DbSet<AppDocumentPerTask> AppDocumentPerTasks { get; set; }
        public virtual DbSet<AppDocumentPerTaskExsist> AppDocumentPerTaskExsists { get; set; }
        public virtual DbSet<AppDocumentPerUser> AppDocumentPerUsers { get; set; }
        public virtual DbSet<AppDraftBuildingCurriculumStudent> AppDraftBuildingCurriculumStudents { get; set; }
        public virtual DbSet<AppDynamicDetailsPerTypeSchool> AppDynamicDetailsPerTypeSchools { get; set; }
        public virtual DbSet<AppDynamicDetailsSchoolPerStudent> AppDynamicDetailsSchoolPerStudents { get; set; }
        public virtual DbSet<AppEasementPerStandard> AppEasementPerStandards { get; set; }
        public virtual DbSet<AppEasementPerTestOfStudent> AppEasementPerTestOfStudents { get; set; }
        public virtual DbSet<AppExcelToDownload> AppExcelToDownloads { get; set; }
        public virtual DbSet<AppExsistDocument> AppExsistDocuments { get; set; }
        public virtual DbSet<AppFolder> AppFolders { get; set; }
        public virtual DbSet<AppGroup> AppGroups { get; set; }
        public virtual DbSet<AppGroupPerYearbook> AppGroupPerYearbooks { get; set; }
        public virtual DbSet<AppGroupSemesterPerCourse> AppGroupSemesterPerCourses { get; set; }
        public virtual DbSet<AppLecturerPerCourse> AppLecturerPerCourses { get; set; }
        public virtual DbSet<AppLessonPerGroup> AppLessonPerGroups { get; set; }
        public virtual DbSet<AppLocation> AppLocations { get; set; }
        public virtual DbSet<AppMeetingTime> AppMeetingTimes { get; set; }
        public virtual DbSet<AppNote> AppNotes { get; set; }
        public virtual DbSet<AppPresence> AppPresences { get; set; }
        public virtual DbSet<AppProfession> AppProfessions { get; set; }
        public virtual DbSet<AppQuestionsOfTask> AppQuestionsOfTasks { get; set; }
        public virtual DbSet<AppScheduleRegular> AppScheduleRegulars { get; set; }
        public virtual DbSet<AppSchool> AppSchools { get; set; }
        public virtual DbSet<AppScoreStudentPerQuestionsOfTask> AppScoreStudentPerQuestionsOfTasks { get; set; }
        public virtual DbSet<AppSemester> AppSemesters { get; set; }
        public virtual DbSet<AppStandardPerStudent> AppStandardPerStudents { get; set; }
        public virtual DbSet<AppStatusStudentPerGroup> AppStatusStudentPerGroups { get; set; }
        public virtual DbSet<AppStudent> AppStudents { get; set; }
        public virtual DbSet<AppStudentAssingment> AppStudentAssingments { get; set; }
        public virtual DbSet<AppStudentAttendance> AppStudentAttendances { get; set; }
        public virtual DbSet<AppStudentDailySchedule> AppStudentDailySchedules { get; set; }
        public virtual DbSet<AppStudentPerGroup> AppStudentPerGroups { get; set; }
        public virtual DbSet<AppStudentPerYearbook> AppStudentPerYearbooks { get; set; }
        public virtual DbSet<AppTask> AppTasks { get; set; }
        public virtual DbSet<AppTaskExsist> AppTaskExsists { get; set; }
        public virtual DbSet<AppTaskToStudent> AppTaskToStudents { get; set; }
        public virtual DbSet<AppUniqueCode> AppUniqueCodes { get; set; }
        public virtual DbSet<AppUserPerCourse> AppUserPerCourses { get; set; }
        public virtual DbSet<AppUserPerCustomer> AppUserPerCustomers { get; set; }
        public virtual DbSet<AppUserPerGroup> AppUserPerGroups { get; set; }
        public virtual DbSet<AppUserPerSchool> AppUserPerSchools { get; set; }
        public virtual DbSet<AppUserPerYearbook> AppUserPerYearbooks { get; set; }
        public virtual DbSet<AppUserPremission> AppUserPremissions { get; set; }
        public virtual DbSet<AppVoiceSpace> AppVoiceSpaces { get; set; }
        public virtual DbSet<AppYearbook> AppYearbooks { get; set; }
        public virtual DbSet<AppYearbookPerSchool> AppYearbookPerSchools { get; set; }
        public virtual DbSet<CheckType> CheckTypes { get; set; }
        public virtual DbSet<Field> Fields { get; set; }
        public virtual DbSet<SecUser> SecUsers { get; set; }
        public virtual DbSet<TCategory> TCategories { get; set; }
        public virtual DbSet<TCheckType> TCheckTypes { get; set; }
        public virtual DbSet<TCourseField> TCourseFields { get; set; }
        public virtual DbSet<TDynamicDetailsForTypeSchool> TDynamicDetailsForTypeSchools { get; set; }
        public virtual DbSet<TEasement> TEasements { get; set; }
        public virtual DbSet<TGender> TGenders { get; set; }
        public virtual DbSet<TLearningStyle> TLearningStyles { get; set; }
        public virtual DbSet<TPaymentMethod> TPaymentMethods { get; set; }
        public virtual DbSet<TPaymentStatus> TPaymentStatuses { get; set; }
        public virtual DbSet<TReasonForLeaving> TReasonForLeavings { get; set; }
        public virtual DbSet<TRestrictionType> TRestrictionTypes { get; set; }
        public virtual DbSet<TSchoolType> TSchoolTypes { get; set; }
        public virtual DbSet<TStandard> TStandards { get; set; }
        public virtual DbSet<TStatus> TStatuses { get; set; }
        public virtual DbSet<TStatusAplication> TStatusAplications { get; set; }
        public virtual DbSet<TStatusAppel> TStatusAppels { get; set; }
        public virtual DbSet<TStatusStudent> TStatusStudents { get; set; }
        public virtual DbSet<TStatusTaskPerformance> TStatusTaskPerformances { get; set; }
        public virtual DbSet<TTypeAssingment> TTypeAssingments { get; set; }
        public virtual DbSet<TTypeContact> TTypeContacts { get; set; }
        public virtual DbSet<TTypeDeadLine> TTypeDeadLines { get; set; }
        public virtual DbSet<TTypeIdentity> TTypeIdentities { get; set; }
        public virtual DbSet<TTypePresence> TTypePresences { get; set; }
        public virtual DbSet<TTypeYear> TTypeYears { get; set; }
        public virtual DbSet<TabAgeGroup> TabAgeGroups { get; set; }
        public virtual DbSet<TabAttendanceMarking> TabAttendanceMarkings { get; set; }
        public virtual DbSet<TabCitizenship> TabCitizenships { get; set; }
        public virtual DbSet<TabCity> TabCities { get; set; }
        public virtual DbSet<TabCountry> TabCountries { get; set; }
        public virtual DbSet<TabDegree> TabDegrees { get; set; }
        public virtual DbSet<TabExecutionTypeOfTask> TabExecutionTypeOfTasks { get; set; }
        public virtual DbSet<TabListeningTime> TabListeningTimes { get; set; }
        public virtual DbSet<TabNeighborhood> TabNeighborhoods { get; set; }
        public virtual DbSet<TabProfessionCategory> TabProfessionCategories { get; set; }
        public virtual DbSet<TabRequiredDocumentPerCourse> TabRequiredDocumentPerCourses { get; set; }
        public virtual DbSet<TabRequiredDocumentPerFatherCourse> TabRequiredDocumentPerFatherCourses { get; set; }
        public virtual DbSet<TabRequiredDocumentPerGroup> TabRequiredDocumentPerGroups { get; set; }
        public virtual DbSet<TabRequiredDocumentPerProfession> TabRequiredDocumentPerProfessions { get; set; }
        public virtual DbSet<TabRequiredDocumentPerSchool> TabRequiredDocumentPerSchools { get; set; }
        public virtual DbSet<TabRequiredDocumentPerStudent> TabRequiredDocumentPerStudents { get; set; }
        public virtual DbSet<TabRequiredDocumentPerTask> TabRequiredDocumentPerTasks { get; set; }
        public virtual DbSet<TabRequiredDocumentPerTaskExsist> TabRequiredDocumentPerTaskExsists { get; set; }
        public virtual DbSet<TabRequiredDocumentPerUser> TabRequiredDocumentPerUsers { get; set; }
        public virtual DbSet<TabStreet> TabStreets { get; set; }
        public virtual DbSet<TabTaskExecutionStatus> TabTaskExecutionStatuses { get; set; }
        public virtual DbSet<TabTypeAttendanceMarking> TabTypeAttendanceMarkings { get; set; }
        public virtual DbSet<TabTypeGroup> TabTypeGroups { get; set; }
        public virtual DbSet<TabTypeOfTaskCalculation> TabTypeOfTaskCalculations { get; set; }
        public virtual DbSet<TabTypeQuestion> TabTypeQuestions { get; set; }
        public virtual DbSet<TabTypeTask> TabTypeTasks { get; set; }
        public virtual DbSet<TabTypeUser> TabTypeUsers { get; set; }
        public virtual DbSet<VCodeTable> VCodeTables { get; set; }
        public virtual DbSet<ארצות> ארצותs { get; set; }
        public virtual DbSet<גיליון1> גיליון1s { get; set; }
        public virtual DbSet<גיליון3> גיליון3s { get; set; }
        public virtual DbSet<יחי> יחיs { get; set; }
        public virtual DbSet<ישובים> ישוביםs { get; set; }
        public virtual DbSet<משתמשים> משתמשיםs { get; set; }
        public virtual DbSet<רחובות> רחובותs { get; set; }
        public virtual DbSet<תלמידות> תלמידותs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=ravcevel.database.windows.net;Database=ExtraSchool;persist security info=True;user id=voicesystem;password=Sari-30020010;multipleactiveresultsets=True; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AppAddress>(entity =>
            {
                entity.HasKey(e => e.Idaddress)
                    .HasName("PK__APP_Addr__091C2AFB303BED31");

                entity.ToTable("APP_Address");

                entity.Property(e => e.Idaddress).HasColumnName("IDAddress");

                entity.Property(e => e.ApartmentNumber).HasMaxLength(10);

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.Comment).HasMaxLength(250);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime");

                entity.Property(e => e.HouseNumber).HasMaxLength(10);

                entity.Property(e => e.NeighborhoodId).HasColumnName("NeighborhoodID");

                entity.Property(e => e.StreetId).HasColumnName("StreetID");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.AppAddresses)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_APP_Address_TAB_City");

                entity.HasOne(d => d.Neighborhood)
                    .WithMany(p => p.AppAddresses)
                    .HasForeignKey(d => d.NeighborhoodId)
                    .HasConstraintName("FK_APP_Address_TAB_Neighborhood");

                entity.HasOne(d => d.Street)
                    .WithMany(p => p.AppAddresses)
                    .HasForeignKey(d => d.StreetId)
                    .HasConstraintName("FK_APP_Address_TAB_Street");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.AppAddressUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_UserCreated");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.AppAddressUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_UserUpdated");
            });

            modelBuilder.Entity<AppAplication>(entity =>
            {
                entity.HasKey(e => e.Idaplication);

                entity.ToTable("APP_Aplication");

                entity.Property(e => e.Idaplication).HasColumnName("IDAplication");

                entity.Property(e => e.AttendantId).HasColumnName("AttendantID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdate).HasColumnType("date");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.Attendant)
                    .WithMany(p => p.AppAplications)
                    .HasForeignKey(d => d.AttendantId)
                    .HasConstraintName("FK_APP_Aplication_APP_Attendant");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.AppAplications)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Aplication_Category");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.AppAplications)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_APP_Aplication_T_StatusAplication");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.AppAplications)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_APP_Aplication_APP_Student");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.AppAplicationUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_UserCreated_Aplication");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.AppAplicationUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_UserUpdated_Aplication");
            });

            modelBuilder.Entity<AppAppeal>(entity =>
            {
                entity.HasKey(e => e.Idappeal)
                    .HasName("PK_APP_Appel");

                entity.ToTable("APP_Appeal");

                entity.Property(e => e.Idappeal).HasColumnName("IDAppeal");

                entity.Property(e => e.DateCreate).HasColumnType("date");

                entity.Property(e => e.DateUpdate).HasColumnType("date");

                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.Property(e => e.SchoolId).HasColumnName("SchoolID");

                entity.Property(e => e.StatusAppealId).HasColumnName("StatusAppealID");

                entity.Property(e => e.StudentAssingmentId).HasColumnName("StudentAssingmentID");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.AppAppeals)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK_APP_Appel_APP_School");

                entity.HasOne(d => d.StatusAppeal)
                    .WithMany(p => p.AppAppeals)
                    .HasForeignKey(d => d.StatusAppealId)
                    .HasConstraintName("FK_APP_Appel_T_StatusAppel");

                entity.HasOne(d => d.StudentAssingment)
                    .WithMany(p => p.AppAppeals)
                    .HasForeignKey(d => d.StudentAssingmentId)
                    .HasConstraintName("FK_APP_Appel_APP_StudentAssingment");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.AppAppealUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_APP_Appeal_UserPerSchool1");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.AppAppealUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_APP_Appeal_UserPerSchool2");
            });

            modelBuilder.Entity<AppAttendanceHistory>(entity =>
            {
                entity.HasKey(e => e.IdattendanceHistory)
                    .HasName("PK__APP_Atte__9EDA154A87E4437A");

                entity.ToTable("APP_AttendanceHistory");

                entity.Property(e => e.IdattendanceHistory).HasColumnName("IDAttendanceHistory");

                entity.Property(e => e.AttendanceId).HasColumnName("AttendanceID");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.Property(e => e.StudentAttendanceId).HasColumnName("StudentAttendanceID");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.Attendance)
                    .WithMany(p => p.AppAttendanceHistories)
                    .HasForeignKey(d => d.AttendanceId)
                    .HasConstraintName("FK_AttendanceHistory_AttendanceMarkings");

                entity.HasOne(d => d.StudentAttendance)
                    .WithMany(p => p.AppAttendanceHistories)
                    .HasForeignKey(d => d.StudentAttendanceId)
                    .HasConstraintName("FK_AttendanceHistory_StudentAttendance");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.AppAttendanceHistoryUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_AttendanceHistory_UserCreated");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.AppAttendanceHistoryUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_AttendanceHistory_UserUpdated");
            });

            modelBuilder.Entity<AppAttendant>(entity =>
            {
                entity.HasKey(e => e.Idattendant);

                entity.ToTable("APP_Attendant");

                entity.Property(e => e.Idattendant).HasColumnName("IDAttendant");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdate).HasColumnType("date");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdateId).HasColumnName("UserUpdateID");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.AppAttendantUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_APP_Attendant_UserPerSchool");

                entity.HasOne(d => d.UserUpdate)
                    .WithMany(p => p.AppAttendantUserUpdates)
                    .HasForeignKey(d => d.UserUpdateId)
                    .HasConstraintName("FK_APP_Attendant_UserPerSchool1");
            });

            modelBuilder.Entity<AppBirth>(entity =>
            {
                entity.HasKey(e => e.Idbirth);

                entity.ToTable("APP_Birth");

                entity.Property(e => e.Idbirth).HasColumnName("IDBirth");

                entity.Property(e => e.BirthCountryId).HasColumnName("BirthCountryID");

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.BirthHebrewDate).HasMaxLength(50);

                entity.Property(e => e.CitizenshipId).HasColumnName("CitizenshipID");

                entity.Property(e => e.CountryIdofImmigration).HasColumnName("CountryIDOfImmigration");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateOfImmigration).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.BirthCountry)
                    .WithMany(p => p.AppBirthBirthCountries)
                    .HasForeignKey(d => d.BirthCountryId)
                    .HasConstraintName("FK_APP_Birth_TAB_Country");

                entity.HasOne(d => d.Citizenship)
                    .WithMany(p => p.AppBirthCitizenships)
                    .HasForeignKey(d => d.CitizenshipId)
                    .HasConstraintName("FK_APP_Birth_TAB_Country2");

                entity.HasOne(d => d.CountryIdofImmigrationNavigation)
                    .WithMany(p => p.AppBirthCountryIdofImmigrationNavigations)
                    .HasForeignKey(d => d.CountryIdofImmigration)
                    .HasConstraintName("FK_APP_Birth_TAB_Country3");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.AppBirthUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_APP_Birth_UserPerSchool");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.AppBirthUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_APP_Birth_UserPerSchool1");
            });

            modelBuilder.Entity<AppBuildingCurriculum>(entity =>
            {
                entity.HasKey(e => e.BuildingCurriculumId);

                entity.ToTable("APP_BuildingCurriculum", "Curr");

                entity.HasIndex(e => e.LocationId, "IX_APP_BuildingCurriculum_LocationID");

                entity.Property(e => e.BuildingCurriculumId).HasColumnName("BuildingCurriculumID");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.RoomId).HasColumnName("RoomID");

                entity.Property(e => e.SchoolId).HasColumnName("SchoolID");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.AppBuildingCurricula)
                    .HasForeignKey(d => d.LocationId);
            });

            modelBuilder.Entity<AppBuildingCurriculumContent>(entity =>
            {
                entity.HasKey(e => e.BuildingCurriculumContentsId);

                entity.ToTable("APP_BuildingCurriculumContents", "Curr");

                entity.HasIndex(e => e.AppBuildingCurriculumBuildingCurriculumId, "IX_APP_BuildingCurriculumContents_APP_BuildingCurriculumBuildingCurriculumID");

                entity.Property(e => e.BuildingCurriculumContentsId).HasColumnName("BuildingCurriculumContentsID");

                entity.Property(e => e.AppBuildingCurriculumBuildingCurriculumId).HasColumnName("APP_BuildingCurriculumBuildingCurriculumID");

                entity.Property(e => e.BuildingCurriculumId).HasColumnName("BuildingCurriculumID");

                entity.HasOne(d => d.AppBuildingCurriculumBuildingCurriculum)
                    .WithMany(p => p.AppBuildingCurriculumContents)
                    .HasForeignKey(d => d.AppBuildingCurriculumBuildingCurriculumId);
            });

            modelBuilder.Entity<AppBuildingCurriculumCourse>(entity =>
            {
                entity.HasKey(e => e.BuildingCurriculumCourseId);

                entity.ToTable("APP_BuildingCurriculumCourse", "Curr");

                entity.Property(e => e.BuildingCurriculumCourseId).HasColumnName("BuildingCurriculumCourseID");

                entity.Property(e => e.BuildingCurriculumId).HasColumnName("BuildingCurriculumID");

                entity.Property(e => e.GroupSemesterPerCourseId).HasColumnName("GroupSemesterPerCourseID");
            });

            modelBuilder.Entity<AppBuildingCurriculumDay>(entity =>
            {
                entity.HasKey(e => e.BuildingCurriculumDayId);

                entity.ToTable("APP_BuildingCurriculumDay", "Curr");

                entity.HasIndex(e => e.AppBuildingCurriculumBuildingCurriculumId, "IX_APP_BuildingCurriculumDay_APP_BuildingCurriculumBuildingCurriculumID");

                entity.Property(e => e.BuildingCurriculumDayId).HasColumnName("BuildingCurriculumDayID");

                entity.Property(e => e.AppBuildingCurriculumBuildingCurriculumId).HasColumnName("APP_BuildingCurriculumBuildingCurriculumID");

                entity.Property(e => e.BuildingCurriculumId).HasColumnName("BuildingCurriculumID");

                entity.Property(e => e.DayId).HasColumnName("DayID");

                entity.HasOne(d => d.AppBuildingCurriculumBuildingCurriculum)
                    .WithMany(p => p.AppBuildingCurriculumDays)
                    .HasForeignKey(d => d.AppBuildingCurriculumBuildingCurriculumId);
            });

            modelBuilder.Entity<AppBuildingCurriculumPurposeStudy>(entity =>
            {
                entity.HasKey(e => e.BuildingCurriculumPurposeStudiesId);

                entity.ToTable("APP_BuildingCurriculumPurposeStudies", "Curr");

                entity.HasIndex(e => e.AppBuildingCurriculumBuildingCurriculumId, "IX_APP_BuildingCurriculumPurposeStudies_APP_BuildingCurriculumBuildingCurriculumID");

                entity.Property(e => e.BuildingCurriculumPurposeStudiesId).HasColumnName("BuildingCurriculumPurposeStudiesID");

                entity.Property(e => e.AppBuildingCurriculumBuildingCurriculumId).HasColumnName("APP_BuildingCurriculumBuildingCurriculumID");

                entity.HasOne(d => d.AppBuildingCurriculumBuildingCurriculum)
                    .WithMany(p => p.AppBuildingCurriculumPurposeStudies)
                    .HasForeignKey(d => d.AppBuildingCurriculumBuildingCurriculumId);
            });

            modelBuilder.Entity<AppBuildingCurriculumRestriction>(entity =>
            {
                entity.HasKey(e => e.BuildingCurriculumRestrictionsId);

                entity.ToTable("APP_BuildingCurriculumRestrictions", "Curr");

                entity.Property(e => e.BuildingCurriculumRestrictionsId).HasColumnName("BuildingCurriculumRestrictionsID");

                entity.Property(e => e.BiggerThan).HasColumnName("Bigger_than");

                entity.Property(e => e.BuildingCurriculumId).HasColumnName("BuildingCurriculumID");

                entity.Property(e => e.FieldId).HasColumnName("FieldID");

                entity.Property(e => e.SmallerThan).HasColumnName("Smaller_than");
            });

            modelBuilder.Entity<AppBuildingCurriculumStudent>(entity =>
            {
                entity.HasKey(e => e.BuildingCurriculumStudentId);

                entity.ToTable("APP_BuildingCurriculumStudent", "Curr");

                entity.Property(e => e.BuildingCurriculumId).HasColumnName("BuildingCurriculumID");

                entity.Property(e => e.GroupSemesterPerCourseId).HasColumnName("GroupSemesterPerCourseID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");
            });

            modelBuilder.Entity<AppBuildingCurriculumTime>(entity =>
            {
                entity.HasKey(e => e.BuildingCurriculumTimeId);

                entity.ToTable("APP_BuildingCurriculumTime", "Curr");

                entity.HasIndex(e => e.AppBuildingCurriculumBuildingCurriculumId, "IX_APP_BuildingCurriculumTime_APP_BuildingCurriculumBuildingCurriculumID");

                entity.Property(e => e.BuildingCurriculumTimeId).HasColumnName("BuildingCurriculumTimeID");

                entity.Property(e => e.AppBuildingCurriculumBuildingCurriculumId).HasColumnName("APP_BuildingCurriculumBuildingCurriculumID");

                entity.Property(e => e.BuildingCurriculumId).HasColumnName("BuildingCurriculumID");

                entity.HasOne(d => d.AppBuildingCurriculumBuildingCurriculum)
                    .WithMany(p => p.AppBuildingCurriculumTimes)
                    .HasForeignKey(d => d.AppBuildingCurriculumBuildingCurriculumId);
            });

            modelBuilder.Entity<AppBuildingCurriculumTypeLearn>(entity =>
            {
                entity.HasKey(e => e.BuildingCurriculumTypeLearnId);

                entity.ToTable("APP_BuildingCurriculumTypeLearn", "Curr");

                entity.HasIndex(e => e.AppBuildingCurriculumBuildingCurriculumId, "IX_APP_BuildingCurriculumTypeLearn_APP_BuildingCurriculumBuildingCurriculumID");

                entity.Property(e => e.BuildingCurriculumTypeLearnId).HasColumnName("BuildingCurriculumTypeLearnID");

                entity.Property(e => e.AppBuildingCurriculumBuildingCurriculumId).HasColumnName("APP_BuildingCurriculumBuildingCurriculumID");

                entity.Property(e => e.BuildingCurriculumId).HasColumnName("BuildingCurriculumID");

                entity.HasOne(d => d.AppBuildingCurriculumBuildingCurriculum)
                    .WithMany(p => p.AppBuildingCurriculumTypeLearns)
                    .HasForeignKey(d => d.AppBuildingCurriculumBuildingCurriculumId);
            });

            modelBuilder.Entity<AppContact>(entity =>
            {
                entity.HasKey(e => e.Idcontact)
                    .HasName("PK__APP_Cont__5C66259B71B74601");

                entity.ToTable("APP_Contact");

                entity.Property(e => e.Idcontact).HasColumnName("IDContact");

                entity.Property(e => e.ContactInformationId).HasColumnName("ContactInformationID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime");

                entity.Property(e => e.FirstName).HasMaxLength(30);

                entity.Property(e => e.LastName).HasMaxLength(30);

                entity.Property(e => e.TypeIdentityId).HasColumnName("TypeIdentityID");

                entity.Property(e => e.Tz)
                    .HasMaxLength(20)
                    .HasColumnName("TZ");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.ContactInformation)
                    .WithMany(p => p.AppContacts)
                    .HasForeignKey(d => d.ContactInformationId)
                    .HasConstraintName("FK_APP_Contact_APP_ContactInformation");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.AppContacts)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK_APP_Contact_School");

                entity.HasOne(d => d.TypeIdentity)
                    .WithMany(p => p.AppContacts)
                    .HasForeignKey(d => d.TypeIdentityId)
                    .HasConstraintName("FK_APP_Contact_TypeIdentity");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.AppContactUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_APP_Contact_UserPerSchool");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.AppContactUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_APP_Contact_UserPerSchool1");
            });

            modelBuilder.Entity<AppContactInformation>(entity =>
            {
                entity.HasKey(e => e.IdcontactInformation)
                    .HasName("PK__APP_Cont__EB5E17DFB591A66F");

                entity.ToTable("APP_ContactInformation");

                entity.Property(e => e.IdcontactInformation).HasColumnName("IDContactInformation");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.Comment).HasMaxLength(250);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FaxNumber).HasMaxLength(30);

                entity.Property(e => e.IsMobile)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Job).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber1).HasMaxLength(20);

                entity.Property(e => e.PhoneNumber2).HasMaxLength(20);

                entity.Property(e => e.PhoneNumber3).HasMaxLength(20);

                entity.Property(e => e.TelephoneNumber1).HasMaxLength(20);

                entity.Property(e => e.TelephoneNumber2).HasMaxLength(20);

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.AppContactInformations)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK_APP_ContactInformation_Address");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.AppContactInformationUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_APP_ContactInformation_UserPerSchool");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.AppContactInformationUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_APP_ContactInformation_UserPerSchool1");
            });

            modelBuilder.Entity<AppContactPerStudent>(entity =>
            {
                entity.HasKey(e => e.IdcontactPerStudent);

                entity.ToTable("APP_ContactPerStudent");

                entity.Property(e => e.IdcontactPerStudent).HasColumnName("IDContactPerStudent");

                entity.Property(e => e.ContactId).HasColumnName("ContactID");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.TypeContactId).HasColumnName("TypeContactID");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.AppContactPerStudents)
                    .HasForeignKey(d => d.ContactId)
                    .HasConstraintName("FK_APP_ContactPerStudent_Contact");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.AppContactPerStudents)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_APP_ContactPerStudent_APP_Student");

                entity.HasOne(d => d.TypeContact)
                    .WithMany(p => p.AppContactPerStudents)
                    .HasForeignKey(d => d.TypeContactId)
                    .HasConstraintName("FK_APP_ContactPerStudent_T_TypeContact");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.AppContactPerStudentUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_UserCreated_ContactPerStudent");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.AppContactPerStudentUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_UserUpdated_ContactPerStudent");
            });

            modelBuilder.Entity<AppCoordination>(entity =>
            {
                entity.HasKey(e => e.CoordinationId);

                entity.ToTable("App_Coordination");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");
            });

            modelBuilder.Entity<AppCoordinationPerSchool>(entity =>
            {
                entity.HasKey(e => e.IdcoordinationPerSchool);

                entity.ToTable("App_CoordinationPerSchool");

                entity.Property(e => e.IdcoordinationPerSchool).HasColumnName("IDCoordinationPerSchool");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.HasOne(d => d.Coordination)
                    .WithMany(p => p.AppCoordinationPerSchools)
                    .HasForeignKey(d => d.CoordinationId)
                    .HasConstraintName("FK_App_CoordinationPerSchool_App_Coordination");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.AppCoordinationPerSchools)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK_App_CoordinationPerSchool_APP_School");
            });

            modelBuilder.Entity<AppCoordinationType>(entity =>
            {
                entity.HasKey(e => e.IdCoordinationType);

                entity.ToTable("App_CoordinationType");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.HasOne(d => d.IdCoordinationPerSchoolNavigation)
                    .WithMany(p => p.AppCoordinationTypes)
                    .HasForeignKey(d => d.IdCoordinationPerSchool)
                    .HasConstraintName("FK_App_CoordinationType_App_CoordinationPerSchool");
            });

            modelBuilder.Entity<AppCourse>(entity =>
            {
                entity.HasKey(e => e.Idcourse)
                    .HasName("PK_Course");

                entity.ToTable("APP_Course");

                entity.Property(e => e.Idcourse).HasColumnName("IDCourse");

                entity.Property(e => e.AssociateAcademicDegree).HasDefaultValueSql("(CONVERT([smallint],(0)))");

                entity.Property(e => e.BuildingCurriculumContentsId).HasColumnName("BuildingCurriculumContentsID");

                entity.Property(e => e.Code).HasMaxLength(200);

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.DateCreate).HasColumnType("date");

                entity.Property(e => e.DateUpdate).HasColumnType("date");

                entity.Property(e => e.EducatEnglishLevelRequired).HasDefaultValueSql("(CONVERT([smallint],(0)))");

                entity.Property(e => e.Education).HasDefaultValueSql("(CONVERT([smallint],(0)))");

                entity.Property(e => e.EndDate).HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");

                entity.Property(e => e.FetalAttendancePercentage).HasDefaultValueSql("(CONVERT([smallint],(0)))");

                entity.Property(e => e.FinalGradeEducation).HasDefaultValueSql("(CONVERT([smallint],(0)))");

                entity.Property(e => e.HebrewLevelRequired).HasDefaultValueSql("(CONVERT([smallint],(0)))");

                entity.Property(e => e.LearningPoints).HasDefaultValueSql("(CONVERT([smallint],(0)))");

                entity.Property(e => e.LearningStyleId).HasColumnName("LearningStyleID");

                entity.Property(e => e.Money).HasDefaultValueSql("(CONVERT([smallint],(0)))");

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.NoObligationAttend)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.OpeningConditionalOnNumberOfRegistrants)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.OrganizationalAffiliation).HasDefaultValueSql("(CONVERT([smallint],(0)))");

                entity.Property(e => e.PassingGradeGivesAlevelOfHebrew)
                    .HasColumnName("PassingGradeGivesALevelOfHebrew")
                    .HasDefaultValueSql("(CONVERT([smallint],(0)))");

                entity.Property(e => e.ProfessionId).HasColumnName("ProfessionID");

                entity.Property(e => e.SchoolId).HasColumnName("SchoolID");

                entity.Property(e => e.Season).HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");

                entity.Property(e => e.StartDate).HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");

                entity.Property(e => e.SubjectFurtherEducation).HasDefaultValueSql("(CONVERT([smallint],(0)))");

                entity.Property(e => e.UniqueCodeId).HasColumnName("UniqueCodeID");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.Property(e => e.YearbookId).HasColumnName("YearbookID");

                entity.HasOne(d => d.CoordinationType)
                    .WithMany(p => p.AppCourses)
                    .HasForeignKey(d => d.CoordinationTypeId)
                    .HasConstraintName("FK_APP_Course_App_CoordinationType");

                entity.HasOne(d => d.LearningStyle)
                    .WithMany(p => p.AppCourses)
                    .HasForeignKey(d => d.LearningStyleId)
                    .HasConstraintName("FK_APP_Course_T_LearningStyle");

                entity.HasOne(d => d.Profession)
                    .WithMany(p => p.AppCourses)
                    .HasForeignKey(d => d.ProfessionId)
                    .HasConstraintName("FK_APP_Course_APP_Profession");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.AppCourses)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK_APP_Course_APP_School");

                entity.HasOne(d => d.UniqueCode)
                    .WithMany(p => p.AppCourses)
                    .HasForeignKey(d => d.UniqueCodeId)
                    .HasConstraintName("FK_APP_Course_APP_UniqueCodeToTask");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.AppCourseUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_APP_Course_UserPerSchool");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.AppCourseUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_APP_Course_UserPerSchool1");

                entity.HasOne(d => d.Yearbook)
                    .WithMany(p => p.AppCourses)
                    .HasForeignKey(d => d.YearbookId)
                    .HasConstraintName("FK_APP_Course_Yearbook");
            });

            modelBuilder.Entity<AppCourseAssignment>(entity =>
            {
                entity.HasKey(e => e.IdcourseAssignments);

                entity.ToTable("APP_CourseAssignments");

                entity.Property(e => e.IdcourseAssignments).HasColumnName("IDCourseAssignments");

                entity.Property(e => e.ActualDateSubmissionQuestionnaireToTheTeacher).HasColumnType("date");

                entity.Property(e => e.Adeadline)
                    .HasColumnType("date")
                    .HasColumnName("ADeadline");

                entity.Property(e => e.Bdeadline)
                    .HasColumnType("date")
                    .HasColumnName("BDeadline");

                entity.Property(e => e.Cdeadline)
                    .HasColumnType("date")
                    .HasColumnName("CDeadline");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateSubmissionQuestionnaireToTheTeacher).HasColumnType("date");

                entity.Property(e => e.DateUpdate).HasColumnType("date");

                entity.Property(e => e.SchoolId).HasColumnName("SchoolID");

                entity.Property(e => e.TypeAssignmentId).HasColumnName("TypeAssignmentID");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.AppCourseAssignments)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_APP_CourseAssignments_APP_Course");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.AppCourseAssignments)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK_APP_CourseAssignments_APP_School");

                entity.HasOne(d => d.TypeAssignment)
                    .WithMany(p => p.AppCourseAssignments)
                    .HasForeignKey(d => d.TypeAssignmentId)
                    .HasConstraintName("FK_APP_CourseAssignments_T_TypeAssingment");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.AppCourseAssignmentUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_APP_CourseAssignments_UserPerSchool");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.AppCourseAssignmentUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_APP_CourseAssignments_UserPerSchool1");
            });

            modelBuilder.Entity<AppCourseConditionRestriction>(entity =>
            {
                entity.HasKey(e => e.CourseRestrictionsId);

                entity.ToTable("APP_CourseConditionRestriction", "Curr");

                entity.Property(e => e.CourseRestrictionsId).HasColumnName("CourseRestrictionsID");

                entity.Property(e => e.ConditionId).HasColumnName("conditionID");

                entity.Property(e => e.CourseFieldId).HasColumnName("CourseFieldID");

                entity.Property(e => e.SchoolId).HasColumnName("schoolID");
            });

            modelBuilder.Entity<AppCourseRequirment>(entity =>
            {
                entity.HasKey(e => e.IdcourseRequirements)
                    .HasName("PK_APP+CourseRequirment");

                entity.ToTable("APP_CourseRequirment");

                entity.Property(e => e.IdcourseRequirements).HasColumnName("IDCourseRequirements");

                entity.Property(e => e.AssingmentId).HasColumnName("AssingmentID");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.CourseRequiredId).HasColumnName("CourseRequiredID");

                entity.Property(e => e.DateCreate).HasColumnType("date");

                entity.Property(e => e.DateUpdate).HasColumnType("date");

                entity.Property(e => e.SchoolId).HasColumnName("SchoolID");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.Property(e => e.YearBookPerSchoolId).HasColumnName("YearBookPerSchoolID");

                entity.HasOne(d => d.Assingment)
                    .WithMany(p => p.AppCourseRequirments)
                    .HasForeignKey(d => d.AssingmentId)
                    .HasConstraintName("FK_APP+CourseRequirment_APP_CourseAssignments");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.AppCourseRequirmentCourses)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_APP+CourseRequirment_APP_Course");

                entity.HasOne(d => d.CourseRequired)
                    .WithMany(p => p.AppCourseRequirmentCourseRequireds)
                    .HasForeignKey(d => d.CourseRequiredId)
                    .HasConstraintName("FK_APP+CourseRequirment_APP_Course1");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.AppCourseRequirments)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK_APP+CourseRequirment_APP_School");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.AppCourseRequirmentUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_APP_CourseRequirment_UserPerSchool1");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.AppCourseRequirmentUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_APP_CourseRequirment_UserPerSchool");

                entity.HasOne(d => d.YearBookPerSchool)
                    .WithMany(p => p.AppCourseRequirments)
                    .HasForeignKey(d => d.YearBookPerSchoolId)
                    .HasConstraintName("FK_APP_CourseRequirment_YearbookPerSchool");
            });

            modelBuilder.Entity<AppCourseRestriction>(entity =>
            {
                entity.HasKey(e => e.CourseRestrictionsId);

                entity.ToTable("APP_CourseRestrictions", "Curr");

                entity.Property(e => e.CourseRestrictionsId).HasColumnName("CourseRestrictionsID");

                entity.Property(e => e.ConditionId).HasColumnName("conditionID");

                entity.Property(e => e.SchoolId).HasColumnName("schoolID");
            });

            modelBuilder.Entity<AppCustomer>(entity =>
            {
                entity.HasKey(e => e.Idcustomer)
                    .HasName("PK_APP_Customers");

                entity.ToTable("APP_Customer");

                entity.Property(e => e.Idcustomer).HasColumnName("IDCustomer");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdate).HasColumnType("date");

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.AppCustomerUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_UserCreated_Customer");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.AppCustomerUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_UserUpdated_Customer");
            });

            modelBuilder.Entity<AppDailySchedule>(entity =>
            {
                entity.HasKey(e => e.IddailySchedule)
                    .HasName("PK__APP_Dail__BA060CF8E30784C6");

                entity.ToTable("APP_DailySchedule");

                entity.Property(e => e.IddailySchedule).HasColumnName("IDDailySchedule");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime");

                entity.Property(e => e.LearningStyleId).HasColumnName("LearningStyleID");

                entity.Property(e => e.ScheduleDate).HasColumnType("date");

                entity.Property(e => e.ScheduleRegularId).HasColumnName("ScheduleRegularID");

                entity.Property(e => e.SchoolId).HasColumnName("SchoolID");

                entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.AppDailySchedules)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_DailySchedule_GroupSemesterPerCourse");

                entity.HasOne(d => d.LearningStyle)
                    .WithMany(p => p.AppDailySchedules)
                    .HasForeignKey(d => d.LearningStyleId)
                    .HasConstraintName("FK_DailySchedule_LearningStyle");

                entity.HasOne(d => d.ScheduleRegular)
                    .WithMany(p => p.AppDailySchedules)
                    .HasForeignKey(d => d.ScheduleRegularId)
                    .HasConstraintName("FK_DailySchedule_ScheduleRegular");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.AppDailySchedules)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK_DailySchedule_School");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.AppDailyScheduleTeachers)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK_DailySchedule_User");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.AppDailyScheduleUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_DailySchedule_UserCreate");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.AppDailyScheduleUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_DailySchedule_UserUpdate");
            });

            modelBuilder.Entity<AppDocumentPerCourse>(entity =>
            {
                entity.HasKey(e => e.IddocumentPerCourse)
                    .HasName("PK_DocumentPerCourse");

                entity.ToTable("APP_DocumentPerCourse");

                entity.Property(e => e.IddocumentPerCourse).HasColumnName("IDDocumentPerCourse");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.Property(e => e.ExsistDocumentId).HasColumnName("ExsistDocumentID");

                entity.Property(e => e.FolderId).HasColumnName("FolderID");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.RequiredDocumentPerCourseId).HasColumnName("RequiredDocumentPerCourseID");

                entity.Property(e => e.SchoolId).HasColumnName("SchoolID");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.AppDocumentPerCourses)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_APP_DocumentPerCourse_APP_GroupSemesterPerCourse");

                entity.HasOne(d => d.ExsistDocument)
                    .WithMany(p => p.AppDocumentPerCourses)
                    .HasForeignKey(d => d.ExsistDocumentId)
                    .HasConstraintName("FK_APP_DocumentPerCourse_APP_ExsistDocument");

                entity.HasOne(d => d.Folder)
                    .WithMany(p => p.AppDocumentPerCourses)
                    .HasForeignKey(d => d.FolderId)
                    .HasConstraintName("FK_APP_DocumentPerCourse_APP_Folder");

                entity.HasOne(d => d.RequiredDocumentPerCourse)
                    .WithMany(p => p.AppDocumentPerCourses)
                    .HasForeignKey(d => d.RequiredDocumentPerCourseId)
                    .HasConstraintName("FK_APP_DocumentPerCourse_TAB_RequiredDocumentPerCourse");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.AppDocumentPerCourses)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK_APP_DocumentPerCourse_APP_School");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.AppDocumentPerCourseUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_UserCreated_DocumentPerCourse");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.AppDocumentPerCourseUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_UserUpdated_DocumentPerCourse");
            });

            modelBuilder.Entity<AppDocumentPerFatherCourse>(entity =>
            {
                entity.HasKey(e => e.IddocumentPerFatherCourse)
                    .HasName("PK_DocumentPerFatherCourse");

                entity.ToTable("APP_DocumentPerFatherCourse");

                entity.Property(e => e.IddocumentPerFatherCourse).HasColumnName("IDDocumentPerFatherCourse");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.Property(e => e.ExsistDocumentId).HasColumnName("ExsistDocumentID");

                entity.Property(e => e.FatherCourseId).HasColumnName("FatherCourseID");

                entity.Property(e => e.FolderId).HasColumnName("FolderID");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.RequiredDocumentPerFatherCourseId).HasColumnName("RequiredDocumentPerFatherCourseID");

                entity.Property(e => e.SchoolId).HasColumnName("SchoolID");

                entity.Property(e => e.UniqueCodeId).HasColumnName("UniqueCodeID");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.ExsistDocument)
                    .WithMany(p => p.AppDocumentPerFatherCourses)
                    .HasForeignKey(d => d.ExsistDocumentId)
                    .HasConstraintName("FK_DocumentPerFatherCourse_APP_ExsistDocument");

                entity.HasOne(d => d.FatherCourse)
                    .WithMany(p => p.AppDocumentPerFatherCourses)
                    .HasForeignKey(d => d.FatherCourseId)
                    .HasConstraintName("FK_APP_DocumentPerFatherCourse_APP_GroupSemesterPerFatherCourse");

                entity.HasOne(d => d.Folder)
                    .WithMany(p => p.AppDocumentPerFatherCourses)
                    .HasForeignKey(d => d.FolderId)
                    .HasConstraintName("FK_APP_DocumentPerFatherCourse_APP_Folder");

                entity.HasOne(d => d.RequiredDocumentPerFatherCourse)
                    .WithMany(p => p.AppDocumentPerFatherCourses)
                    .HasForeignKey(d => d.RequiredDocumentPerFatherCourseId)
                    .HasConstraintName("FK_APP_DocumentPerFatherCourse_TAB_RequiredDocumentPerFatherCourse");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.AppDocumentPerFatherCourses)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK_APP_DocumentPerFatherCourse_APP_School");

                entity.HasOne(d => d.UniqueCode)
                    .WithMany(p => p.AppDocumentPerFatherCourses)
                    .HasForeignKey(d => d.UniqueCodeId)
                    .HasConstraintName("FK_DocumentPerFatherCourse_APP_UniqueCodeToTask");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.AppDocumentPerFatherCourseUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_APP_DocumentPerFatherCourse_UserPerSchool");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.AppDocumentPerFatherCourseUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_APP_DocumentPerFatherCourse_UserPerSchool2");
            });

            modelBuilder.Entity<AppDocumentPerGroup>(entity =>
            {
                entity.HasKey(e => e.IddocumentPerGroup)
                    .HasName("PK_DocumentPerGroup");

                entity.ToTable("APP_DocumentPerGroup");

                entity.Property(e => e.IddocumentPerGroup).HasColumnName("IDDocumentPerGroup");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.Property(e => e.ExsistDocumentId).HasColumnName("ExsistDocumentID");

                entity.Property(e => e.FolderId).HasColumnName("FolderID");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.RequiredDocumentPerGroupId).HasColumnName("RequiredDocumentPerGroupID");

                entity.Property(e => e.SchoolId).HasColumnName("SchoolID");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.ExsistDocument)
                    .WithMany(p => p.AppDocumentPerGroups)
                    .HasForeignKey(d => d.ExsistDocumentId)
                    .HasConstraintName("FK_DocumentPerGroup_APP_ExsistDocument");

                entity.HasOne(d => d.Folder)
                    .WithMany(p => p.AppDocumentPerGroups)
                    .HasForeignKey(d => d.FolderId)
                    .HasConstraintName("FK_APP_DocumentPerGroup_APP_Folder");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.AppDocumentPerGroups)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_APP_DocumentPerGroup_APP_GroupPerYearbook");

                entity.HasOne(d => d.RequiredDocumentPerGroup)
                    .WithMany(p => p.AppDocumentPerGroups)
                    .HasForeignKey(d => d.RequiredDocumentPerGroupId)
                    .HasConstraintName("FK_APP_DocumentPerGroup_TAB_RequiredDocumentPerGroup");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.AppDocumentPerGroups)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK_APP_DocumentPerGroup_APP_School");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.AppDocumentPerGroupUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_UserCreated_DocumentPerGroup");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.AppDocumentPerGroupUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_UserUpdated_DocumentPerGroup");
            });

            modelBuilder.Entity<AppDocumentPerProfession>(entity =>
            {
                entity.HasKey(e => e.IddocumentPerProfession)
                    .HasName("PK_DocumentPerProfession");

                entity.ToTable("APP_DocumentPerProfession");

                entity.Property(e => e.IddocumentPerProfession).HasColumnName("IDDocumentPerProfession");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.Property(e => e.ExsistDocumentId).HasColumnName("ExsistDocumentID");

                entity.Property(e => e.FolderId).HasColumnName("FolderID");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.ProfessionId).HasColumnName("ProfessionID");

                entity.Property(e => e.RequiredDocumentPerProfessionId).HasColumnName("RequiredDocumentPerProfessionID");

                entity.Property(e => e.SchoolId).HasColumnName("SchoolID");

                entity.Property(e => e.UniqueCodeId).HasColumnName("UniqueCodeID");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.ExsistDocument)
                    .WithMany(p => p.AppDocumentPerProfessions)
                    .HasForeignKey(d => d.ExsistDocumentId)
                    .HasConstraintName("FK_DocumentPerProfession_APP_ExsistDocument");

                entity.HasOne(d => d.Folder)
                    .WithMany(p => p.AppDocumentPerProfessions)
                    .HasForeignKey(d => d.FolderId)
                    .HasConstraintName("FK_APP_DocumentPerProfession_APP_Folder");

                entity.HasOne(d => d.Profession)
                    .WithMany(p => p.AppDocumentPerProfessions)
                    .HasForeignKey(d => d.ProfessionId)
                    .HasConstraintName("FK_APP_DocumentPerProfession_APP_Profession");

                entity.HasOne(d => d.RequiredDocumentPerProfession)
                    .WithMany(p => p.AppDocumentPerProfessions)
                    .HasForeignKey(d => d.RequiredDocumentPerProfessionId)
                    .HasConstraintName("FK_APP_DocumentPerProfession_TAB_RequiredDocumentPerProfession");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.AppDocumentPerProfessions)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK_APP_DocumentPerProfession_APP_School");

                entity.HasOne(d => d.UniqueCode)
                    .WithMany(p => p.AppDocumentPerProfessions)
                    .HasForeignKey(d => d.UniqueCodeId)
                    .HasConstraintName("FK_DocumentPerProfession_APP_UniqueCodeToProfession");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.AppDocumentPerProfessionUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_UserCreated_DocumentPerProfession");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.AppDocumentPerProfessionUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_UserUpdated_DocumentPerProfession");
            });

            modelBuilder.Entity<AppDocumentPerSchool>(entity =>
            {
                entity.HasKey(e => e.IddocumentPerSchool)
                    .HasName("PK_DocumentPerSchool");

                entity.ToTable("APP_DocumentPerSchool");

                entity.Property(e => e.IddocumentPerSchool).HasColumnName("IDDocumentPerSchool");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.Property(e => e.ExsistDocumentId).HasColumnName("ExsistDocumentID");

                entity.Property(e => e.FolderId).HasColumnName("FolderID");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.RequiredDocumentPerSchoolId).HasColumnName("RequiredDocumentPerSchoolID");

                entity.Property(e => e.SchoolId).HasColumnName("SchoolID");

                entity.Property(e => e.UniqueCodeId).HasColumnName("UniqueCodeID");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.ExsistDocument)
                    .WithMany(p => p.AppDocumentPerSchools)
                    .HasForeignKey(d => d.ExsistDocumentId)
                    .HasConstraintName("FK_DocumentPerSchool_APP_ExsistDocument");

                entity.HasOne(d => d.Folder)
                    .WithMany(p => p.AppDocumentPerSchools)
                    .HasForeignKey(d => d.FolderId)
                    .HasConstraintName("FK_APP_DocumentPerSchool_APP_Folder");

                entity.HasOne(d => d.RequiredDocumentPerSchool)
                    .WithMany(p => p.AppDocumentPerSchools)
                    .HasForeignKey(d => d.RequiredDocumentPerSchoolId)
                    .HasConstraintName("FK_APP_DocumentPerSchool_TAB_RequiredDocumentPerSchool");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.AppDocumentPerSchools)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK_APP_DocumentPerSchool_APP_School");

                entity.HasOne(d => d.UniqueCode)
                    .WithMany(p => p.AppDocumentPerSchools)
                    .HasForeignKey(d => d.UniqueCodeId)
                    .HasConstraintName("FK_DocumentPerSchool_APP_UniqueCodeToSchool");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.AppDocumentPerSchoolUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_UserCreated_DocumentPerSchool");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.AppDocumentPerSchoolUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_UserUpdated_DocumentPerSchool");
            });

            modelBuilder.Entity<AppDocumentPerStudent>(entity =>
            {
                entity.HasKey(e => e.IddocumentPerStudent)
                    .HasName("PK_DocumentPerStudent");

                entity.ToTable("APP_DocumentPerStudent");

                entity.Property(e => e.IddocumentPerStudent).HasColumnName("IDDocumentPerStudent");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.Property(e => e.ExsistDocumentId).HasColumnName("ExsistDocumentID");

                entity.Property(e => e.FolderId).HasColumnName("FolderID");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.RequiredDocumentPerStudentId).HasColumnName("RequiredDocumentPerStudentID");

                entity.Property(e => e.SchoolId).HasColumnName("SchoolID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.ExsistDocument)
                    .WithMany(p => p.AppDocumentPerStudents)
                    .HasForeignKey(d => d.ExsistDocumentId)
                    .HasConstraintName("FK_APP_DocumentPerStudent_APP_ExsistDocument");

                entity.HasOne(d => d.Folder)
                    .WithMany(p => p.AppDocumentPerStudents)
                    .HasForeignKey(d => d.FolderId)
                    .HasConstraintName("FK_APP_DocumentPerStudent_APP_Folder");

                entity.HasOne(d => d.RequiredDocumentPerStudent)
                    .WithMany(p => p.AppDocumentPerStudents)
                    .HasForeignKey(d => d.RequiredDocumentPerStudentId)
                    .HasConstraintName("FK_APP_DocumentPerStudent_TAB_RequiredDocumentPerStudent");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.AppDocumentPerStudents)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK_APP_DocumentPerStudent_APP_School");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.AppDocumentPerStudents)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_APP_DocumentPerStudent_APP_Student");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.AppDocumentPerStudentUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_UserCreated_DocumentPerStudent");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.AppDocumentPerStudentUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_UserUpdated_DocumentPerStudent");
            });

            modelBuilder.Entity<AppDocumentPerTask>(entity =>
            {
                entity.HasKey(e => e.IddocumentPerTask)
                    .HasName("PK_DocumentPerTask");

                entity.ToTable("APP_DocumentPerTask");

                entity.Property(e => e.IddocumentPerTask).HasColumnName("IDDocumentPerTask");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.Property(e => e.ExsistDocumentId).HasColumnName("ExsistDocumentID");

                entity.Property(e => e.FolderId).HasColumnName("FolderID");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.RequiredDocumentPerTaskId).HasColumnName("RequiredDocumentPerTaskID");

                entity.Property(e => e.SchoolId).HasColumnName("SchoolID");

                entity.Property(e => e.TaskId).HasColumnName("TaskID");

                entity.Property(e => e.UniqueCodeId).HasColumnName("UniqueCodeID");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.ExsistDocument)
                    .WithMany(p => p.AppDocumentPerTasks)
                    .HasForeignKey(d => d.ExsistDocumentId)
                    .HasConstraintName("FK_DocumentPerTask_APP_ExsistDocument");

                entity.HasOne(d => d.Folder)
                    .WithMany(p => p.AppDocumentPerTasks)
                    .HasForeignKey(d => d.FolderId)
                    .HasConstraintName("FK_APP_DocumentPerTask_APP_Folder");

                entity.HasOne(d => d.RequiredDocumentPerTask)
                    .WithMany(p => p.AppDocumentPerTasks)
                    .HasForeignKey(d => d.RequiredDocumentPerTaskId)
                    .HasConstraintName("FK_APP_DocumentPerTask_TAB_RequiredDocumentPerTask");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.AppDocumentPerTasks)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK_APP_DocumentPerTask_APP_School");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.AppDocumentPerTasks)
                    .HasForeignKey(d => d.TaskId)
                    .HasConstraintName("FK_APP_DocumentPerTask_APP_Task");

                entity.HasOne(d => d.UniqueCode)
                    .WithMany(p => p.AppDocumentPerTasks)
                    .HasForeignKey(d => d.UniqueCodeId)
                    .HasConstraintName("FK_DocumentPerTask_APP_UniqueCodeToTask");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.AppDocumentPerTaskUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_UserCreated_DocumentPerTask");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.AppDocumentPerTaskUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_UserUpdated_DocumentPerTask");
            });

            modelBuilder.Entity<AppDocumentPerTaskExsist>(entity =>
            {
                entity.HasKey(e => e.IddocumentPerTaskExsist)
                    .HasName("PK_DocumentPerTaskExsist");

                entity.ToTable("APP_DocumentPerTaskExsist");

                entity.Property(e => e.IddocumentPerTaskExsist).HasColumnName("IDDocumentPerTaskExsist");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.Property(e => e.ExsistDocumentId).HasColumnName("ExsistDocumentID");

                entity.Property(e => e.FolderId).HasColumnName("FolderID");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.RequiredDocumentPerTaskExsistId).HasColumnName("RequiredDocumentPerTaskExsistID");

                entity.Property(e => e.SchoolId).HasColumnName("SchoolID");

                entity.Property(e => e.TaskExsistId).HasColumnName("TaskExsistID");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.ExsistDocument)
                    .WithMany(p => p.AppDocumentPerTaskExsists)
                    .HasForeignKey(d => d.ExsistDocumentId)
                    .HasConstraintName("FK_APP_DocumentPerTaskExsist_APP_ExsistDocument");

                entity.HasOne(d => d.Folder)
                    .WithMany(p => p.AppDocumentPerTaskExsists)
                    .HasForeignKey(d => d.FolderId)
                    .HasConstraintName("FK_APP_DocumentPerTaskExsist_APP_Folder");

                entity.HasOne(d => d.RequiredDocumentPerTaskExsist)
                    .WithMany(p => p.AppDocumentPerTaskExsists)
                    .HasForeignKey(d => d.RequiredDocumentPerTaskExsistId)
                    .HasConstraintName("FK_APP_DocumentPerTaskExsist_TAB_RequiredDocumentPerTaskExsist");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.AppDocumentPerTaskExsists)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK_APP_DocumentPerTaskExsist_APP_School");

                entity.HasOne(d => d.TaskExsist)
                    .WithMany(p => p.AppDocumentPerTaskExsists)
                    .HasForeignKey(d => d.TaskExsistId)
                    .HasConstraintName("FK_APP_DocumentPerTaskExsist_APP_TaskExsist");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.AppDocumentPerTaskExsistUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_UserCreated_DocumentPerTaskExsist");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.AppDocumentPerTaskExsistUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_UserUpdated_DocumentPerTaskExsist");
            });

            modelBuilder.Entity<AppDocumentPerUser>(entity =>
            {
                entity.HasKey(e => e.IddocumentPerUser)
                    .HasName("PK_DocumentPerUser");

                entity.ToTable("APP_DocumentPerUser");

                entity.Property(e => e.IddocumentPerUser).HasColumnName("IDDocumentPerUser");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.Property(e => e.ExsistDocumentId).HasColumnName("ExsistDocumentID");

                entity.Property(e => e.FolderId).HasColumnName("FolderID");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.RequiredDocumentPerUserId).HasColumnName("RequiredDocumentPerUserID");

                entity.Property(e => e.SchoolId).HasColumnName("SchoolID");

                entity.Property(e => e.UniqueCodeId).HasColumnName("UniqueCodeID");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.ExsistDocument)
                    .WithMany(p => p.AppDocumentPerUsers)
                    .HasForeignKey(d => d.ExsistDocumentId)
                    .HasConstraintName("FK_DocumentPerUser_APP_ExsistDocument");

                entity.HasOne(d => d.Folder)
                    .WithMany(p => p.AppDocumentPerUsers)
                    .HasForeignKey(d => d.FolderId)
                    .HasConstraintName("FK_APP_DocumentPerUser_APP_Folder");

                entity.HasOne(d => d.RequiredDocumentPerUser)
                    .WithMany(p => p.AppDocumentPerUsers)
                    .HasForeignKey(d => d.RequiredDocumentPerUserId)
                    .HasConstraintName("FK_APP_DocumentPerUser_TAB_RequiredDocumentPerUser");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.AppDocumentPerUsers)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK_APP_DocumentPerUser_APP_School");

                entity.HasOne(d => d.UniqueCode)
                    .WithMany(p => p.AppDocumentPerUsers)
                    .HasForeignKey(d => d.UniqueCodeId)
                    .HasConstraintName("FK_DocumentPerUser_APP_UniqueCodeToTask");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.AppDocumentPerUserUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_UserCreated_DocumentPerUser");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AppDocumentPerUserUsers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_DocumentPerUser_UserPerSchool");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.AppDocumentPerUserUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_UserUpdated_DocumentPerUser");
            });

            modelBuilder.Entity<AppDraftBuildingCurriculumStudent>(entity =>
            {
                entity.HasKey(e => e.DraftBuildingCurriculumStudentId);

                entity.ToTable("APP_DraftBuildingCurriculumStudent", "Curr");

                entity.Property(e => e.BuildingCurriculumId).HasColumnName("BuildingCurriculumID");

                entity.Property(e => e.GroupSemesterPerCourseId).HasColumnName("GroupSemesterPerCourseID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");
            });

            modelBuilder.Entity<AppDynamicDetailsPerTypeSchool>(entity =>
            {
                entity.HasKey(e => e.IddynamicDetailsPerTypeSchool);

                entity.ToTable("APP_DynamicDetailsPerTypeSchool");

                entity.Property(e => e.IddynamicDetailsPerTypeSchool).HasColumnName("IDDynamicDetailsPerTypeSchool");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdate).HasColumnType("date");

                entity.Property(e => e.TypeSchoolId).HasColumnName("TypeSchoolID");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.DynamicDetails)
                    .WithMany(p => p.AppDynamicDetailsPerTypeSchools)
                    .HasForeignKey(d => d.DynamicDetailsId)
                    .HasConstraintName("FK_APP_DynamicDetailsPerTypeSchool_T_DynamicDetailsForTypeSchool");

                entity.HasOne(d => d.TypeSchool)
                    .WithMany(p => p.AppDynamicDetailsPerTypeSchools)
                    .HasForeignKey(d => d.TypeSchoolId)
                    .HasConstraintName("FK_APP_DynamicDetailsPerTypeSchool_T_SchoolType");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.AppDynamicDetailsPerTypeSchoolUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_APP_DynamicDetailsPerTypeSchool_UserPerSchool1");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.AppDynamicDetailsPerTypeSchoolUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_APP_DynamicDetailsPerTypeSchool_UserPerSchool");
            });

            modelBuilder.Entity<AppDynamicDetailsSchoolPerStudent>(entity =>
            {
                entity.HasKey(e => e.IddynamicDetailsSchoolPerStudent);

                entity.ToTable("APP_DynamicDetailsSchoolPerStudent");

                entity.Property(e => e.IddynamicDetailsSchoolPerStudent).HasColumnName("IDDynamicDetailsSchoolPerStudent");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdate).HasColumnType("date");

                entity.Property(e => e.DynamicDetailId).HasColumnName("DynamicDetailID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.AppDynamicDetailsSchoolPerStudents)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_APP_DynamicDetailsSchoolPerStudent_APP_Student");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.AppDynamicDetailsSchoolPerStudentUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_APP_DynamicDetailsSchoolPerStudent_UserPerSchool");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.AppDynamicDetailsSchoolPerStudentUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_APP_DynamicDetailsSchoolPerStudent_UserPerSchool1");
            });

            modelBuilder.Entity<AppEasementPerStandard>(entity =>
            {
                entity.HasKey(e => e.IdeasementPerStandard)
                    .HasName("PK_EasementPerStandard");

                entity.ToTable("APP_EasementPerStandard");

                entity.Property(e => e.IdeasementPerStandard)
                    .ValueGeneratedNever()
                    .HasColumnName("IDEasementPerStandard");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdate).HasColumnType("date");

                entity.Property(e => e.EasementId).HasColumnName("EasementID");

                entity.Property(e => e.StandardId).HasColumnName("StandardID");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.Easement)
                    .WithMany(p => p.AppEasementPerStandards)
                    .HasForeignKey(d => d.EasementId)
                    .HasConstraintName("FK_APP_EasementPerStandard_T_Easement");

                entity.HasOne(d => d.Standard)
                    .WithMany(p => p.AppEasementPerStandards)
                    .HasForeignKey(d => d.StandardId)
                    .HasConstraintName("FK_APP_EasementPerStandard_T_Standard");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.AppEasementPerStandardUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_APP_EasementPerStandard_UserPerSchool");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.AppEasementPerStandardUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_APP_EasementPerStandard_UserPerSchool1");
            });

            modelBuilder.Entity<AppEasementPerTestOfStudent>(entity =>
            {
                entity.HasKey(e => e.IdeasementPerTestOfStudent);

                entity.ToTable("APP_EasementPerTestOfStudent");

                entity.Property(e => e.IdeasementPerTestOfStudent).HasColumnName("IDEasementPerTestOfStudent");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.Property(e => e.EasementId).HasColumnName("EasementID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.TestId).HasColumnName("TestID??");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.Easement)
                    .WithMany(p => p.AppEasementPerTestOfStudents)
                    .HasForeignKey(d => d.EasementId)
                    .HasConstraintName("FK_APP_EasementPerTestOfStudent_T_Easement");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.AppEasementPerTestOfStudents)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_APP_EasementPerTestOfStudent_APP_Student");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.AppEasementPerTestOfStudentUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_UserCreated_EasementPerTestOfStudent");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.AppEasementPerTestOfStudentUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_UserUpdated_EasementPerTestOfStudent");
            });

            modelBuilder.Entity<AppExcelToDownload>(entity =>
            {
                entity.HasKey(e => e.IdexcelToDownload)
                    .HasName("PK__APP_Exce__395A6D9044D3ECEF");

                entity.ToTable("APP_ExcelToDownload");

                entity.Property(e => e.IdexcelToDownload).HasColumnName("IDExcelToDownload");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Type).HasMaxLength(20);

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.AppExcelToDownloadUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_ExcelToDownload_UserCreated");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.AppExcelToDownloadUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_ExcelToDownload_UserUpdated");
            });

            modelBuilder.Entity<AppExsistDocument>(entity =>
            {
                entity.HasKey(e => e.IdexsistDocument);

                entity.ToTable("APP_ExsistDocument");

                entity.Property(e => e.IdexsistDocument).HasColumnName("IDExsistDocument");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.AppExsistDocumentUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_UserCreated_ExsistDocument");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.AppExsistDocumentUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_UserUpdated_ExsistDocument");
            });

            modelBuilder.Entity<AppFolder>(entity =>
            {
                entity.HasKey(e => e.IdFolder)
                    .HasName("PK_Folder");

                entity.ToTable("APP_Folder");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.AppFolders)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK_APP_Folder_APP_School");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.AppFolderUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_UserCreated_Folder");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.AppFolderUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_UserUpdated_Folder");
            });

            modelBuilder.Entity<AppGroup>(entity =>
            {
                entity.HasKey(e => e.Idgroup);

                entity.ToTable("APP_Group");

                entity.Property(e => e.Idgroup).HasColumnName("IDGroup");

                entity.Property(e => e.AgeGroupId).HasColumnName("AgeGroupID");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.Property(e => e.ExtensionId).HasColumnName("ExtensionID");

                entity.Property(e => e.ListeningTimeId).HasColumnName("ListeningTimeID");

                entity.Property(e => e.NameGroup).HasMaxLength(50);

                entity.Property(e => e.SchoolId).HasColumnName("SchoolID");

                entity.Property(e => e.TypeGroupId).HasColumnName("TypeGroupID");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.Property(e => e.VoiceSpaceId).HasColumnName("VoiceSpaceID");

                entity.HasOne(d => d.AgeGroup)
                    .WithMany(p => p.AppGroups)
                    .HasForeignKey(d => d.AgeGroupId)
                    .HasConstraintName("FK_APP_Group_TAB_AgeGroup");

                entity.HasOne(d => d.CoordinationType)
                    .WithMany(p => p.AppGroups)
                    .HasForeignKey(d => d.CoordinationTypeId)
                    .HasConstraintName("FK_APP_Group_App_CoordinationType");

                entity.HasOne(d => d.ListeningTime)
                    .WithMany(p => p.AppGroups)
                    .HasForeignKey(d => d.ListeningTimeId)
                    .HasConstraintName("FK_APP_Group_TAB_ListeningTime");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.AppGroups)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK_APP_Group_APP_School");

                entity.HasOne(d => d.TypeGroup)
                    .WithMany(p => p.AppGroups)
                    .HasForeignKey(d => d.TypeGroupId)
                    .HasConstraintName("FK_APP_Group_TAB_TypeGroup");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.AppGroupUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_APP_Group_UserPerSchool");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.AppGroupUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_APP_Group_UserPerSchool1");

                entity.HasOne(d => d.VoiceSpace)
                    .WithMany(p => p.AppGroups)
                    .HasForeignKey(d => d.VoiceSpaceId)
                    .HasConstraintName("FK_APP_Group_APP_VoiceSpace");
            });

            modelBuilder.Entity<AppGroupPerYearbook>(entity =>
            {
                entity.HasKey(e => e.IdgroupPerYearbook)
                    .HasName("PK_GroupPerYearbook");

                entity.ToTable("APP_GroupPerYearbook");

                entity.HasIndex(e => new { e.GroupId, e.YearbookId }, "UniqueFields")
                    .IsUnique();

                entity.Property(e => e.IdgroupPerYearbook).HasColumnName("IDGroupPerYearbook");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.Property(e => e.YearbookId).HasColumnName("YearbookID");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.AppGroupPerYearbooks)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_APP_GroupPerYearbook_APP_Group");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.AppGroupPerYearbookUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_APP_GroupPerYearbook_UserPerSchool");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.AppGroupPerYearbookUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_APP_GroupPerYearbook_UserPerSchool1");

                entity.HasOne(d => d.Yearbook)
                    .WithMany(p => p.AppGroupPerYearbooks)
                    .HasForeignKey(d => d.YearbookId)
                    .HasConstraintName("FK_APP_GroupPerYearbook_APP_YearbookPerSchool");
            });

            modelBuilder.Entity<AppGroupSemesterPerCourse>(entity =>
            {
                entity.HasKey(e => e.IdgroupSemesterPerCourse);

                entity.ToTable("APP_GroupSemesterPerCourse");

                entity.Property(e => e.IdgroupSemesterPerCourse).HasColumnName("IDGroupSemesterPerCourse");

                entity.Property(e => e.Code).HasMaxLength(200);

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdate).HasColumnType("date");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.SemesterId).HasColumnName("SemesterID");

                entity.Property(e => e.ToDate).HasColumnType("date");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.AppGroupSemesterPerCourses)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_APP_GroupSemesterPerCourse_APP_Course");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.AppGroupSemesterPerCourses)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_APP_GroupSemesterPerCourse_APP_GroupPerYearbook");

                entity.HasOne(d => d.Semester)
                    .WithMany(p => p.AppGroupSemesterPerCourses)
                    .HasForeignKey(d => d.SemesterId)
                    .HasConstraintName("FK_APP_GroupSemesterPerCourse_APP_Semester");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.AppGroupSemesterPerCourseUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_APP_GroupSemesterPerCourse_UserPerSchool");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.AppGroupSemesterPerCourseUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_APP_GroupSemesterPerCourse_UserPerSchool1");
            });

            modelBuilder.Entity<AppLecturerPerCourse>(entity =>
            {
                entity.HasKey(e => e.Idlecturer);

                entity.ToTable("APP_LecturerPerCourse");

                entity.Property(e => e.Idlecturer)
                    .ValueGeneratedNever()
                    .HasColumnName("IDLecturer");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdate).HasColumnType("date");

                entity.Property(e => e.ReplacingId).HasColumnName("ReplacingID");

                entity.Property(e => e.SchoolId).HasColumnName("SchoolID");

                entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.AppLecturerPerCourses)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_APP_LecturerPerCourse_APP_Course");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.AppLecturerPerCourses)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK_APP_LecturerPerCourse_APP_School");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.AppLecturerPerCourseTeachers)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK_LecturerPerCourse_UserPerSchool");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.AppLecturerPerCourseUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_UserCreated_LecturerPerCourse");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.AppLecturerPerCourseUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_UserUpdated_LecturerPerCourse");
            });

            modelBuilder.Entity<AppLessonPerGroup>(entity =>
            {
                entity.HasKey(e => e.IdlessonPerGroup)
                    .HasName("PK__APP_Less__D4A443236A85B0CE");

                entity.ToTable("APP_LessonPerGroup");

                entity.Property(e => e.IdlessonPerGroup).HasColumnName("IDLessonPerGroup");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.AppLessonPerGroups)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_LessonPerGroup_GroupPerYearBook");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.AppLessonPerGroupUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_UserCreated_LessonPerGroup");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.AppLessonPerGroupUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_UserUpdated_LessonPerGroup");
            });

            modelBuilder.Entity<AppLocation>(entity =>
            {
                entity.HasKey(e => e.Idlocation);

                entity.ToTable("APP_Location", "Curr");

                entity.HasIndex(e => e.AppAddressIdaddress, "IX_APP_Location_APP_AddressIDAddress");

                entity.Property(e => e.Idlocation).HasColumnName("IDLocation");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.AppAddressIdaddress).HasColumnName("APP_AddressIDAddress");

                entity.HasOne(d => d.AppAddressIdaddressNavigation)
                    .WithMany(p => p.AppLocations)
                    .HasForeignKey(d => d.AppAddressIdaddress);
            });

            modelBuilder.Entity<AppMeetingTime>(entity =>
            {
                entity.HasKey(e => e.MeetingTimesId);

                entity.ToTable("APP_MeetingTimes", "Curr");

                entity.HasIndex(e => e.GroupSemesterPerCourseId, "IX_APP_MeetingTimes_GroupSemesterPerCourseID");

                entity.Property(e => e.MeetingTimesId).HasColumnName("MeetingTimesID");

                entity.Property(e => e.GroupSemesterPerCourseId).HasColumnName("GroupSemesterPerCourseID");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.GroupSemesterPerCourse)
                    .WithMany(p => p.AppMeetingTimes)
                    .HasForeignKey(d => d.GroupSemesterPerCourseId);
            });

            modelBuilder.Entity<AppNote>(entity =>
            {
                entity.HasKey(e => e.Idnote);

                entity.ToTable("App_Note");

                entity.Property(e => e.Idnote).HasColumnName("IDNote");

                entity.Property(e => e.ControlName).HasMaxLength(50);

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdate).HasColumnType("date");

                entity.Property(e => e.FormName).HasMaxLength(50);

                entity.Property(e => e.Idstudent).HasColumnName("IDStudent");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.IdstudentNavigation)
                    .WithMany(p => p.AppNotes)
                    .HasForeignKey(d => d.Idstudent)
                    .HasConstraintName("FK_App_Note_APP_Student");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.AppNoteUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_UserCreated_Note");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.AppNoteUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_UserUpdated_Note");
            });

            modelBuilder.Entity<AppPresence>(entity =>
            {
                entity.HasKey(e => e.Idpresence)
                    .HasName("PK__APP_Pres__FF9F9663D232BA2F");

                entity.ToTable("APP_Presence");

                entity.Property(e => e.Idpresence).HasColumnName("IDPresence");

                entity.Property(e => e.DailyScheduleId).HasColumnName("DailyScheduleID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.TypePresenceId).HasColumnName("TypePresenceID");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.DailySchedule)
                    .WithMany(p => p.AppPresences)
                    .HasForeignKey(d => d.DailyScheduleId)
                    .HasConstraintName("FK_APP_Presence_APP_DailySchedule");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.AppPresences)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK_APP_Presence_app_school");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.AppPresences)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APP_Presence_app_student");

                entity.HasOne(d => d.TypePresence)
                    .WithMany(p => p.AppPresences)
                    .HasForeignKey(d => d.TypePresenceId)
                    .HasConstraintName("FK_APP_Presence_TAB_AttendanceMarkings");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.AppPresenceUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_APP_Presence_App_UserPerSchool2");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.AppPresenceUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_APP_Presence_App_UserPerSchool1");
            });

            modelBuilder.Entity<AppProfession>(entity =>
            {
                entity.HasKey(e => e.Idprofession);

                entity.ToTable("APP_Profession");

                entity.Property(e => e.Idprofession).HasColumnName("IDProfession");

                entity.Property(e => e.CoordinatorId).HasColumnName("CoordinatorID");

                entity.Property(e => e.DateCreate).HasColumnType("date");

                entity.Property(e => e.DateUpdate).HasColumnType("date");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.ProfessionCategoryId).HasColumnName("ProfessionCategoryID");

                entity.Property(e => e.SchoolId).HasColumnName("SchoolID");

                entity.Property(e => e.UniqueCodeId).HasColumnName("UniqueCodeID");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.CoordinationType)
                    .WithMany(p => p.AppProfessions)
                    .HasForeignKey(d => d.CoordinationTypeId)
                    .HasConstraintName("FK_APP_Profession_App_CoordinationType");

                entity.HasOne(d => d.Coordinator)
                    .WithMany(p => p.AppProfessionCoordinators)
                    .HasForeignKey(d => d.CoordinatorId)
                    .HasConstraintName("FK_APP_Profession_APP_UserPerSchool");

                entity.HasOne(d => d.ProfessionCategory)
                    .WithMany(p => p.AppProfessions)
                    .HasForeignKey(d => d.ProfessionCategoryId)
                    .HasConstraintName("FK_APP_Profession_TAB_ProfessionCategory");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.AppProfessions)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK_APP_Profession_APP_School");

                entity.HasOne(d => d.UniqueCode)
                    .WithMany(p => p.AppProfessions)
                    .HasForeignKey(d => d.UniqueCodeId)
                    .HasConstraintName("FK_Profession_UniqueCode");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.AppProfessionUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_APP_Profession_UserPerSchool");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.AppProfessionUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_APP_Profession_UserPerSchool1");
            });

            modelBuilder.Entity<AppQuestionsOfTask>(entity =>
            {
                entity.HasKey(e => e.IdquestionOfTask)
                    .HasName("PK__APP_Ques__CCE96CA0394A004E");

                entity.ToTable("APP_QuestionsOfTask");

                entity.Property(e => e.IdquestionOfTask).HasColumnName("IDQuestionOfTask");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdate).HasColumnType("date");

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.TypeQuestionId).HasColumnName("TypeQuestionID");

                entity.Property(e => e.UniqeCodeId).HasColumnName("UniqeCodeID");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.AppQuestionsOfTasks)
                    .HasForeignKey(d => d.TaskId)
                    .HasConstraintName("FK_QuestionsOfTask_Task");

                entity.HasOne(d => d.TypeQuestion)
                    .WithMany(p => p.AppQuestionsOfTasks)
                    .HasForeignKey(d => d.TypeQuestionId)
                    .HasConstraintName("FK_QuestionsOfTask_TypeQuestion");

                entity.HasOne(d => d.UniqeCode)
                    .WithMany(p => p.AppQuestionsOfTasks)
                    .HasForeignKey(d => d.UniqeCodeId)
                    .HasConstraintName("FK_QuestionsOfTask_UniqueCode");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.AppQuestionsOfTaskUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_QuestionsOfTask_UserCreated");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.AppQuestionsOfTaskUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_QuestionsOfTask_UserUpdated");
            });

            modelBuilder.Entity<AppScheduleRegular>(entity =>
            {
                entity.HasKey(e => e.IdscheduleRegular)
                    .HasName("PK__APP_Sche__BEC0425CB939E24B");

                entity.ToTable("APP_ScheduleRegular");

                entity.Property(e => e.IdscheduleRegular).HasColumnName("IDScheduleRegular");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.LessonPerGroupId).HasColumnName("LessonPerGroupID");

                entity.Property(e => e.SchoolId).HasColumnName("SchoolID");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.AppScheduleRegulars)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_ScheduleRegular_GroupSemesterPerCourse");

                entity.HasOne(d => d.LessonPerGroup)
                    .WithMany(p => p.AppScheduleRegulars)
                    .HasForeignKey(d => d.LessonPerGroupId)
                    .HasConstraintName("FK_ScheduleRegular_LessonPerGroup");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.AppScheduleRegulars)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK_ScheduleRegular_School");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.AppScheduleRegularUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_ScheduleRegular_UserCreate");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.AppScheduleRegularUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_ScheduleRegular_UserUpdate");
            });

            modelBuilder.Entity<AppSchool>(entity =>
            {
                entity.HasKey(e => e.Idschool);

                entity.ToTable("APP_School");

                entity.Property(e => e.Idschool).HasColumnName("IDSchool");

                entity.Property(e => e.AdressId).HasColumnName("AdressID");

                entity.Property(e => e.ContactInformationId).HasColumnName("ContactInformationID");

                entity.Property(e => e.CoordinationCode).HasMaxLength(50);

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.SchoolTypeId).HasColumnName("SchoolTypeID");

                entity.Property(e => e.UserContactId).HasColumnName("UserContactID");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.Adress)
                    .WithMany(p => p.AppSchools)
                    .HasForeignKey(d => d.AdressId)
                    .HasConstraintName("FK_APP_School_APP_Address");

                entity.HasOne(d => d.ContactInformation)
                    .WithMany(p => p.AppSchools)
                    .HasForeignKey(d => d.ContactInformationId)
                    .HasConstraintName("FK_APP_School_APP_ContactInformation");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.AppSchools)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_School_Customer");

                entity.HasOne(d => d.SchoolType)
                    .WithMany(p => p.AppSchools)
                    .HasForeignKey(d => d.SchoolTypeId)
                    .HasConstraintName("FK_APP_School_T_SchoolType");

                entity.HasOne(d => d.UserContact)
                    .WithMany(p => p.AppSchools)
                    .HasForeignKey(d => d.UserContactId)
                    .HasConstraintName("FK_APP_School_APP_Contact");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.AppSchoolUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_UserCreated_School");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.AppSchoolUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_UserUpdated_School");
            });

            modelBuilder.Entity<AppScoreStudentPerQuestionsOfTask>(entity =>
            {
                entity.HasKey(e => e.IdscoreStudentPerQuestionsOfTask)
                    .HasName("PK__APP_Scor__D8ACF5F94DAEF9AA");

                entity.ToTable("APP_ScoreStudentPerQuestionsOfTask");

                entity.HasIndex(e => new { e.QuestionOfTaskId, e.TaskToStudentId }, "IX_APP_ScoreStudentPerQuestionsOfTask")
                    .IsUnique();

                entity.Property(e => e.IdscoreStudentPerQuestionsOfTask).HasColumnName("IDScoreStudentPerQuestionsOfTask");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.Property(e => e.QuestionOfTaskId).HasColumnName("QuestionOfTaskID");

                entity.Property(e => e.TaskToStudentId).HasColumnName("TaskToStudentID");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.QuestionOfTask)
                    .WithMany(p => p.AppScoreStudentPerQuestionsOfTasks)
                    .HasForeignKey(d => d.QuestionOfTaskId)
                    .HasConstraintName("FK_ScoreStudentPerQuestionsOfTask_QuestionsOfTask");

                entity.HasOne(d => d.TaskToStudent)
                    .WithMany(p => p.AppScoreStudentPerQuestionsOfTasks)
                    .HasForeignKey(d => d.TaskToStudentId)
                    .HasConstraintName("FK_TaskToStudent_ScoreStudentPerQuestionsOfTask");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.AppScoreStudentPerQuestionsOfTaskUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_UserCreated_ScoreStudentPerQuestionsOfTask");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.AppScoreStudentPerQuestionsOfTaskUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_UserUpdated_ScoreStudentPerQuestionsOfTask");
            });

            modelBuilder.Entity<AppSemester>(entity =>
            {
                entity.HasKey(e => e.Idsemester)
                    .HasName("PK_T_Semester");

                entity.ToTable("APP_Semester");

                entity.Property(e => e.Idsemester).HasColumnName("IDSemester");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.Property(e => e.FromDate).HasColumnType("date");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.ToDate).HasColumnType("date");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.Property(e => e.YearbookId).HasColumnName("YearbookID");

                entity.HasOne(d => d.CoordinationType)
                    .WithMany(p => p.AppSemesters)
                    .HasForeignKey(d => d.CoordinationTypeId)
                    .HasConstraintName("FK_APP_Semester_App_CoordinationType");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.AppSemesterUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_UserCreated_Semester");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.AppSemesterUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_UserUpdated_Semester");

                entity.HasOne(d => d.Yearbook)
                    .WithMany(p => p.AppSemesters)
                    .HasForeignKey(d => d.YearbookId)
                    .HasConstraintName("FK_T_Semester_APP_YearbookPerSchool");
            });

            modelBuilder.Entity<AppStandardPerStudent>(entity =>
            {
                entity.HasKey(e => e.IdstandardPerStudent)
                    .HasName("PK_StandardPerStudent");

                entity.ToTable("APP_StandardPerStudent");

                entity.Property(e => e.IdstandardPerStudent).HasColumnName("IDStandardPerStudent");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdate).HasColumnType("date");

                entity.Property(e => e.StandardId).HasColumnName("StandardID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.Standard)
                    .WithMany(p => p.AppStandardPerStudents)
                    .HasForeignKey(d => d.StandardId)
                    .HasConstraintName("FK_APP_StandardPerStudent_T_Standard");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.AppStandardPerStudents)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_APP_StandardPerStudent_APP_Student");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.AppStandardPerStudentUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_UserCreated_StandardPerStudent");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.AppStandardPerStudentUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_UserUpdated_StandardPerStudent");
            });

            modelBuilder.Entity<AppStatusStudentPerGroup>(entity =>
            {
                entity.HasKey(e => e.IdstatusStudentPerGroup)
                    .HasName("PK_APP_ReasonForLeavingID");

                entity.ToTable("APP_StatusStudentPerGroup");

                entity.Property(e => e.IdstatusStudentPerGroup).HasColumnName("IDStatusStudentPerGroup");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdate).HasColumnType("date");

                entity.Property(e => e.FromDate).HasColumnType("date");

                entity.Property(e => e.ReasonForLeavingId).HasColumnName("ReasonForLeavingID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.StudentPerGroupId).HasColumnName("StudentPerGroupID");

                entity.Property(e => e.ToDate).HasColumnType("date");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.ReasonForLeaving)
                    .WithMany(p => p.AppStatusStudentPerGroups)
                    .HasForeignKey(d => d.ReasonForLeavingId)
                    .HasConstraintName("FK_StatusStudentPerGroup_ReasonForLeaving");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.AppStatusStudentPerGroups)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_StatusStudentPerGroup_Status");

                entity.HasOne(d => d.StudentPerGroup)
                    .WithMany(p => p.AppStatusStudentPerGroups)
                    .HasForeignKey(d => d.StudentPerGroupId)
                    .HasConstraintName("FK_APP_StatusStudentPerGroup_APP_StudentPerGroup");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.AppStatusStudentPerGroupUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_UserCreated_StatusStudentPerGroup");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.AppStatusStudentPerGroupUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_UserUpdated_StatusStudentPerGroup");
            });

            modelBuilder.Entity<AppStudent>(entity =>
            {
                entity.HasKey(e => e.Idstudent)
                    .HasName("PK_App_Students");

                entity.ToTable("APP_Student");

                entity.HasIndex(e => new { e.Tz, e.SchoolId }, "UniqueTzSchoolId")
                    .IsUnique();

                entity.Property(e => e.Idstudent).HasColumnName("IDStudent");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.AnatherDetails).HasMaxLength(50);

                entity.Property(e => e.ApotropusTypeIdentityId).HasColumnName("ApotropusTypeIdentityID");

                entity.Property(e => e.ApotropusTz)
                    .HasMaxLength(20)
                    .HasColumnName("ApotropusTZ");

                entity.Property(e => e.BirthId).HasColumnName("BirthID");

                entity.Property(e => e.Code).HasMaxLength(50);

                entity.Property(e => e.ContactInformationId).HasColumnName("ContactInformationID");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.Property(e => e.FatherTypeIdentityId).HasColumnName("FatherTypeIdentityID");

                entity.Property(e => e.FatherTz)
                    .HasMaxLength(20)
                    .HasColumnName("FatherTZ");

                entity.Property(e => e.FirstName).HasMaxLength(200);

                entity.Property(e => e.ForeignFirstName).HasMaxLength(50);

                entity.Property(e => e.ForeignLastName).HasMaxLength(50);

                entity.Property(e => e.GenderId).HasColumnName("GenderID");

                entity.Property(e => e.LastName).HasMaxLength(200);

                entity.Property(e => e.MotherTypeIdentityId).HasColumnName("MotherTypeIdentityID");

                entity.Property(e => e.MotherTz)
                    .HasMaxLength(20)
                    .HasColumnName("MotherTZ");

                entity.Property(e => e.PassportPicture).HasMaxLength(200);

                entity.Property(e => e.PreviousSchoolId).HasColumnName("PreviousSchoolID");

                entity.Property(e => e.PreviusName).HasMaxLength(50);

                entity.Property(e => e.ReasonForLeavingId).HasColumnName("ReasonForLeavingID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.StatusStudentId).HasColumnName("StatusStudentID");

                entity.Property(e => e.TypeIdentityId).HasColumnName("TypeIdentityID");

                entity.Property(e => e.Tz)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("TZ");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.AppStudents)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK_APP_Student_APP_Address");

                entity.HasOne(d => d.ApotropusTypeIdentity)
                    .WithMany(p => p.AppStudentApotropusTypeIdentities)
                    .HasForeignKey(d => d.ApotropusTypeIdentityId)
                    .HasConstraintName("FK_APP_Student_T_ApotropusTypeIdentity");

                entity.HasOne(d => d.Birth)
                    .WithMany(p => p.AppStudents)
                    .HasForeignKey(d => d.BirthId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_APP_Student_APP_Birth1");

                entity.HasOne(d => d.ContactInformation)
                    .WithMany(p => p.AppStudents)
                    .HasForeignKey(d => d.ContactInformationId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_APP_Student_APP_ContactInformation");

                entity.HasOne(d => d.FatherTypeIdentity)
                    .WithMany(p => p.AppStudentFatherTypeIdentities)
                    .HasForeignKey(d => d.FatherTypeIdentityId)
                    .HasConstraintName("FK_APP_Student_T_FatherTypeIdentity");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.AppStudents)
                    .HasForeignKey(d => d.GenderId)
                    .HasConstraintName("FK_APP_Student_T_Gender");

                entity.HasOne(d => d.MotherTypeIdentity)
                    .WithMany(p => p.AppStudentMotherTypeIdentities)
                    .HasForeignKey(d => d.MotherTypeIdentityId)
                    .HasConstraintName("FK_APP_Student_T_MotherTypeIdentity");

                entity.HasOne(d => d.PreviousSchool)
                    .WithMany(p => p.AppStudentPreviousSchools)
                    .HasForeignKey(d => d.PreviousSchoolId)
                    .HasConstraintName("FK_APP_Student_APP_School");

                entity.HasOne(d => d.ReasonForLeaving)
                    .WithMany(p => p.AppStudents)
                    .HasForeignKey(d => d.ReasonForLeavingId)
                    .HasConstraintName("FK_APP_Student_T_ReasonForLeaving");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.AppStudentSchools)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK_APP_Student_APP_School1");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.AppStudents)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_APP_Student_T_StatusID");

                entity.HasOne(d => d.StatusStudent)
                    .WithMany(p => p.AppStudents)
                    .HasForeignKey(d => d.StatusStudentId)
                    .HasConstraintName("FK_APP_Student_T_StatusStudent");

                entity.HasOne(d => d.TypeIdentity)
                    .WithMany(p => p.AppStudentTypeIdentities)
                    .HasForeignKey(d => d.TypeIdentityId)
                    .HasConstraintName("FK_APP_Student_T_TypeIdentity");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.AppStudentUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_UserCreated_Student");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.AppStudentUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_UserUpdated_Student");
            });

            modelBuilder.Entity<AppStudentAssingment>(entity =>
            {
                entity.HasKey(e => e.IdstudentAssingment)
                    .HasName("PK_APP_StudentAssiment");

                entity.ToTable("APP_StudentAssingment");

                entity.Property(e => e.IdstudentAssingment).HasColumnName("IDStudentAssingment");

                entity.Property(e => e.AssingmentId).HasColumnName("AssingmentID");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdate).HasColumnType("date");

                entity.Property(e => e.DeadlineId).HasColumnName("DeadlineID");

                entity.Property(e => e.ExecutionDate).HasColumnType("date");

                entity.Property(e => e.PaymentMethodId).HasColumnName("PaymentMethodID");

                entity.Property(e => e.PaymentStatusId).HasColumnName("paymentStatusID");

                entity.Property(e => e.ReceivingPaymentId).HasColumnName("ReceivingPaymentID");

                entity.Property(e => e.SchoolId).HasColumnName("SchoolID");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.Assingment)
                    .WithMany(p => p.AppStudentAssingments)
                    .HasForeignKey(d => d.AssingmentId)
                    .HasConstraintName("FK_APP_StudentAssingment_APP_CourseAssignments");

                entity.HasOne(d => d.Deadline)
                    .WithMany(p => p.AppStudentAssingments)
                    .HasForeignKey(d => d.DeadlineId)
                    .HasConstraintName("FK_APP_StudentAssingment_T_TypeDeadLine");

                entity.HasOne(d => d.PaymentMethod)
                    .WithMany(p => p.AppStudentAssingments)
                    .HasForeignKey(d => d.PaymentMethodId)
                    .HasConstraintName("FK_APP_StudentAssingment_T_PaymentMethod");

                entity.HasOne(d => d.PaymentStatus)
                    .WithMany(p => p.AppStudentAssingments)
                    .HasForeignKey(d => d.PaymentStatusId)
                    .HasConstraintName("FK_APP_StudentAssingment_T_PaymentStatus");

                entity.HasOne(d => d.ReceivingPayment)
                    .WithMany(p => p.AppStudentAssingmentReceivingPayments)
                    .HasForeignKey(d => d.ReceivingPaymentId)
                    .HasConstraintName("FK_StudentAssingment_UserPerSchool");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.AppStudentAssingments)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK_APP_StudentAssingment_APP_School");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.AppStudentAssingmentUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_UserCreated_StudentAssingment");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.AppStudentAssingmentUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_UserUpdated_StudentAssingment");
            });

            modelBuilder.Entity<AppStudentAttendance>(entity =>
            {
                entity.HasKey(e => e.IdstudentAttendance)
                    .HasName("PK__APP_Stud__94A7BC933195C646");

                entity.ToTable("APP_StudentAttendance");

                entity.Property(e => e.IdstudentAttendance).HasColumnName("IDStudentAttendance");

                entity.Property(e => e.AttendanceId).HasColumnName("AttendanceID");

                entity.Property(e => e.DailyScheduleId).HasColumnName("DailyScheduleID");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.Attendance)
                    .WithMany(p => p.AppStudentAttendances)
                    .HasForeignKey(d => d.AttendanceId)
                    .HasConstraintName("FK_StudentAttendance_AttendanceMarkings");

                entity.HasOne(d => d.DailySchedule)
                    .WithMany(p => p.AppStudentAttendances)
                    .HasForeignKey(d => d.DailyScheduleId)
                    .HasConstraintName("FK_StudentAttendance_DailySchedule");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.AppStudentAttendances)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_StudentAttendance_Student");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.AppStudentAttendanceUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_StudentAttendance_UserCreated");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.AppStudentAttendanceUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_StudentAttendance_UserUpdated");
            });

            modelBuilder.Entity<AppStudentDailySchedule>(entity =>
            {
                entity.HasKey(e => e.IdstudentDailySchedule)
                    .HasName("PK__APP_Stud__4E9AF987DCC5FABF");

                entity.ToTable("APP_StudentDailySchedule");

                entity.Property(e => e.IdstudentDailySchedule).HasColumnName("IDStudentDailySchedule");

                entity.Property(e => e.DailyScheduleId).HasColumnName("DailyScheduleID");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.DailySchedule)
                    .WithMany(p => p.AppStudentDailySchedules)
                    .HasForeignKey(d => d.DailyScheduleId)
                    .HasConstraintName("FK_StudentDailySchedule_DailySchedule");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.AppStudentDailySchedules)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_StudentDailySchedule_Student");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.AppStudentDailyScheduleUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_StudentDailySchedule_UserCreated");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.AppStudentDailyScheduleUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_StudentDailySchedule_UserUpdated");
            });

            modelBuilder.Entity<AppStudentPerGroup>(entity =>
            {
                entity.HasKey(e => e.IdstudentPerGroup)
                    .HasName("PK_Table_1");

                entity.ToTable("APP_StudentPerGroup");

                entity.Property(e => e.IdstudentPerGroup).HasColumnName("IDStudentPerGroup");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.Property(e => e.FromDate).HasColumnType("date");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.ToDate).HasColumnType("date");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.AppStudentPerGroups)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_APP_StudentPerGroup_APP_GroupPerYearbook");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.AppStudentPerGroups)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_APP_StudentPerGroup_APP_Student");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.AppStudentPerGroupUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_UserCreated_StudentPerGroup");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.AppStudentPerGroupUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_UserUpdated_StudentPerGroup");
            });

            modelBuilder.Entity<AppStudentPerYearbook>(entity =>
            {
                entity.HasKey(e => e.IdstudentPerYearbook);

                entity.ToTable("APP_StudentPerYearbook");

                entity.Property(e => e.IdstudentPerYearbook).HasColumnName("IDStudentPerYearbook");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdate).HasColumnType("date");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.Property(e => e.YearbookId).HasColumnName("YearbookID");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.AppStudentPerYearbooks)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_StudentPerYearbook_Student");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.AppStudentPerYearbookUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_UserCreated_StudentPerYearbook");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.AppStudentPerYearbookUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_UserUpdated_StudentPerYearbook");

                entity.HasOne(d => d.Yearbook)
                    .WithMany(p => p.AppStudentPerYearbooks)
                    .HasForeignKey(d => d.YearbookId)
                    .HasConstraintName("FK_StudentPerYearbook_Yearbook");
            });

            modelBuilder.Entity<AppTask>(entity =>
            {
                entity.HasKey(e => e.Idtask);

                entity.ToTable("APP_Task");

                entity.Property(e => e.Idtask).HasColumnName("IDTask");

                entity.Property(e => e.CodeTask).HasMaxLength(200);

                entity.Property(e => e.CoordinatorId).HasColumnName("CoordinatorID");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdate).HasColumnType("date");

                entity.Property(e => e.ExecutionTypeOfTaskId).HasColumnName("ExecutionTypeOfTaskID");

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.NameEnglish).HasMaxLength(200);

                entity.Property(e => e.SchoolId).HasColumnName("SchoolID");

                entity.Property(e => e.TypeOfTaskCalculationId).HasColumnName("TypeOfTaskCalculationID");

                entity.Property(e => e.TypeTaskId).HasColumnName("TypeTaskID");

                entity.Property(e => e.UniqueCodeId).HasColumnName("UniqueCodeID");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.Property(e => e.YearBookId).HasColumnName("YearBookID");

                entity.HasOne(d => d.CheckType)
                    .WithMany(p => p.AppTasks)
                    .HasForeignKey(d => d.CheckTypeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_APP_Task_T_CheckType");

                entity.HasOne(d => d.CoordinationType)
                    .WithMany(p => p.AppTasks)
                    .HasForeignKey(d => d.CoordinationTypeId)
                    .HasConstraintName("FK_APP_Task_App_CoordinationType");

                entity.HasOne(d => d.Coordinator)
                    .WithMany(p => p.AppTaskCoordinators)
                    .HasForeignKey(d => d.CoordinatorId)
                    .HasConstraintName("FK_Task_UserPerSchool");

                entity.HasOne(d => d.ExecutionTypeOfTask)
                    .WithMany(p => p.AppTasks)
                    .HasForeignKey(d => d.ExecutionTypeOfTaskId)
                    .HasConstraintName("FK_Task_ExecutionTypeOfTask");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.AppTasks)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK_APP_Task_APP_School");

                entity.HasOne(d => d.TypeOfTaskCalculation)
                    .WithMany(p => p.AppTasks)
                    .HasForeignKey(d => d.TypeOfTaskCalculationId)
                    .HasConstraintName("FK_Task_QuestionsOfTask");

                entity.HasOne(d => d.TypeTask)
                    .WithMany(p => p.AppTasks)
                    .HasForeignKey(d => d.TypeTaskId)
                    .HasConstraintName("FK_APP_Task_TAB_TypeTask");

                entity.HasOne(d => d.UniqueCode)
                    .WithMany(p => p.AppTasks)
                    .HasForeignKey(d => d.UniqueCodeId)
                    .HasConstraintName("FK_Task_APP_UniqueCodeToTask");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.AppTaskUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_UserCreated_Task");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.AppTaskUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_UserUpdated_Task");

                entity.HasOne(d => d.YearBook)
                    .WithMany(p => p.AppTasks)
                    .HasForeignKey(d => d.YearBookId)
                    .HasConstraintName("FK_APP_YearbookPerSchool_APP_Task");
            });

            modelBuilder.Entity<AppTaskExsist>(entity =>
            {
                entity.HasKey(e => e.IdexsistTask)
                    .HasName("PK_App_ExsistTask");

                entity.ToTable("APP_TaskExsist");

                entity.Property(e => e.IdexsistTask).HasColumnName("IDExsistTask");

                entity.Property(e => e.CodeTaskExsist).HasMaxLength(200);

                entity.Property(e => e.CoordinatorId).HasColumnName("CoordinatorID");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateSubmitA).HasColumnType("date");

                entity.Property(e => e.DateSubmitB).HasColumnType("date");

                entity.Property(e => e.DateSubmitC).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.SchoolId).HasColumnName("SchoolID");

                entity.Property(e => e.TaskId).HasColumnName("TaskID");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.Property(e => e.YearBookId).HasColumnName("YearBookID");

                entity.HasOne(d => d.Coordinator)
                    .WithMany(p => p.AppTaskExsistCoordinators)
                    .HasForeignKey(d => d.CoordinatorId)
                    .HasConstraintName("FK_Coordinator_APP_TaskExsist");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.AppTaskExsists)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_APP_GroupSemesterPerCourse_APP_TaskExsist");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.AppTaskExsists)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK_APP_TaskExsist_APP_School");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.AppTaskExsists)
                    .HasForeignKey(d => d.TaskId)
                    .HasConstraintName("FK_APP_TaskExsist_APP_Task");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.AppTaskExsistUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_APP_UserPerSchool_APP_TaskExsist");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.AppTaskExsistUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_APP_UserPerSchool_APP_TaskExsist2");

                entity.HasOne(d => d.YearBook)
                    .WithMany(p => p.AppTaskExsists)
                    .HasForeignKey(d => d.YearBookId)
                    .HasConstraintName("FK_APP_TaskExsist_APP_YearbookPerSchool");
            });

            modelBuilder.Entity<AppTaskToStudent>(entity =>
            {
                entity.HasKey(e => e.IdtaskToStudent)
                    .HasName("PK_APP_TastToStudent");

                entity.ToTable("APP_TaskToStudent");

                entity.Property(e => e.IdtaskToStudent).HasColumnName("IDTaskToStudent");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateNeedSubmit).HasColumnType("date");

                entity.Property(e => e.DateNeedSubmitStr)
                    .HasMaxLength(30)
                    .IsFixedLength(true);

                entity.Property(e => e.DateSubmit).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.Property(e => e.PaymentMethodId).HasColumnName("PaymentMethodID");

                entity.Property(e => e.PaymentStatusId).HasColumnName("PaymentStatusID");

                entity.Property(e => e.ReceivePaymentId).HasColumnName("ReceivePaymentID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.TaskExsistId).HasColumnName("TaskExsistID");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.Property(e => e.YearBookId).HasColumnName("YearBookID");

                entity.HasOne(d => d.PaymentMethod)
                    .WithMany(p => p.AppTaskToStudents)
                    .HasForeignKey(d => d.PaymentMethodId)
                    .HasConstraintName("FK_APP_TasktostudentToPaymentmethod");

                entity.HasOne(d => d.PaymentStatus)
                    .WithMany(p => p.AppTaskToStudents)
                    .HasForeignKey(d => d.PaymentStatusId)
                    .HasConstraintName("FK_APP_TasktostudentToPaymentstatus");

                entity.HasOne(d => d.ReceivePayment)
                    .WithMany(p => p.AppTaskToStudentReceivePayments)
                    .HasForeignKey(d => d.ReceivePaymentId)
                    .HasConstraintName("FK_TaskToStudent_UserPerSchool");

                entity.HasOne(d => d.StatusTaskPerformance)
                    .WithMany(p => p.AppTaskToStudents)
                    .HasForeignKey(d => d.StatusTaskPerformanceId)
                    .HasConstraintName("FK_APP_TaskToStudent_T_StatusTaskPerformance");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.AppTaskToStudents)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_APP_Task_APP_Student");

                entity.HasOne(d => d.TaskExsist)
                    .WithMany(p => p.AppTaskToStudents)
                    .HasForeignKey(d => d.TaskExsistId)
                    .HasConstraintName("FK_APP_TaskToStudent_APP_TaskExsist");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.AppTaskToStudentUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_UserCreated_TaskToStudent");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.AppTaskToStudentUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_UserUpdated_TaskToStudent");

                entity.HasOne(d => d.YearBook)
                    .WithMany(p => p.AppTaskToStudents)
                    .HasForeignKey(d => d.YearBookId)
                    .HasConstraintName("FK_APP_TaskToStudent_APP_YearbookPerSchool");
            });

            modelBuilder.Entity<AppUniqueCode>(entity =>
            {
                entity.HasKey(e => e.IduniqueCode)
                    .HasName("PK_APP_UniqueCodeToTask");

                entity.ToTable("APP_UniqueCode");

                entity.Property(e => e.IduniqueCode).HasColumnName("IDUniqueCode");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.AppUniqueCodes)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_APP_UniqueCode_UserPerCustomer");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.AppUniqueCodeUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_UserCreated_UniqueCode");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.AppUniqueCodeUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_UserUpdated_UniqueCode");
            });

            modelBuilder.Entity<AppUserPerCourse>(entity =>
            {
                entity.HasKey(e => e.IduserPerCourse);

                entity.ToTable("APP_UserPerCourse");

                entity.Property(e => e.IduserPerCourse).HasColumnName("IDUserPerCourse");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.Property(e => e.FromDate).HasColumnType("date");

                entity.Property(e => e.GroupSemesterPerCourseId).HasColumnName("GroupSemesterPerCourseID");

                entity.Property(e => e.ToDate).HasColumnType("date");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.GroupSemesterPerCourse)
                    .WithMany(p => p.AppUserPerCourses)
                    .HasForeignKey(d => d.GroupSemesterPerCourseId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_APP_UserPerCourse_APP_GroupSemesterPerCourse");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.AppUserPerCourseUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_UserCreated_UserPerCourse");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AppUserPerCourseUsers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_APP_UserPerCourse_UserPerCourse");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.AppUserPerCourseUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_UserUpdated_UserPerCourse");
            });

            modelBuilder.Entity<AppUserPerCustomer>(entity =>
            {
                entity.HasKey(e => e.IduserPerCustomer);

                entity.ToTable("APP_UserPerCustomer");

                entity.HasIndex(e => e.IduserPerCustomer, "IX_APP_UserPerCustomer")
                    .IsUnique();

                entity.HasIndex(e => e.UserId, "IX_APP_UserPerCustomer_1")
                    .IsUnique();

                entity.Property(e => e.IduserPerCustomer).HasColumnName("IDUserPerCustomer");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.AppUserPerCustomers)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_UserPerCustomer_Customer");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.AppUserPerCustomerUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_UserCreated_UserPerCustomer");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.AppUserPerCustomer)
                    .HasForeignKey<AppUserPerCustomer>(d => d.UserId)
                    .HasConstraintName("FK_UserPerCustomer_SEC_User");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.AppUserPerCustomerUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_UserUpdated_UserPerCustomer");
            });

            modelBuilder.Entity<AppUserPerGroup>(entity =>
            {
                entity.HasKey(e => e.IduserPerGroup);

                entity.ToTable("APP_UserPerGroup");

                entity.Property(e => e.IduserPerGroup).HasColumnName("IDUserPerGroup");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.Property(e => e.FromDate).HasColumnType("date");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.ToDate).HasColumnType("date");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.AppUserPerGroups)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_APP_UserPerGroup_APP_GroupPerYearbook");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.AppUserPerGroupUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_UserCreated_UserPerGroup");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AppUserPerGroupUsers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_APP_UserPerCourse_APP_UserPerGroup");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.AppUserPerGroupUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_UserUpdated_UserPerGroup");
            });

            modelBuilder.Entity<AppUserPerSchool>(entity =>
            {
                entity.HasKey(e => e.IduserPerSchool);

                entity.ToTable("APP_UserPerSchool");

                entity.Property(e => e.IduserPerSchool).HasColumnName("IDUserPerSchool");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.BirthId).HasColumnName("BirthID");

                entity.Property(e => e.ContactInformationId).HasColumnName("ContactInformationID");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateOfStartWork).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.Property(e => e.DegreeId).HasColumnName("DegreeID");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.ForeignFirstName).HasMaxLength(200);

                entity.Property(e => e.ForeignLastName).HasMaxLength(200);

                entity.Property(e => e.FullName).HasMaxLength(100);

                entity.Property(e => e.GenderId).HasColumnName("GenderID");

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.PreviusName).HasMaxLength(100);

                entity.Property(e => e.SchoolId).HasColumnName("SchoolID");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.TypeUserId).HasColumnName("TypeUserID");

                entity.Property(e => e.UniqueCodeId).HasColumnName("UniqueCodeID");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserUpdetedId).HasColumnName("UserUpdetedID");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.AppUserPerSchools)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK_APP_UserPerSchool_Address");

                entity.HasOne(d => d.Birth)
                    .WithMany(p => p.AppUserPerSchools)
                    .HasForeignKey(d => d.BirthId)
                    .HasConstraintName("FK_APP_UserPerSchool_Birth");

                entity.HasOne(d => d.ContactInformation)
                    .WithMany(p => p.AppUserPerSchools)
                    .HasForeignKey(d => d.ContactInformationId)
                    .HasConstraintName("FK_APP_UserPerSchool_ContactInformation");

                entity.HasOne(d => d.Degree)
                    .WithMany(p => p.AppUserPerSchools)
                    .HasForeignKey(d => d.DegreeId)
                    .HasConstraintName("FK_UserPerSchool_Degree");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.AppUserPerSchools)
                    .HasForeignKey(d => d.GenderId)
                    .HasConstraintName("FK_APP_UserPerSchool_Gender");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.AppUserPerSchools)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK_APP_UserPerSchool_School");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.AppUserPerSchools)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_UserPerSchool_Status");

                entity.HasOne(d => d.TypeUser)
                    .WithMany(p => p.AppUserPerSchools)
                    .HasForeignKey(d => d.TypeUserId)
                    .HasConstraintName("FK_UserPerSchool_TypeUser");

                entity.HasOne(d => d.UniqueCode)
                    .WithMany(p => p.AppUserPerSchools)
                    .HasForeignKey(d => d.UniqueCodeId)
                    .HasConstraintName("FK_APP_UserPerSchool_UniqueCode");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.InverseUserCreated)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_APP_UserPerSchool_UserPerSchool1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AppUserPerSchools)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_APP_UserPerSchool_User");

                entity.HasOne(d => d.UserUpdeted)
                    .WithMany(p => p.InverseUserUpdeted)
                    .HasForeignKey(d => d.UserUpdetedId)
                    .HasConstraintName("FK_APP_UserPerSchool_UserPerSchool2");
            });

            modelBuilder.Entity<AppUserPerYearbook>(entity =>
            {
                entity.HasKey(e => e.IduserPerYearbook);

                entity.ToTable("APP_UserPerYearbook");

                entity.HasIndex(e => new { e.UserId, e.YearbookId }, "IX_APP_UserPerYearbook")
                    .IsUnique();

                entity.Property(e => e.IduserPerYearbook).HasColumnName("IDUserPerYearbook");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.Property(e => e.YearbookId).HasColumnName("YearbookID");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.AppUserPerYearbookUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_UserCreated_UserPerYearbook");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AppUserPerYearbookUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_UserPerYearbook_UserPerSchool");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.AppUserPerYearbookUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_UserUpdated_UserPerYearbook");

                entity.HasOne(d => d.Yearbook)
                    .WithMany(p => p.AppUserPerYearbooks)
                    .HasForeignKey(d => d.YearbookId)
                    .HasConstraintName("FK_APP_UserPerYearbook1");
            });

            modelBuilder.Entity<AppUserPremission>(entity =>
            {
                entity.HasKey(e => e.IduserPermission);

                entity.ToTable("APP_UserPremission");

                entity.Property(e => e.IduserPermission).HasColumnName("IDUserPermission");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.Property(e => e.PermissionId).HasColumnName("PermissionID");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.AppUserPremissionUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_UserCreated_UserPremission");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AppUserPremissionUsers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserPremission_UserPerSchool");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.AppUserPremissionUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_UserUpdated_UserPremission");
            });

            modelBuilder.Entity<AppVoiceSpace>(entity =>
            {
                entity.HasKey(e => e.IdvoiseSpace);

                entity.ToTable("APP_VoiceSpace");

                entity.Property(e => e.IdvoiseSpace).HasColumnName("IDVoiseSpace");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.AppVoiceSpaceUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_UserCreated_VoiceSpace");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.AppVoiceSpaceUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_UserUpdated_VoiceSpace");
            });

            modelBuilder.Entity<AppYearbook>(entity =>
            {
                entity.HasKey(e => e.Idyearbook);

                entity.ToTable("APP_Yearbook");

                entity.Property(e => e.Idyearbook).HasColumnName("IDYearbook");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.Property(e => e.FromDate).HasColumnType("date");

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.ToDate).HasColumnType("date");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.AppYearbookUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_UserCreated_Yearbook");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.AppYearbookUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_UserUpdated_Yearbook");
            });

            modelBuilder.Entity<AppYearbookPerSchool>(entity =>
            {
                entity.HasKey(e => e.IdyearbookPerSchool);

                entity.ToTable("APP_YearbookPerSchool");

                entity.Property(e => e.IdyearbookPerSchool).HasColumnName("IDYearbookPerSchool");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdete).HasColumnType("date");

                entity.Property(e => e.FromDate).HasColumnType("date");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.SchoolId).HasColumnName("SchoolID");

                entity.Property(e => e.ToDate).HasColumnType("date");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.Property(e => e.YearbookId).HasColumnName("YearbookID");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.AppYearbookPerSchools)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK_APP_YearbookPerSchool_APP_School");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.AppYearbookPerSchoolUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_UserCreated_YearbookPerSchool");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.AppYearbookPerSchoolUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_UserUpdated_YearbookPerSchool");

                entity.HasOne(d => d.Yearbook)
                    .WithMany(p => p.AppYearbookPerSchools)
                    .HasForeignKey(d => d.YearbookId)
                    .HasConstraintName("FK_YearbookPerSchool_Yearbook");
            });

            modelBuilder.Entity<CheckType>(entity =>
            {
                entity.HasKey(e => e.IdcheckType);

                entity.ToTable("CheckType");

                entity.Property(e => e.IdcheckType)
                    .ValueGeneratedNever()
                    .HasColumnName("IDCheckType");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Field>(entity =>
            {
                entity.ToTable("Field");

                entity.Property(e => e.FieldId).HasColumnName("FieldID");

                entity.Property(e => e.FieldName).IsRequired();
            });

            modelBuilder.Entity<SecUser>(entity =>
            {
                entity.HasKey(e => e.Iduser);

                entity.ToTable("SEC_User");

                entity.Property(e => e.Iduser).HasColumnName("IDUser");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.Property(e => e.TypeIdentityId).HasColumnName("TypeIdentityID");

                entity.Property(e => e.Tz)
                    .HasMaxLength(50)
                    .HasColumnName("TZ");

                entity.Property(e => e.UserCode).HasMaxLength(50);

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserPassword).HasMaxLength(50);

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.TypeIdentity)
                    .WithMany(p => p.SecUsers)
                    .HasForeignKey(d => d.TypeIdentityId)
                    .HasConstraintName("FK_APP_User_TypeIdentity");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.SecUserUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_UserCreated_User");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.SecUserUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_UserUpdated_User");
            });

            modelBuilder.Entity<TCategory>(entity =>
            {
                entity.HasKey(e => e.Idcategory)
                    .HasName("PK_T_Kategory");

                entity.ToTable("T_Category");

                entity.Property(e => e.Idcategory).HasColumnName("IDCategory");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<TCheckType>(entity =>
            {
                entity.HasKey(e => e.IdcheckType);

                entity.ToTable("T_CheckType");

                entity.Property(e => e.IdcheckType).HasColumnName("IDCheckType");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<TCourseField>(entity =>
            {
                entity.HasKey(e => e.CourseFieldId);

                entity.ToTable("T_CourseField", "Curr");

                entity.Property(e => e.CourseFieldId).HasColumnName("CourseFieldID");

                entity.Property(e => e.CourseFieldDes).IsRequired();
            });

            modelBuilder.Entity<TDynamicDetailsForTypeSchool>(entity =>
            {
                entity.HasKey(e => e.IddynamicDetailsForTypeSchool);

                entity.ToTable("T_DynamicDetailsForTypeSchool");

                entity.Property(e => e.IddynamicDetailsForTypeSchool).HasColumnName("IDDynamicDetailsForTypeSchool");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<TEasement>(entity =>
            {
                entity.HasKey(e => e.Ideasement);

                entity.ToTable("T_Easement");

                entity.Property(e => e.Ideasement).HasColumnName("IDEasement");

                entity.Property(e => e.EasementName).HasMaxLength(50);
            });

            modelBuilder.Entity<TGender>(entity =>
            {
                entity.HasKey(e => e.Idgender)
                    .HasName("PK_TAB_Gender");

                entity.ToTable("T_Gender");

                entity.Property(e => e.Idgender).HasColumnName("IDGender");

                entity.Property(e => e.Name).HasMaxLength(10);
            });

            modelBuilder.Entity<TLearningStyle>(entity =>
            {
                entity.HasKey(e => e.IdlearningStyle);

                entity.ToTable("T_LearningStyle");

                entity.Property(e => e.IdlearningStyle).HasColumnName("IDLearningStyle");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<TPaymentMethod>(entity =>
            {
                entity.HasKey(e => e.IdpaymentMethod);

                entity.ToTable("T_PaymentMethod");

                entity.Property(e => e.IdpaymentMethod).HasColumnName("IDPaymentMethod");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<TPaymentStatus>(entity =>
            {
                entity.HasKey(e => e.IdpaymentStatus);

                entity.ToTable("T_PaymentStatus");

                entity.Property(e => e.IdpaymentStatus).HasColumnName("IDPaymentStatus");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<TReasonForLeaving>(entity =>
            {
                entity.HasKey(e => e.IdreasonForLeaving);

                entity.ToTable("T_ReasonForLeaving");

                entity.Property(e => e.IdreasonForLeaving).HasColumnName("IDReasonForLeaving");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.SchoolId).HasColumnName("SchoolID");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.TReasonForLeavings)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK_ReasonForLeaving_School");
            });

            modelBuilder.Entity<TRestrictionType>(entity =>
            {
                entity.HasKey(e => e.RestrictionTypeId);

                entity.ToTable("T_RestrictionType", "Curr");

                entity.Property(e => e.RestrictionTypeId).HasColumnName("RestrictionTypeID");

                entity.Property(e => e.RestrictionTypeDes).IsRequired();
            });

            modelBuilder.Entity<TSchoolType>(entity =>
            {
                entity.HasKey(e => e.IdtypeSchool);

                entity.ToTable("T_SchoolType");

                entity.Property(e => e.IdtypeSchool).HasColumnName("IDTypeSchool");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<TStandard>(entity =>
            {
                entity.HasKey(e => e.Idstandard)
                    .HasName("PK_Standard");

                entity.ToTable("T_Standard");

                entity.Property(e => e.Idstandard).HasColumnName("IDStandard");

                entity.Property(e => e.StandardName).HasMaxLength(50);
            });

            modelBuilder.Entity<TStatus>(entity =>
            {
                entity.HasKey(e => e.Idstatus)
                    .HasName("PK_TAB_Status");

                entity.ToTable("T_Status");

                entity.Property(e => e.Idstatus).HasColumnName("IDStatus");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<TStatusAplication>(entity =>
            {
                entity.HasKey(e => e.IdstatusApp);

                entity.ToTable("T_StatusAplication");

                entity.Property(e => e.IdstatusApp).HasColumnName("IDStatusApp");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<TStatusAppel>(entity =>
            {
                entity.HasKey(e => e.IdstatusAppel);

                entity.ToTable("T_StatusAppel");

                entity.Property(e => e.IdstatusAppel).HasColumnName("IDStatusAppel");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<TStatusStudent>(entity =>
            {
                entity.HasKey(e => e.IdstatusStudent);

                entity.ToTable("T_StatusStudent");

                entity.Property(e => e.IdstatusStudent).HasColumnName("IDStatusStudent");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<TStatusTaskPerformance>(entity =>
            {
                entity.ToTable("T_StatusTaskPerformance");

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.IsDefault).HasColumnName("isDefault");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Mosad)
                    .WithMany(p => p.TStatusTaskPerformances)
                    .HasForeignKey(d => d.MosadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_T_StatusTaskPerformance_APP_School");
            });

            modelBuilder.Entity<TTypeAssingment>(entity =>
            {
                entity.HasKey(e => e.IdtypeAssingment);

                entity.ToTable("T_TypeAssingment");

                entity.Property(e => e.IdtypeAssingment).HasColumnName("IDTypeAssingment");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<TTypeContact>(entity =>
            {
                entity.HasKey(e => e.IdtypeContact);

                entity.ToTable("T_TypeContact");

                entity.Property(e => e.IdtypeContact).HasColumnName("IDTypeContact");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.SchoolId).HasColumnName("SchoolID");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.TTypeContacts)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK_T_TypeContact_APP_School");
            });

            modelBuilder.Entity<TTypeDeadLine>(entity =>
            {
                entity.HasKey(e => e.IdtypeDeadline0);

                entity.ToTable("T_TypeDeadLine");

                entity.Property(e => e.IdtypeDeadline0).HasColumnName("IDTypeDeadline0");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<TTypeIdentity>(entity =>
            {
                entity.HasKey(e => e.IdtypeIdentity)
                    .HasName("PK_TTTAB_TypeIdentity");

                entity.ToTable("T_TypeIdentity");

                entity.Property(e => e.IdtypeIdentity).HasColumnName("IDTypeIdentity");

                entity.Property(e => e.Name).HasMaxLength(20);
            });

            modelBuilder.Entity<TTypePresence>(entity =>
            {
                entity.HasKey(e => e.IdtypePresence)
                    .HasName("PK__T_TypePr__AD0F24A1C9E8511B");

                entity.ToTable("T_TypePresence");

                entity.Property(e => e.IdtypePresence).HasColumnName("IDTypePresence");

                entity.Property(e => e.TypePresenceDes).HasMaxLength(100);
            });

            modelBuilder.Entity<TTypeYear>(entity =>
            {
                entity.HasKey(e => e.IdtypeYears);

                entity.ToTable("T_TypeYear");

                entity.Property(e => e.IdtypeYears).HasColumnName("IDTypeYears");
            });

            modelBuilder.Entity<TabAgeGroup>(entity =>
            {
                entity.HasKey(e => e.IdageGroup);

                entity.ToTable("TAB_AgeGroup");

                entity.Property(e => e.IdageGroup).HasColumnName("IDAgeGroup");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.SchoolId).HasColumnName("SchoolID");

                entity.HasOne(d => d.CoordinationType)
                    .WithMany(p => p.TabAgeGroups)
                    .HasForeignKey(d => d.CoordinationTypeId)
                    .HasConstraintName("FK_TAB_AgeGroup_App_CoordinationType");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.TabAgeGroups)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK_AgeGroup_School");
            });

            modelBuilder.Entity<TabAttendanceMarking>(entity =>
            {
                entity.HasKey(e => e.IdattendanceMarkings)
                    .HasName("PK__APP_Atte__BEFA1CAB7138FDF1");

                entity.ToTable("TAB_AttendanceMarkings");

                entity.Property(e => e.IdattendanceMarkings).HasColumnName("IDAttendanceMarkings");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.Property(e => e.MarkingName).HasMaxLength(200);

                entity.Property(e => e.MarkingTypeId).HasColumnName("MarkingTypeID");

                entity.Property(e => e.MarkupDisplay).HasMaxLength(50);

                entity.Property(e => e.SchoolId).HasColumnName("SchoolID");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.TabAttendanceMarkings)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_TAB_AttendanceMarkings_APP_GroupSemesterPerCourse");

                entity.HasOne(d => d.MarkingType)
                    .WithMany(p => p.TabAttendanceMarkings)
                    .HasForeignKey(d => d.MarkingTypeId)
                    .HasConstraintName("FK_AttendanceMarkings_TypeAttendanceMarkings");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.TabAttendanceMarkings)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK_AttendanceMarkings_School");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.TabAttendanceMarkingUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_AttendanceMarkings_UserCreated");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.TabAttendanceMarkingUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_AttendanceMarkings_UserUpdated");
            });

            modelBuilder.Entity<TabCitizenship>(entity =>
            {
                entity.HasKey(e => e.Idcitizenship);

                entity.ToTable("TAB_Citizenship");

                entity.Property(e => e.Idcitizenship).HasColumnName("IDCitizenship");

                entity.Property(e => e.Name).HasMaxLength(200);
            });

            modelBuilder.Entity<TabCity>(entity =>
            {
                entity.HasKey(e => e.Idcity);

                entity.ToTable("TAB_City");

                entity.Property(e => e.Idcity)
                    .ValueGeneratedNever()
                    .HasColumnName("IDCity");

                entity.Property(e => e.Name).HasMaxLength(200);
            });

            modelBuilder.Entity<TabCountry>(entity =>
            {
                entity.HasKey(e => e.Idcountry);

                entity.ToTable("TAB_Country");

                entity.Property(e => e.Idcountry)
                    .ValueGeneratedNever()
                    .HasColumnName("IDCountry");

                entity.Property(e => e.Name).HasMaxLength(200);
            });

            modelBuilder.Entity<TabDegree>(entity =>
            {
                entity.HasKey(e => e.Iddegree);

                entity.ToTable("TAB_Degree");

                entity.Property(e => e.Iddegree).HasColumnName("IDDegree");

                entity.Property(e => e.Name).HasMaxLength(200);
            });

            modelBuilder.Entity<TabExecutionTypeOfTask>(entity =>
            {
                entity.HasKey(e => e.IdexecutionTypeOfTask);

                entity.ToTable("TAB_ExecutionTypeOfTask");

                entity.Property(e => e.IdexecutionTypeOfTask).HasColumnName("IDExecutionTypeOfTask");

                entity.Property(e => e.Name).HasMaxLength(200);
            });

            modelBuilder.Entity<TabListeningTime>(entity =>
            {
                entity.HasKey(e => e.IdlisteningTime);

                entity.ToTable("TAB_ListeningTime");

                entity.Property(e => e.IdlisteningTime).HasColumnName("IDListeningTime");
            });

            modelBuilder.Entity<TabNeighborhood>(entity =>
            {
                entity.HasKey(e => e.Idneighborhood);

                entity.ToTable("TAB_Neighborhood");

                entity.Property(e => e.Idneighborhood).HasColumnName("IDNeighborhood");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.TabNeighborhoods)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK_TAB_Neighborhood_TAB_City");
            });

            modelBuilder.Entity<TabProfessionCategory>(entity =>
            {
                entity.HasKey(e => e.IdProfessionCategory);

                entity.ToTable("TAB_ProfessionCategory");

                entity.Property(e => e.Name).HasMaxLength(500);

                entity.Property(e => e.SchoolId).HasColumnName("SchoolID");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.TabProfessionCategories)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK_ProfessionCategory_School");
            });

            modelBuilder.Entity<TabRequiredDocumentPerCourse>(entity =>
            {
                entity.HasKey(e => e.IdrequiredDocumentPerCourse)
                    .HasName("PK_RequiredDocumentPerCourse");

                entity.ToTable("TAB_RequiredDocumentPerCourse");

                entity.Property(e => e.IdrequiredDocumentPerCourse).HasColumnName("IDRequiredDocumentPerCourse");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.SchoolId).HasColumnName("SchoolID");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.TabRequiredDocumentPerCourses)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK_TAB_RequiredDocumentPerCourse_APP_School");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.TabRequiredDocumentPerCourseUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_UserCreated_RequiredDocumentPerCourse");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.TabRequiredDocumentPerCourseUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_UserUpdated_RequiredDocumentPerCourse");
            });

            modelBuilder.Entity<TabRequiredDocumentPerFatherCourse>(entity =>
            {
                entity.HasKey(e => e.IdrequiredDocumentPerFatherCourse)
                    .HasName("PK_RequiredDocumentPerFatherCourse");

                entity.ToTable("TAB_RequiredDocumentPerFatherCourse");

                entity.Property(e => e.IdrequiredDocumentPerFatherCourse).HasColumnName("IDRequiredDocumentPerFatherCourse");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.SchoolId).HasColumnName("SchoolID");

                entity.Property(e => e.UniqueCodeId).HasColumnName("UniqueCodeID");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.TabRequiredDocumentPerFatherCourses)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK_TAB_RequiredDocumentPerFatherCourse_APP_School");

                entity.HasOne(d => d.UniqueCode)
                    .WithMany(p => p.TabRequiredDocumentPerFatherCourses)
                    .HasForeignKey(d => d.UniqueCodeId)
                    .HasConstraintName("FK_RequiredDocumentPerFatherCourse_APP_UniqueCodeToTask");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.TabRequiredDocumentPerFatherCourseUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_UserCreated_RequiredDocumentPerFatherCourse");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.TabRequiredDocumentPerFatherCourseUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_UserUpdated_RequiredDocumentPerFatherCourse");
            });

            modelBuilder.Entity<TabRequiredDocumentPerGroup>(entity =>
            {
                entity.HasKey(e => e.IdrequiredDocumentPerGroup)
                    .HasName("PK_RequiredDocumentPerGroup");

                entity.ToTable("TAB_RequiredDocumentPerGroup");

                entity.Property(e => e.IdrequiredDocumentPerGroup).HasColumnName("IDRequiredDocumentPerGroup");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.SchoolId).HasColumnName("SchoolID");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.TabRequiredDocumentPerGroups)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK_TAB_RequiredDocumentPerGroup_APP_School");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.TabRequiredDocumentPerGroupUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_UserCreated_RequiredDocumentPerGroup");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.TabRequiredDocumentPerGroupUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_UserUpdated_RequiredDocumentPerGroup");
            });

            modelBuilder.Entity<TabRequiredDocumentPerProfession>(entity =>
            {
                entity.HasKey(e => e.IdrequiredDocumentPerProfession)
                    .HasName("PK_RequiredDocumentPerProfession");

                entity.ToTable("TAB_RequiredDocumentPerProfession");

                entity.Property(e => e.IdrequiredDocumentPerProfession).HasColumnName("IDRequiredDocumentPerProfession");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.SchoolId).HasColumnName("SchoolID");

                entity.Property(e => e.UniqueCodeId).HasColumnName("UniqueCodeID");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.TabRequiredDocumentPerProfessions)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK_TAB_RequiredDocumentPerProfession_APP_School");

                entity.HasOne(d => d.UniqueCode)
                    .WithMany(p => p.TabRequiredDocumentPerProfessions)
                    .HasForeignKey(d => d.UniqueCodeId)
                    .HasConstraintName("FK_RequiredDocumentPerProfession_APP_UniqueCodeToProfession");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.TabRequiredDocumentPerProfessionUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_UserCreated_RequiredDocumentPerProfession");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.TabRequiredDocumentPerProfessionUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_UserUpdated_RequiredDocumentPerProfession");
            });

            modelBuilder.Entity<TabRequiredDocumentPerSchool>(entity =>
            {
                entity.HasKey(e => e.IdrequiredDocumentPerSchool)
                    .HasName("PK_RequiredDocumentPerSchool");

                entity.ToTable("TAB_RequiredDocumentPerSchool");

                entity.Property(e => e.IdrequiredDocumentPerSchool).HasColumnName("IDRequiredDocumentPerSchool");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.SchoolId).HasColumnName("SchoolID");

                entity.Property(e => e.UniqueCodeId).HasColumnName("UniqueCodeID");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.TabRequiredDocumentPerSchools)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK_TAB_RequiredDocumentPerSchool_APP_School");

                entity.HasOne(d => d.UniqueCode)
                    .WithMany(p => p.TabRequiredDocumentPerSchools)
                    .HasForeignKey(d => d.UniqueCodeId)
                    .HasConstraintName("FK_RequiredDocumentPerSchool_APP_UniqueCodeToSchool");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.TabRequiredDocumentPerSchoolUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_UserCreated_RequiredDocumentPerSchool");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.TabRequiredDocumentPerSchoolUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_UserUpdated_RequiredDocumentPerSchool");
            });

            modelBuilder.Entity<TabRequiredDocumentPerStudent>(entity =>
            {
                entity.HasKey(e => e.IdrequiredDocumentPerStudent)
                    .HasName("PK_RequiredDocumentPerStudent");

                entity.ToTable("TAB_RequiredDocumentPerStudent");

                entity.Property(e => e.IdrequiredDocumentPerStudent).HasColumnName("IDRequiredDocumentPerStudent");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.SchoolId).HasColumnName("SchoolID");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.TabRequiredDocumentPerStudents)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK_TAB_RequiredDocumentPerStudent_APP_School");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.TabRequiredDocumentPerStudentUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_UserCreated_RequiredDocumentPerStudent");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.TabRequiredDocumentPerStudentUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_UserUpdated_RequiredDocumentPerStudent");
            });

            modelBuilder.Entity<TabRequiredDocumentPerTask>(entity =>
            {
                entity.HasKey(e => e.IdrequiredDocumentPerTask)
                    .HasName("PK_RequiredDocumentPerTask");

                entity.ToTable("TAB_RequiredDocumentPerTask");

                entity.Property(e => e.IdrequiredDocumentPerTask).HasColumnName("IDRequiredDocumentPerTask");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.SchoolId).HasColumnName("SchoolID");

                entity.Property(e => e.UniqueCodeId).HasColumnName("UniqueCodeID");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.TabRequiredDocumentPerTasks)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK_TAB_RequiredDocumentPerTask_APP_School");

                entity.HasOne(d => d.UniqueCode)
                    .WithMany(p => p.TabRequiredDocumentPerTasks)
                    .HasForeignKey(d => d.UniqueCodeId)
                    .HasConstraintName("FK_RequiredDocumentPerTask_APP_UniqueCodeToTask");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.TabRequiredDocumentPerTaskUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_UserCreated_RequiredDocumentPerTask");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.TabRequiredDocumentPerTaskUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_UserUpdated_RequiredDocumentPerTask");
            });

            modelBuilder.Entity<TabRequiredDocumentPerTaskExsist>(entity =>
            {
                entity.HasKey(e => e.IdrequiredDocumentPerTaskExsist)
                    .HasName("PK_RequiredDocumentPerTaskExsist");

                entity.ToTable("TAB_RequiredDocumentPerTaskExsist");

                entity.Property(e => e.IdrequiredDocumentPerTaskExsist).HasColumnName("IDRequiredDocumentPerTaskExsist");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.SchoolId).HasColumnName("SchoolID");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.TabRequiredDocumentPerTaskExsists)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK_TAB_RequiredDocumentPerTaskExsist_APP_School");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.TabRequiredDocumentPerTaskExsistUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_UserCreated_RequiredDocumentPerTaskExsist");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.TabRequiredDocumentPerTaskExsistUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_UserUpdated_RequiredDocumentPerTaskExsist");
            });

            modelBuilder.Entity<TabRequiredDocumentPerUser>(entity =>
            {
                entity.HasKey(e => e.IdrequiredDocumentPerUser)
                    .HasName("PK_RequiredDocumentPerUser");

                entity.ToTable("TAB_RequiredDocumentPerUser");

                entity.Property(e => e.IdrequiredDocumentPerUser).HasColumnName("IDRequiredDocumentPerUser");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.SchoolId).HasColumnName("SchoolID");

                entity.Property(e => e.UniqueCodeId).HasColumnName("UniqueCodeID");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.TabRequiredDocumentPerUsers)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK_TAB_RequiredDocumentPerUser_APP_School");

                entity.HasOne(d => d.UniqueCode)
                    .WithMany(p => p.TabRequiredDocumentPerUsers)
                    .HasForeignKey(d => d.UniqueCodeId)
                    .HasConstraintName("FK_RequiredDocumentPerUser_APP_UniqueCodeToTask");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.TabRequiredDocumentPerUserUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_UserCreated_RequiredDocumentPerUser");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.TabRequiredDocumentPerUserUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_UserUpdated_RequiredDocumentPerUser");
            });

            modelBuilder.Entity<TabStreet>(entity =>
            {
                entity.HasKey(e => e.Idstreet);

                entity.ToTable("TAB_Street");

                entity.HasIndex(e => new { e.CodeStreet, e.CityId }, "Street_City_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Idstreet).HasColumnName("IDStreet");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.TabStreets)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TAB_Street_TAB_City");
            });

            modelBuilder.Entity<TabTaskExecutionStatus>(entity =>
            {
                entity.HasKey(e => e.IdtaskExecutionStatus);

                entity.ToTable("TAB_TaskExecutionStatus");

                entity.Property(e => e.IdtaskExecutionStatus).HasColumnName("IDTaskExecutionStatus");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.SchoolId).HasColumnName("SchoolID");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.TabTaskExecutionStatuses)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK_TaskExecutionStatus_School");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.TabTaskExecutionStatusUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_UserCreated_TaskExecutionStatus");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.TabTaskExecutionStatusUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_UserUpdated_TaskExecutionStatus");
            });

            modelBuilder.Entity<TabTypeAttendanceMarking>(entity =>
            {
                entity.HasKey(e => e.IdtypeAttendanceMarking)
                    .HasName("PK__APP_Type__2E540433712C1019");

                entity.ToTable("TAB_TypeAttendanceMarkings");

                entity.Property(e => e.IdtypeAttendanceMarking).HasColumnName("IDTypeAttendanceMarking");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.SchoolId).HasColumnName("SchoolID");

                entity.Property(e => e.TypeAttendanceName).HasMaxLength(200);

                entity.Property(e => e.TypePresenceId).HasColumnName("TypePresenceID");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.TabTypeAttendanceMarkings)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK_TypeAttendanceMarkings_School");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.TabTypeAttendanceMarkingUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_TypeAttendanceMarkings_UserCreated");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.TabTypeAttendanceMarkingUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_TypeAttendanceMarkings_UserUpdated");
            });

            modelBuilder.Entity<TabTypeGroup>(entity =>
            {
                entity.HasKey(e => e.IdtypeGroup);

                entity.ToTable("TAB_TypeGroup");

                entity.Property(e => e.IdtypeGroup).HasColumnName("IDTypeGroup");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.SchoolId).HasColumnName("SchoolID");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.CoordinationType)
                    .WithMany(p => p.TabTypeGroups)
                    .HasForeignKey(d => d.CoordinationTypeId)
                    .HasConstraintName("FK_TAB_TypeGroup_App_CoordinationType");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.TabTypeGroups)
                    .HasForeignKey(d => d.SchoolId)
                    .HasConstraintName("FK_TAB_TypeGroup_APP_School");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.TabTypeGroupUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_UserCreated_TypeGroup");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.TabTypeGroupUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_UserUpdated_TypeGroup");
            });

            modelBuilder.Entity<TabTypeOfTaskCalculation>(entity =>
            {
                entity.HasKey(e => e.IdtypeOfTaskCalculation)
                    .HasName("PK_TypeOfTaskCalculation");

                entity.ToTable("TAB_TypeOfTaskCalculation");

                entity.Property(e => e.IdtypeOfTaskCalculation).HasColumnName("IDTypeOfTaskCalculation");

                entity.Property(e => e.Name).HasMaxLength(200);
            });

            modelBuilder.Entity<TabTypeQuestion>(entity =>
            {
                entity.HasKey(e => e.IdtypeQuestion)
                    .HasName("PK__TAB_Type__7F7657EA3022DDE0");

                entity.ToTable("TAB_TypeQuestion");

                entity.Property(e => e.IdtypeQuestion).HasColumnName("IDTypeQuestion");

                entity.Property(e => e.Name).HasMaxLength(200);
            });

            modelBuilder.Entity<TabTypeTask>(entity =>
            {
                entity.HasKey(e => e.IdtypeTask);

                entity.ToTable("TAB_TypeTask");

                entity.Property(e => e.IdtypeTask).HasColumnName("IDTypeTask");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.TabTypeTaskUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_UserCreated_TypeTask");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.TabTypeTaskUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_UserUpdated_TypeTask");
            });

            modelBuilder.Entity<TabTypeUser>(entity =>
            {
                entity.HasKey(e => e.IdtypeUser);

                entity.ToTable("TAB_TypeUser");

                entity.Property(e => e.IdtypeUser).HasColumnName("IDTypeUser");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("date");

                entity.Property(e => e.Name).HasMaxLength(500);

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId).HasColumnName("UserUpdatedID");

                entity.HasOne(d => d.UserCreated)
                    .WithMany(p => p.TabTypeUserUserCreateds)
                    .HasForeignKey(d => d.UserCreatedId)
                    .HasConstraintName("FK_UserCreated_TypeUser");

                entity.HasOne(d => d.UserUpdated)
                    .WithMany(p => p.TabTypeUserUserUpdateds)
                    .HasForeignKey(d => d.UserUpdatedId)
                    .HasConstraintName("FK_UserUpdated_TypeUser");
            });

            modelBuilder.Entity<VCodeTable>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_CodeTables");

                entity.Property(e => e.Name).HasMaxLength(500);

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.Table)
                    .IsRequired()
                    .HasMaxLength(21)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ארצות>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ארצות$");

                entity.Property(e => e.ארץבאנגלית)
                    .HasMaxLength(255)
                    .HasColumnName("ארץ_באנגלית");

                entity.Property(e => e.סמלארץ).HasColumnName("סמל_ארץ");

                entity.Property(e => e.שםארץ)
                    .HasMaxLength(255)
                    .HasColumnName("שם_ארץ");
            });

            modelBuilder.Entity<גיליון1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("גיליון1$");

                entity.Property(e => e.Scoolid).HasColumnName("scoolid");
            });

            modelBuilder.Entity<גיליון3>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("גיליון3$");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime");

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.Idsemester).HasColumnName("IDSemester");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.ToDate).HasColumnType("datetime");

                entity.Property(e => e.UserCreatedId)
                    .HasMaxLength(255)
                    .HasColumnName("UserCreatedID");

                entity.Property(e => e.UserUpdatedId)
                    .HasMaxLength(255)
                    .HasColumnName("UserUpdatedID");

                entity.Property(e => e.YearbookId)
                    .HasMaxLength(255)
                    .HasColumnName("YearbookID");
            });

            modelBuilder.Entity<יחי>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("יחי$");

                entity.Property(e => e._6).HasColumnName("6");

                entity.Property(e => e.תוצאותתיל)
                    .HasMaxLength(255)
                    .HasColumnName("תוצאות תיל");
            });

            modelBuilder.Entity<ישובים>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ישובים$");

                entity.Property(e => e.לשכה).HasMaxLength(255);

                entity.Property(e => e.סמלישוב).HasColumnName("סמל_ישוב");

                entity.Property(e => e.סמללשכתמנא).HasColumnName("סמל_לשכת_מנא");

                entity.Property(e => e.סמלמועצהאיזורית).HasColumnName("סמל_מועצה_איזורית");

                entity.Property(e => e.סמלנפה).HasColumnName("סמל_נפה");

                entity.Property(e => e.שםישוב)
                    .HasMaxLength(255)
                    .HasColumnName("שם_ישוב");

                entity.Property(e => e.שםישובלועזי)
                    .HasMaxLength(255)
                    .HasColumnName("שם_ישוב_לועזי");

                entity.Property(e => e.שםמועצה)
                    .HasMaxLength(255)
                    .HasColumnName("שם_מועצה");

                entity.Property(e => e.שםנפה)
                    .HasMaxLength(255)
                    .HasColumnName("שם_נפה");
            });

            modelBuilder.Entity<משתמשים>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("משתמשים$");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateUpdated).HasMaxLength(255);

                entity.Property(e => e.IduserPerYearbook).HasColumnName("IDUserPerYearbook");

                entity.Property(e => e.UserCreatedId).HasColumnName("UserCreatedID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserUpdatedId)
                    .HasMaxLength(255)
                    .HasColumnName("UserUpdatedID");

                entity.Property(e => e.YearbookId).HasColumnName("YearbookID");
            });

            modelBuilder.Entity<רחובות>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("רחובות$");

                entity.Property(e => e.סמלישוב).HasColumnName("סמל_ישוב");

                entity.Property(e => e.סמלרחוב).HasColumnName("סמל_רחוב");

                entity.Property(e => e.שםישוב)
                    .HasMaxLength(255)
                    .HasColumnName("שם_ישוב");

                entity.Property(e => e.שםרחוב)
                    .HasMaxLength(255)
                    .HasColumnName("שם_רחוב");
            });

            modelBuilder.Entity<תלמידות>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("תלמידות$");

                entity.Property(e => e.F5).HasMaxLength(255);

                entity.Property(e => e.מספרנבחנת).HasColumnName("מספר נבחנת");

                entity.Property(e => e.סמינר).HasMaxLength(255);

                entity.Property(e => e.שם).HasMaxLength(255);

                entity.Property(e => e.תז).HasColumnName("ת#ז#");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
