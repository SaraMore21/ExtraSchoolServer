using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Classes
{
    public class CodeTableDTO
    {
        public string Table { get; set; }
        public string Name { get; set; }
        public int Value  { get; set; }
        public Nullable<int> StatusID { get; set; }
    }
}
