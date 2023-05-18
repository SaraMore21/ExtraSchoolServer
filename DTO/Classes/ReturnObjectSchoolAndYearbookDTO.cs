using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Classes
{
    public class ReturnObjectSchoolAndYearbookDTO
    {
        public List<AppSchoolWhithYearbookDTO> ListSchool { get; set; }
        //public List<AppYearbookPerSchoolDTO> ListYearbookPerSchool { get; set; }
        public int Status { get; set; }
        public string NameStatus { get; set; }
        public int UserId { get; set; }
        public List<AppYearbookDTO> ListYearbook { get; set; }
        public int UserPerCustomerId { get; set; }
    }
}
