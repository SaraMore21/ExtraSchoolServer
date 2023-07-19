using DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.Interfaces
{
    public interface IDocumentPerGroupRepository
    {
        List<AppDocumentPerGroup> GetLstDocumentPerGroup(int GroupId, int schollId);
        AppDocumentPerGroup UploadDocumentPerGroup(AppDocumentPerGroup appDocumentPerGroup);
        string DeleteDocumentPerGroup(int idDocumentPerGroup, int idGroup);
        List<AppDocumentPerGroup> UploadFewDocumentsPerGroup(List<AppDocumentPerGroup> lists, string nameFolder);
        AppDocumentPerGroup DeleteFewDocumentPerGroup(int idFolder, int requiredDocumentPerGroupId);
        void SaveNameFile(int idfile, string nameFile);
    }
}
