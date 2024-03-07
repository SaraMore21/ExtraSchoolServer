using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppGroup
    {
        public AppGroup()
        {
            AppGroupPerYearbooks = new HashSet<AppGroupPerYearbook>();
        }

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
        public int? CoordinationTypeId { get; set; }

        public virtual TabAgeGroup AgeGroup { get; set; }
        public virtual AppCoordinationType CoordinationType { get; set; }
        public virtual TabListeningTime ListeningTime { get; set; }
        public virtual AppSchool School { get; set; }
        public virtual TabTypeGroup TypeGroup { get; set; }
        public virtual AppUserPerSchool UserCreated { get; set; }
        public virtual AppUserPerSchool UserUpdated { get; set; }
        public virtual AppVoiceSpace VoiceSpace { get; set; }
        public virtual ICollection<AppGroupPerYearbook> AppGroupPerYearbooks { get; set; }
    }
}
