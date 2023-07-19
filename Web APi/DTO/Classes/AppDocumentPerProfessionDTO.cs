using System;


namespace DTO.Classes
{
    public class AppDocumentPerProfessionDTO
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
        public string? FolderName { get; set; }
        public string Type { get; set; }
        public int? FolderCreated { get; set; }
        public int? IndexFolder { get; set; }
        public int? ExsistDocumentId { get; set; }
        public int? UniqueCodeId { get; set; }
        public int? DisplayOrderNum { get; set; }


    }
}
