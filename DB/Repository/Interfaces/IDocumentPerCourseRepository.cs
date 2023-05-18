using DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.Interfaces
{
    public interface IDocumentPerCourseRepository
    {
        List<AppDocumentPerCourse> GetLstDocumentPerCourse(int CourseId, int schollId);
        AppDocumentPerCourse UploadDocumentPerCourse(AppDocumentPerCourse appDocumentPerCourse);
        string DeleteDocumentPerCourse(int idDocumentPerCourse, int idCourse);
        List<AppDocumentPerCourse> UploadFewDocumentsPerCourse(List<AppDocumentPerCourse> lists, string nameFolder);
        AppDocumentPerCourse DeleteFewDocumentPerCourse(int idFolder, int requiredDocumentPerCourseId);
        void SaveNameFile(int idfile, string nameFile);
    }
}
