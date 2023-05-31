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
    public class QuestionsOfTaskRepository : IQuestionsOfTaskRepository
    {
        private readonly ExtraSchoolContext _context;

        public QuestionsOfTaskRepository(ExtraSchoolContext context)
        {
            _context = context;
        }

        //הוספת שאלונים למטלה
        public List<AppQuestionsOfTask> AddQuestionsOfTask(List<AppQuestionsOfTask> ListQuestion, int taskId)
        {
            var i = 1;
            ListQuestion.ForEach(f => { f.TaskId = taskId; f.Number = i++; });
            _context.AppQuestionsOfTasks.AddRange(ListQuestion);
            _context.SaveChanges();
            return ListQuestion;
        }
        //עדכון שאלונים למטלה
        public List<AppQuestionsOfTask> UpdateQuestionOfTask(List<AppQuestionsOfTask> ListQuestion, int taskId, bool isCoordination,int UserId)
        {
            var i = 1;
            //List<AppQuestionsOfTask> ListQuestion;
            //if (Lq!=null&&Lq.Count()>0&&Lq[0].TaskId != taskId)
            //{
            //    ListQuestion = _context.AppQuestionsOfTasks.ToList().Where(w => Lq.FirstOrDefault(f => f.UniqeCodeId == w.UniqeCodeId) != null && w.TaskId == taskId).ToList();
            //    ListQuestion.AddRange(Lq.Where(w => w.IdquestionOfTask == 0).ToList());
            //}
            //else
            //    ListQuestion = Lq;

            ListQuestion.ForEach(f => { f.TaskId = taskId; f.Number = i++; });
            var ListUpdate = new List<AppQuestionsOfTask>();
            var ListAdd = ListQuestion;
            var ListDelete = _context.AppQuestionsOfTasks.Include(s=>s.AppScoreStudentPerQuestionsOfTasks).ToList().Where(w => w.TaskId == taskId && ListQuestion.FirstOrDefault(f =>(isCoordination==false&& f.IdquestionOfTask==w.IdquestionOfTask)||(isCoordination==true&& f.UniqeCodeId == w.UniqeCodeId)) == null).ToList();
            foreach (var item in ListQuestion)
            {
                if (item.IdquestionOfTask != 0)
                {
                    var q = isCoordination == true ? _context.AppQuestionsOfTasks.FirstOrDefault(f => f.UniqeCodeId == item.UniqeCodeId && f.TaskId == item.TaskId) : _context.AppQuestionsOfTasks.FirstOrDefault(f => f.IdquestionOfTask == item.IdquestionOfTask);
                    if (q != null)
                    {
                        q.Name = item.Name;
                        q.Number = item.Number;
                        q.Percent = item.Percent;
                        q.UserUpdatedId = UserId;
                        q.DateUpdate = DateTime.Today;
                        q.UniqeCodeId = item.UniqeCodeId;
                        ListUpdate.Add(q);
                    }
                }
            }
            ListAdd = ListQuestion.ToList().Where(w => isCoordination == true ? ListUpdate.FirstOrDefault(f => f.UniqeCodeId == w.UniqeCodeId && f.TaskId == w.TaskId) == null : ListUpdate.FirstOrDefault(f => f.IdquestionOfTask == w.IdquestionOfTask) == null).ToList();
            ListAdd.ForEach(f => { f.UserCreatedId = UserId; f.DateCreated = DateTime.Today; f.IdquestionOfTask = 0; });
            ListDelete.ForEach(f =>
            {
                _context.AppScoreStudentPerQuestionsOfTasks.RemoveRange(f.AppScoreStudentPerQuestionsOfTasks);
            });
            _context.AppQuestionsOfTasks.RemoveRange(ListDelete);
            _context.AppQuestionsOfTasks.AddRange(ListAdd);
            _context.SaveChanges();
            ListDelete.ForEach(q =>
            {
                var Question = _context.AppUniqueCodes.Include(i => i.AppQuestionsOfTasks).FirstOrDefault(f => f.IduniqueCode == q.UniqeCodeId);
                if (Question!=null && Question.AppQuestionsOfTasks.Count() == 0)
                    _context.AppUniqueCodes.Remove(Question);
            });
            _context.SaveChanges();
            return ListQuestion;
        }
        //שליפת שאלות למטלה
        public List<AppQuestionsOfTask> GetQuestionOfTask(int TaskId)
        {
            return _context.AppQuestionsOfTasks.Where(f => f.TaskId == TaskId).ToList();
        }
    }
}
