using DTO.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IFatherCourseService
    {
        List<AppCourseDTO> GetListFatherCoursesBySchoolAndYearbook(string SchoolsId, int YearbookId);
        AppCourseDTO AddFatherCourse(AppCourseDTO FatherCourse);
        AppCourseDTO EditFatherCourse(AppCourseDTO FatherCourse);
        bool DeleteFatherCrouse(int FatherCourseId);
        Tuple<List<AppCourseDTO>, List<AppProfessionDTO>, List<SecUserDTO>,int,int> AddCoordinationsFatherCourse(ObjectFatherCoursekAndListSchools objectFatherCoursekAndListSchools, int YearbookId, int CoustomerId);
        public Tuple<List<AppCourseDTO>, List<AppProfessionDTO>, int, List<SecUserDTO>, int> EditCoordinatorCourseFather(AppCourseDTO fatherCourse, int UserId, int CoustomerId);
        public AppCourseDTO getFatherCourseById(int fatherCourseId);
    }
}
