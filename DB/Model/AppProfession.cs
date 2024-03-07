using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppProfession
    {
        public AppProfession()
        {
            AppCourses = new HashSet<AppCourse>();
            AppDocumentPerProfessions = new HashSet<AppDocumentPerProfession>();
        }

        public int Idprofession { get; set; }
        public string Name { get; set; }
        public int? CoordinatorId { get; set; }
        public int? SchoolId { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreate { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdate { get; set; }
        public int? ProfessionCategoryId { get; set; }
        public bool? IsActive { get; set; }
        public int? UniqueCodeId { get; set; }
        public int? CoordinationTypeId { get; set; }

        public virtual AppCoordinationType CoordinationType { get; set; }
        public virtual AppUserPerSchool Coordinator { get; set; }
        public virtual TabProfessionCategory ProfessionCategory { get; set; }
        public virtual AppSchool School { get; set; }
        public virtual AppUniqueCode UniqueCode { get; set; }
        public virtual AppUserPerSchool UserCreated { get; set; }
        public virtual AppUserPerSchool UserUpdated { get; set; }
        public virtual ICollection<AppCourse> AppCourses { get; set; }
        public virtual ICollection<AppDocumentPerProfession> AppDocumentPerProfessions { get; set; }
    }
}
