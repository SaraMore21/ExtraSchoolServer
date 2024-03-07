using AutoMapper;
using DB.Model;
using DB.Repository.Interfaces;
using DTO.Classes;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Classes
{
    public class DocumentPerGroupService: IDocumentPerGroupService
    {
        public readonly IDocumentPerGroupRepository _DocumentPerGroupRepository;
        public readonly IMapper _Mapper;

        public DocumentPerGroupService(IDocumentPerGroupRepository DocumentPerGroupRepository, IMapper Mapper)
        {
            _DocumentPerGroupRepository = DocumentPerGroupRepository;
            _Mapper = Mapper;
        }

        public string DeleteDocumentPerGroup(int idDocumentPerGroup, int idGroup)
        {
            return _DocumentPerGroupRepository.DeleteDocumentPerGroup(idDocumentPerGroup, idGroup);
        }

        public AppDocumentPerGroupDTO DeleteFewDocumentPerGroup(int idFolder, int requiredDocumentPerGroupId)
        {
            return _Mapper.Map<AppDocumentPerGroupDTO>(_DocumentPerGroupRepository.DeleteFewDocumentPerGroup(idFolder, requiredDocumentPerGroupId));
        }

        public List<AppDocumentPerGroupDTO> GetLstDocumentPerGroup(int GroupId, int schollId)
        {
            return _Mapper.Map<List<AppDocumentPerGroupDTO>>(_DocumentPerGroupRepository.GetLstDocumentPerGroup(GroupId, schollId));
        }

        public void SaveNameFile(int idfile, string nameFile)
        {
            _DocumentPerGroupRepository.SaveNameFile(idfile, nameFile);
        }

        public AppDocumentPerGroupDTO UploadDocumentPerGroup(AppDocumentPerGroupDTO documentPerGroupDTO)
        {
            return _Mapper.Map<AppDocumentPerGroupDTO>(_DocumentPerGroupRepository.UploadDocumentPerGroup(_Mapper.Map<AppDocumentPerGroup>(documentPerGroupDTO)));
        }

        public List<AppDocumentPerGroupDTO> UploadFewDocumentsPerGroup(List<AppDocumentPerGroupDTO> lstDocumentPerGroupDTO, string nameFolder)
        {
            return _Mapper.Map<List<AppDocumentPerGroupDTO>>(_DocumentPerGroupRepository.UploadFewDocumentsPerGroup(_Mapper.Map<List<AppDocumentPerGroup>>(lstDocumentPerGroupDTO), nameFolder));

        }


    }
}
