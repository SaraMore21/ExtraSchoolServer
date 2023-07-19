using DTO.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IDocumentPerTaskExsistService
    {
        public List<AppDocumentPerTaskExsistDTO> GetLstDocumentPerTaskExsist(int TaskExsistId, int schollId);
        AppDocumentPerTaskExsistDTO UploadDocumentPerTaskExsist(AppDocumentPerTaskExsistDTO documentPerTaskExsistDTO);
        string DeleteDocumentPerTaskExsist(int idDocumentPerTaskExsist, int idTaskExsist);
        List<AppDocumentPerTaskExsistDTO> UploadFewDocumentsPerTaskExsist(List<AppDocumentPerTaskExsistDTO> lstDocumentPerTaskExsistDTO, string nameFolder);
        AppDocumentPerTaskExsistDTO DeleteFewDocumentPerTaskExsist(int idFolder, int requiredDocumentPerTaskExsistId);
        void SaveNameFile(int idfile, string nameFile);
    }
}
