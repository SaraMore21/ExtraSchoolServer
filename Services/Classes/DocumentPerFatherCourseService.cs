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
    public class DocumentPerFatherCourseService : IDocumentPerFatherCourseService
    {
        public readonly IDocumentPerFatherCourseRepository _DocumentPerFatherCourseRepository;
        public readonly IMapper _Mapper;

        public DocumentPerFatherCourseService(IDocumentPerFatherCourseRepository DocumentPerFatherCourseRepository, IMapper Mapper)
        {
            _DocumentPerFatherCourseRepository = DocumentPerFatherCourseRepository;
            _Mapper = Mapper;
        }

        public string DeleteDocumentPerFatherCourse(int idDocumentPerFatherCourse, int idFatherCourse, int uniqueCodeDocumentId)
        {
            return _DocumentPerFatherCourseRepository.DeleteDocumentPerFatherCourse(idDocumentPerFatherCourse, idFatherCourse, uniqueCodeDocumentId);
        }

        public AppDocumentPerFatherCourseDTO DeleteFewDocumentPerFatherCourse(int idFolder, int requiredDocumentPerFatherCourseId, int idFatherCourse, int uniqueCodeDocumentId)
        {
            return _Mapper.Map<AppDocumentPerFatherCourseDTO>(_DocumentPerFatherCourseRepository.DeleteFewDocumentPerFatherCourse(idFolder, requiredDocumentPerFatherCourseId,idFatherCourse, uniqueCodeDocumentId));
        }

        public List<AppDocumentPerFatherCourseDTO> GetLstDocumentPerFatherCourse(int FatherCourseId, int schollId)
        {
            var a= _Mapper.Map<List<AppDocumentPerFatherCourseDTO>>(_DocumentPerFatherCourseRepository.GetLstDocumentPerFatherCourse(FatherCourseId, schollId));
            return a;
        }

        public void SaveNameFile(int idfile, string nameFile, int uniqeId)
        {
            _DocumentPerFatherCourseRepository.SaveNameFile(idfile, nameFile, uniqeId);
        }

        public AppDocumentPerFatherCourseDTO UploadDocumentPerFatherCourse(AppDocumentPerFatherCourseDTO documentPerFatherCourseDTO, int uniqueCodeID)
        {
            return _Mapper.Map<AppDocumentPerFatherCourseDTO>(_DocumentPerFatherCourseRepository.UploadDocumentPerFatherCourse(_Mapper.Map<AppDocumentPerFatherCourse>(documentPerFatherCourseDTO),uniqueCodeID));
        }

        public List<AppDocumentPerFatherCourseDTO> UploadFewDocumentsPerFatherCourse(List<AppDocumentPerFatherCourseDTO> lstDocumentPerFatherCourseDTO, string nameFolder, int uniqueCodeID, int userId, int customerId)
        {
            var a =  _Mapper.Map<List<AppDocumentPerFatherCourseDTO>>(_DocumentPerFatherCourseRepository.UploadFewDocumentsPerFatherCourse(_Mapper.Map<List<AppDocumentPerFatherCourse>>(lstDocumentPerFatherCourseDTO), nameFolder, uniqueCodeID, userId, customerId));
            return a;
        }


    }
}
