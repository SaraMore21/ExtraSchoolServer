using AutoMapper;
using DB.Model;
using DB.Repository.Interfaces;
using DTO.Classes;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Services.Classes
{

    public class DocumentPerProfessionService : IDocumentPerProfessionService
    {
        public readonly IDocumentPerProfessionRepository _DocumentPerProfessionRepository;
        public readonly IMapper _Mapper;

        public DocumentPerProfessionService(IDocumentPerProfessionRepository DocumentPerProfessionRepository, IMapper Mapper)
        {
            _DocumentPerProfessionRepository = DocumentPerProfessionRepository;
            _Mapper = Mapper;
        }


        public string DeleteDocumentPerProfession(int idDocumentPerProfession, int idProfession, int uniqueCodeDocumentId)
        {
            return _DocumentPerProfessionRepository.DeleteDocumentPerProfession(idDocumentPerProfession, idProfession, uniqueCodeDocumentId);
        }

        public AppDocumentPerProfessionDTO DeleteFewDocumentPerProfession(int idFolder, int requiredDocumentPerProfessionId, int idProfession, int uniqueCodeDocumentId)
        {
            return _Mapper.Map<AppDocumentPerProfessionDTO>(_DocumentPerProfessionRepository.DeleteFewDocumentPerProfession(idFolder, requiredDocumentPerProfessionId, idProfession, uniqueCodeDocumentId));
        }

        public List<AppDocumentPerProfessionDTO> GetLstDocumentPerProfession(int ProfessionId, int schollId)
        {
            var a = _Mapper.Map<List<AppDocumentPerProfessionDTO>>(_DocumentPerProfessionRepository.GetLstDocumentPerProfession(ProfessionId, schollId));
            return a;
        }

        public void SaveNameFile(int idfile, string nameFile, int uniqeId)
        {
            _DocumentPerProfessionRepository.SaveNameFile(idfile, nameFile, uniqeId);
        }

        public AppDocumentPerProfessionDTO UploadDocumentPerProfession(AppDocumentPerProfessionDTO documentPerProfessionDTO, int uniqueCodeID)
        {
            return _Mapper.Map<AppDocumentPerProfessionDTO>(_DocumentPerProfessionRepository.UploadDocumentPerProfession(_Mapper.Map<AppDocumentPerProfession>(documentPerProfessionDTO), uniqueCodeID));
        }

        public List<AppDocumentPerProfessionDTO> UploadFewDocumentsPerProfession(List<AppDocumentPerProfessionDTO> lstDocumentPerProfessionDTO, string nameFolder, int uniqueCodeID, int userId, int customerId)
        {
            var a = _Mapper.Map<List<AppDocumentPerProfessionDTO>>(_DocumentPerProfessionRepository.UploadFewDocumentsPerProfession(_Mapper.Map<List<AppDocumentPerProfession>>(lstDocumentPerProfessionDTO), nameFolder, uniqueCodeID, userId, customerId));
            return a;
        }

    }
}
