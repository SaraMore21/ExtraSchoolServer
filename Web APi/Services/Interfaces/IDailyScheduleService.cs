using DTO.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IDailyScheduleService
    {
       List<SecUserDTO> GetAvailableTeachers(DateTime scheduleDate, int numLesson,int SchoolId,int CourseId);
       List<SecUserDTO> GetAvailableTeachersByHourRange(DateTime ScheduleDate, TimeSpan FromTime, TimeSpan ToTime, int SchoolId, int CourseId);
       SecUserDTO GetTeacherBySelectCourse(int GroupSemesterPerCourseId, DateTime scheduleDate);
       List<AppDailyScheduleDTO> GetDailySchedulePerGroup(int GroupId, DateTime ScheduleDate);
       AppDailyScheduleDTO EditDailySchedule(AppDailyScheduleDTO DailySchedule);
        Tuple<AppDailyScheduleDTO, string> AddDailySchedule(AppDailyScheduleDTO DailySchedule);
       List<AppLessonPerGroupDTO> GetNumLessonAvailable(int GroupId, DateTime ScheduleDate);
       Tuple<AppGroupSemesterPerCourseDTO, AppUserPerSchoolDTO,int> GetDailyScheduleDetailsByScheduleRegular(int GroupId, DateTime ScheduleDate, TimeSpan StartTime, TimeSpan EndTime);
       bool DeleteDailySchedule(int IdDailySchedule);
    
    }
}
