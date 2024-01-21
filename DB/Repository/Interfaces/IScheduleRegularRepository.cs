using DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.Interfaces
{
    public interface IScheduleRegularRepository
    {
        List<AppScheduleRegular> GetScheduleRegularBetwwnDatesByCourseIdDayAndNumLesson(int? courseId, DateTime? startDate, DateTime? endDate, short? dayInWeek, short? numLesson);
        List<AppScheduleRegular> GetScheduleRegularBetweenDatesOfSchool(int? schoolId, DateTime? startDate, DateTime? endDate);
        bool AddListScheduleRegular(List<AppScheduleRegular> newSchedules);
        List<AppScheduleRegular> GetScheduleRegularBetweenDatesOfGroup(int groupId, DateTime startDate, DateTime endDate);
        List<AppScheduleRegular> GetScheduleRegularPerWeek(DateTime ScheduleDate, int GroupId);
        bool isValidTeacher(int? courseId, DateTime? startDate, DateTime? endDate, int? lessonPerGroupId);
        List<AppDailySchedule> StopTheScheduleRegularForTheWholeSchool(int schoolId, DateTime startDate, DateTime endDate, int userID);
        void openDailyScheduleToNewRegularSchedule(AppScheduleRegular scheduleRegular, AppLessonPerGroup lessonPerGroup, List<AppDailySchedule> dailyScheduleOldOfGroup);
        bool AddScheduleRegular(AppScheduleRegular appScheduleRegular, List<AppDailySchedule> dailyScheduleOldOfGroup);
        AppScheduleRegular UpdateScheduleRegularByWebsite(AppScheduleRegular appScheduleRegular, int userID,DateTime date);
        List<AppScheduleRegular> GetScheduleRegularBetweenDatesByGroupIdDayAndTime(int? GroupId, DateTime? startDate, DateTime? endDate, short? dayInWeek, TimeSpan? StartTime, TimeSpan? EndTime);
        bool UpdateScheduleRegular(AppScheduleRegular appScheduleRegular, int GroupId, int userID, bool isOverride);
    }
}
