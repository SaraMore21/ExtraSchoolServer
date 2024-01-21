using DTO.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IDocumentPerFatherCourseService
    {
        public List<AppDocumentPerFatherCourseDTO> GetLstDocumentPerFatherCourse(int FatherCourseId, int schollId);
        AppDocumentPerFatherCourseDTO UploadDocumentPerFatherCourse(AppDocumentPerFatherCourseDTO documentPerFatherCourseDTO, int uniqueCodeID);
        string DeleteDocumentPerFatherCourse(int idDocumentPerFatherCourse, int idFatherCourse, int uniqueCodeId);
        List<AppDocumentPerFatherCourseDTO> UploadFewDocumentsPerFatherCourse(List<AppDocumentPerFatherCourseDTO> lstDocumentPerFatherCourseDTO, string nameFolder, int uniqueCodeID, int userId, int customerId);
        AppDocumentPerFatherCourseDTO DeleteFewDocumentPerFatherCourse(int idFolder, int requiredDocumentPerFatherCourseId ,int idFatherCourse, int uniqueCodeId);
        void SaveNameFile(int idfile, string nameFile, int uniqeId);
    }
}
