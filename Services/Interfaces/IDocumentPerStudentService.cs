using DTO.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IDocumentPerStudentService
    {
        public List<AppDocumentPerStudentDTO> GetLstDocumentPerStudent(int StudentId, int schollId);
        AppDocumentPerStudentDTO UploadDocumentPerStudent(AppDocumentPerStudentDTO documentPerStudentDTO);
        string DeleteDocumentPerStudent(int idDocumentPerStudent, int idStudent);
        List<AppDocumentPerStudentDTO> UploadFewDocumentsPerStudent(List<AppDocumentPerStudentDTO> lstDocumentPerStudentDTO, string nameFolder);
        AppDocumentPerStudentDTO DeleteFewDocumentPerStudent(int idFolder, int requiredDocumentPerStudentId);
        void SaveNameFile(int idfile, string nameFile);

    }
}
