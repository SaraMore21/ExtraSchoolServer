using DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.Interfaces
{
    public interface IDocumentPerStudentRepository
    {
        List<AppDocumentPerStudent> GetLstDocumentPerStudent(int StudentId, int schollId);
        AppDocumentPerStudent UploadDocumentPerStudent(AppDocumentPerStudent appDocumentPerStudent);
        string DeleteDocumentPerStudent(int idDocumentPerStudent, int idStudent);
        List<AppDocumentPerStudent> UploadFewDocumentsPerStudent(List<AppDocumentPerStudent> lists, string nameFolder);
        AppDocumentPerStudent DeleteFewDocumentPerStudent(int idFolder, int requiredDocumentPerStudentId);
        void SaveNameFile(int idfile, string nameFile);
    }
}
