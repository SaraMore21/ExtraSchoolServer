using DB.Model;
using DB.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.Classes
{
    public class ScheduleRegularRepository : IScheduleRegularRepository
    {
        private readonly ExtraSchoolContext _context;
        private readonly IDailyScheduleRepository _DailyScheduleRepository;
        public bool isnewdailSchedules = false;
        public ScheduleRegularRepository(ExtraSchoolContext context, IDailyScheduleRepository DailyScheduleRepository)
        {
            _context = context;
            _DailyScheduleRepository = DailyScheduleRepository;
        }

        public bool AddListScheduleRegular(List<AppScheduleRegular> newSchedules)
        {
            try
            {
                _context.AppScheduleRegulars.AddRange(newSchedules);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        //שליפת המערכת הקבועה לקורס פר שנתון בתאריכים חופפים 
        public List<AppScheduleRegular> GetScheduleRegularBetwwnDatesByCourseIdDayAndNumLesson(int? courseId, DateTime? startDate, DateTime? endDate, short? dayInWeek, short? numLesson)
        {
            List<AppScheduleRegular> LstSchedules = new List<AppScheduleRegular>();
            LstSchedules = _context.AppScheduleRegulars.Include(i => i.LessonPerGroup)/*.Include(i => i.AppDailySchedules).ThenInclude(t => t.AppPresences)*/.Include(i => i.Course)
             .Where(w =>
            w.CourseId == courseId &&
            (w.StartDate <= endDate && w.EndDate >= startDate && w.LessonPerGroup.DayOfWeek == dayInWeek && w.LessonPerGroup.NumLesson == numLesson)
            ).ToList();
            return LstSchedules;

        }

        //שליפת המערכת הקבועה + המערכות היומיות לקבוצה פר שנתון בתאריכים חופפים 
        public List<AppScheduleRegular> GetScheduleRegularBetweenDatesByGroupIdDayAndTime(int? GroupId, DateTime? startDate, DateTime? endDate, short? dayInWeek, TimeSpan? StartTime, TimeSpan? EndTime)
        {
            List<AppScheduleRegular> LstSchedules = new List<AppScheduleRegular>();
            LstSchedules = _context.AppScheduleRegulars.Include(i => i.LessonPerGroup).Include(i => i.AppDailySchedules).ThenInclude(t => t.AppPresences).Include(i => i.Course)
             .Where(w =>
            w.Course.GroupId == GroupId &&
            (w.StartDate <= endDate && w.EndDate >= startDate && w.LessonPerGroup.DayOfWeek == dayInWeek &&
                w.LessonPerGroup.StartTime < EndTime &&
                w.LessonPerGroup.EndTime > StartTime)
            ).ToList();
            return LstSchedules;

        }

        //שליפת המערכת הקבועה לקבוצה פר שנתון בתאריכים חופפים 
        public List<AppScheduleRegular> GetScheduleRegularBetweenDatesOfGroup(int groupId, DateTime startDate, DateTime endDate)
        {

            List<AppScheduleRegular> LstSchedules = new List<AppScheduleRegular>();
            LstSchedules = _context.AppScheduleRegulars.Include(i => i.Course)
             .Where(w =>
             w.Course != null && w.Course.GroupId == groupId &&
            (w.StartDate <= endDate && w.EndDate >= startDate)
            ).ToList();
            return LstSchedules;
        }

        //שליפת המערכות החופפות של כל המוסד לזמן שמועלית כעת מערכת
        public List<AppScheduleRegular> GetScheduleRegularBetweenDatesOfSchool(int? schoolId, DateTime? startDate, DateTime? endDate)
        {
            List<AppScheduleRegular> LstSchedules = new List<AppScheduleRegular>();
            LstSchedules = _context.AppScheduleRegulars.Include(i => i.Course).Include(i => i.AppDailySchedules).ThenInclude(i => i.AppPresences)
             .Include(i => i.AppDailySchedules).ThenInclude(i => i.Course).AsNoTracking().Where(w =>
            w.SchoolId == schoolId &&
            (w.StartDate <= endDate && w.EndDate >= startDate)
            ).ToList();
            return LstSchedules;
        }

        //שליפת מערכת קבועה לשבוע -לפי תאריך וקבוצה
        public List<AppScheduleRegular> GetScheduleRegularPerWeek(DateTime ScheduleDate, int GroupId)
        {
            //הוספתי את זה-בדיקה האם זה אותה קבוצה 
            //w.Course != null && w.Course.GroupId == GroupId &&
            List<AppScheduleRegular> ListScheduleRegular = new List<AppScheduleRegular>();
            for (int j = 1; j <= 7; j++)
            {
                ListScheduleRegular.AddRange(_context.AppScheduleRegulars.Include(i => i.LessonPerGroup).Include(i => i.Course.Course).Include(i => i.Course).ThenInclude(i => i.AppUserPerCourses.ToList().Where(f => f.FromDate <= ScheduleDate.AddDays(Convert.ToInt32(ScheduleDate.DayOfWeek) + 1 - 7) && f.ToDate >= ScheduleDate.AddDays(Convert.ToInt32(ScheduleDate.DayOfWeek) + 1 - 7))).ThenInclude(i => i.User)
                    .ToList().Where(w => w.Course != null && w.Course.GroupId == GroupId && w.LessonPerGroup != null && w.LessonPerGroup.DayOfWeek == j && w.StartDate <= ScheduleDate.AddDays(Convert.ToInt32(ScheduleDate.DayOfWeek) + 1 - 7) && w.EndDate >= ScheduleDate.AddDays(Convert.ToInt32(ScheduleDate.DayOfWeek) + 1 - 7)));
                //ListScheduleRegular.AddRange(_context.AppScheduleRegulars.Include(i => i.LessonPerGroup).Include(i => i.Course.Course).Include(i => i.Course).ThenInclude(i => i.AppUserPerCourses.ToList().Where(f => f.FromDate <= ScheduleDate.AddDays(Convert.ToInt32(ScheduleDate.DayOfWeek) + 1 - 7) && f.ToDate >= ScheduleDate.AddDays(Convert.ToInt32(ScheduleDate.DayOfWeek) + 1 - 7))).ThenInclude(i => i.User)
                //    .ToList().Where(w => w.LessonPerGroup.DayOfWeek == j && w.StartDate <= ScheduleDate.AddDays(Convert.ToInt32(ScheduleDate.DayOfWeek) + 1 - 7) && w.EndDate >= ScheduleDate.AddDays(Convert.ToInt32(ScheduleDate.DayOfWeek) + 1 - 7)));
            }
            return ListScheduleRegular;
            //var ScheduleRegular = _context.AppScheduleRegulars.Where(w => w.StartDate <= ScheduleDate && w.EndDate >= ScheduleDate && w.Course.GroupId == GroupId).ToList();
            //return ScheduleRegular;
        }

        //בדיקה אם ניתן להציב מורה במערכת קבועה
        public bool isValidTeacher(int? courseId, DateTime? startDate, DateTime? endDate, int? lessonPerGroupId)
        {
            try
            {
                AppLessonPerGroup LessonPerGroup = _context.AppLessonPerGroups.FirstOrDefault(f => f.IdlessonPerGroup == lessonPerGroupId);
                AppGroupSemesterPerCourse groupSemesterPerCourse = _context.AppGroupSemesterPerCourses.Include(i => i.AppUserPerCourses).FirstOrDefault(f => f.IdgroupSemesterPerCourse == courseId);

                // שליפת המערכות הקבועות בתאריכים חופפים ובזמנים חופפים
                List<AppScheduleRegular> LstSchedules = new List<AppScheduleRegular>();
                LstSchedules = _context.AppScheduleRegulars.Include(i => i.AppDailySchedules).Include(i => i.Course.AppUserPerCourses).Include(i => i.LessonPerGroup).Include(i => i.AppDailySchedules)
                .Where(w =>
                (w.StartDate <= endDate && w.EndDate >= startDate) && w.LessonPerGroup.DayOfWeek == LessonPerGroup.DayOfWeek
                && (w.LessonPerGroup.StartTime <= LessonPerGroup.EndTime && w.LessonPerGroup.EndTime >= LessonPerGroup.StartTime)
                ).ToList();

                //בדיקה שאין מורה חופפת לא בקבועה ולא ביומת למערכת החדשה המועלית...
                foreach (var schedul in LstSchedules)
                {
                    foreach (var user in schedul.Course.AppUserPerCourses.ToList())
                    {
                        //if (LessonPerGroup != null)
                        return false;
                    }
                    if (schedul.AppDailySchedules.FirstOrDefault(fr => fr.IsChange == true &&
                     (fr.StartTime <= LessonPerGroup.EndTime && fr.EndTime >= LessonPerGroup.StartTime) &&
                     groupSemesterPerCourse.AppUserPerCourses.FirstOrDefault(l => l.UserId == fr.TeacherId) != null)
                    != null)
                        return false;
                }

                //var ListDaily = _context.AppDailySchedules.FirstOrDefault(w => w.IsChange == true
                //&& w.ScheduleDate >= startDate && w.ScheduleDate <= endDate &&
                // LessonPerGroup.DayOfWeek == (Convert.ToInt32(w.ScheduleDate.Value.DayOfWeek) + 1) &&
                // (w.StartTime <= LessonPerGroup.EndTime && w.EndTime >= LessonPerGroup.StartTime)
                // && groupSemesterPerCourse != null && groupSemesterPerCourse.AppUserPerCourses != null
                //&& groupSemesterPerCourse.AppUserPerCourses.FirstOrDefault(r => r.UserId == w.TeacherId && r.FromDate >= endDate && r.ToDate <= startDate) != null);
                //if (ListDaily != null && ListDaily.IddailySchedule != 0)
                //    return false;
                return true;
            }
            catch (Exception e)
            {

                return false;
            }


        }

        //הפסקת המערכת הקבועה של כלל המוסד
        public List<AppDailySchedule> StopTheScheduleRegularForTheWholeSchool(int schoolId, DateTime startDate, DateTime endDate, int userID)
        {
            List<AppScheduleRegular> LstScheduleRegularsToDelete = new List<AppScheduleRegular>();
            List<AppDailySchedule> LstDailySchedules = new List<AppDailySchedule>();
            List<AppDailySchedule> LstDailySchedulesToDelete = new List<AppDailySchedule>();
            List<AppDailySchedule> LstDailySchedulesToUpdate = new List<AppDailySchedule>();

            //שליפת המערכות החופפות של כל המוסד לזמן שמועלית כעת מערכת
            List<AppScheduleRegular> LstScheduleRegulars = GetScheduleRegularBetweenDatesOfSchool(schoolId, startDate, endDate);
            foreach (var schedule in LstScheduleRegulars)
            {
                //למחוק את כל מי שלא שינו ידנית או שאין לו נוכחות....
                if (schedule.AppDailySchedules != null)
                {
                    //כל המערכות היומיות שחופפות לימים
                    LstDailySchedules = schedule.AppDailySchedules.Where(w =>
                   w.ScheduleDate >= startDate && w.ScheduleDate <= endDate).ToList();

                    //כל המערכות היומיות שצריכות לימחק 
                    LstDailySchedulesToDelete.AddRange(LstDailySchedules.Where(w => w.IsChange == false && (w.AppPresences == null || w.AppPresences.Count == 0)));
                    //כל המערכות היומיות שצריכות להתעדכן ולנתק אותם מהמערכת הקבועה 
                    LstDailySchedulesToUpdate.AddRange(LstDailySchedules.Where(w => w.IsChange == true || (w.AppPresences != null && w.AppPresences.Count > 0)).ToList());
                }

                //אם זה מערכת שכולה בתוך הטווח תאריכים- מוחקים
                if (schedule.StartDate >= startDate && schedule.EndDate <= endDate)
                    LstScheduleRegularsToDelete.Add(schedule);
                else
                //אם זה מערכת שמתחילה באותו זמן או בקצת אחרי ונגמרת יותר מאוחר- יש לעדכן את ההתחלה לתאריך הסופי + יום
                    if (schedule.StartDate >= startDate && schedule.EndDate > endDate)
                {
                    schedule.StartDate = endDate.AddDays(1);
                    schedule.UserUpdatedId = userID;
                    schedule.DateUpdated = DateTime.Today;
                }

                else
                     //אם זה מערכת שנגמרת באותו זמן או קצת לפני ומתחילה יותר מוקדם- יש לעדכן את הסיום לתאריך התחלה - יום
                     if (schedule.StartDate < startDate && schedule.EndDate < endDate)
                {
                    schedule.EndDate = startDate.AddDays(-1);
                    schedule.UserUpdatedId = userID;
                    schedule.DateUpdated = DateTime.Today;
                }
                else
                     //אם זה מערכת שמתחילה לפני ונגמרת אחרי-כלומר כל המערכת כלואה בתוכו- יש לחלק את המערכת ל-2 אחד של הזמן שלפני ואחד של הזמן שאחרי
                     if (schedule.EndDate > endDate && schedule.StartDate < startDate)
                {
                    AppScheduleRegular scheduleRegular = new AppScheduleRegular()
                    {
                        CourseId = schedule.CourseId,
                        LessonPerGroupId = schedule.LessonPerGroupId,
                        DateCreated = DateTime.Today,
                        UserCreatedId = userID,
                        SchoolId = schedule.SchoolId,
                        StartDate = endDate.AddDays(1),
                        EndDate = schedule.EndDate
                    };
                    _context.AppScheduleRegulars.Add(scheduleRegular);
                    schedule.EndDate = startDate.AddDays(-1);
                    schedule.UserUpdatedId = userID;
                    schedule.DateUpdated = DateTime.Today;

                }
            }

            ////עידכון המערכת הישנה שהיה בה שינוי ידני או שיש לשיעור הזה נוכחות - ניתוק מהמערכת הקבועה
            //LstDailySchedulesToUpdate.ForEach(f =>
            //{
            //    f.UserUpdatedId = userID;
            //    f.DateUpdated = DateTime.Today;
            //    f.ScheduleRegularId = null;
            //    f.ScheduleRegular = null;
            //});



            //מחיקת המערכת היומית הישנה
            _context.AppDailySchedules.RemoveRange(LstDailySchedulesToDelete);
            //מחיקת המערכת הקבועה הישנה
            // מה קורה עם המערכות היומיות שמחוברות וצריכות להתעגכן?????
            _context.AppScheduleRegulars.RemoveRange(LstScheduleRegularsToDelete);
            _context.SaveChanges();
            return LstDailySchedulesToUpdate;
        }
        
        public void openDailyScheduleToNewRegularSchedule(AppScheduleRegular scheduleRegular, AppLessonPerGroup lessonPerGroup, List<AppDailySchedule> dailyScheduleOldOfGroup)
        {
            int count = (scheduleRegular.EndDate - scheduleRegular.StartDate).Value.Days;
            int DateStartSchedule = Convert.ToInt32(scheduleRegular.StartDate.Value.DayOfWeek) + 1;

            int DayNeedStartDailySchedule = 0;
            if (lessonPerGroup == null || lessonPerGroup.DayOfWeek == null || lessonPerGroup.DayOfWeek == 0)
            {
                return;
            }

            if (DateStartSchedule <= lessonPerGroup.DayOfWeek)
                DayNeedStartDailySchedule = (int)lessonPerGroup.DayOfWeek - DateStartSchedule;
            else
                DayNeedStartDailySchedule = 7 - DateStartSchedule + (int)lessonPerGroup.DayOfWeek;

            DateTime CurrentDate;
            AppDailySchedule dailySchedule;
            AppDailySchedule dailyScheduleOld;
            List<AppDailySchedule> LstDailySchedules = new List<AppDailySchedule>();
            if (dailyScheduleOldOfGroup == null)
                dailyScheduleOldOfGroup = new List<AppDailySchedule>();
            for (int i = DayNeedStartDailySchedule; i <= count; i += 7)
            {

                CurrentDate = scheduleRegular.StartDate.Value.AddDays(i);
                dailyScheduleOld = dailyScheduleOldOfGroup.FirstOrDefault(f => f.ScheduleDate.Value.Date == CurrentDate.Date);
                if (dailyScheduleOld == null)
                {
                    dailySchedule = new AppDailySchedule()
                    {
                        DateCreated = DateTime.Today,
                        UserCreatedId = scheduleRegular.UserCreatedId,
                        SchoolId = scheduleRegular.SchoolId,
                        ScheduleDate = CurrentDate,
                        ScheduleRegularId = scheduleRegular.IdscheduleRegular,
                        LearningStyleId = 2,
                        NumLesson = scheduleRegular.LessonPerGroup.NumLesson,
                        StartTime = scheduleRegular.LessonPerGroup.StartTime,
                        EndTime = scheduleRegular.LessonPerGroup.EndTime,
                        CourseId = scheduleRegular.CourseId,
                        IsChange = false
                    };

                    isnewdailSchedules = true;
                    LstDailySchedules.Add(dailySchedule);
                }
                else
                {
                    dailyScheduleOld.ScheduleRegularId = scheduleRegular.IdscheduleRegular;
                    dailyScheduleOld.UserUpdatedId = scheduleRegular.UserCreatedId;
                    dailyScheduleOld.DateUpdated = scheduleRegular.DateCreated;
                    dailyScheduleOldOfGroup.Remove(dailyScheduleOld);
                }

                //if (sched.AppDailySchedules != null && sched.AppDailySchedules.Count > 0)
                //    sched.AppDailySchedules.Where(w => w.ScheduleDate <= AppScheduleRegular.EndDate && w.ScheduleDate >= AppScheduleRegular.StartDate).ToList().ForEach(daily =>
                //    {
                //        if (daily != null)
                //        {
                //            if (daily.IsChange == true)
                //                DateTahtChangeByHand.Add(daily);
                //else
                //        {


                //                                            //לא יתכן לעדכן קורס כי מחפש מערכת לפי הקורס
                //                                            // daily.CourseId == AppScheduleRegular.CourseId;
                //                                            //  daily.
                //                                        }
                //    }
                //});
            }

            dailyScheduleOldOfGroup.ForEach(f => f.ScheduleRegularId = null);
            _context.SaveChanges();
           
            _DailyScheduleRepository.AddListDailySchedule(LstDailySchedules,(int)scheduleRegular.UserCreatedId, isnewdailSchedules);
            
        }
//
        public bool AddScheduleRegular(AppScheduleRegular appScheduleRegular, List<AppDailySchedule> dailyScheduleOldOfGroup)
        {
            try
            {
                AppLessonPerGroup lessonPerGroup = appScheduleRegular.LessonPerGroup;
                appScheduleRegular.LessonPerGroup = null;
                _context.AppScheduleRegulars.Add(appScheduleRegular);
                _context.SaveChanges();
               
                openDailyScheduleToNewRegularSchedule(appScheduleRegular, lessonPerGroup, dailyScheduleOldOfGroup);

                return true;
            }
            catch (Exception e)
            {

                return false;
            }


        }

        //עידכון מערכת קבועה
        public bool UpdateScheduleRegular(AppScheduleRegular appScheduleRegular, int GroupId, int userID, bool isOverride)
        {
            if (appScheduleRegular != null && appScheduleRegular.LessonPerGroupId != null && appScheduleRegular.LessonPerGroupId > 0 && appScheduleRegular.LessonPerGroup == null)
            {
                appScheduleRegular.LessonPerGroup = _context.AppLessonPerGroups.FirstOrDefault(f => f.IdlessonPerGroup == appScheduleRegular.LessonPerGroupId);

            }
            if (appScheduleRegular.LessonPerGroup == null)
                return false;

            List<AppScheduleRegular> SchedulesRegularExsist = GetScheduleRegularBetweenDatesByGroupIdDayAndTime(GroupId, appScheduleRegular.StartDate, appScheduleRegular.EndDate, appScheduleRegular.LessonPerGroup.DayOfWeek,
                            appScheduleRegular.LessonPerGroup.StartTime, appScheduleRegular.LessonPerGroup.EndTime);
            List<AppDailySchedule> LstDailySchedules = new List<AppDailySchedule>();
            List<AppScheduleRegular> LstScheduleRegularToDelete = new List<AppScheduleRegular>();
            bool IsSuccedd = false;

            // אם לא קיים בדאטא בייס מערכת חופפת לקבוצה 
            if (SchedulesRegularExsist == null || SchedulesRegularExsist.Count == 0)
            {
                IsSuccedd = AddScheduleRegular(appScheduleRegular, new List<AppDailySchedule>());

            }
            // אם קיים בדאטא בייס מערכת חופפת לקבוצה 
            else
            {
                //אם ביקשו לדרוס
                if (isOverride == true)
                {
                    //טיפול במערכת הקבועה
                    foreach (var schedule in SchedulesRegularExsist)
                    {
                        if (schedule.AppDailySchedules != null)
                            LstDailySchedules.AddRange(schedule.AppDailySchedules);
                        //אם זה מערכת שכולה בתוך הטווח תאריכים- מעדכנים
                        if (schedule.StartDate >= appScheduleRegular.StartDate && schedule.EndDate <= appScheduleRegular.EndDate)
                        {
                            //schedule.StartDate = appScheduleRegular.StartDate;
                            //schedule.EndDate = appScheduleRegular.EndDate;
                            //schedule.CourseId = appScheduleRegular.CourseId;
                            //schedule.LessonPerGroupId = appScheduleRegular.LessonPerGroupId;
                            //schedule.UserUpdatedId = userID;
                            //schedule.DateUpdated = DateTime.Today;
                            LstScheduleRegularToDelete.Add(schedule);
                        }
                        else
                            //אם זה מערכת שמתחילה באותו זמן או בקצת אחרי ונגמרת יותר מאוחר- יש לעדכן את ההתחלה לתאריך הסופי + יום
                            if (schedule.StartDate >= appScheduleRegular.StartDate && schedule.EndDate > appScheduleRegular.EndDate)
                        {
                            schedule.StartDate = appScheduleRegular.EndDate.Value.AddDays(1);
                            schedule.UserUpdatedId = userID;
                            schedule.DateUpdated = DateTime.Today;
                        }

                        else
                             //אם זה מערכת שנגמרת באותו זמן או קצת לפני ומתחילה יותר מוקדם- יש לעדכן את הסיום לתאריך התחלה - יום
                             if (schedule.StartDate < appScheduleRegular.StartDate && schedule.EndDate < appScheduleRegular.EndDate)
                        {
                            schedule.EndDate = appScheduleRegular.StartDate.Value.AddDays(-1);
                            schedule.UserUpdatedId = userID;
                            schedule.DateUpdated = DateTime.Today;
                        }
                        else
                             //אם זה מערכת שמתחילה לפני ונגמרת אחרי-כלומר כל המערכת החדשה כלואה בתוכו- יש לחלק את המערכת ל-2 אחד של הזמן שלפני ואחד של הזמן שאחרי
                             if (schedule.EndDate > appScheduleRegular.EndDate && schedule.StartDate < appScheduleRegular.StartDate)
                        {
                            AppScheduleRegular scheduleRegular = new AppScheduleRegular()
                            {
                                CourseId = schedule.CourseId,
                                LessonPerGroupId = schedule.LessonPerGroupId,
                                DateCreated = DateTime.Today,
                                UserCreatedId = userID,
                                SchoolId = schedule.SchoolId,
                                StartDate = appScheduleRegular.EndDate.Value.AddDays(1),
                                EndDate = schedule.EndDate
                            };
                            _context.AppScheduleRegulars.Add(scheduleRegular);
                            schedule.EndDate = appScheduleRegular.StartDate.Value.AddDays(-1);
                            schedule.UserUpdatedId = userID;
                            schedule.DateUpdated = DateTime.Today;

                        }

                        if (LstScheduleRegularToDelete != null)
                        {
                            _context.RemoveRange(LstScheduleRegularToDelete);
                        }

                    }

                    int DateStartSchedule = Convert.ToInt32(appScheduleRegular.StartDate.Value.DayOfWeek) + 1;

                    int DayNeedStartDailySchedule = 0;

                    if (DateStartSchedule <= appScheduleRegular.LessonPerGroup.DayOfWeek)
                        DayNeedStartDailySchedule = (int)appScheduleRegular.LessonPerGroup.DayOfWeek - DateStartSchedule;
                    else
                        DayNeedStartDailySchedule = 7 - DateStartSchedule + (int)appScheduleRegular.LessonPerGroup.DayOfWeek;


                    //טיפול במערכת היומית
                    int count = (appScheduleRegular.EndDate - appScheduleRegular.StartDate).Value.Days;
                    DateTime CurrentDate;
                    AppDailySchedule dailySchedule;
                    AppDailySchedule dailyScheduleOld;
                    List<AppDailySchedule> LstDailySchedulesToAdd = new List<AppDailySchedule>();

                    _context.AppScheduleRegulars.Add(appScheduleRegular);
                    _context.SaveChanges();
                    for (int i = DayNeedStartDailySchedule; i < count; i += 7)
                    {

                        CurrentDate = appScheduleRegular.StartDate.Value.AddDays(i);
                        dailyScheduleOld = LstDailySchedules.FirstOrDefault(f => f.ScheduleDate.Value.Date == CurrentDate.Date);
                        if (dailyScheduleOld == null)
                        {
                            dailySchedule = new AppDailySchedule()
                            {
                                DateCreated = DateTime.Today,
                                UserCreatedId =userID,
                                SchoolId = appScheduleRegular.SchoolId,
                                ScheduleDate = CurrentDate,
                                ScheduleRegularId = appScheduleRegular.IdscheduleRegular,
                                LearningStyleId = 2,
                                NumLesson = appScheduleRegular.LessonPerGroup.NumLesson,
                                StartTime = appScheduleRegular.LessonPerGroup.StartTime,
                                EndTime = appScheduleRegular.LessonPerGroup.EndTime,
                                CourseId = appScheduleRegular.CourseId,
                                IsChange = false
                            };
                            LstDailySchedulesToAdd.Add(dailySchedule);
                        }
                        else
                        {
                            if (dailyScheduleOld.IsChange == false && (dailyScheduleOld.AppPresences == null) || dailyScheduleOld.AppPresences.Count() == 0)
                            {
                                dailyScheduleOld.DateCreated = DateTime.Today;
                                dailyScheduleOld.UserCreatedId = userID; 
                                dailyScheduleOld.ScheduleRegularId = appScheduleRegular.IdscheduleRegular;
                                dailyScheduleOld.LearningStyleId = 2;
                                dailyScheduleOld.NumLesson = appScheduleRegular.LessonPerGroup.NumLesson;
                                dailyScheduleOld.StartTime = appScheduleRegular.LessonPerGroup.StartTime;
                                dailyScheduleOld.EndTime = appScheduleRegular.LessonPerGroup.EndTime;
                                dailyScheduleOld.CourseId = appScheduleRegular.CourseId;
                                dailyScheduleOld.IsChange = false;
                            }
                            else
                            {
                                dailyScheduleOld.DateUpdated = DateTime.Today;
                                dailyScheduleOld.UserUpdatedId = userID;
                                dailyScheduleOld.ScheduleRegularId = appScheduleRegular.IdscheduleRegular;
                            }
                            LstDailySchedulesToAdd.Add(dailyScheduleOld);
                        }

                    }
                    //_context.AppDailySchedules.AddRange(LstDailySchedulesToAdd);

                    _DailyScheduleRepository.AddListDailySchedule(LstDailySchedulesToAdd, userID, isnewdailSchedules);

                    _context.SaveChanges();
                    IsSuccedd = true;

                }
                else
                    IsSuccedd = true;
            }
            return IsSuccedd;

         }
        //עידכון מערכת קבועה דרך האתר -ידני
        public AppScheduleRegular UpdateScheduleRegularByWebsite(AppScheduleRegular appScheduleRegular, int userID,DateTime date)
        {
            //טיפול במערכת הקבועה
            AppScheduleRegular scheduleRegular = _context.AppScheduleRegulars.FirstOrDefault(f => f.IdscheduleRegular == appScheduleRegular.IdscheduleRegular);
            if (scheduleRegular == null) return null;
            scheduleRegular.CourseId = appScheduleRegular.CourseId;
            scheduleRegular.UserUpdatedId = userID;
            scheduleRegular.DateUpdated = DateTime.Today;

            //טיפול במערכת היומית           
            List<AppDailySchedule> LstDailySchedules =_DailyScheduleRepository.getDailyScheduleByScheduleRegularID(appScheduleRegular.IdscheduleRegular);

            foreach (var DailySchedule in LstDailySchedules)
            {
                if (DailySchedule != null)
                {
                    if (DailySchedule.IsChange == false && (DailySchedule.AppPresences == null) || DailySchedule.AppPresences.Count() == 0)
                    {
                        DailySchedule.DateUpdated = DateTime.Today;
                        DailySchedule.UserUpdatedId = userID;
                        DailySchedule.CourseId = appScheduleRegular.CourseId;
                    }
                }
            }

            _context.SaveChanges();
            scheduleRegular = _context.AppScheduleRegulars.Include(l => l.LessonPerGroup).Include(c => c.Course.Course)
                .Include(i => i.Course).ThenInclude(i => i.AppUserPerCourses.ToList().Where(f => f.FromDate <= date && f.ToDate >= date)).ThenInclude(i=>i.User)
                .FirstOrDefault(f => f.IdscheduleRegular == appScheduleRegular.IdscheduleRegular);
            return scheduleRegular;
        }

    }
}
