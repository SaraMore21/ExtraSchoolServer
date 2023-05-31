using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Classes
{
    public class AppUserPerSchoolDTO
    {
        public int IduserPerSchool { get; set; }
        public int? UserId { get; set; }
        public int? SchoolId { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int? UserCreatedId { get; set; }
        public int? UserUpdetedId { get; set; }
        public int? ContactInformationId { get; set; }
        public bool? IsActive { get; set; }
        public string Note { get; set; }
        public int? TypeUserId { get; set; }
        public int? UniqueCodeId { get; set; }
        public DateTime? StartOfWorkDate { get; set; }
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

        public SecUserDTO User { get; set; }




    }
}
