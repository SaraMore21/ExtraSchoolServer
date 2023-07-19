using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Classes
{
    public class AppCoordinationTypeDTO
    {
        public int IdCoordinationType { get; set; }
        public int? IdCoordinationPerSchool { get; set; }
        public string CoordinationType { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
