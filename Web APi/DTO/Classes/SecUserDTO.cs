using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Classes
{
    public class SecUserDTO
    {
        public int Iduser { get; set; }
        public string Tz { get; set; }
        public int? TypeIdentityId { get; set; }
        public string UserPassword { get; set; }
        public string UserCode { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdated { get; set; }

        
        public int SchoolId { get; set; }
        public string SchoolName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public int UserPerSchoolID { get; set; }
        public int? UniqueCodeId { get; set; }

        //public SecUser user { get; set; }


    }
}
