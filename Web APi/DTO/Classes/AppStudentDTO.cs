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
        // public virtual AppContactInformationDTO ContactInformation { get; set; }
        //public AppSchoolDTO School { get; set; }
        //public string FatherTypeIdentityNavigationD { get; set; }




    }
}



