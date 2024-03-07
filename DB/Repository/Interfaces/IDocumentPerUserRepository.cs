using DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.Interfaces
{
    public interface IDocumentPerUserRepository
    {
        List<AppDocumentPerUser> GetLstDocumentPerUser(int UserId, int schollId);
        AppDocumentPerUser UploadDocumentPerUser(AppDocumentPerUser appDocumentPerUser, int uniqueCodeID);
        string DeleteDocumentPerUser(int idDocumentPerUser, int idUser, int uniqueCodeId);
        List<AppDocumentPerUser> UploadFewDocumentsPerUser(List<AppDocumentPerUser> lists, string nameFolder, int uniqueCodeID, int userId, int? customerId);
        AppDocumentPerUser DeleteFewDocumentPerUser(int idFolder, int requiredDocumentPerUserId, int idUser, int uniqueCodeDocumentId);
        void SaveNameFile(int idfile, string nameFile, int uniqeId);
    }
}
