using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Classes
{
    public class ObjectProfessionAndListSchool
    {
        public AppProfessionDTO Profession { get; set; }
        public List<AppSchoolWhithYearbookDTO> ListSchool { get; set; }
    }
}
