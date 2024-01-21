using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.Classes
{
    public class AppStudentDTO
    {
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
        public string SchoolName { get; set; }
        public int? YearbookId { get; set;}
        public int? NumRequiredPerStudent { get; set; }
        public int? NumExsistRequiredPerStudent { get; set; }

        public AppAddressDTO Address { get; set; }
        public AppBirthDTO Birth { get; set; }
        public ICollection<AppContactPerStudentDTO> AppContactPerStudents { get; set; }



        //שדות נוספים שהוספנו לצורך הצגה במסך הראשי
        //עיר
        public string CityName { get; set; }
        //רחוב
        public string StreetName { get; set; }
        //מס' בית
        public string HouseNum { get; set; }
        //מס דירה
        public string AptNum { get; set; }
        //מיקוד
        public int? ZipCode { get; set; }
        //תיבת דואר
        public int? PoBox { get; set; }
        //טלפון 1
        public string Phone1 { get; set; }
        //טלפון 2
        public string Phone2 { get; set; }
        //נייד 1
        public string Cell1 { get; set; }
        //נייד 2
        public string Cell2 { get; set; }
        //נייד 3
        public string Cell3 { get; set; }
        //פקס
        public string Fax { get; set; }
        //מייל
        public string Mail { get; set; }
        //        סטטוס
        public string Status { get; set; }
        //        סטטוס תלמיד
        public string StatusStudent { get; set; }
        //            סוג זיהוי אם
        public string MotherTypeIdentity { get; set; }
        //            סוג זיהוי אב
        public string FatherTypeIdentity { get; set; }
        //            מין
        public string Gender { get; set; }
        //אזרחות
        public string Citizenship { get; set; }
        //תאריך לידה
        public string BirtheDate { get; set; }
        //ארץ לידה
        public string BirtheCountry { get; set; }
        //ארץ עליה
        public string ImigrationCountry { get; set; }
        //תאריך עליה
        public string ImigrationDate { get; set; }
        //סוג זיהוי
        public string IdentityType { get; set; }
        // public virtual AppContactInformationDTO ContactInformation { get; set; }
        //public AppSchoolDTO School { get; set; }
        //public string FatherTypeIdentityNavigationD { get; set; }




    }
}



