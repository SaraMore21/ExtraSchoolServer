using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Classes
{
    public class TabTypeGroupDTO
    {
        public int IdtypeGroup { get; set; }
        public string Name { get; set; }
        public int? SchoolId { get; set; }
        public bool? IsMultiple { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string CoordinationCode { get; set; }
    }
}
