using DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.Interfaces
{
    public interface IDailyScheduleRepository
    {
        List<AppUserPerSchool> GetAvailableTeachers(DateTime scheduleDate, int numLesson,int SchoolId,int CourseId);
        List<AppUserPerSchool> GetAvailableTeachersByHourRange(DateTime ScheduleDate, TimeSpan FromTime, TimeSpan ToTime, int SchoolId, int CourseId);
        AppUserPerSchool GetTeacherBySelectCourse(int GroupSemesterPerCourseId, DateTime scheduleDate);
        List<AppDailySchedule> GetDailySchedulePerGroup(int GroupId, DateTime ScheduleDate);
        AppDailySchedule EditDailySchedule(AppDailySchedule DailySchedule);
        Tuple<AppDailySchedule, string> AddDailySchedule(AppDailySchedule DailySchedule);
        List<AppLessonPerGroup> GetNumLessonAvailable(int GroupId, DateTime ScheduleDate);
        Tuple<AppGroupSemesterPerCourse, AppUserPerSchool,int> GetDailyScheduleDetailsByScheduleRegular(int GroupId, DateTime ScheduleDate, TimeSpan StartTime, TimeSpan EndTime);
        bool DeleteDailySchedule(int IdDailySchedule);
        void AddListDailySchedule(List<AppDailySchedule> lstDailySchedules,int userId=0);
        void SetScheduleRegularIdNull(List<AppDailySchedule> dailyScheduleOld);
        List<AppDailySchedule> getDailyScheduleByScheduleRegularID(int ScheduleRegularID);
    }
}
