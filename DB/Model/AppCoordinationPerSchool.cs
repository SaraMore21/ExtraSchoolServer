using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppCoordinationPerSchool
    {
        public AppCoordinationPerSchool()
        {
            AppCoordinationTypes = new HashSet<AppCoordinationType>();
        }

        public int IdcoordinationPerSchool { get; set; }
        public int? CoordinationId { get; set; }
        public int? SchoolId { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdated { get; set; }

        public virtual AppCoordination Coordination { get; set; }
        public virtual AppSchool School { get; set; }
        public virtual ICollection<AppCoordinationType> AppCoordinationTypes { get; set; }
    }
}
