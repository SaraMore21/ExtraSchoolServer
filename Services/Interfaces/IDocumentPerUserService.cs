using DTO.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IDocumentPerUserService
    {
        public List<AppDocumentPerUserDTO> GetLstDocumentPerUser(int UserId, int schollId);
        AppDocumentPerUserDTO UploadDocumentPerUser(AppDocumentPerUserDTO documentPerUserDTO, int uniqueCodeID);
        string DeleteDocumentPerUser(int idDocumentPerUser, int idUser, int uniqueCodeId);
        List<AppDocumentPerUserDTO> UploadFewDocumentsPerUser(List<AppDocumentPerUserDTO> lstDocumentPerUserDTO, string nameFolder, int uniqueCodeID, int userId, int customerId);
        AppDocumentPerUserDTO DeleteFewDocumentPerUser(int idFolder, int requiredDocumentPerUserId, int idUser, int uniqueCodeId);
        void SaveNameFile(int idfile, string nameFile, int uniqeId);
    }
}

