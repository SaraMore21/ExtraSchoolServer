using DB.Model;
using DB.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace DB.Repository.Classes
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ExtraSchoolContext _context;
        private readonly IUserRepository _UserRepository;
        private readonly IQuestionsOfTaskRepository _questionsOfTaskRepository;
        private readonly IUniqeCodeRepository _uniqeCodeRepository;
        private readonly IScoreStudentPerQuestionsOfTaskRepository _scoreStudentPerQuestionsOfTaskRepository;

        public TaskRepository(ExtraSchoolContext context, IUserRepository UserRepository,IQuestionsOfTaskRepository questionsOfTaskRepository,IUniqeCodeRepository uniqeCodeRepository, IScoreStudentPerQuestionsOfTaskRepository scoreStudentPerQuestionsOfTaskRepository)
        {
            _context = context;
            _UserRepository = UserRepository;
            _questionsOfTaskRepository = questionsOfTaskRepository;
            _uniqeCodeRepository = uniqeCodeRepository;
            _scoreStudentPerQuestionsOfTaskRepository = scoreStudentPerQuestionsOfTaskRepository;
        }

        public AppTask AddOrUpdate(int schoolID, int yearbookId, AppTask appTask)
        {
            if (appTask.Idtask == 0 || appTask.Idtask == null)
            {
                appTask.YearBookId = yearbookId;
                appTask.SchoolId = schoolID;
                appTask.TypeTask = null;
                appTask.Coordinator = null;
                appTask.School = null;
                appTask.TypeOfTaskCalculation = null;
                appTask.CheckType = null;
                _context.AppTasks.Add(appTask);
            }
            else
            {
                var x = _context.AppTasks.FirstOrDefault(f => f.Idtask == appTask.Idtask);
                if (x != null)
                {
                    if (_context.AppScoreStudentPerQuestionsOfTasks.FirstOrDefault(f => f.Score != null && f.QuestionOfTask.TaskId == appTask.Idtask) != null)
                        return null;
                    x.CodeTask = appTask.CodeTask;
                    x.CoordinatorId = appTask.CoordinatorId;
                    x.DateUpdate = appTask.DateUpdate;
                    x.Name = appTask.Name;
                    x.NameEnglish = appTask.NameEnglish;
                    x.TypeTaskId = appTask.TypeTaskId;
                    x.TypeOfTaskCalculationId = appTask.TypeOfTaskCalculationId;
                    x.UserUpdatedId = appTask.UserUpdatedId;
                    
                }

            }
            _context.SaveChanges();
            appTask = _context.AppTasks.Include(i => i.TypeTask).Include(t=>t.TypeOfTaskCalculation).Include(i => i.Coordinator.User).Include(i=>i.CheckType).FirstOrDefault(f => f.Idtask == appTask.Idtask);
            return appTask;
        }

        public Tuple<List<AppTask>, List<AppUserPerSchool>, int> AddOrUpdateTasksOfSpecificCodeByCustomer(AppTask appTask, List<SchoolWithYearBookAndUserPerSchool> schools, int YearbookId, int IDcustomer, List<AppQuestionsOfTask> ListQuestion)
        {
            AppTask task;
            SecUser users = new SecUser();
            Dictionary<int, int> dict = new Dictionary<int, int>();
            Tuple<Dictionary<int, int>, List<AppUserPerSchool>,int> tuple;
            tuple = Tuple.Create(new Dictionary<int, int>(), new List<AppUserPerSchool>(),0);
            int value = 0;
            List<AppQuestionsOfTask> LQ;
            if (appTask.CoordinatorId != null)
            {
                tuple = _UserRepository.AddUserByCustomer((int)appTask.CoordinatorId, schools, IDcustomer);
                dict = tuple.Item1;
            }            
            List<AppTask> appTasks = new List<AppTask>();
            //הוספה
            if (appTask.Idtask == 0 || appTask.Idtask == null)
            {
                AppTask a = new AppTask();

                AppUniqueCode f = new AppUniqueCode() { CustomerId = null, DateCreated = DateTime.UtcNow.AddHours(3) };
                _context.AppUniqueCodes.Add(f);
                _context.SaveChanges();

                if (appTask.CoordinatorId != null)
                {
                    users = _context.SecUsers.Include(i => i.AppUserPerSchools).FirstOrDefault(w => w.Iduser == appTask.CoordinatorId);
                }
                foreach (var item in schools)
                {
                    task = new AppTask();
                    task.SchoolId = item.SchoolId;
                    task.TypeTaskId = appTask.TypeTaskId;
                    task.TypeOfTaskCalculationId = appTask.TypeOfTaskCalculationId;
                    task.CoordinatorId = dict != null && dict.TryGetValue(item.SchoolId, out value) ? value : null;
                    task.CodeTask = appTask.CodeTask;
                    task.DateCreated = DateTime.Today;
                    task.Name = appTask.Name;
                    task.NameEnglish = appTask.NameEnglish;
                    task.YearBookId = item.YearBookId;
                    task.UserCreatedId = item.UserPerSchoolId;
                    task.UniqueCodeId = f.IduniqueCode;
                    appTasks.Add(task);
                }

                _context.AppTasks.AddRange(appTasks);


  
            }
            //עריכה
            else
            {
                var x = _context.AppTasks.ToList().Where(f => f.UniqueCodeId == appTask.UniqueCodeId && schools.FirstOrDefault(t => t.SchoolId == f.SchoolId) != null);
                AppTask task2;
                
                if (x != null)
                {
                    if (_context.AppScoreStudentPerQuestionsOfTasks.Include(q=>q.QuestionOfTask.Task).FirstOrDefault(f => f.Score != null && f.QuestionOfTask.Task.UniqueCodeId == appTask.UniqueCodeId) != null)
                        return Tuple.Create(new List<AppTask>(),new List<AppUserPerSchool>(),-1);
                    foreach (var item in schools)
                    {
                        task2 = x.FirstOrDefault(f => f.SchoolId == item.SchoolId);
                        if (task2 != null)
                        { 
                            task2.CodeTask = appTask.CodeTask;
                            task2.CoordinatorId = dict != null && dict.TryGetValue(item.SchoolId, out value) ? value : null;
                            task2.DateUpdate = appTask.DateUpdate;
                            task2.Name = appTask.Name;
                            task2.NameEnglish = appTask.NameEnglish;
                            task2.TypeTaskId = appTask.TypeTaskId;
                            task2.CheckTypeId = appTask.CheckTypeId;
                            task2.TypeOfTaskCalculationId = appTask.TypeOfTaskCalculationId;
                            task2.DateUpdate = DateTime.Today;
                            task2.UserUpdatedId = item.UserPerSchoolId;
                            task2.YearBookId = item.YearBookId;
                            LQ = new List<AppQuestionsOfTask>();
                            ListQuestion.ForEach(f => {
                                f.UniqeCodeId = f.UniqeCodeId == null ? _uniqeCodeRepository.AddUniqeCode(IDcustomer) : f.UniqeCodeId;
                                LQ.Add(Clone(f, task2, IDcustomer)); 
                            });
                            _questionsOfTaskRepository.UpdateQuestionOfTask(LQ, task2.Idtask,true,(int)task2.UserUpdatedId);
                            var ListTaskExsist= _context.AppTaskExsists.Where(w => w.TaskId == task2.Idtask).ToList();
                            foreach (var taskExsist in ListTaskExsist)
                            {
                                _scoreStudentPerQuestionsOfTaskRepository.AddScoreStudentsOfQuestion(task2.Idtask, (int)taskExsist.CourseId, item.UserPerSchoolId);
                            }
                        }
                    }

                }

            }
            _context.SaveChanges();

            List<AppQuestionsOfTask> newList;
            //הוספת שאלונים למטלה
            foreach (var taskItem in appTasks)
            {

                //LQ =new List<AppQuestionsOfTask>(ListQuestion);
                //LQ = DeepClone(ListQuestion);
                //LQ= DB.Repository.Classes.GenericFunctionsRepository.DeepClone(ListQuestion);
                //LQ.ForEach(f => {  
                //if (f.IdquestionOfTask == 0) { f.UserCreatedId = taskItem.UserUpdatedId ?? taskItem.UserCreatedId; f.DateCreated = DateTime.Today; }
                //else { f.UserUpdatedId = taskItem.UserUpdatedId; f.DateUpdate = DateTime.Today; }
                //});


                //newList = new List<AppQuestionsOfTask>();
                LQ = new List<AppQuestionsOfTask>();
                ListQuestion.ForEach(f =>
                {
                    f.UniqeCodeId =f.UniqeCodeId== null?_uniqeCodeRepository.AddUniqeCode(IDcustomer):f.UniqeCodeId;
                    LQ.Add(Clone(f, taskItem, IDcustomer)); 
                });
                _questionsOfTaskRepository.AddQuestionsOfTask(LQ, taskItem.Idtask);

            }

            List<AppTask> lstTasks = _context.AppTasks.Include(s => s.School).Include(y => y.YearBook).Include(i => i.TypeTask).Include(i=>i.CheckType).Include(t=>t.TypeOfTaskCalculation).Include(i => i.Coordinator.User).ToList().Where(w => w.YearBook.YearbookId == YearbookId && schools != null && schools.FirstOrDefault(t => t.SchoolId == w.SchoolId) != null).ToList();
            Tuple<List<AppTask>, List<AppUserPerSchool>,int> tup= Tuple.Create(lstTasks, tuple.Item2, tuple.Item3);
            return tup;
        }

        public AppQuestionsOfTask Clone(AppQuestionsOfTask Q,AppTask taskItem,int CustomerId)
        {
            var Question= new AppQuestionsOfTask
            {
                Name=Q.Name,
                Percent=Q.Percent,
                IdquestionOfTask=Q.IdquestionOfTask,
                UniqeCodeId=Q.UniqeCodeId,
                TaskId=Q.TaskId
            };
            //if (Question.IdquestionOfTask == 0) { Question.UserCreatedId = taskItem.UserUpdatedId ?? taskItem.UserCreatedId; Question.DateCreated = DateTime.Today; }
            //    else { Question.UserUpdatedId = taskItem.UserUpdatedId; Question.DateUpdate = DateTime.Today; }
            return Question;
        }

        //public T DeepClone<T>(this T obj)
        //{
        //    using (var ms = new MemoryStream())
        //    {
        //        var formatter = new BinaryFormatter();
        //        formatter.Serialize(ms, obj);
        //        ms.Position = 0;

        //        return (T)formatter.Deserialize(ms);
        //    }
        //}

        public bool DeleteTask(int schoolID, int yearbookId, int idTask)
        {
            var x = _context.AppTasks.Include(i => i.AppTaskExsists).FirstOrDefault(f => f.Idtask == idTask);
            if (x != null)
            {
                if (x.AppTaskExsists.Count() > 0)
                    return false;
                else
                {
                    _context.AppTasks.Remove(x);
                    _context.SaveChanges();
                    return true;
                }
            }
            return false;

        }

        public List<AppTask> GetAllTaskBySchoolId(string SchoolsId, int YearbookId)
        {
            SchoolsId = SchoolsId.Remove(SchoolsId.Length - 1);
            var Array = SchoolsId.Split(",").ToList();
            return _context.AppTasks.Include(s => s.School).Include(y => y.YearBook).Include(i => i.TypeTask).Include(i=>i.CheckType).Include(tc=>tc.TypeOfTaskCalculation).Include(i => i.Coordinator.User).Where(w => Array.Any(a => a == w.SchoolId.ToString()) == true && w.YearBook.YearbookId == YearbookId).ToList();
        }
    }
}

