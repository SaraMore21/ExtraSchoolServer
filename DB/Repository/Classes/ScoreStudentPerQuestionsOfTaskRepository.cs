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
    public class ScoreStudentPerQuestionsOfTaskRepository : IScoreStudentPerQuestionsOfTaskRepository
    {
        private readonly ExtraSchoolContext _context;
        public ScoreStudentPerQuestionsOfTaskRepository(ExtraSchoolContext context)
        {
            _context = context;
        }

        public void AddScoreStudentsOfQuestion(int TaskId, int CourseId, int UserCreatedId)
        {
            try
            {
                var ListQuestion = _context.AppQuestionsOfTasks.Where(w => w.TaskId == TaskId).ToList();
                var ListStudent = _context.AppGroupSemesterPerCourses.Include(g=>g.Group.AppStudentPerGroups).ThenInclude(s=>s.Student).FirstOrDefault(f => f.IdgroupSemesterPerCourse == CourseId).Group.AppStudentPerGroups.Select(s => s.Student).ToList();
                foreach (var Q in ListQuestion)
                {
                    AddScoreToStudent(Q.IdquestionOfTask, ListStudent, UserCreatedId);
                }
            }
            catch
            {
                throw;
            }
        }
        public List<AppScoreStudentPerQuestionsOfTask> AddScoreToStudent(int QuestionId, List<AppStudent> ListStudent, int UserCreatedId)
        {
            try
            {
                AppScoreStudentPerQuestionsOfTask scoreToStudent;
                List<AppScoreStudentPerQuestionsOfTask> ListScoreToStudent = new List<AppScoreStudentPerQuestionsOfTask>();
                foreach (var Student in ListStudent)
                {
                  //  if (_context.AppScoreStudentPerQuestionsOfTasks.FirstOrDefault(f => f.StudentId == Student.Idstudent && f.QuestionOfTaskId == QuestionId) == null)
                    {
                        scoreToStudent = new AppScoreStudentPerQuestionsOfTask()
                        {
                            //StudentId = Student.Idstudent,
                            QuestionOfTaskId = QuestionId,
                            UserCreatedId = UserCreatedId,
                            DateCreated = DateTime.Today,
                            Score= 0
                        };
                        ListScoreToStudent.Add(scoreToStudent);
                    }
                }
                _context.AppScoreStudentPerQuestionsOfTasks.AddRange(ListScoreToStudent);
                _context.SaveChanges();
                return ListScoreToStudent;
            }
            catch
            {
                throw;
            }
        }
    }
}
