using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Classes
{
    public class AppContactWithDetailsDTO
    {
        public int IdcontactPerStudent { get; set; }
        public int? StudentId { get; set; }
        public int? ContactId { get; set; }
        public int? TypeContactId { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdated { get; set; }

        public AppContactDTO Contact { get; set; }

        public TTypeContactDTO TypeContact { get; set; }
        public AppAddressDTO Address { get; set; }
    }
}
 