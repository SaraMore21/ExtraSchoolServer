using DTO.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IDocumentPerTaskService
    {
        public List<AppDocumentPerTaskDTO> GetLstDocumentPerTask(int TaskId, int schollId);
        AppDocumentPerTaskDTO UploadDocumentPerTask(AppDocumentPerTaskDTO documentPerTaskDTO, int uniqueCodeID);
        string DeleteDocumentPerTask(int idDocumentPerTask, int idTask, int uniqueCodeId);
        List<AppDocumentPerTaskDTO> UploadFewDocumentsPerTask(List<AppDocumentPerTaskDTO> lstDocumentPerTaskDTO, string nameFolder, int uniqueCodeID, int userId, int customerId);
        AppDocumentPerTaskDTO DeleteFewDocumentPerTask(int idFolder, int requiredDocumentPerTaskId, int idTask, int uniqueCodeId);
        void SaveNameFile(int idfile, string nameFile, int uniqeId);
    }
}
