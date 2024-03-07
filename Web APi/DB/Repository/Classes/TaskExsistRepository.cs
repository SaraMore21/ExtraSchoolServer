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
    public class TaskExsistRepository : ITaskExsistRepository
    {
        private readonly ExtraSchoolContext _context;
        private readonly IScoreStudentPerQuestionsOfTaskRepository _scoreStudentPerQuestionsOfTaskRepository;

        public TaskExsistRepository(ExtraSchoolContext context,IScoreStudentPerQuestionsOfTaskRepository scoreStudentPerQuestionsOfTaskRepository)
        {
            _context = context;
            _scoreStudentPerQuestionsOfTaskRepository = scoreStudentPerQuestionsOfTaskRepository;
        }

        //בדיקת סך האחוזים לקורס מסויים
        public int getSumPercentsOfCourse(int? CourseId, int taskId)
        {
            AppGroupSemesterPerCourse course = _context.AppGroupSemesterPerCourses.Include(i => i.AppTaskExsists).FirstOrDefault(f => f.IdgroupSemesterPerCourse == CourseId);
            if (course != null && course.AppTaskExsists != null && course.AppTaskExsists.Count() > 0)
            {
                int sum = (int)course.AppTaskExsists.Sum(s => s.Percents);
                AppTaskExsist a = course.AppTaskExsists.FirstOrDefault(f => f.CourseId == CourseId && f.IdexsistTask == taskId);
                int sumCourse = a != null && a.Percents != null ? (int)a.Percents : 0;
                return sum > 0 ? sum - sumCourse : 0;

            }
            return 0;
        }

        public AppTaskExsist AddOrUpdate(int schoolID, int yearbookId, AppTaskExsist AppTaskExsist)
        {
            if (AppTaskExsist.IdexsistTask == 0 || AppTaskExsist.IdexsistTask == null)
            {
                AppTaskExsist.YearBookId = yearbookId;
                AppTaskExsist.SchoolId = schoolID;
                AppTaskExsist.Course = null;
                AppTaskExsist.Coordinator = null;
                _context.AppTaskExsists.Add(AppTaskExsist);
                _context.SaveChanges();
                if (AppTaskExsist.CourseId != 0 && _context.AppTasks.FirstOrDefault(f => f.Idtask == AppTaskExsist.TaskId).TypeTaskId == 2)
                   _scoreStudentPerQuestionsOfTaskRepository.AddScoreStudentsOfQuestion((int)AppTaskExsist.TaskId, (int)AppTaskExsist.CourseId, (int)AppTaskExsist.UserCreatedId);
            }
            else
            {
                var x = _context.AppTaskExsists.Include(i => i.AppTaskToStudents).FirstOrDefault(f => f.IdexsistTask == AppTaskExsist.IdexsistTask);

                DateTime? dateA = x.DateSubmitA;
                DateTime? dateB = x.DateSubmitB;
                DateTime? dateC = x.DateSubmitC;

                if (dateB != null && AppTaskExsist.DateSubmitB == null)
                    if (x.AppTaskToStudents != null && x.AppTaskToStudents.Any(a => a.DateNeedSubmitStr != null && a.DateNeedSubmitStr.Contains("מועד ב")))
                        throw new AccessViolationException("לא ניתן למחוק את מועד ב' כיוון שיש תלמידות שכבר משוייכות למועד זה.");

                if (dateC != null && AppTaskExsist.DateSubmitC == null)
                    if (x.AppTaskToStudents != null && x.AppTaskToStudents.Any(a => a.DateNeedSubmitStr != null && a.DateNeedSubmitStr.Contains("מועד ג")))
                        throw new AccessViolationException("לא ניתן למחוק את מועד ג' כיוון שיש תלמידות שכבר משוייכות למועד זה.");

                if (x != null)
                {
                    x.CodeTaskExsist = AppTaskExsist.CodeTaskExsist;
                    x.CoordinatorId = AppTaskExsist.CoordinatorId;
                    x.DateUpdated = AppTaskExsist.DateUpdated;
                    x.UserUpdatedId = AppTaskExsist.UserUpdatedId;
                    x.Name = AppTaskExsist.Name;
                    x.CourseId = AppTaskExsist.CourseId;
                    x.DateSubmitA = AppTaskExsist.DateSubmitA;//!= null ? AppTaskExsist.DateSubmitA.Value.AddDays(1) : AppTaskExsist.DateSubmitA;
                    x.DateSubmitB = AppTaskExsist.DateSubmitB;//!= null ? AppTaskExsist.DateSubmitB.Value.AddDays(1) : AppTaskExsist.DateSubmitB;
                    x.DateSubmitC = AppTaskExsist.DateSubmitC;//!= null ? AppTaskExsist.DateSubmitC.Value.AddDays(1) : AppTaskExsist.DateSubmitC;
                    x.PassingGrade = AppTaskExsist.PassingGrade;
                    x.Percents = AppTaskExsist.Percents;
                    x.Cost = AppTaskExsist.Cost;
                }

                if (x.AppTaskToStudents != null)
                {
                    List<AppTaskToStudent> list = x.AppTaskToStudents.ToList();
                    if (x.DateSubmitA != null && (dateA == null || x.DateSubmitA.Value.Date != dateA.Value.Date))
                        list.ToList().ForEach(f =>
                        {
                            if (f.DateNeedSubmitStr != null && f.DateNeedSubmitStr.Contains("מועד א") == true)
                            {
                                f.DateNeedSubmitStr = "מועד א";
                                f.DateNeedSubmit = x.DateSubmitA.Value.Date;
                                list.Remove(f);
                            }
                        });
                    if (x.DateSubmitB != null && (dateB == null || x.DateSubmitB.Value.Date != dateB.Value.Date))
                        list.ToList().ForEach(f =>
                        {
                            if (f.DateNeedSubmitStr != null && f.DateNeedSubmitStr.Contains("מועד ב") == true)
                            {
                                f.DateNeedSubmitStr = "מועד ב";
                                f.DateNeedSubmit = x.DateSubmitB.Value.Date;
                                list.Remove(f);
                            }
                        });
                    if (x.DateSubmitC != null && (dateC == null || x.DateSubmitC.Value.Date != dateC.Value.Date))
                        list.ToList().ForEach(f =>
                        {
                            if (f.DateNeedSubmitStr != null && f.DateNeedSubmitStr.Contains("מועד ג") == true)
                            {
                                f.DateNeedSubmitStr = "מועד ג";
                                f.DateNeedSubmit = x.DateSubmitC.Value.Date;
                                list.Remove(f);
                            }
                        });
                }

            }
            _context.SaveChanges();
            var taskExsist = _context.AppTaskExsists.Include(i => i.Coordinator.User).Include(i => i.Course.Course).Include(i => i.Course.AppTaskExsists)
              .FirstOrDefault(f => f.IdexsistTask == AppTaskExsist.IdexsistTask);
            return taskExsist;
        }

        public bool DeleteTaskExsist(int idTaskExsist, bool deleteTaskToStudents)
        {
            var x = _context.AppTaskExsists.Include(i => i.AppTaskToStudents).FirstOrDefault(f => f.IdexsistTask == idTaskExsist);
            if (x != null)
            {
                if (x.AppTaskToStudents.Count() > 0 && deleteTaskToStudents == false)
                    return false;
                else
                {
                    if (deleteTaskToStudents == true)
                        _context.AppTaskToStudent.RemoveRange(x.AppTaskToStudents);
                    _context.AppTaskExsists.Remove(x);
                    _context.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public List<AppTaskExsist> GetAllTaskExsistByTaskId(int taskId)
        {
            var x = _context.AppTaskExsists.Include(i => i.Coordinator.User).Include(i => i.Course.Course).Include(i => i.Course.AppTaskExsists).
                Where(w => w.TaskId == taskId).ToList();
            return x;
        }
        //שליפת מטלות קיימות ע"פ מטלת אב
        public List<AppTaskExsist> GetTaskExsistByTaskId(int taskId)
        {
            return _context.AppTaskExsists.Where(w => w.TaskId ==taskId).ToList();
        }   
        //שליפת מטלות קיימות לקורסים שקיימים בקבוצה
        public List<AppTaskExsist> GetTaskExsistByGroupId(int GroupPerYearbookId)
        {
           return _context.AppTaskExsists.Include(c=>c.Course.Course).Where(w =>w.Course!=null&& w.Course.GroupId == GroupPerYearbookId).ToList();
        }
    }
}
