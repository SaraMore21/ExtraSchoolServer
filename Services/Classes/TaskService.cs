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
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;
        private readonly IQuestionsOfTaskRepository _questionsOfTaskRepository;
        private readonly ITaskExsistRepository _taskExsistRepository;
        private readonly IScoreStudentPerQuestionsOfTaskRepository _scoreStudentPerQuestionsOfTaskRepository;

        public TaskService(ITaskRepository taskRepository, IMapper mapper, IQuestionsOfTaskRepository questionsOfTaskRepository, ITaskExsistRepository taskExsistRepository, IScoreStudentPerQuestionsOfTaskRepository scoreStudentPerQuestionsOfTaskRepository)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
            _questionsOfTaskRepository = questionsOfTaskRepository;
            _taskExsistRepository = taskExsistRepository;
            _scoreStudentPerQuestionsOfTaskRepository = scoreStudentPerQuestionsOfTaskRepository;
        }

        public AppTaskDTO AddOrUpdate(int schoolID, int yearbookId, AppTaskDTO taskDTO)
        {
            AppTask t = _taskRepository.AddOrUpdate(schoolID, yearbookId, _mapper.Map<AppTask>(taskDTO));
            if (t == null) return null;
            var a = _mapper.Map<AppTaskDTO>(t);
            if (taskDTO.Idtask == 0)
                _questionsOfTaskRepository.AddQuestionsOfTask(_mapper.Map<List<AppQuestionsOfTask>>(taskDTO.ListQuestion), t.Idtask);
            else
            {
                _questionsOfTaskRepository.UpdateQuestionOfTask(_mapper.Map<List<AppQuestionsOfTask>>(taskDTO.ListQuestion), t.Idtask, false, (int)t.UserUpdatedId);
                //הועבר למתי שפותחים מטלה קיימת לקבוצה ששם נפתח כל המטלה לתלמיד...

                //var ListTaskExsist = _taskExsistRepository.GetTaskExsistByTaskId(t.Idtask);
                //foreach (var taskExsist in ListTaskExsist)
                //{
                //    _scoreStudentPerQuestionsOfTaskRepository.AddScoreStudentsOfQuestion(t.Idtask, (int)taskExsist.CourseId, (int)t.UserUpdatedId);
                //}
            }
            return a;
        }

        public Tuple<List<AppTaskDTO>, List<SecUserDTO>, AppUserPerSchoolWithDetailsDTO, int> AddOrUpdateTasksOfSpecificCodeByCustomer(AppTaskDTO taskDTO, List<AppSchoolWhithYearbookDTO> Schools, int YearbookId, int IDcustomer)
        {
            List<DB.Repository.Classes.SchoolWithYearBookAndUserPerSchool> schools = new List<DB.Repository.Classes.SchoolWithYearBookAndUserPerSchool>();
            DB.Repository.Classes.SchoolWithYearBookAndUserPerSchool s = new DB.Repository.Classes.SchoolWithYearBookAndUserPerSchool();
            Schools.ForEach(f =>
                    {
                        s = new DB.Repository.Classes.SchoolWithYearBookAndUserPerSchool();
                        s.SchoolId = f.school.Idschool;
                        s.UserPerSchoolId = f.UserId;
                        s.YearBookId = (int)f.AppYearbookPerSchools.FirstOrDefault(r => r.SchoolId == s.SchoolId && r.YearbookId == YearbookId)?.IdyearbookPerSchool;

                        schools.Add(s);
                    }
                );

            Tuple<List<AppTask>, List<AppUserPerSchool>, int> tuple = _taskRepository.AddOrUpdateTasksOfSpecificCodeByCustomer(_mapper.Map<AppTask>(taskDTO), schools, YearbookId, IDcustomer, _mapper.Map<List<AppQuestionsOfTask>>(taskDTO.ListQuestion));


            List<AppTaskDTO> AppTaskDTO = _mapper.Map<List<AppTaskDTO>>(tuple.Item1);



            List<SecUserDTO> appUserPerSchools = null;
            AppUserPerSchoolWithDetailsDTO appUserPerSchoolWithDetailsDTO = null;
            if (tuple.Item2 != null && tuple.Item2.Count() > 0)
            {
                appUserPerSchools = _mapper.Map<List<SecUserDTO>>(tuple.Item2);
                appUserPerSchoolWithDetailsDTO = _mapper.Map<AppUserPerSchoolWithDetailsDTO>(tuple.Item2[0]);
            }

            Tuple<List<AppTaskDTO>, List<SecUserDTO>, AppUserPerSchoolWithDetailsDTO, int> tuple2 = Tuple.Create(AppTaskDTO, appUserPerSchools, appUserPerSchoolWithDetailsDTO, tuple.Item3);
            return tuple2;
        }

        public bool DeleteTask(int schoolID, int yearbookId, int idTask)
        {
            return _taskRepository.DeleteTask(schoolID, yearbookId, idTask);
        }

        public List<AppTaskDTO> GetAllTaskBySchoolId(string SchoolsId, int YearbookId)
        {
            var t = _taskRepository.GetAllTaskBySchoolId(SchoolsId, YearbookId);
            var a = _mapper.Map<List<AppTaskDTO>>(t);
            return a;
        }
    }


}
