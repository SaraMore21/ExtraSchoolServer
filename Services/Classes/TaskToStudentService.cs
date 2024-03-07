using AutoMapper;
using DB.Model;
using DB.Repository.Interfaces;
using DTO.Classes;
using Services.Interfaces;
using System.Collections.Generic;

namespace Services.Classes
{
    public class TaskToStudentService : ITaskToStudentService
    {
        private ITaskToStudentRepository _TaskToStudentRepository;
        private IMapper _mapper;

        public TaskToStudentService(ITaskToStudentRepository TaskToStudentRepository, IMapper mapper)
        {
            _TaskToStudentRepository = TaskToStudentRepository;
            _mapper = mapper;
        }

        public AppTaskToStudentDTO AddOrUpdate(int schoolID, int yearbookId, AppTaskToStudentDTO TaskToStudent, bool isAotomat)
        {
            if (isAotomat)
            {
                _TaskToStudentRepository.UpdateScoreStudentPerQuestions(_mapper.Map<List<AppScoreStudentPerQuestionsOfTask>>(TaskToStudent.AppScoreStudentPerQuestionsOfTasks));
            }
            AppTaskToStudent t = _TaskToStudentRepository.AddOrUpdate(schoolID, yearbookId, _mapper.Map<AppTaskToStudent>(TaskToStudent));
            var a = _mapper.Map<AppTaskToStudentDTO>(t);
            return a;
        }

        public bool DeleteTaskToStudent(int schoolID, int yearbookId, int idTaskExsist)
        {
            return _TaskToStudentRepository.DeleteTaskToStudent(schoolID, yearbookId, idTaskExsist);
        }

        public List<AppTaskToStudentDTO> GetAllTaskToStudentByTaskExsistID(int tasxExsistId, int schoolID, int yearbookId)
        {
            var x = _mapper.Map<List<AppTaskToStudentDTO>>(_TaskToStudentRepository.GetAllTaskToStudentByTaskExsistID(schoolID, yearbookId, tasxExsistId));
            return x;
        }

        public bool UpdateActiveTask(int schoolID, int taskToStudentId, bool isActive)
        {
            return _TaskToStudentRepository.UpdateActiveTask(schoolID, taskToStudentId, isActive);
        }
        public bool EditScoreToStudents(List<AppTaskToStudentDTO> ListTaskToStudent)
        {
            return _TaskToStudentRepository.EditScoreToStudents(_mapper.Map<List<AppTaskToStudent>>(ListTaskToStudent));
        }
        //שליפת ציונוי התלמידות לשאלה
        public List<AppScoreStudentPerQuestionsOfTaskDTO> GetScoreStudentInQuestionOfTask(int QuestionId)
        {
            return _mapper.Map<List<AppScoreStudentPerQuestionsOfTaskDTO>>(_TaskToStudentRepository.GetScoreStudentInQuestionOfTask(QuestionId));
        }

        public List<AppScoreStudentPerQuestionsOfTaskDTO> EditScoreQuestionToStudents(List<AppScoreStudentPerQuestionsOfTaskDTO> ListScoreQuestionPerStudent)
        {
            return _mapper.Map<List<AppScoreStudentPerQuestionsOfTaskDTO>>(_TaskToStudentRepository.EditScoreQuestionToStudents(_mapper.Map<List<AppScoreStudentPerQuestionsOfTask>>(ListScoreQuestionPerStudent)));
        }

   
    }
}
