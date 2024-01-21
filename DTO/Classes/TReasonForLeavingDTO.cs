using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Classes
{
    public class TReasonForLeavingDTO
    {
        public int IdreasonForLeaving { get; set; }
        public string Name { get; set; }
        public int? SchoolId { get; set; }
    }
}
