using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppCoordination
    {
        public AppCoordination()
        {
            AppCoordinationPerSchools = new HashSet<AppCoordinationPerSchool>();
        }

        public int CoordinationId { get; set; }
        public string CoordinationName { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdated { get; set; }

        public virtual ICollection<AppCoordinationPerSchool> AppCoordinationPerSchools { get; set; }
    }
}
