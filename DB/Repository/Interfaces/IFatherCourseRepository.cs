using DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.Interfaces
{
    public interface IFatherCourseRepository
    {
        List<AppCourse> GetListFatherCoursesBySchoolAndYearbook(string SchoolsId, int YearbookId);
        AppCourse AddFatherCourse(AppCourse FatherCourse);
        AppCourse EditFatherCourse(AppCourse FatherCourse);
        bool DeleteFatherCrouse(int FatherCourseId);
        //int AddCoordinationsFatherCourse(object listSchool, int YearbookId, int CoustomerId);
        bool CheckIfExsistFatherCourseInSchool(List<int> listSchool, AppCourse FatherCourse);
        Tuple<AppCourse, AppProfession, AppUserPerSchool,int,int> AddCoordinationsFatherCourse(AppCourse fahterCourse, string ProfessioName,int CoustomerId,AppSchool school,int UserCreatedId,int YearbookId);
        public Tuple<List<AppCourse>, List<AppProfession>, int, List<AppUserPerSchool>, int> EditCoordinatorCourseFather(AppCourse fatherCourse, int UserId, int CoustomerId);
       public  AppCourse getFatherCourseById(int fatherCourseId);
    }
}
