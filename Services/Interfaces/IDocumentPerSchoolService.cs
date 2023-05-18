using DTO.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IDocumentPerSchoolService
    {
        public List<AppDocumentPerSchoolDTO> GetLstDocumentPerSchool(int SchoolId);
        AppDocumentPerSchoolDTO UploadDocumentPerSchool(AppDocumentPerSchoolDTO documentPerSchoolDTO, int uniqueCodeID);
        string DeleteDocumentPerSchool(int idDocumentPerSchool, int idSchool, int uniqueCodeId);
        List<AppDocumentPerSchoolDTO> UploadFewDocumentsPerSchool(List<AppDocumentPerSchoolDTO> lstDocumentPerSchoolDTO, string nameFolder, string uniqueCodeID, int userId, int customerId);
        AppDocumentPerSchoolDTO DeleteFewDocumentPerSchool(int idFolder, int requiredDocumentPerSchoolId, int idSchool, int uniqueCodeId);
        void SaveNameFile(int idfile, string nameFile, int uniqeId);
    }
}
