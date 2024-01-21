using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Classes
{
    public class TAB_TableDTO
    {
        public string Name { get; set; }
        public List<CodeTableDTO> CodeTable { get; set; }
    }
}
