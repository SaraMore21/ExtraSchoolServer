using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Classes
{
    public class AppContactDTO
    {

        public int Idcontact { get; set; }
        public int? ContactInformationId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string Tz { get; set; }
        public int? TypeIdentityId { get; set; }
        public int? SchoolId { get; set; }

        public AppContactInformationDTO ContactInformation { get; set; }

    }
}
