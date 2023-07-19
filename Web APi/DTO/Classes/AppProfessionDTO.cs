using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Classes
{
    public class AppProfessionDTO
    {
        public int Idprofession { get; set; }
        public string Name { get; set; }
        public int? CoordinatorId { get; set; }
        public int? SchoolId { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreate { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdate { get; set; }
        public int? ProfessionCategoryId { get; set; }
        public bool ? IsActive { get; set; }
        public int? UniqueCodeId { get; set; }
        public int? CoordinationTypeId { get; set; }

        public string SchoolName { get; set; }
        public SecUserDTO Coordinator { get; set; }

        //public AppUserPerSchoolDTO Coordinator { get; set; }
        public  TAB_ProfessionCategoryDTO ProfessionCategory { get; set; }


    }
}
