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
    public class DocumentPerCourseService: IDocumentPerCourseService
    {
        public readonly IDocumentPerCourseRepository _DocumentPerCourseRepository;
        public readonly IMapper _Mapper;

        public DocumentPerCourseService(IDocumentPerCourseRepository DocumentPerCourseRepository, IMapper Mapper)
        {
            _DocumentPerCourseRepository = DocumentPerCourseRepository;
            _Mapper = Mapper;
        }

        public string DeleteDocumentPerCourse(int idDocumentPerCourse, int idCourse)
        {
           return _DocumentPerCourseRepository.DeleteDocumentPerCourse(idDocumentPerCourse, idCourse);
        }

        public AppDocumentPerCourseDTO DeleteFewDocumentPerCourse(int idFolder, int requiredDocumentPerCourseId)
        {
           return _Mapper.Map< AppDocumentPerCourseDTO>( _DocumentPerCourseRepository.DeleteFewDocumentPerCourse(idFolder, requiredDocumentPerCourseId));
        }

        public List<AppDocumentPerCourseDTO> GetLstDocumentPerCourse(int CourseId, int schollId)
        {
            return _Mapper.Map<List<AppDocumentPerCourseDTO>>(_DocumentPerCourseRepository.GetLstDocumentPerCourse(CourseId, schollId));
        }

        public void SaveNameFile(int idfile, string nameFile)
        {
           _DocumentPerCourseRepository.SaveNameFile(idfile, nameFile);
        }

        public AppDocumentPerCourseDTO UploadDocumentPerCourse(AppDocumentPerCourseDTO documentPerCourseDTO)
        {
            return _Mapper.Map<AppDocumentPerCourseDTO>(_DocumentPerCourseRepository.UploadDocumentPerCourse(_Mapper.Map<AppDocumentPerCourse>(documentPerCourseDTO)));
        }

        public List<AppDocumentPerCourseDTO> UploadFewDocumentsPerCourse(List<AppDocumentPerCourseDTO> lstDocumentPerCourseDTO, string nameFolder)
        {
            return _Mapper.Map<List<AppDocumentPerCourseDTO>>(_DocumentPerCourseRepository.UploadFewDocumentsPerCourse(_Mapper.Map<List<AppDocumentPerCourse>>(lstDocumentPerCourseDTO), nameFolder));

        }

    
    }
}
