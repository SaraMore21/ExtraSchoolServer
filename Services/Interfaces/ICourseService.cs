using DTO.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ICourseService
    {
        List<AppGroupSemesterPerCourseDTO> GetAllCourseBySchoolDAndYearbookId(string ShoolsId,int YearbookId); 
        List<AppCourseDTO> GetAllCourseBySchoolId(int ShoolId);
        List<AppSemesterDTO> GetAllSemester(int YearbookId);
        //AppGroupSemesterPerCourseDTO AddCourse(int SchoolId, int SemesterId, int CourseId, int GroupId, DateTime SemesterFromDate, DateTime SemesterToDate, int TeacherId, int YearbookId,int UserCreatedId, AppCourseDTO Course);
        int DeleteCourse(int CourseId);
        List<AppUserPerCourseDTO> GetUsersPerCourse(int CourseId);
        bool EditCourse(int CourseId,string CourseCode, List<AppUserPerCourseDTO> ListUserPerCourse);
        AppCourseDTO AddFatherCourse(AppCourseDTO Course);
        List<AppGroupSemesterPerCourseDTO> GetAllCourseByFatherCourseId(int FatherCourseId);
        AppGroupSemesterPerCourseDTO AddCourse(AppGroupSemesterPerCourseDTO course, int TeacherId);
        List<AppGroupSemesterPerCourseDTO> GetCoursesForGroup(int GroupId, DateTime scheduleDate);
        SecUserDTO GetUserPerCourse(int CourseId, DateTime Date);
        List<AppGroupSemesterPerCourseDTO> AddCoordinationsCourse(ObjectCourseAndListSchools objectCourseAndListSchools, int YearbookId);
        ObjectCourseAndListSchools TestGetCoordinatedCourse();
    }
}
