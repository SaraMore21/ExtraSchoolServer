using System;
using System.Collections.Generic;

#nullable disable

namespace DB.Model
{
    public partial class AppDocumentPerProfession
    {
        public int IddocumentPerProfession { get; set; }
        public string Name { get; set; }
        public int? SchoolId { get; set; }
        public int? UserCreatedId { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdatedId { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string Path { get; set; }
        public int? ProfessionId { get; set; }
        public int? RequiredDocumentPerProfessionId { get; set; }
        public int? FolderId { get; set; }
        public string Type { get; set; }
        public int? UniqueCodeId { get; set; }
        public int? ExsistDocumentId { get; set; }
        public int? DisplayOrderNum { get; set; }

        public virtual AppExsistDocument ExsistDocument { get; set; }
        public virtual AppFolder Folder { get; set; }
        public virtual AppProfession Profession { get; set; }
        public virtual TabRequiredDocumentPerProfession RequiredDocumentPerProfession { get; set; }
        public virtual AppSchool School { get; set; }
        public virtual AppUniqueCode UniqueCode { get; set; }
        public virtual AppUserPerSchool UserCreated { get; set; }
        public virtual AppUserPerSchool UserUpdated { get; set; }
    }
}
