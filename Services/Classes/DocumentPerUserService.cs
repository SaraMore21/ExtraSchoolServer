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
    public class DocumentPerUserService: IDocumentPerUserService
    {
        public readonly IDocumentPerUserRepository _DocumentPerUserRepository;
        public readonly IMapper _Mapper;

        public DocumentPerUserService(IDocumentPerUserRepository DocumentPerUserRepository, IMapper Mapper)
        {
            _DocumentPerUserRepository = DocumentPerUserRepository;
            _Mapper = Mapper;
        }

        public string DeleteDocumentPerUser(int idDocumentPerUser, int idUser, int uniqueCodeDocumentId)
        {
            return _DocumentPerUserRepository.DeleteDocumentPerUser(idDocumentPerUser, idUser, uniqueCodeDocumentId);
        }

        public AppDocumentPerUserDTO DeleteFewDocumentPerUser(int idFolder, int requiredDocumentPerUserId, int idUser, int uniqueCodeDocumentId)
        {
            return _Mapper.Map<AppDocumentPerUserDTO>(_DocumentPerUserRepository.DeleteFewDocumentPerUser(idFolder, requiredDocumentPerUserId, idUser, uniqueCodeDocumentId));
        }

        public List<AppDocumentPerUserDTO> GetLstDocumentPerUser(int UserId, int schollId)
        {
            var a = _Mapper.Map<List<AppDocumentPerUserDTO>>(_DocumentPerUserRepository.GetLstDocumentPerUser(UserId, schollId));
            return a;
        }

        public void SaveNameFile(int idfile, string nameFile, int uniqeId)
        {
            _DocumentPerUserRepository.SaveNameFile(idfile, nameFile, uniqeId);
        }

        public AppDocumentPerUserDTO UploadDocumentPerUser(AppDocumentPerUserDTO documentPerUserDTO, int uniqueCodeID)
        {
            return _Mapper.Map<AppDocumentPerUserDTO>(_DocumentPerUserRepository.UploadDocumentPerUser(_Mapper.Map<AppDocumentPerUser>(documentPerUserDTO), uniqueCodeID));
        }

        public List<AppDocumentPerUserDTO> UploadFewDocumentsPerUser(List<AppDocumentPerUserDTO> lstDocumentPerUserDTO, string nameFolder, int uniqueCodeID, int userId, int customerId)
        {
            var a = _Mapper.Map<List<AppDocumentPerUserDTO>>(_DocumentPerUserRepository.UploadFewDocumentsPerUser(_Mapper.Map<List<AppDocumentPerUser>>(lstDocumentPerUserDTO), nameFolder, uniqueCodeID, userId, customerId));
            return a;
        }

    }
}
