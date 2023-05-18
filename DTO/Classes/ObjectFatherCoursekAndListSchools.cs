using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Classes
{
    public class ObjectFatherCoursekAndListSchools
    {
        public AppCourseDTO FatherCourse { get; set; }
        public List<AppSchoolWhithYearbookDTO> ListSchool { get; set; }
    }
}
