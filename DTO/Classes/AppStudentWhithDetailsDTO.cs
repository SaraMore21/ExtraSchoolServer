using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Classes
{
    public class AppStudentWhithDetailsDTO
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


        public AppAddressDTO Address { get; set; }
        public AppBirthDTO Birth { get; set; }
        public AppContactInformationDTO ContactInformation { get; set; }
        public List<AppContactPerStudentDTO> ContactPerStudent { get; set; }


        ////Birth
        //public int? BirthCountryId { get; set; }
        //public DateTime BirthDate { get; set; }
        //public string BirthHebrewDate { get; set; }
        //public int? CitizenshipId { get; set; }
        //public DateTime DateOfImmigration { get; set; }
        //public int? CountryIDOfImmigration { get; set; }

        ////Address
        //public int? CityId { get; set; }
        //public int? NeighborhoodId { get; set; }
        //public int? StreetId {get;set;}
        //public string HouseNumber { get; set; }
        //public string ApartmentNumber { get; set; }
        //public int PoBox { get; set; }
        //public int ZipCode { get; set; }

        ////ContactInformation
        //public string TelephoneNumber1 { get; set; }
        //public string TelephoneNumber2 { get; set; }
        //public string PhoneNumber1 { get; set; }
        //public string PhoneNumber2 { get; set; }
        //public string PhoneNumber3 { get; set; }
        //public string FaxNumber { get; set; }
        //public string Email { get; set; }



    }
}
