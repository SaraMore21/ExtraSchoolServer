using DB.Model;
using System;
using System.Collections.Generic;


namespace DB.Repository.Interfaces
{
    public interface IDocumentPerProfessionRepository
    {
        List<AppDocumentPerProfession> GetLstDocumentPerProfession(int ProfessionId, int schollId);
        AppDocumentPerProfession UploadDocumentPerProfession(AppDocumentPerProfession appDocumentPerProfession, int uniqueCodeID);
        string DeleteDocumentPerProfession(int idDocumentPerProfession, int idProfession, int uniqueCodeId);
        List<AppDocumentPerProfession> UploadFewDocumentsPerProfession(List<AppDocumentPerProfession> lists, string nameFolder, int uniqueCodeID, int userId, int? customerId);
        AppDocumentPerProfession DeleteFewDocumentPerProfession(int idFolder, int requiredDocumentPerProfessionId, int idProfession, int uniqueCodeDocumentId);
        void SaveNameFile(int idfile, string nameFile, int uniqeId);
    }
}
