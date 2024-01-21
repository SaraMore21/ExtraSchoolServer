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
    public class DocumentPerTaskExsistService : IDocumentPerTaskExsistService
    {
        public readonly IDocumentPerTaskExsistRepository _DocumentPerTaskExsistRepository;
        public readonly IMapper _Mapper;

        public DocumentPerTaskExsistService(IDocumentPerTaskExsistRepository DocumentPerTaskExsistRepository, IMapper Mapper)
        {
            _DocumentPerTaskExsistRepository = DocumentPerTaskExsistRepository;
            _Mapper = Mapper;
        }

        public string DeleteDocumentPerTaskExsist(int idDocumentPerTaskExsist, int idTaskExsist)
        {
            return _DocumentPerTaskExsistRepository.DeleteDocumentPerTaskExsist(idDocumentPerTaskExsist, idTaskExsist);
        }

        public AppDocumentPerTaskExsistDTO DeleteFewDocumentPerTaskExsist(int idFolder, int requiredDocumentPerTaskExsistId)
        {
            return _Mapper.Map<AppDocumentPerTaskExsistDTO>(_DocumentPerTaskExsistRepository.DeleteFewDocumentPerTaskExsist(idFolder, requiredDocumentPerTaskExsistId));
        }

        public List<AppDocumentPerTaskExsistDTO> GetLstDocumentPerTaskExsist(int TaskExsistId, int schollId)
        {
            return _Mapper.Map<List<AppDocumentPerTaskExsistDTO>>(_DocumentPerTaskExsistRepository.GetLstDocumentPerTaskExsist(TaskExsistId, schollId));
        }

        public void SaveNameFile(int idfile, string nameFile)
        {
            _DocumentPerTaskExsistRepository.SaveNameFile(idfile, nameFile);
        }

        public AppDocumentPerTaskExsistDTO UploadDocumentPerTaskExsist(AppDocumentPerTaskExsistDTO documentPerTaskExsistDTO)
        {
            return _Mapper.Map<AppDocumentPerTaskExsistDTO>(_DocumentPerTaskExsistRepository.UploadDocumentPerTaskExsist(_Mapper.Map<AppDocumentPerTaskExsist>(documentPerTaskExsistDTO)));
        }

        public List<AppDocumentPerTaskExsistDTO> UploadFewDocumentsPerTaskExsist(List<AppDocumentPerTaskExsistDTO> lstDocumentPerTaskExsistDTO, string nameFolder)
        {
            return _Mapper.Map<List<AppDocumentPerTaskExsistDTO>>(_DocumentPerTaskExsistRepository.UploadFewDocumentsPerTaskExsist(_Mapper.Map<List<AppDocumentPerTaskExsist>>(lstDocumentPerTaskExsistDTO), nameFolder));

        }

    }
}
