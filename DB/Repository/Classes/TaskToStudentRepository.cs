using DB.Model;
using DB.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.Classes
{
    public class TaskToStudentRepository : ITaskToStudentRepository
    {
        private readonly ExtraSchoolContext _context;

        public TaskToStudentRepository(ExtraSchoolContext context)
        {
            _context = context;
        }

        public TStatusTaskPerformance GetDefaultStatusPerSchoolId(int schoollId)
        {

            var l= _context.TStatusTaskPerformances.FirstOrDefault(s => s.MosadId == schoollId && s.IsDefault == true);

            return l;
        }


        //הוספת מטלות לכל בנות הקורס ושאלות תואמות למטלת אב
        public bool AddTaskForAllStudentInCourse(int schoolID, int yearbookId, AppTaskExsist TaskExsist)
        {
            AppTaskToStudent AppTaskToStudent = new AppTaskToStudent();
            if (TaskExsist != null && TaskExsist.IdexsistTask != 0 && TaskExsist.CourseId != null)
            {
                AppScoreStudentPerQuestionsOfTask scoreToStudent;
                List<AppScoreStudentPerQuestionsOfTask> ListScoreToStudent = new List<AppScoreStudentPerQuestionsOfTask>();
                var ListQuestion = _context.AppQuestionsOfTasks.Where(w => w.TaskId == TaskExsist.TaskId).ToList();

                List<AppStudent> listStudent = new List<AppStudent>();
                List<AppTaskToStudent> listTaskToStudent = new List<AppTaskToStudent>();
                listStudent = _context.AppStudentPerGroups.Where(w => w.Group.AppGroupSemesterPerCourses.FirstOrDefault(f => f.IdgroupSemesterPerCourse == TaskExsist.CourseId) != null).Select(s => s.Student).ToList();
                foreach (var item in listStudent)
                {

                    AppTaskToStudent = new AppTaskToStudent()
                    {
                        TaskExsistId = TaskExsist.IdexsistTask,
                        StudentId = item.Idstudent,
                        UserCreatedId = TaskExsist.UserCreatedId,
                        DateCreated = TaskExsist.DateCreated,
                        DateNeedSubmit = TaskExsist.DateSubmitA,
                        DateNeedSubmitStr = "מועד א", //+ (TaskExsist.DateSubmitA.Value.Day.ToString() + '/' + TaskExsist.DateSubmitA.Value.Month.ToString() + '/' + TaskExsist.DateSubmitA.Value.Year.ToString()).ToString(),
                        DateSubmit = null,
                        Grade = 0,
                        FinalScore = null,
                        PaymentStatusId = null,
                        PaymentMethodId = null,
                        ReceivePaymentId = null,
                        AmountReceived = 0,
                        Comment = null,
                        AdministratorApproval = false,
                        YearBookId = yearbookId,
                        IsActiveTask = true,
                        StatusTaskPerformanceId = GetDefaultStatusPerSchoolId(schoolID).Id
                };
                    // if ()
                    {
                        foreach (var Q in ListQuestion)
                        {

                            ListScoreToStudent.Add(
                                new AppScoreStudentPerQuestionsOfTask()
                                {
                                    //TaskToStudentId = Student.Idstudent,
                                    QuestionOfTaskId = Q.IdquestionOfTask,
                                    UserCreatedId = TaskExsist.UserCreatedId,
                                    DateCreated = DateTime.Today,
                                    Score = 0
                                }
                                                  );

                        }
                        AppTaskToStudent.AppScoreStudentPerQuestionsOfTasks = ListScoreToStudent;

                    }
                    listTaskToStudent.Add(AppTaskToStudent);

                }

                _context.AppTaskToStudents.AddRange(listTaskToStudent);
                _context.SaveChanges();
            }

            return true;
        }

      

        //עידכון מטלה של תלמיד
        public AppTaskToStudent AddOrUpdate(int schoolID, int yearbookId, AppTaskToStudent TaskToStudent)
        {
            if (TaskToStudent.IdtaskToStudent == 0 || TaskToStudent.IdtaskToStudent == null)
            {
                TaskToStudent.YearBookId = yearbookId;
                TaskToStudent.PaymentMethod = null;
                TaskToStudent.PaymentStatus = null;
                TaskToStudent.ReceivePayment = null;
                TaskToStudent.Student = null;
                TaskToStudent.StatusTaskPerformanceId = GetDefaultStatusPerSchoolId(schoolID).Id;
                _context.AppTaskToStudents.Add(TaskToStudent);
            }
            else
            {
                var x = _context.AppTaskToStudents.FirstOrDefault(f => f.IdtaskToStudent == TaskToStudent.IdtaskToStudent);
                if (x != null)
                {
                    x.AdministratorApproval = TaskToStudent.AdministratorApproval;
                    x.AmountReceived = TaskToStudent.AmountReceived;
                    x.DateUpdated = TaskToStudent.DateUpdated;
                    x.UserUpdatedId = TaskToStudent.UserUpdatedId;
                    x.Comment = TaskToStudent.Comment;
                    x.DateNeedSubmitStr = TaskToStudent.DateNeedSubmitStr;
                    x.DateNeedSubmit = TaskToStudent.DateNeedSubmit != null ? TaskToStudent.DateNeedSubmit.Value.Date : TaskToStudent.DateNeedSubmit;
                    //x.DateNeedSubmit = TaskToStudent.DateNeedSubmit != null ? TaskToStudent.DateNeedSubmit: TaskToStudent.DateNeedSubmit;

                    x.DateSubmit = TaskToStudent.DateSubmit != null ? TaskToStudent.DateSubmit.Value.Date: TaskToStudent.DateSubmit;
                    x.FinalScore = TaskToStudent.FinalScore;
                    x.Grade = TaskToStudent.Grade;
                    x.FinalScore = TaskToStudent.FinalScore;
                    x.PaymentMethodId = TaskToStudent.PaymentMethodId;
                    x.PaymentStatusId = TaskToStudent.PaymentStatusId;
                    x.ReceivePaymentId = TaskToStudent.ReceivePaymentId;
                    x.StudentId = TaskToStudent.StudentId;
                    x.IsActiveTask = TaskToStudent.IsActiveTask;
                    x.StatusTaskPerformanceId = TaskToStudent.StatusTaskPerformanceId;

                }

            }
            _context.SaveChanges();
            TaskToStudent = _context.AppTaskToStudents.Include(i => i.Student).Include(i => i.ReceivePayment.User).Include(i => i.PaymentStatus).Include(i => i.PaymentMethod)
                 .Include(i => i.AppScoreStudentPerQuestionsOfTasks.OrderBy(o => o.QuestionOfTask.Number)).ThenInclude(t => t.QuestionOfTask).FirstOrDefault(f => f.IdtaskToStudent == TaskToStudent.IdtaskToStudent);
            return TaskToStudent;
        }

        //מחיקת מטלה לתלמיד
        public bool DeleteTaskToStudent(int schoolID, int yearbookId, int idTaskToStudent)
        {
            var x = _context.AppTaskToStudents.FirstOrDefault(f => f.IdtaskToStudent == idTaskToStudent);
            if (x != null)
            {
                _context.AppTaskToStudents.Remove(x);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        //שליפת כל המטלות של תלמידות של מטלה מסויימת
        public List<AppTaskToStudent> GetAllTaskToStudentByTaskExsistID(int SchoolId, int YearbookId, int TaskExsistID)
        {
            var x = _context.AppTaskToStudents.Include(i => i.Student).Include(i => i.ReceivePayment.User).Include(s=>s.StatusTaskPerformance).Include(i => i.PaymentStatus).Include(i => i.PaymentMethod).
                  Include(i => i.AppScoreStudentPerQuestionsOfTasks.OrderBy(o => o.QuestionOfTask.Number)).ThenInclude(t => t.QuestionOfTask).Where(w => w.TaskExsistId == TaskExsistID && w.YearBookId == YearbookId).ToList();
            return x;
        }

        //עידכון הפעיל של המטלה
        public bool UpdateActiveTask(int schoolID, int taskToStudentId, bool isActive)
        {
            var x = _context.AppTaskToStudents.FirstOrDefault(f => f.IdtaskToStudent == taskToStudentId);
            if (x != null)
            {
                if (isActive == true)
                {
                    //הפיכת המטלה ללא פעיל - לא יתכן שתי מטלות לתלמידה פעילות לאותה מטלה
                    AppTaskToStudent task = _context.AppTaskToStudents.FirstOrDefault(f => x.TaskExsistId == f.TaskExsistId && x.StudentId == f.StudentId && f.IsActiveTask == true);
                    if (task != null)
                    {
                        task.IsActiveTask = false;
                        task.DateUpdated = DateTime.Today;
                        //task.UserUpdateId = ;
                    }
                }
                x.IsActiveTask = isActive;
                x.DateUpdated = DateTime.Today;
                //x.UserUpdateId = ;

                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool EditScoreToStudents(List<AppTaskToStudent> ListTaskToStudent)
        {
            AppTaskToStudent CurrentTaskToStudent;
            var LTTS = _context.AppTaskToStudents.ToList().Where(w => ListTaskToStudent.FirstOrDefault(f => f.IdtaskToStudent == w.IdtaskToStudent) != null).ToList();
            foreach (var taskToStudent in LTTS)
            {
                CurrentTaskToStudent = ListTaskToStudent.FirstOrDefault(f => f.IdtaskToStudent == taskToStudent.IdtaskToStudent);
                taskToStudent.Grade = CurrentTaskToStudent.Grade;
                taskToStudent.FinalScore = CurrentTaskToStudent.FinalScore;
                taskToStudent.StatusTaskPerformanceId = CurrentTaskToStudent.StatusTaskPerformanceId;
            }
            _context.SaveChanges();
            return true;
        }

        public void UpdateScoreStudentPerQuestions(List<AppScoreStudentPerQuestionsOfTask> appScoreStudentPerQuestionsOfTasks)
        {

            AppScoreStudentPerQuestionsOfTask ScorePerQuestion;
            foreach (var SQ in appScoreStudentPerQuestionsOfTasks)
            {
                ScorePerQuestion = _context.AppScoreStudentPerQuestionsOfTasks.FirstOrDefault(f => f.IdscoreStudentPerQuestionsOfTask == SQ.IdscoreStudentPerQuestionsOfTask);
                ScorePerQuestion.Score = SQ.Score;
            }
            _context.SaveChanges();
        }

        //שליפת ציונוי התלמידות לשאלה
        public List<AppScoreStudentPerQuestionsOfTask> GetScoreStudentInQuestionOfTask(int QuestionId)
        {
            return _context.AppScoreStudentPerQuestionsOfTasks.Include(s => s.TaskToStudent.Student).Where(f => f.QuestionOfTaskId == QuestionId).ToList();
        }
        //עריכת ציוני תלמידות בשאלה
        public List<AppScoreStudentPerQuestionsOfTask> EditScoreQuestionToStudents(List<AppScoreStudentPerQuestionsOfTask> ListScoreQuestionPerStudent)
        {
            var LSQ = _context.AppScoreStudentPerQuestionsOfTasks.Include(q => q.QuestionOfTask).ToList().Where(w => ListScoreQuestionPerStudent.FirstOrDefault(f => f.IdscoreStudentPerQuestionsOfTask == w.IdscoreStudentPerQuestionsOfTask) != null).ToList();
            AppScoreStudentPerQuestionsOfTask ScorePerQuestion;
            AppTaskToStudent TS;
            foreach (var SQ in LSQ)
            {
                var ezer = SQ.Score;
                ScorePerQuestion = ListScoreQuestionPerStudent.FirstOrDefault(f => f.IdscoreStudentPerQuestionsOfTask == SQ.IdscoreStudentPerQuestionsOfTask);
                SQ.Score = ScorePerQuestion?.Score;
                TS = _context.AppTaskToStudents.Include(t => t.TaskExsist).FirstOrDefault(f => f.IdtaskToStudent == ScorePerQuestion.TaskToStudentId);
                TS.Grade += SQ.QuestionOfTask.Percent * ScorePerQuestion.Score / 100 - (SQ.QuestionOfTask.Percent * ezer / 100);
            }
            _context.SaveChanges();
            return LSQ;
        }
    }
}
