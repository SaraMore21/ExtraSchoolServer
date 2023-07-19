using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Classes
{
    public class AppGroupDTO
    {

        public int Idgroup { get; set; }
        public int? AgeGroupId { get; set; }
        public int? SchoolId { get; set; }
        public int? TypeGroupId { get; set; }
        public int? ExtensionId { get; set; }
        public int? VoiceSpaceId { get; set; }
        public int? ListeningTimeId { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string NameGroup { get; set; }

        public string AgeGroupName { get; set; }
        public string TypeGroupName { get; set; }
        public int? CoordinationTypeId { get; set; }

        //for documents
        //public int IdgroupPeryearbook { get; set; }

        //public ICollection<AppGroupPerYearbookDTO> AppGroupPerYearbooks { get; set; }

    }
}
