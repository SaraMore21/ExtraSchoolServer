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
    public class DocumentPerStudentService : IDocumentPerStudentService
    {
        public readonly IDocumentPerStudentRepository _DocumentPerStudentRepository;
        public readonly IMapper _Mapper;

        public DocumentPerStudentService(IDocumentPerStudentRepository DocumentPerStudentRepository, IMapper Mapper)
        {
            _DocumentPerStudentRepository = DocumentPerStudentRepository;
            _Mapper = Mapper;
        }

        public string DeleteDocumentPerStudent(int idDocumentPerStudent, int idStudent)
        {
            return _DocumentPerStudentRepository.DeleteDocumentPerStudent(idDocumentPerStudent, idStudent);
        }

        public AppDocumentPerStudentDTO DeleteFewDocumentPerStudent(int idFolder, int requiredDocumentPerStudentId)
        {
            return _Mapper.Map<AppDocumentPerStudentDTO>(_DocumentPerStudentRepository.DeleteFewDocumentPerStudent(idFolder, requiredDocumentPerStudentId));
        }

        public List<AppDocumentPerStudentDTO> GetLstDocumentPerStudent(int StudentId, int schollId)
        {
            return _Mapper.Map<List<AppDocumentPerStudentDTO>>(_DocumentPerStudentRepository.GetLstDocumentPerStudent(StudentId, schollId));
        }

        public void SaveNameFile(int idfile, string nameFile)
        {
            _DocumentPerStudentRepository.SaveNameFile(idfile, nameFile);
        }

        public AppDocumentPerStudentDTO UploadDocumentPerStudent(AppDocumentPerStudentDTO documentPerStudentDTO)
        {
            return _Mapper.Map<AppDocumentPerStudentDTO>(_DocumentPerStudentRepository.UploadDocumentPerStudent(_Mapper.Map<AppDocumentPerStudent>(documentPerStudentDTO)));
        }

        public List<AppDocumentPerStudentDTO> UploadFewDocumentsPerStudent(List<AppDocumentPerStudentDTO> lstDocumentPerStudentDTO, string nameFolder)
        {
            return _Mapper.Map<List<AppDocumentPerStudentDTO>>(_DocumentPerStudentRepository.UploadFewDocumentsPerStudent(_Mapper.Map<List<AppDocumentPerStudent>>(lstDocumentPerStudentDTO), nameFolder));

        }

    }
}
