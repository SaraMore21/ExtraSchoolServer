using DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.Interfaces
{
    public interface IDocumentPerSchoolRepository
    {
        List<AppDocumentPerSchool> GetLstDocumentPerSchool(int SchoolId);
        List<AppDocumentPerSchool> UploadFewDocumentsPerSchool(List<AppDocumentPerSchool> lists, string nameFolder, string uniqueCodeID, int userId, int? customerId);
        AppDocumentPerSchool UploadDocumentPerSchool(AppDocumentPerSchool appDocumentPerSchool, int uniqueCodeID);
        void SaveNameFile(int idfile, string nameFile, int uniqeId);
        AppDocumentPerSchool DeleteFewDocumentPerSchool(int idFolder, int requiredDocumentPerSchoolId, int idSchool, int uniqueCodeDocumentId);
        void deleteDocumentsPerSchoolOfUniqueCode(int uniqueCodeDocumentId);
        string DeleteDocumentPerSchool(int idDocumentPerSchool, int idSchool, int uniqueCodeDocumentId);
    }
}
