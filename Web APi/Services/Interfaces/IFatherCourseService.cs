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
        List<AppCourseDTO> AddCoordinationsFatherCourse(ObjectFatherCoursekAndCoordinationId objectFatherCoursekAndCoordinationId, int YearbookId, int CoustomerId);
        public Tuple<List<AppCourseDTO>, List<AppProfessionDTO>, int, List<SecUserDTO>, int> EditCoordinatorCourseFather(AppCourseDTO fatherCourse, int UserId, int CoustomerId);
        public AppCourseDTO getFatherCourseById(int fatherCourseId);
    }
}
