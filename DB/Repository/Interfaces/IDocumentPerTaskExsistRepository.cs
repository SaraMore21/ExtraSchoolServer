using DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.Interfaces
{
    public interface IDocumentPerTaskExsistRepository
    {
        List<AppDocumentPerTaskExsist> GetLstDocumentPerTaskExsist(int TaskExsistId, int schollId);
        AppDocumentPerTaskExsist UploadDocumentPerTaskExsist(AppDocumentPerTaskExsist appDocumentPerTaskExsist);
        string DeleteDocumentPerTaskExsist(int idDocumentPerTaskExsist, int idTaskExsist);
        List<AppDocumentPerTaskExsist> UploadFewDocumentsPerTaskExsist(List<AppDocumentPerTaskExsist> lists, string nameFolder);
        AppDocumentPerTaskExsist DeleteFewDocumentPerTaskExsist(int idFolder, int requiredDocumentPerTaskExsistId);
        void SaveNameFile(int idfile, string nameFile);
    }
}
