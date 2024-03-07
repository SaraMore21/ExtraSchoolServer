using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Model;
using DB.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DB.Repository.Classes
{
    public class AppStudentsPerCourseRepository : IStudentsPerCourseRepository
    {
        public readonly ExtraSchoolContext _context;
        private readonly IGroupRepository _groupRepository;


        public AppStudentsPerCourseRepository(ExtraSchoolContext context, IGroupRepository GroupRepository)
        {
            _context = context;
            _groupRepository = GroupRepository;
        }
        public float AddOrUpdateGradePerCourse(int schoolID, int courseId, int taskexistId, float finelScorePerStudent, int studentId) {
            //var x = _context.AppStudentsPerCourses.FirstOrDefault(f => f.GroupSemesterperCourseId == courseId);
           
                int Percents = 0;

            var taskExist = _context.AppTaskExsists.FirstOrDefault(t => t.IdexsistTask == taskexistId);
            if (taskExist != null)
            {
                Percents = taskExist.Percents!=null?(int)taskExist.Percents:0;
              
            }


            List<int> taskExsistsId = _context.AppTaskExsists.Where(t => t.CourseId == taskExist.CourseId).Select(t=>t.IdexsistTask).ToList();
            List<AppTaskToStudent> taskToStudents = _context.AppTaskToStudent.Include(t=>t.TaskExsist).Where(t => taskExsistsId.Contains((int)t.TaskExsistId) && t.StudentId==studentId).ToList();
            double grade = 0;

            taskToStudents.ForEach(t =>
            {
                grade+=(double)t.TaskExsist.Percents * 0.01 * (double)t.FinalScore;
            });



            //float StudentPercoure = (float)_context.AppStudentsPerCourses.FirstOrDefault(f => f.GroupSemesterperCourseId == courseId && f.StudentId == studentId).Grade;
            AppStudentsPerCourse StudentPercourse = _context.AppStudentsPerCourses.FirstOrDefault(f => f.GroupSemesterperCourseId == courseId && f.StudentId == studentId);

            StudentPercourse.FinalScore = grade;//StudentPercourse.Grade!=null? StudentPercourse.Grade + finelScorePerStudent * (Percents * 0.01): finelScorePerStudent * (Percents * 0.01);
            _context.SaveChanges();
            return (float)StudentPercourse.FinalScore;

        }
        public List<AppStudentsPerCourse> GetAllCourseToStudentBycoureID(int courseId)
        {
            var x = _context.AppStudentsPerCourses.Include(c => c.Student).Where(s => s.GroupSemesterperCourseId == courseId).ToList();
            return x;
        }


        public AppStudentsPerCourse UpdateCoursePerStudent(AppStudentsPerCourse StudentsPerCourse)
        {
            try
            {
                var x = _context.AppStudentsPerCourses.Include(s=>s.Student).FirstOrDefault(pr => pr.IdstudentsPerCourse == StudentsPerCourse.IdstudentsPerCourse);
                if (x != null)
                {

                    x.Grade = StudentsPerCourse.Grade;
                    x.FinalScore = StudentsPerCourse.FinalScore;

                    _context.SaveChanges();
                  
                }
                return x;
            }

            catch (Exception e)
            {
              
                throw e;
            }
            //presences = _context.AppPresences.Include(i => i.DailySchedule).Include(i => i.Student).Include(i => i.TypePresence).Include(i => i.UserCreated).Include(i => i.UserCreated);

           

        }

        public List<AppStudentsPerCourse> AddListStudentsPerGroupToCourse(int idgroup, int idgroupsemesterpercourse, int yearbookid)
        {

            List<AppStudentPerGroup> lspg = _groupRepository.GetStudentPerGroup(idgroup, yearbookid);
            List<int> lstudentsId = new List<int>();
            lspg.ForEach(s => lstudentsId.Add((int)s.StudentId));
            List<AppStudentsPerCourse> listToAdd = new List<AppStudentsPerCourse>();

            lstudentsId.ForEach(l =>
            {
                AppStudentsPerCourse sc = new AppStudentsPerCourse();
                sc.StudentId = l;
                sc.GroupSemesterperCourseId = idgroupsemesterpercourse;
                sc.DateCreated = DateTime.Today;
                listToAdd.Add(sc);
            });

            _context.AppStudentsPerCourses.AddRange(listToAdd);
            _context.SaveChanges();
            return listToAdd;

        }
        
        public AppStudentsPerCourse AddStudentToCourse(int studentId,int idgroupsemesterpercourse)
        {

            AppStudentsPerCourse sc = new AppStudentsPerCourse();
            sc.StudentId = studentId;
            sc.GroupSemesterperCourseId = idgroupsemesterpercourse;
            sc.DateCreated = DateTime.Today;
            _context.AppStudentsPerCourses.Add(sc);
            _context.SaveChanges();
            return sc;
        }
        public List<AppGroupSemesterPerCourse> GetLIstCoursePerGroupId(int GroupId)
        {
           var x=  _context.AppGroupSemesterPerCourses.Include(g => g.Group).Include(c => c.Course).Where(w => w.GroupId == GroupId).ToList();
            return x;
        }
    }

}


