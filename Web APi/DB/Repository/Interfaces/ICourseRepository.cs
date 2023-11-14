using DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.Interfaces
{
    public interface ICourseRepository
    {
        List<AppGroupSemesterPerCourse> GetAllCourseBySchoolDAndYearbookId(string ShoolsId, int YearbookId);
        List<AppCourse> GetAllCourseBySchoolId(int ShoolId);
        List<AppSemester> GetAllSemester(int YearbookId);
        AppSemester GetSemesterById(int semesterid,int yearbookid);
        //AppGroupSemesterPerCourse AddCourse(int SchoolId, int SemesterId, int CourseId, int GroupId, DateTime SemesterFromDate, DateTime SemesterToDate, int TeacherId, int YearbookId,int UserCreatedId, AppCourse Course);
        int DeleteCourse(int CourseId);
        List<AppUserPerCourse> GetUsersPerCourse(int CourseId);
        bool EditCourse(int CourseId,string CourseCode, List<AppUserPerCourse> ListUserPerCourse);
        AppCourse AddFatherCourse(AppCourse Course);
        List<AppGroupSemesterPerCourse> GetAllCourseByFatherCourseId(int FatherCourseId);
        AppGroupSemesterPerCourse AddCourse(AppGroupSemesterPerCourse course, int TeacherId);
        List<AppGroupSemesterPerCourse> GetCoursesForGroup(int GroupId, DateTime scheduleDate);
        AppUserPerSchool GetUserPerCourse(int CourseId, DateTime Date);
        AppCourse GetCourseById(int lessonNameId);
        AppGroupSemesterPerCourse AddCordinatedCourse(AppGroupSemesterPerCourse course);
        Tuple<AppGroupSemesterPerCourse,List<AppSchool>> TestGetCoordinatedCourse();
        AppCourse checkIfExistCourseIdInSchoolByYearbook(int courseId, int yearbookId);

    }
}
