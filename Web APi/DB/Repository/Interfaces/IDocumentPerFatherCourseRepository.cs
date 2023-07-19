using DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.Interfaces
{
    public interface IDocumentPerFatherCourseRepository
    {
        List<AppDocumentPerFatherCourse> GetLstDocumentPerFatherCourse(int FatherCourseId, int schollId);
        AppDocumentPerFatherCourse UploadDocumentPerFatherCourse(AppDocumentPerFatherCourse appDocumentPerFatherCourse, int uniqueCodeID);
        string DeleteDocumentPerFatherCourse(int idDocumentPerFatherCourse, int idFatherCourse, int uniqueCodeId);
        List<AppDocumentPerFatherCourse> UploadFewDocumentsPerFatherCourse(List<AppDocumentPerFatherCourse> lists, string nameFolder, int uniqueCodeID, int userId, int? customerId);
        AppDocumentPerFatherCourse DeleteFewDocumentPerFatherCourse(int idFolder, int requiredDocumentPerFatherCourseId, int idFatherCourse, int uniqueCodeDocumentId);
        void SaveNameFile(int idfile, string nameFile, int uniqeId);
    }
}
