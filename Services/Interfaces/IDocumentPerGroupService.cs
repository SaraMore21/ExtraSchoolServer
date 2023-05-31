using DTO.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IDocumentPerGroupService
    {
        public List<AppDocumentPerGroupDTO> GetLstDocumentPerGroup(int GroupId, int schollId);
        AppDocumentPerGroupDTO UploadDocumentPerGroup(AppDocumentPerGroupDTO documentPerGroupDTO);
        string DeleteDocumentPerGroup(int idDocumentPerGroup, int idGroup);
        List<AppDocumentPerGroupDTO> UploadFewDocumentsPerGroup(List<AppDocumentPerGroupDTO> lstDocumentPerGroupDTO, string nameFolder);
        AppDocumentPerGroupDTO DeleteFewDocumentPerGroup(int idFolder, int requiredDocumentPerGroupId);
        void SaveNameFile(int idfile, string nameFile);
    }
}
