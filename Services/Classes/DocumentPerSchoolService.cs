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
    public class DocumentPerSchoolService : IDocumentPerSchoolService
    {
        public readonly IDocumentPerSchoolRepository _DocumentPerSchoolRepository;
        public readonly IMapper _Mapper;

        public DocumentPerSchoolService(IDocumentPerSchoolRepository DocumentPerSchoolRepository, IMapper Mapper)
        {
            _DocumentPerSchoolRepository = DocumentPerSchoolRepository;
            _Mapper = Mapper;
        }

        public string DeleteDocumentPerSchool(int idDocumentPerSchool, int idSchool, int uniqueCodeDocumentId)
        {
            return _DocumentPerSchoolRepository.DeleteDocumentPerSchool(idDocumentPerSchool, idSchool, uniqueCodeDocumentId);
        }

        public AppDocumentPerSchoolDTO DeleteFewDocumentPerSchool(int idFolder, int requiredDocumentPerSchoolId, int idSchool, int uniqueCodeDocumentId)
        {
            return _Mapper.Map<AppDocumentPerSchoolDTO>(_DocumentPerSchoolRepository.DeleteFewDocumentPerSchool(idFolder, requiredDocumentPerSchoolId, idSchool, uniqueCodeDocumentId));
        }

        public List<AppDocumentPerSchoolDTO> GetLstDocumentPerSchool(int SchoolId)
        {
            var a = _Mapper.Map<List<AppDocumentPerSchoolDTO>>(_DocumentPerSchoolRepository.GetLstDocumentPerSchool(SchoolId));
            return a;
        }

        public void SaveNameFile(int idfile, string nameFile, int uniqeId)
        {
            _DocumentPerSchoolRepository.SaveNameFile(idfile, nameFile, uniqeId);
        }

        public AppDocumentPerSchoolDTO UploadDocumentPerSchool(AppDocumentPerSchoolDTO documentPerSchoolDTO, int uniqueCodeID)
        {
            return _Mapper.Map<AppDocumentPerSchoolDTO>(_DocumentPerSchoolRepository.UploadDocumentPerSchool(_Mapper.Map<AppDocumentPerSchool>(documentPerSchoolDTO), uniqueCodeID));
        }

        public List<AppDocumentPerSchoolDTO> UploadFewDocumentsPerSchool(List<AppDocumentPerSchoolDTO> lstDocumentPerSchoolDTO, string nameFolder, string uniqueCodeID, int userId, int customerId)
        {
            var a = _Mapper.Map<List<AppDocumentPerSchoolDTO>>(_DocumentPerSchoolRepository.UploadFewDocumentsPerSchool(_Mapper.Map<List<AppDocumentPerSchool>>(lstDocumentPerSchoolDTO), nameFolder, uniqueCodeID, userId, customerId));
            return a;
        }
    }
}
