using DTO.Classes;
using System;
using System.Collections.Generic;


namespace Services.Interfaces
{
    public interface IDocumentPerProfessionService
    {
        public List<AppDocumentPerProfessionDTO> GetLstDocumentPerProfession(int ProfessionId, int schollId);
        AppDocumentPerProfessionDTO UploadDocumentPerProfession(AppDocumentPerProfessionDTO documentPerProfessionDTO, int uniqueCodeID);
        string DeleteDocumentPerProfession(int idDocumentPerProfession, int idProfession, int uniqueCodeId);
        List<AppDocumentPerProfessionDTO> UploadFewDocumentsPerProfession(List<AppDocumentPerProfessionDTO> lstDocumentPerProfessionDTO, string nameFolder, int uniqueCodeID, int userId, int customerId);
        AppDocumentPerProfessionDTO DeleteFewDocumentPerProfession(int idFolder, int requiredDocumentPerProfessionId, int idProfession, int uniqueCodeId);
        void SaveNameFile(int idfile, string nameFile, int uniqeId);

    }
}
