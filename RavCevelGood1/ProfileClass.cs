using AutoMapper;
using DB.Model;
using DTO.Classes;
using DTO.ExcelClasses;
using System;
using System.Linq;

namespace RavCevelGood
{
    public class ProfileClass : Profile
    {
        public int resul;
        public short resul2;
        public double resul3;
        public bool resul5;


        public ProfileClass()
        {
            CreateMap<SecUserDTO, SecUser>().ReverseMap();
            CreateMap<SecUser, SecUserDTO>()
                .ForMember(m => m.FullName, opt => opt.MapFrom(mp => mp.LastName + " " + mp.FirstName))
                .ReverseMap();     
            
            CreateMap<AppUserPerSchool, SecUserDTO>()
                .IncludeMembers(m => m,Op=> Op.User)
                .ForMember(m => m.UserPerSchoolID, opt => opt.MapFrom(mp => mp.IduserPerSchool))
                .ForMember(m => m.UniqueCodeId, opt => opt.MapFrom(mp => mp.UniqueCodeId))
                .ReverseMap();
            CreateMap<SecUserDTO, AppUserPerSchool>().ReverseMap();

            CreateMap<AppSchool, AppSchoolDTO>().ReverseMap();
            CreateMap<AppSchoolDTO, AppSchool>().ReverseMap();

            CreateMap<TabStreet, TAB_StreetDTO>().ReverseMap();
            CreateMap<TAB_StreetDTO, TabStreet>().ReverseMap();




            CreateMap<AppUserPerSchool, SecUserDTO>()
                .IncludeMembers(m => m, opt => opt.User)
                .ForMember(m=> m.SchoolId,opt=>opt.MapFrom(mp=>mp.SchoolId))
                .ForMember(m => m.SchoolName, opt => opt.MapFrom(mp => mp.School.Name))
                .ForMember(m => m.UserPerSchoolID, opt => opt.MapFrom(mp => mp.IduserPerSchool))
                .ReverseMap();

            CreateMap<AppSchool,AppSchoolWhithYearbookDTO>()
                .ForMember(m => m.school, opt => opt.MapFrom(mp => mp))
                .ReverseMap();
            CreateMap<AppSchoolWhithYearbookDTO, AppSchool>().ReverseMap();

            CreateMap<AppSchoolWhithYearbookDTO, AppUserPerSchool>().ReverseMap();
            CreateMap<AppUserPerSchool, AppSchoolWhithYearbookDTO>()
                .ForMember(m => m.school, opt => opt.MapFrom(mp => mp.School))
                .ForMember(m => m.UserId, opt => opt.MapFrom(mp => mp.IduserPerSchool))
                .ForMember(m => m.AppYearbookPerSchools, opt => opt.MapFrom(mp =>mp!=null&&mp.School!=null? mp.School.AppYearbookPerSchools:null))

                .ReverseMap();



            CreateMap<AppYearbook, AppYearbookDTO>().ReverseMap();
            CreateMap<AppYearbookDTO, AppYearbook>().ReverseMap();

            CreateMap<AppSemester, AppSemesterDTO>().ReverseMap();
            CreateMap<AppSemesterDTO, AppSemester>().ReverseMap();

            CreateMap<AppCourse, AppCourseDTO>()
            .ForMember(m => m.SchoolName, opt => opt.MapFrom(mp => mp.School.Name))
            .ForMember(m=>m.ProfessionName,opt=>opt.MapFrom(mp=>mp.Profession.Name))
            .ForMember(m=>m.learningStyleName,opt=>opt.MapFrom(mp=>mp.LearningStyle.Name))

                .ReverseMap();
            CreateMap<AppCourseDTO, AppCourse>().ReverseMap();

            CreateMap<AppYearbookPerSchool, AppYearbookPerSchoolDTO>().ReverseMap();
            CreateMap<AppYearbookPerSchoolDTO, AppYearbookPerSchool>().ReverseMap();

            CreateMap<AppContactInformation, AppContactInformationDTO>().ReverseMap();
            CreateMap<AppContactInformationDTO, AppContactInformation>().ReverseMap();

            CreateMap<AppContactPerStudentDTO, AppContactPerStudent>().ReverseMap();
            CreateMap<AppContactPerStudent, AppContactPerStudentDTO>().ReverseMap();

            CreateMap<CodeTableDTO, VCodeTable>().ReverseMap();
            CreateMap<VCodeTable, CodeTableDTO>().ReverseMap();

            CreateMap<AppStudent, AppStudentDTO>()
                .ForMember(m=>m.SchoolId,opt=>opt.MapFrom(mp=>mp.School!=null?mp.School.Name:""))
                .ReverseMap();
            CreateMap<AppStudentDTO, AppStudent>().ReverseMap();

            CreateMap<SecUser, AppUserPerSchoolWithDetailsDTO>().ReverseMap();
            CreateMap<AppUserPerSchoolWithDetailsDTO, SecUser>().ReverseMap();

            CreateMap<AppUserPerSchool, AppUserPerSchoolWithDetailsDTO>()
           .ReverseMap();
            CreateMap<AppStudentWhithDetailsDTO, AppUserPerSchool>().ReverseMap();


            CreateMap<AppProfession, AppProfessionDTO>()
                 .ForMember(m => m.Coordinator, opt => opt.MapFrom(mp =>mp.Coordinator!=null ? mp.Coordinator.User:null))
                 .ForMember(m=>m.SchoolName,opt=>opt.MapFrom(mp=>mp.School.Name))
                .ReverseMap();
            CreateMap<AppProfessionDTO, AppProfession>()
                .ForMember(m => m.CoordinatorId, opt => opt.MapFrom(mp => mp.Coordinator != null ? mp.Coordinator.UserPerSchoolID : 0))
                .ReverseMap();

            CreateMap<AppTaskDTO, AppTask>().ReverseMap();
            CreateMap<AppTask, AppTaskDTO>()
                .ForMember(m => m.typeTaskName, opt => opt.MapFrom(mp => mp.TypeTask != null ? mp.TypeTask.Name : null))
                .ForMember(m => m.CoordinatorName, opt => opt.MapFrom(mp => mp.Coordinator != null &&
                 mp.Coordinator.User != null ? (mp.Coordinator.User.LastName + " " + mp.Coordinator.User.FirstName) : " "))
                .ForMember(m=>m.SchoolName,opt=>opt.MapFrom(mp=>mp.School!=null?mp.School.Name:""))
                .ReverseMap();

            CreateMap<AppTaskExsistDTO, AppTaskExsist>().ReverseMap();
            CreateMap<AppTaskExsist, AppTaskExsistDTO>()
                  .ForMember(m => m.DateSubmitA, opt => opt.MapFrom(mp => mp.DateSubmitA != null ? new DateTime(mp.DateSubmitA.Value.Year, mp.DateSubmitA.Value.Month, mp.DateSubmitA.Value.Day) : (DateTime?)null))
                  .ForMember(m => m.DateSubmitB, opt => opt.MapFrom(mp => mp.DateSubmitB != null ? new DateTime(mp.DateSubmitB.Value.Year, mp.DateSubmitB.Value.Month, mp.DateSubmitB.Value.Day) : (DateTime?)null))
                  .ForMember(m => m.DateSubmitC, opt => opt.MapFrom(mp => mp.DateSubmitC != null ? new DateTime(mp.DateSubmitC.Value.Year, mp.DateSubmitC.Value.Month, mp.DateSubmitC.Value.Day) : (DateTime?)null))
                  .ForMember(m => m.CourseName, opt => opt.MapFrom(mp => mp.Course != null && mp.Course.Course != null ? mp.Course.Course.Name : null))
                  .ForMember(m => m.PercentsCourse, opt => opt.MapFrom(mp => mp.Course != null && mp.Course.AppTaskExsists != null ? mp.Course.AppTaskExsists.Sum(s=> s.Percents) : mp.Percents))
                .ForMember(m => m.CoordinatorName, opt => opt.MapFrom(mp => mp.Coordinator != null &&
                  mp.Coordinator.User != null ? (mp.Coordinator.User.LastName + " " + mp.Coordinator.User.FirstName) : " "))
                .ReverseMap();

            CreateMap<AppTaskToStudentDTO, AppTaskToStudent>().ReverseMap();
            CreateMap<AppTaskToStudent, AppTaskToStudentDTO>()
                  .ForMember(m => m.studentName, opt => opt.MapFrom(mp => mp.Student != null ? mp.Student.LastName+" "+ mp.Student.FirstName/* + " ," + mp.Student.Tz*/ : null))
                  .ForMember(m => m.PaymentMethodName, opt => opt.MapFrom(mp => mp.PaymentMethod != null ? mp.PaymentMethod.Name : null))
                  .ForMember(m => m.PaymentStatusName, opt => opt.MapFrom(mp => mp.PaymentStatus != null ? mp.PaymentStatus.Name : null))
                  .ForMember(m => m.ReceivePaymentName, opt => opt.MapFrom(mp => mp.ReceivePayment != null && mp.ReceivePayment.User!= null ? mp.ReceivePayment.User.LastName+" "+ mp.ReceivePayment.User.FirstName  : null))
                  .ForMember(m => m.DateNeedSubmitStr, opt => opt.MapFrom(mp => mp.DateNeedSubmitStr.TrimEnd(' ')))
                .ReverseMap();


            CreateMap<TabTypeTask, TabTypeTaskDTO>().ReverseMap();
            CreateMap<TabTypeTaskDTO, TabTypeTask>().ReverseMap();

            CreateMap<TTypeContact, TTypeContactDTO>().ReverseMap();
            CreateMap<TTypeContactDTO, TTypeContact>().ReverseMap();


            CreateMap<AppGroupSemesterPerCourseDTO, AppGroupSemesterPerCourse>().ReverseMap();

            CreateMap<AppGroupSemesterPerCourse, AppGroupSemesterPerCourseDTO>()
                //.ForMember(m => m.ProfessionName, opt => opt.MapFrom(mp => mp.Course != null && mp.Course.Profession != null ? mp.Course.Profession.Name : ""))
                //.ForMember(m => m.BasicGroupId, opt => opt.MapFrom(mp => mp.Group != null ? mp.Group.GroupId : null))
                .ForMember(m => m.GroupName, opt => opt.MapFrom(mp => mp.Group != null ? mp.Group.Group.NameGroup : ""))
                .ForMember(m => m.SemesterName, opt => opt.MapFrom(mp => mp.Semester != null ? mp.Semester.Name : ""))
                .ReverseMap();

            CreateMap<AppStudentWhithDetailsDTO, AppStudent>()
          //.ForPath(m => m.Address.ApartmentNumber, opt => opt.MapFrom(mp => mp.ApartmentNumber))
          //.ForPath(m => m.Address.CityId, opt => opt.MapFrom(mp => mp.CityId))
          //.ForPath(m => m.Address.HouseNumber, opt => opt.MapFrom(mp => mp.HouseNumber))
          //.ForPath(m => m.Address.NeighborhoodId, opt => opt.MapFrom(mp => mp.NeighborhoodId))
          //.ForPath(m => m.Address.PoBox, opt => opt.MapFrom(mp => mp.PoBox))
          //.ForPath(m => m.Address.StreetId, opt => opt.MapFrom(mp => mp.StreetId))
          //.ForPath(m => m.Address.ZipCode, opt => opt.MapFrom(mp => mp.ZipCode))
          //.ForPath(m => m.Birth.BirthCountryId, opt => opt.MapFrom(mp => mp.BirthCountryId))
          //.ForPath(m => m.Birth.BirthDate, opt => opt.MapFrom(mp => mp.BirthDate))
          //.ForPath(m => m.Birth.BirthHebrewDate, opt => opt.MapFrom(mp => mp.BirthHebrewDate))
          //.ForPath(m => m.Birth.CitizenshipId, opt => opt.MapFrom(mp => mp.CitizenshipId))
          //.ForPath(m => m.Birth.CountryIdofImmigration, opt => opt.MapFrom(mp => mp.CountryIDOfImmigration))
          //.ForPath(m => m.Birth.DateOfImmigration, opt => opt.MapFrom(mp => mp.DateOfImmigration))
          //.ForPath(m => m.ContactInformation.Email, opt => opt.MapFrom(mp => mp.Email))
          //.ForPath(m => m.ContactInformation.FaxNumber, opt => opt.MapFrom(mp => mp.FaxNumber))
          //.ForPath(m => m.ContactInformation.PhoneNumber1, opt => opt.MapFrom(mp => mp.PhoneNumber1))
          //.ForPath(m => m.ContactInformation.PhoneNumber2, opt => opt.MapFrom(mp => mp.PhoneNumber2))
          //.ForPath(m => m.ContactInformation.PhoneNumber3, opt => opt.MapFrom(mp => mp.PhoneNumber3))
          //.ForPath(m => m.ContactInformation.TelephoneNumber1, opt => opt.MapFrom(mp => mp.TelephoneNumber1))
          // .ForPath(m => m.ContactInformation.TelephoneNumber2, opt => opt.MapFrom(mp => mp.TelephoneNumber2))
          .ReverseMap();

            CreateMap<AppStudent, AppStudentWhithDetailsDTO>()
                  .ForMember(m => m.ContactPerStudent, opt=>opt.MapFrom( mp=> mp.AppContactPerStudents.ToList()))

                //.ForMember(m => m.Birth.BirthCountryId, opt => opt.MapFrom(mp => mp.Birth.BirthCountryId))
                //.ForMember(m => m.BirthDate, opt => opt.MapFrom(mp => mp.Birth.BirthDate))
                //.ForMember(m => m.BirthHebrewDate, opt => opt.MapFrom(mp => mp.Birth.BirthHebrewDate))
                //.ForMember(m => m.CitizenshipId, opt => opt.MapFrom(mp => mp.Birth.CitizenshipId))
                //.ForMember(m => m.DateOfImmigration, opt => opt.MapFrom(mp => mp.Birth.DateOfImmigration))
                //.ForMember(m => m.CountryIDOfImmigration, opt => opt.MapFrom(mp => mp.Birth.CountryIdofImmigration))
                ////.ForMember(m => m.Age, opt => opt.MapFrom(mp => (DateTime.Now - mp.Birth.BirthDate)))

                //.ForMember(m => m.CityId, opt => opt.MapFrom(mp => mp.Address.CityId))
                //.ForMember(m => m.NeighborhoodId, opt => opt.MapFrom(mp => mp.Address.NeighborhoodId))
                //.ForMember(m => m.StreetId, opt => opt.MapFrom(mp => mp.Address.StreetId))
                //.ForMember(m => m.HouseNumber, opt => opt.MapFrom(mp => mp.Address.HouseNumber))
                //.ForMember(m => m.ApartmentNumber, opt => opt.MapFrom(mp => mp.Address.ApartmentNumber))
                //.ForMember(m => m.PoBox, opt => opt.MapFrom(mp => mp.Address.PoBox))
                //.ForMember(m => m.ZipCode, opt => opt.MapFrom(mp => mp.Address.ZipCode))

                //.ForMember(m => m.TelephoneNumber1, opt => opt.MapFrom(mp => mp.ContactInformation.TelephoneNumber1))
                //.ForMember(m => m.TelephoneNumber2, opt => opt.MapFrom(mp => mp.ContactInformation.TelephoneNumber2))
                //.ForMember(m => m.PhoneNumber1, opt => opt.MapFrom(mp => mp.ContactInformation.PhoneNumber1))
                //.ForMember(m=>m.PhoneNumber2, opt =>opt.MapFrom(mp=>mp.ContactInformation.PhoneNumber2))
                //.ForMember(m=>m.PhoneNumber3, opt=>opt.MapFrom(mp=>mp.ContactInformation.PhoneNumber3))
                //.ForMember(m=>m.FaxNumber, opt =>opt.MapFrom(mp=>mp.ContactInformation.FaxNumber))
                //.ForMember(m=>m.Email, opt =>opt.MapFrom(mp=>mp.ContactInformation.Email))

                .ReverseMap();





            CreateMap<AppStudentXL, AppStudent>()
                //.ForMember(m => m.TypeIdentityId, opt => opt.MapFrom(mp => int.TryParse(mp.TypeIdentity, out resul) ? resul : (int?)null))
                //.ForMember(m => m.ApotropusTypeIdentity, opt => opt.MapFrom(mp =>int.TryParse( mp.ApotropusTypeIdentity, out resul) ? resul : (int?)null))
                //.ForMember(m => m.MotherTypeIdentity, opt => opt.MapFrom(mp => int.TryParse(mp.MotherTypeIdentity, out resul)? resul : (int?) null))
                //.ForMember(m => m.FatherTypeIdentity, opt => opt.MapFrom(mp => int.TryParse(mp.FatherTypeIdentity, out resul) ? resul : (int?)null))
                //.ForMember(m => m.GenderId, opt => opt.MapFrom(mp =>short.TryParse( mp.Gender, out resul2) ? resul2 : (int?)null))
                //.ForMember(m => m.IsActive, opt => opt.MapFrom(mp =>(/*mp.IsActive != null ? bool.TryParse(mp.IsActive) :*/ true)))
                //.ForMember(m => m.StatusId, opt => opt.MapFrom(mp =>int.TryParse( mp.Status, out resul) ? resul : (int?)null))
                //.ForMember(m => m.StatusStudentId, opt => opt.MapFrom(mp =>int.TryParse( mp.StatusStudentId, out resul) ? resul : (int?)null))
                //.ForMember(m => m.ReasonForLeaving, opt => opt.MapFrom(mp => short.TryParse(mp.ReasonForLeaving, out resul2) ? resul2 : (int?)null))

                //  public int? PreviousSchoolId { get; set; }
                //  public int? field1 { get; set; }


                //.ForMember(m => m.TypeIdentity.IdtypeIdentity, opt => opt.MapFrom(mp => int.TryParse(mp.TypeIdentity, out resul) ? resul : (int?)null))
                //.ForMember(m => m.ApotropusTypeIdentity, opt => opt.MapFrom(mp => int.TryParse(mp.ApotropusTypeIdentity, out resul) ? resul : (int?)null))
                //.ForMember(m => m.MotherTypeIdentity, opt => opt.MapFrom(mp => int.TryParse(mp.MotherTypeIdentity, out resul) ? resul : (int?)null))
                //.ForMember(m => m.FatherTypeIdentity, opt => opt.MapFrom(mp => int.TryParse(mp.FatherTypeIdentity, out resul) ? resul : (int?)null))
                //.ForMember(m => m.IsActive, opt => opt.MapFrom(mp => bool.TryParse(mp.IsActive, out resul5) ? resul5 : true))
                //.ForMember(m => m.StatusId, opt => opt.MapFrom(mp => int.TryParse(mp.Status, out resul) ? resul : (int?)null))
                //.ForMember(m => m.StatusStudentId, opt => opt.MapFrom(mp => int.TryParse(mp.StatusStudentId, out resul) ? resul : (int?)null))
                //.ForMember(m => m.ReasonForLeaving, opt => opt.MapFrom(mp => short.TryParse(mp.ReasonForLeaving, out resul2) ? resul2 : (int?)null))
                //.ForPath(m => m.Gender.Idgender, opt => opt.MapFrom(mp => short.TryParse(mp.Gender, out resul2) ? resul2 : (short?)null))
                .ForPath(m => m.Address.CityId, opt => opt.MapFrom(mp => int.TryParse(mp.City, out resul) ? resul : (int?)null))
                .ForPath(m => m.Address.HouseNumber, opt => opt.MapFrom(mp => (mp.BuildingNum)))
                .ForPath(m => m.Address.ApartmentNumber, opt => opt.MapFrom(mp => mp.HouseNum))
                .ForPath(m => m.Address.NeighborhoodId, opt => opt.MapFrom(mp => int.TryParse(mp.Neighborhood, out resul) ? resul : (int?)null))
                .ForPath(m => m.Address.PoBox, opt => opt.MapFrom(mp => int.TryParse(mp.MailBox, out resul) ? resul : (int?)null))
                .ForPath(m => m.Address.StreetId, opt => opt.MapFrom(mp => int.TryParse(mp.Street, out resul) ? resul : (int?)null))
                .ForPath(m => m.Address.ZipCode, opt => opt.MapFrom(mp => int.TryParse(mp.Zip, out resul) ? resul : (int?)null))
                .ForPath(m => m.Birth.BirthCountryId, opt => opt.MapFrom(mp => int.TryParse(mp.BirthCountryId, out resul) ? resul : (int?)null))
                .ForPath(m => m.Birth.CountryIdofImmigration, opt => opt.MapFrom(mp => int.TryParse(mp.CountryIdofImmigration, out resul) ? resul : (int?)null))
                .ForPath(m => m.Birth.BirthHebrewDate, opt => opt.MapFrom(mp => mp.BirthHebrewDate))
                .ForPath(m => m.Birth.CitizenshipId, opt => opt.MapFrom(mp => int.TryParse(mp.Citizenship, out resul) ? resul : (int?)null))
                .ForPath(m => m.Birth.BirthDate, opt => opt.MapFrom(mp => mp.BirthDate != null ? (double.TryParse(mp.BirthDate, out resul3) ? DateTime.FromOADate(resul3) : (DateTime?)null) : (DateTime?)null))
                .ForPath(m => m.Birth.DateOfImmigration, opt => opt.MapFrom(mp => mp.DateOfImmigration != null ? (double.TryParse(mp.DateOfImmigration, out resul3) ? DateTime.FromOADate(resul3) : (DateTime?)null) : (DateTime?)null))
                .ForPath(m => m.ContactInformation.TelephoneNumber1, opt => opt.MapFrom(mp => mp.Telehone1))
                .ForPath(m => m.ContactInformation.TelephoneNumber2, opt => opt.MapFrom(mp => mp.Telehone2))
                .ForPath(m => m.ContactInformation.PhoneNumber1, opt => opt.MapFrom(mp => mp.Mobile1))
                .ForPath(m => m.ContactInformation.PhoneNumber2, opt => opt.MapFrom(mp => mp.Mobile2))
                .ForPath(m => m.ContactInformation.PhoneNumber3, opt => opt.MapFrom(mp => mp.Mobile3))
                .ForPath(m => m.ContactInformation.FaxNumber, opt => opt.MapFrom(mp => mp.Fax))
                .ForPath(m => m.ContactInformation.Email, opt => opt.MapFrom(mp => mp.Mail))
                     .ReverseMap();
            // .PreserveReferences();
            CreateMap<AppContactPerStudentXL, AppContactDTO>().ReverseMap();


            CreateMap<AppContact, AppContactDTO>().ReverseMap();
            CreateMap<AppContactDTO, AppContact>().ReverseMap();


            CreateMap<AppAddress, AppAddressDTO>().ReverseMap();
            CreateMap<AppAddressDTO, AppAddress>().ReverseMap();


            CreateMap<AppBirth, AppBirthDTO>().ReverseMap();
            CreateMap<AppBirthDTO, AppBirth>().ReverseMap();


            CreateMap<TGender, TGenderDTO>().ReverseMap();
            CreateMap<TGenderDTO, TGender>().ReverseMap();


            CreateMap<AppGroup, AppGroupDTO>()
           // .ForMember(m => m.AppGroupPerYearbooks, opt => opt.MapFrom(mp => mp.AppGroupPerYearbooks))
           .ReverseMap();
            CreateMap<AppGroupDTO, AppGroup>().ReverseMap();


            CreateMap<AppStudentPerGroupDTO, AppStudentPerGroup>().ReverseMap();
            CreateMap<AppStudentPerGroup, AppStudentPerGroupDTO>().ReverseMap();


            CreateMap<AppYearbookPerSchool, AppYearbookPerSchoolDTO>().ReverseMap();
            CreateMap<AppYearbookPerSchoolDTO, AppYearbookPerSchool>().ReverseMap();

            CreateMap<AppGroupPerYearbookDTO, AppGroupPerYearbook>().ReverseMap();

            CreateMap<AppGroupPerYearbook, AppGroupPerYearbookDTO>()
               .ForMember(mp=>mp.SchoolName,opt=>opt.MapFrom(m=>m.Group!=null&&m.Group.School!=null? m.Group.School.Name:""))
                .ReverseMap();


            CreateMap<TabAgeGroup, TabAgeGroupDTO>().ReverseMap();
            CreateMap<TabAgeGroupDTO, TabAgeGroup>().ReverseMap();


            CreateMap<TabTypeGroup, TabTypeGroupDTO>().ReverseMap();
            CreateMap<TabTypeGroupDTO, TabTypeGroup>().ReverseMap();


            CreateMap<AppUserPerGroup, AppUserPerGroupDTO>()
                .ForMember(m=>m.User,opt=>opt.MapFrom(mp=>mp!=null&&mp.User!=null?mp.User.User:null))
                .ReverseMap();
            CreateMap<AppUserPerGroupDTO, AppUserPerGroup>().ReverseMap();

            CreateMap<AppUserPerCourseDTO, AppUserPerCourse>().ReverseMap();
            CreateMap<AppUserPerCourse, AppUserPerCourseDTO>()  
                .ForMember(mp=>mp.User,opt=>opt.MapFrom(m=>m!=null&&m.User!=null? m.User.User:null))
                //.ForMember(mp=>mp.User.SchoolId,opt=>opt.MapFrom(m=>(int)m.UserId))
                .ForPath(m => m.User.SchoolId, opt => opt.MapFrom(mp =>mp!=null&&mp.User!=null? mp.User.SchoolId:null))
                .ForPath(m => m.User.SchoolName, opt => opt.MapFrom(mp =>mp!=null&&mp.User!=null&&mp.User.School!=null? mp.User.School.Name:""))
                .ForPath(m => m.User.UserPerSchoolID, opt => opt.MapFrom(mp => mp.User.IduserPerSchool))
            .ReverseMap();

            CreateMap<AppUserPerSchool, AppUserPerSchoolDTO>()

                .ReverseMap();
            CreateMap<AppUserPerSchoolDTO, AppUserPerSchool>().ReverseMap();

            CreateMap<AppDocumentPerStudent, AppDocumentPerStudentDTO>()
             .ForMember(m => m.FolderName, opt => opt.MapFrom(mp => mp != null && mp.Folder != null ? mp.Folder.Name : " "))
                .ReverseMap();
            CreateMap<AppDocumentPerStudentDTO, AppDocumentPerStudent>().ReverseMap();

            CreateMap<AppDocumentPerGroup, AppDocumentPerGroupDTO>()
             .ForMember(m => m.FolderName, opt => opt.MapFrom(mp => mp != null && mp.Folder != null ? mp.Folder.Name : " "))
                .ReverseMap();
            CreateMap<AppDocumentPerGroupDTO, AppDocumentPerGroup>().ReverseMap();

            CreateMap<AppDocumentPerCourse, AppDocumentPerCourseDTO>()
            .ForMember(m => m.FolderName, opt => opt.MapFrom(mp => mp != null && mp.Folder != null ? mp.Folder.Name : " "))
                .ReverseMap();
            CreateMap<AppDocumentPerCourseDTO, AppDocumentPerCourse>()
                .ReverseMap();

            CreateMap<AppDocumentPerFatherCourseDTO, AppDocumentPerFatherCourse>().ReverseMap();
            CreateMap<AppDocumentPerFatherCourse, AppDocumentPerFatherCourseDTO>()
              .ForMember(m => m.FolderCreated, opt => opt.MapFrom(mp => mp != null && mp.Folder != null ? mp.Folder.UserCreated : 0))
              .ForMember(m => m.FolderName, opt => opt.MapFrom(mp => mp != null && mp.Folder != null ? mp.Folder.Name : " "))
                .ReverseMap();
      

            CreateMap<AppDocumentPerSchool, AppDocumentPerSchoolDTO>()
             .ForMember(m => m.FolderName, opt => opt.MapFrom(mp => mp != null && mp.Folder != null ? mp.Folder.Name : " "))
                .ReverseMap();
            CreateMap<AppDocumentPerSchoolDTO, AppDocumentPerSchool>().ReverseMap();

            CreateMap<AppDocumentPerTask, AppDocumentPerTaskDTO>()
         .ForMember(m => m.FolderName, opt => opt.MapFrom(mp => mp != null && mp.Folder != null ? mp.Folder.Name : " "))
            .ReverseMap();
            CreateMap<AppDocumentPerTaskDTO, AppDocumentPerTask>().ReverseMap();

            CreateMap<TAB_ProfessionCategoryDTO, TabProfessionCategory>().ReverseMap();
            CreateMap<TabProfessionCategory, TAB_ProfessionCategoryDTO>().ReverseMap();
        }

    }
}
