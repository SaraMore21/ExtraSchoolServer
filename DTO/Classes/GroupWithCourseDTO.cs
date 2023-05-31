using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Classes
{
    public class GroupWithCourseDTO
    {
        public AppGroupDTO Group { get; set; }
        public List<AppGroupSemesterPerCourseDTO> ListCourse { get; set; }
        public int StudentPerGroupId { get; set; }
    }
}
