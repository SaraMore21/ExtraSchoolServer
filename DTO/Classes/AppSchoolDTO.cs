using DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Classes
{
    public class AppSchoolDTO
    {
        public int Idschool { get; set; }
        public string Name { get; set; }
        public int? UserContactId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int? AdressId { get; set; }
        public string ContactInformationId { get; set; }
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


        public AppContactInformationDTO ContactInformation { get; set; }
        public virtual AppContactDTO UserContact { get; set; }

        //  public virtual ICollection<AppStudentDTO> AppStudents { get; set; }
    }

    public class UserSchoolDTO
    {
        public List<AppSchoolDTO> ListSchool { get; set; }
        public int UserId { get; set; }
        
    }
}
