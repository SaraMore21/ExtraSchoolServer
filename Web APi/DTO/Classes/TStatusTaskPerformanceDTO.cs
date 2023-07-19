using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Classes
{
    public class TStatusTaskPerformanceDTO
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string DisplayName { get; set; }
        public int MosadId { get; set; }
        public bool IsDefault { get; set; }
    }
}
