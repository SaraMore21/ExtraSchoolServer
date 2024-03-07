using DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.Interfaces
{
    public interface IStudentsPerCourseRepository
    {
       
        public float AddOrUpdateGradePerCourse(int schoolID, int courseId, int taskexistId, float fineScorePerStudent, int studentId);
       
        public List<AppStudentsPerCourse> GetAllCourseToStudentBycoureID(int courseId);
        public AppStudentsPerCourse UpdateCoursePerStudent(AppStudentsPerCourse appStudentsPerCourses);
        public List<AppStudentsPerCourse> AddListStudentsPerGroupToCourse(int idgroup, int idgroupsemesterpercourse, int yearbookid);
        public AppStudentsPerCourse AddStudentToCourse(int studentId, int idgroupsemesterpercourse);
        public List<AppGroupSemesterPerCourse> GetLIstCoursePerGroupId(int GroupId);
    }
}
