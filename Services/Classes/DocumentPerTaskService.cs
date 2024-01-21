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
    public class DocumentPerTaskService: IDocumentPerTaskService
    {
        public readonly IDocumentPerTaskRepository _DocumentPerTaskRepository;
        public readonly IMapper _Mapper;

        public DocumentPerTaskService(IDocumentPerTaskRepository DocumentPerTaskRepository, IMapper Mapper)
        {
            _DocumentPerTaskRepository = DocumentPerTaskRepository;
            _Mapper = Mapper;
        }


        public string DeleteDocumentPerTask(int idDocumentPerTask, int idTask, int uniqueCodeDocumentId)
        {
            return _DocumentPerTaskRepository.DeleteDocumentPerTask(idDocumentPerTask, idTask, uniqueCodeDocumentId);
        }

        public AppDocumentPerTaskDTO DeleteFewDocumentPerTask(int idFolder, int requiredDocumentPerTaskId, int idTask, int uniqueCodeDocumentId)
        {
            return _Mapper.Map<AppDocumentPerTaskDTO>(_DocumentPerTaskRepository.DeleteFewDocumentPerTask(idFolder, requiredDocumentPerTaskId, idTask, uniqueCodeDocumentId));
        }

        public List<AppDocumentPerTaskDTO> GetLstDocumentPerTask(int TaskId, int schollId)
        {
            var a = _Mapper.Map<List<AppDocumentPerTaskDTO>>(_DocumentPerTaskRepository.GetLstDocumentPerTask(TaskId, schollId));
            return a;
        }

        public void SaveNameFile(int idfile, string nameFile, int uniqeId)
        {
            _DocumentPerTaskRepository.SaveNameFile(idfile, nameFile, uniqeId);
        }

        public AppDocumentPerTaskDTO UploadDocumentPerTask(AppDocumentPerTaskDTO documentPerTaskDTO, int uniqueCodeID)
        {
            return _Mapper.Map<AppDocumentPerTaskDTO>(_DocumentPerTaskRepository.UploadDocumentPerTask(_Mapper.Map<AppDocumentPerTask>(documentPerTaskDTO), uniqueCodeID));
        }

        public List<AppDocumentPerTaskDTO> UploadFewDocumentsPerTask(List<AppDocumentPerTaskDTO> lstDocumentPerTaskDTO, string nameFolder, int uniqueCodeID, int userId, int customerId)
        {
            var a = _Mapper.Map<List<AppDocumentPerTaskDTO>>(_DocumentPerTaskRepository.UploadFewDocumentsPerTask(_Mapper.Map<List<AppDocumentPerTask>>(lstDocumentPerTaskDTO), nameFolder, uniqueCodeID, userId, customerId));
            return a;
        }

    }
}
