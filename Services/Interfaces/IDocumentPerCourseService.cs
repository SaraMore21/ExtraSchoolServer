using DTO.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IDocumentPerCourseService
    {
        public List<AppDocumentPerCourseDTO> GetLstDocumentPerCourse(int CourseId, int schollId);
        AppDocumentPerCourseDTO UploadDocumentPerCourse(AppDocumentPerCourseDTO documentPerCourseDTO);
        string DeleteDocumentPerCourse(int idDocumentPerCourse, int idCourse);
        List<AppDocumentPerCourseDTO> UploadFewDocumentsPerCourse(List<AppDocumentPerCourseDTO> lstDocumentPerCourseDTO, string nameFolder);
        AppDocumentPerCourseDTO DeleteFewDocumentPerCourse(int idFolder, int requiredDocumentPerCourseId);
        void SaveNameFile(int idfile, string nameFile);
    }
}
