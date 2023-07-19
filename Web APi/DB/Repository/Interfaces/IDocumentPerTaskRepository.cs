using DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.Interfaces
{
    public interface IDocumentPerTaskRepository
    {
        List<AppDocumentPerTask> GetLstDocumentPerTask(int TaskId, int schollId);
        AppDocumentPerTask UploadDocumentPerTask(AppDocumentPerTask appDocumentPerTask, int uniqueCodeID);
        string DeleteDocumentPerTask(int idDocumentPerTask, int idTask, int uniqueCodeId);
        List<AppDocumentPerTask> UploadFewDocumentsPerTask(List<AppDocumentPerTask> lists, string nameFolder, int uniqueCodeID, int userId, int? customerId);
        AppDocumentPerTask DeleteFewDocumentPerTask(int idFolder, int requiredDocumentPerTaskId, int idTask, int uniqueCodeDocumentId);
        void SaveNameFile(int idfile, string nameFile, int uniqeId);
    }
}
