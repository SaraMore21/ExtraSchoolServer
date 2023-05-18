using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Classes
{
     public class AppContactPerStudentDTO
    {
        public int IdcontactPerStudent { get; set; }
        public int? StudentId { get; set; }
        public int? ContactId { get; set; }
        public int? TypeContactId { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdated { get; set; }

        public AppContactDTO Contact { get; set; }
       // public  AppStudentDTO Student { get; set; }
        //public string ContactTypeName { set; get; }
        public TTypeContactDTO TypeContact { get; set; }

        //public TTypeContactDTO Type { get; set; }
        //public  AppUserPerSchoolDTO UserCreated { get; set; }
        //public  AppUserPerSchoolDTO UserUpdated { get; set; }
       // public  TTypeContactDTO TypeContact { get; set; }

    }
}
