using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Classes
{
    public class AppGroupPerYearbookDTO
    {


        public int IdgroupPerYearbook { get; set; }
        public int? GroupId { get; set; }
        public int? YearbookId { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdated { get; set; }
        


        public AppGroupDTO Group { get; set; }
        public string SchoolName { get; set; }
        public int SchoolID { get; set; }


        public virtual ICollection<AppUserPerGroupDTO> AppUserPerGroups { get; set; }

    }
}
