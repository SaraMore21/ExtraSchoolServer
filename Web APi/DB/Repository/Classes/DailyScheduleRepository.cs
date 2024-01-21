using DB.Model;
using DB.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.Classes
{
    public class DailyScheduleRepository : IDailyScheduleRepository
    {

        private readonly ExtraSchoolContext _context;
        private readonly IPresenceRepository _presenceRepository;
        const int PRESENT = 5;
        public List<int> idDailySchdule = new List<int>();
        public DailyScheduleRepository(ExtraSchoolContext context, IPresenceRepository presenceRepository)
        {
            _context = context;
            _presenceRepository = presenceRepository;
        }
        //שליפת המורות הפנויות לפי נתוני שיעור ספציפי במוסד
        public List<AppUserPerSchool> GetAvailableTeachers(DateTime scheduleDate, int numLesson, int SchoolId, int CourseId)
        {
            var ListTeacherBusy = _context.AppDailySchedules.Where(w => w.CourseId != CourseId && w.ScheduleDate == scheduleDate.Date && w.SchoolId == SchoolId && w.NumLesson == numLesson && w.TeacherId != null && w.TeacherId != 0).Select(s => s.TeacherId).ToList();
            ListTeacherBusy.AddRange(_context.AppDailySchedules.Where(w => w.CourseId != CourseId && w.ScheduleDate == scheduleDate.Date && w.SchoolId == SchoolId && w.NumLesson == numLesson && (w.TeacherId == null || w.TeacherId == 0)).Select(s => s.Course.AppUserPerCourses.FirstOrDefault(f => f.FromDate <= scheduleDate.Date && f.ToDate >= scheduleDate.Date).UserId).ToList());
            var result = _context.AppUserPerSchools.Include(i => i.User).Where(w => ((w.LastName != null && w.LastName != "") || (w.FirstName != null && w.FirstName != "")) && w.SchoolId == SchoolId && ListTeacherBusy.Contains(w.IduserPerSchool) == false).ToList();
            return result;
        }
        //שליפת המורות הפנויות לפי טווח שעות ושאר נתוני השיעור
        public List<AppUserPerSchool> GetAvailableTeachersByHourRange(DateTime ScheduleDate, TimeSpan FromTime, TimeSpan ToTime, int SchoolId, int CourseId)
        {
            var ListTeacherBusy = _context.AppDailySchedules.Where(w => w.CourseId != CourseId && w.ScheduleDate == ScheduleDate.Date && w.SchoolId == SchoolId && w.StartTime < ToTime && w.EndTime > FromTime && w.TeacherId != null && w.TeacherId != 0).Select(s => s.TeacherId).ToList();
            ListTeacherBusy.AddRange(_context.AppDailySchedules.Where(w => w.CourseId != CourseId && w.ScheduleDate == ScheduleDate.Date && w.SchoolId == SchoolId &&
             w.StartTime < ToTime && w.EndTime > FromTime && (w.TeacherId == null || w.TeacherId == 0)).Select(s => s.Course.AppUserPerCourses.FirstOrDefault(f => f.FromDate <= ScheduleDate.Date && f.ToDate >= ScheduleDate.Date).UserId).ToList());
            var result = _context.AppUserPerSchools.Include(i => i.User).Where(w => ((w.LastName != null && w.LastName != "") || (w.FirstName != null && w.FirstName != "")) && w.SchoolId == SchoolId && ListTeacherBusy.Contains(w.IduserPerSchool) == false).ToList();
            return result;
        }
        //שליפת השיעורים הפנויים לקבוצה בתאריך
        public List<AppLessonPerGroup> GetNumLessonAvailable(int GroupId, DateTime ScheduleDate)
        {
            //ערכים ריקים
            List<AppDailySchedule> ListDailySchedule = _context.AppDailySchedules.Include(i => i.Course).Where(w => w.ScheduleDate.Value.Date == ScheduleDate.Date && w.Course != null && w.Course.GroupId == GroupId).ToList();
            return _context.AppLessonPerGroups.ToList().Where(w => w.GroupId == GroupId && (int)w.DayOfWeek == (Convert.ToInt32(ScheduleDate.DayOfWeek) + 1)
           && ListDailySchedule.ToList().FirstOrDefault(f => f.StartTime < w.EndTime && f.EndTime > w.StartTime) == null).ToList();
        }
        //שליפת מורה לפי הקורס הנבחר
        public AppUserPerSchool GetTeacherBySelectCourse(int GroupSemesterPerCourseId, DateTime scheduleDate)
        {
            return _context.AppUserPerCourses.Include(u => u.User.User).FirstOrDefault(f => f.GroupSemesterPerCourseId == GroupSemesterPerCourseId && f.FromDate.Value.Date <= scheduleDate.Date && f.ToDate.Value.Date >= scheduleDate.Date)?.User;
        }
        //שליפת מערכת יומית לקבוצה בתאריך
        public List<AppDailySchedule> GetDailySchedulePerGroup(int GroupId, DateTime ScheduleDate)
        {
            return _context.AppDailySchedules.Include(i => i.LearningStyle).Include(i => i.Course.Course).Include(i => i.Teacher).Include(i => i.Course.AppUserPerCourses.Where(w => w.FromDate.Value.Date <= ScheduleDate.Date && w.ToDate.Value.Date >= ScheduleDate.Date)).ThenInclude(i => i.User).Where(w => w.Course.GroupId == GroupId && w.ScheduleDate.Value.Date == ScheduleDate.Date).OrderBy(o => o.StartTime).ToList();
        }
        //עריכת מערכת יומית-שמירת פרטי השיעור 
        public AppDailySchedule EditDailySchedule(AppDailySchedule DailySchedule)
        {
            DailySchedule.LearningStyle = null;
            DailySchedule.Teacher = null;
            DailySchedule.Course = null;
            var DS = _context.AppDailySchedules.Include(i => i.Course.AppUserPerCourses).FirstOrDefault(f => f.IddailySchedule == DailySchedule.IddailySchedule);
            if (DS == null) return null;
            //במקרה והמורה משובצת בשעה המבוקשת לקבוצה אחרת
            if (_context.AppDailySchedules.FirstOrDefault(w =>
            w.IddailySchedule != DailySchedule.IddailySchedule && w.ScheduleDate == DailySchedule.ScheduleDate.Value.Date && w.NumLesson == DS.NumLesson &&
               ((w.TeacherId != null && w.TeacherId == DailySchedule.TeacherId) ||
               (w.TeacherId == null && w.Course.AppUserPerCourses.FirstOrDefault(f => f.FromDate.Value.Date <= DailySchedule.ScheduleDate.Value.Date && f.ToDate.Value.Date >= DailySchedule.ScheduleDate.Value.Date).UserId == DailySchedule.TeacherId))) != null)
                return new AppDailySchedule();
            //של המורה החדשה ID כאשר המורה שונה מהמורה שבקורס -הצבת   
            if (DS.Course?.AppUserPerCourses?.FirstOrDefault(f => f.FromDate.Value.Date <= DailySchedule.ScheduleDate.Value.Date && f.ToDate.Value.Date >= DailySchedule.ScheduleDate.Value.Date)?.UserId != DailySchedule.TeacherId)
                DS.TeacherId = DailySchedule.TeacherId;
            //אם נעשה שינוי במורה/הקורס או הסוג למידה
            if (DailySchedule.LearningStyleId != DS.LearningStyleId || DailySchedule.CourseId != DS.CourseId || DS.TeacherId != null)
                DS.IsChange = true;
            DS.CourseId = DailySchedule.CourseId;
            DS.LearningStyleId = DailySchedule.LearningStyleId;
            _context.SaveChanges();
            DS = _context.AppDailySchedules.Include(i => i.Course.Course).Include(i => i.Course.AppUserPerCourses).ThenInclude(i => i.User).Include(i => i.LearningStyle).Include(i => i.Teacher).FirstOrDefault(f => f.IddailySchedule == DS.IddailySchedule);
            return DS;
        }

        public List<AppDailySchedule> GetDailyScheduleBetweenDatesOfCourse(int? courseId, DateTime? startDate, DateTime? endDate)
        {
            List<AppDailySchedule> LstSchedules = new List<AppDailySchedule>();
            LstSchedules = _context.AppDailySchedules.Where(w =>
            w.CourseId == courseId && (w.ScheduleDate.Value.Date <= endDate.Value.Date && w.ScheduleDate.Value.Date >= startDate.Value.Date)
            ).ToList();
            return LstSchedules;
        }
        //הוספת מערכת יומית
        public Tuple<AppDailySchedule, string> AddDailySchedule(AppDailySchedule DailySchedule)
        {
            DailySchedule.LearningStyle = null;
            if (DailySchedule.NumLesson == -1) DailySchedule.NumLesson = null;
            var GroupId = _context.AppGroupSemesterPerCourses.FirstOrDefault(g => g.IdgroupSemesterPerCourse == DailySchedule.CourseId)?.GroupId;
            //בדיקה האם יש לקבוצה זו שיעור במערכת יומית בשעות חופפות
            if (_context.AppDailySchedules.FirstOrDefault(f => f.StartTime < DailySchedule.EndTime && f.EndTime > DailySchedule.StartTime
            && f.Course != null && f.Course.GroupId == GroupId && f.ScheduleDate.Value.Date == DailySchedule.ScheduleDate.Value.Date) != null)
                return new Tuple<AppDailySchedule, string>(null, "לקבוצה זו קיים שיעור הנפגש עם השעות שהזנת");
            //בדיקה האם המורה לא משובצת בשעה הרצויה
            if (_context.AppDailySchedules.FirstOrDefault(w => w.StartTime < DailySchedule.EndTime && w.EndTime > DailySchedule.StartTime
            && (w.TeacherId != null ? w.TeacherId == DailySchedule.TeacherId
            : w.Course != null && w.Course.AppUserPerCourses != null && (w.Course.AppUserPerCourses.FirstOrDefault(f => f.FromDate.Value.Date <= DailySchedule.ScheduleDate.Value.Date && f.ToDate.Value.Date >= DailySchedule.ScheduleDate.Value.Date && f.UserId == DailySchedule.TeacherId) != null)
            ))
            != null)
                return new Tuple<AppDailySchedule, string>(null, "מורה זו משובצת בטווח השעות הרצויות");
            try
            {
                _context.AppDailySchedules.Add(DailySchedule);
                _context.SaveChanges();
                DailySchedule = _context.AppDailySchedules.Include(i => i.Course.Course).Include(i => i.Course.AppUserPerCourses).ThenInclude(i => i.User).Include(i => i.LearningStyle).Include(i => i.Teacher).FirstOrDefault(f => f.IddailySchedule == DailySchedule.IddailySchedule);

                return Tuple.Create(DailySchedule, "השיעור נוסף בהצלחה");
            }
            catch (Exception e){ 

                throw e;
            }
        }



        //שליפת נתוני מערכת יומית לפי מערכת קבועה 
        public Tuple<AppGroupSemesterPerCourse, AppUserPerSchool, int> GetDailyScheduleDetailsByScheduleRegular(int GroupId, DateTime ScheduleDate, TimeSpan StartTime, TimeSpan EndTime)
        {
            var SR = _context.AppScheduleRegulars.Include(i => i.Course.Course).Include(i => i.Course.AppUserPerCourses).ThenInclude(i => i.User.User).FirstOrDefault(f => f.LessonPerGroup != null && f.LessonPerGroup.GroupId == GroupId && f.StartDate <= ScheduleDate && f.EndDate >= ScheduleDate && f.LessonPerGroup.DayOfWeek == (Convert.ToInt32(ScheduleDate.DayOfWeek) + 1) &&
                    f.LessonPerGroup.StartTime == StartTime && f.LessonPerGroup.EndTime == EndTime);
            if (SR == null) return null;
            return Tuple.Create(SR.Course, SR.Course.AppUserPerCourses.FirstOrDefault(f => f.FromDate.Value.Date <= ScheduleDate.Date && f.ToDate.Value.Date >= ScheduleDate.Date)?.User, SR.IdscheduleRegular);

        }
        //מחיקת מערכת יומית
        public bool DeleteDailySchedule(int IdDailySchedule)
        {
            var DailySchedule = _context.AppDailySchedules.Include(i => i.AppPresences).FirstOrDefault(f => f.IddailySchedule == IdDailySchedule);
            if (DailySchedule.AppPresences != null && DailySchedule.AppPresences.Count() != 0)
                return false;
            _context.AppDailySchedules.Remove(DailySchedule);
            _context.SaveChanges();
            return true;
        }

        //public List<int> GetListIdDailySchedule(int SchoolId, int IdSchedulRegular)
        //{
        //    return _context.AppDailySchedules.Where(w => w.SchoolId == SchoolId &&w.ScheduleRegularId== IdSchedulRegular).AsNoTracking().Select(s=>s.IddailySchedule).ToList();
        //}

        public void AddListDailySchedule(List<AppDailySchedule> lstDailySchedules,int userId=0)
        {
            

            _context.AppDailySchedules.AddRange(lstDailySchedules);
            _context.SaveChanges();

            //int maxId = _context.AppDailySchedules.Max(ds => ds.IddailySchedule);

            List<AppDailySchedule> newLstDailySchedules = new List<AppDailySchedule>();
            //List<int> ListIdDailySchedule = new List<int>();
            newLstDailySchedules = lstDailySchedules;
            //ListIdDailySchedule= GetListIdDailySchedule((int)lstDailySchedules[0].SchoolId, (int)lstDailySchedules[0].ScheduleRegularId);

            //for (int i = maxId, j = lstDailySchedules.Count - 1; j >= 0; i--, j--)
            //{
            //    lstDailySchedules[j].IddailySchedule = i;
            //    newLstDailySchedules.Add(
            //         lstDailySchedules[j]
            //        );
            //}
            //for(int i=0;i< ListIdDailySchedule.Count; i++)
            //{
            //    lstDailySchedules[i].IddailySchedule = ListIdDailySchedule[i];
            //    newLstDailySchedules.Add(
            //         lstDailySchedules[i]
            //        );
            //}
            List<AppPresence> lpresence = new List<AppPresence>();
            newLstDailySchedules.ForEach(d => {
                
                List<AppStudentPerGroup> listStudents = new List<AppStudentPerGroup>();
                //AppStudentPerGroup spg = new AppStudentPerGroup();
                //spg.StudentId = 368;


               // listStudents.Add(spg);
                using (var cmd = _context.Database.GetDbConnection().CreateCommand())
                {

                    cmd.CommandText = "[dbo].[sp_getStudentsByCourseId]";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    if (cmd.Connection.State != System.Data.ConnectionState.Open) cmd.Connection.Open();
                    cmd.Parameters.Add(new SqlParameter("@courseId", (int)d.CourseId));


                    SqlDataReader rdr = (SqlDataReader)cmd.ExecuteReader();


                    if (rdr.HasRows)
                    {

                        while (rdr.Read())
                        {
                            AppStudentPerGroup spg = new AppStudentPerGroup();

                            if (rdr["StudentId"] != DBNull.Value) spg.StudentId = int.Parse(rdr["StudentId"].ToString());

                            listStudents.Add(spg);
                        }
                    }

                    //gvGrid.DataSource = lessons;
                    //gvGrid.DataBind();
                    cmd.Connection.Close();
                }



                listStudents.ForEach(s =>
                {
                    //idDailySchdule.Add(d.IddailySchedule);
                       AppPresence newPresence = new AppPresence();
                    newPresence.DailyScheduleId = d.IddailySchedule;
                    newPresence.DateCreated = DateTime.Today;
                    newPresence.StudentId =(int) s.StudentId;
                    newPresence.TypePresenceId = PRESENT;
                    newPresence.UserCreatedId = d.UserCreatedId;
                    lpresence.Add(newPresence);
                }
                );
                

            }


            );

            
            _presenceRepository.addOrUpdateAttendance(null, userId, lpresence, idDailySchdule);

        }

        //אם העלו מערכת חדשה ולא לכל היומי שהתקיים העלו מערכת חדשה -> ניתוק מהמערכת הקבועה
        public void SetScheduleRegularIdNull(List<AppDailySchedule> dailyScheduleOld)
        {
            dailyScheduleOld.ForEach(f => f.ScheduleRegularId = null);
            _context.SaveChanges();
        }
        //שליפת מערכות יומיות המשוייכות למערכת יומית
        public List<AppDailySchedule> getDailyScheduleByScheduleRegularID(int ScheduleRegularID)
        {
            List<AppDailySchedule> LstDailySchedule = _context.AppDailySchedules.Include(i=> i.AppPresences).Where(w=>w.ScheduleRegularId == ScheduleRegularID ).ToList();
            return LstDailySchedule;
        }
    }
}
