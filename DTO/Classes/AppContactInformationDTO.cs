using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Classes
{
    public class AppContactInformationDTO
    {
        public int IdcontactInformation { get; set; }
        public string TelephoneNumber1 { get; set; }
        public string TelephoneNumber2 { get; set; }
        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }
        public string PhoneNumber3 { get; set; }
        public string FaxNumber { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string IsMobile { get; set; }
        public string Job { get; set; }
        public int? AddressId { get; set; }


        //  public virtual ICollection<AppStudentDTO> AppStudents { get; set; }

    }
}
