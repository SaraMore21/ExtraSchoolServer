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
    public class TaskExsistService : ITaskExsistService
    {
        private ITaskExsistRepository _TaskExsistrepository;
        private ITaskToStudentRepository _TaskToStudentRepository;
        private IMapper _mapper;
        private readonly IScoreStudentPerQuestionsOfTaskRepository _scoreStudentPerQuestionsOfTaskRepository;


        public TaskExsistService(ITaskExsistRepository TaskExsistrepository, IMapper Mapper, ITaskToStudentRepository TaskToStudentRepository, IScoreStudentPerQuestionsOfTaskRepository IscoreStudentPerQuestionsOfTaskRepository)
        {
            _TaskExsistrepository = TaskExsistrepository;
            _TaskToStudentRepository = TaskToStudentRepository;
            _mapper = Mapper;
            _scoreStudentPerQuestionsOfTaskRepository = IscoreStudentPerQuestionsOfTaskRepository;
        }

        public AppTaskExsistDTO AddOrUpdate(int schoolID, int yearbookId, AppTaskExsistDTO taskExsistDTO)
        {
            AppTaskExsist t = _TaskExsistrepository.AddOrUpdate(schoolID, yearbookId, _mapper.Map<AppTaskExsist>(taskExsistDTO));
            if (taskExsistDTO.IdexsistTask == 0 || taskExsistDTO.IdexsistTask == null)
            {
                _TaskToStudentRepository.AddTaskForAllStudentInCourse(schoolID, yearbookId, t);
               // _scoreStudentPerQuestionsOfTaskRepository.AddScoreStudentsOfQuestion((int)t.TaskId, (int)t.CourseId, (int)t.UserUpdatedId);
            }
            var a = _mapper.Map<AppTaskExsistDTO>(t);
            return a;
        }

        public bool DeleteTask(int idTaskExsist, bool deleteTaskToStudents)
        {
            return _TaskExsistrepository.DeleteTaskExsist(idTaskExsist, deleteTaskToStudents);

        }

        public List<AppTaskExsistDTO> GetAllTaskBySchoolId(int tasxExsistId)
        {
            var x = _mapper.Map<List<AppTaskExsistDTO>>(_TaskExsistrepository.GetAllTaskExsistByTaskId(tasxExsistId));
            return x;
        }

        public int getSumPercentsOfCourse(int? CourseId, int tasxExsistId)
        {
            var x = _TaskExsistrepository.getSumPercentsOfCourse(CourseId, tasxExsistId);
            return x;
        }
    }
}
