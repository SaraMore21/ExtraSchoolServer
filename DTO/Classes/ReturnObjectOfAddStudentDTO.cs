using DTO.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ReturnObjectOfAddStudentDTO
    {
        public string? ID { get; set; }
        public string? Name { get; set; }
        public AppStudentDTO? AppStudent { get; set; }
        public List<TaskToGroupDTO> ListTaskToGroup { get; set; }

    }
    public class ReturnObjectOfStudentPerGroupDTO
    {
        public string? ID { get; set; }
        public string? Name { get; set; }
        public AppStudentPerGroupDTO? StudentPerGroup { get; set; }
    }
}
