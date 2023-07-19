using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Classes
{
    public class AppSchoolWhithYearbookDTO
    {
        public AppSchoolDTO school { get; set; }
        public int UserId { get; set; }
        public virtual ICollection<AppYearbookPerSchoolDTO> AppYearbookPerSchools { get; set; }
    }
}
