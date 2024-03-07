using DTO.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IStudentsPerCourseService
    {
        public float AddOrUpdateGradePerCourse(int schoolID, int courseId, int taskexistId, float fineScorePerStudent, int studentId);
        public List<AppStudentsPerCourseDTO> GetAllCourseToStudentBycoureID(int courseId);

        public AppStudentsPerCourseDTO UpdateCoursePerStudent(AppStudentsPerCourseDTO course);
        public List<AppStudentsPerCourseDTO> AddListStudentsPerGroupToCourse(int idgroup, int idgroupsemesterpercourse, int yearbookid);
        public AppStudentsPerCourseDTO AddStudentToCourse(int studentId, int idgroupsemesterpercourse);
          
    }
}
