using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Classes
{
    public class ReturnObjectOfAddUserDTO
    {

        public string? ID { get; set; }
        public string? Name { get; set; }
        public SecUserDTO? User { get; set; }

    }
}
