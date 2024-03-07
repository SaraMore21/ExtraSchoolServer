using DB.Model;
using DB.Repository.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
namespace DB.Repository.Classes
{
    public class Presence:IPresenceRepository
    {
        private readonly ExtraSchoolContext _context;
        private readonly ICourseRepository _courseRepository;
        public Presence(ExtraSchoolContext context, ICourseRepository courseRepository)
        {
            _context = context;
            _courseRepository = courseRepository;
        }

        public List<Lesson> GetLessonsByDate(DateTime date, int idGroup)
        {
            List<Lesson> lessons = new List<Lesson>();
            Lesson lesson = null;
            using (var cmd = _context.Database.GetDbConnection().CreateCommand())
            {
                
                cmd.CommandText = "[dbo].[sp_GetLessonsByDate]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (cmd.Connection.State != System.Data.ConnectionState.Open) cmd.Connection.Open();
                cmd.Parameters.Add(new SqlParameter("@date", date));
                cmd.Parameters.Add(new SqlParameter("@idGroup", idGroup));

                SqlDataReader rdr = (SqlDataReader)cmd.ExecuteReader();


                if (rdr.HasRows)
                {
                  
                    while (rdr.Read())
                    {
                        lesson = new Lesson();

                        //  lesson בתוך האובייקט  courseid לא השתמשתי בזה בסוף-הגדרתי משתנה 
                       int courseid;
                        if (rdr["NumLesson"] != DBNull.Value) lesson.LessonNumber = int.Parse(rdr["NumLesson"].ToString());
                        if (rdr["IDDailySchedule"] != DBNull.Value) lesson.ScheduleId = int.Parse(rdr["IDDailySchedule"].ToString());
                        if (rdr["TeacherID"] != DBNull.Value) lesson.TeacherId = int.Parse(rdr["TeacherID"].ToString());
                        if (rdr["ScheduleDate"] != DBNull.Value) lesson.Date = DateTime.Parse(rdr["ScheduleDate"].ToString());
                        if (rdr["IsChange"] != DBNull.Value) lesson.IsChanges = bool.Parse(rdr["IsChange"].ToString());
                        if (rdr["CourseID"] != DBNull.Value)
                        {
                            courseid = int.Parse(rdr["CourseID"].ToString());
                            lesson.LessonName = _courseRepository.GetCourseById(courseid).Name;
                        }
                        lessons.Add(lesson);
                    }
                }

                //gvGrid.DataSource = lessons;
                //gvGrid.DataBind();
                cmd.Connection.Close();
            }
            return lessons;
        }





        public List<PresencePerDay> GetPresenceByDay(DateTime date, int idGroup)
        {
            List<AttendencePerDay> attendences = new List<AttendencePerDay>();
            List<AppPresence> presences = new List<AppPresence>();
            List<Lesson> lessons = new List<Lesson>();
            Lesson lesson = null;
            AppPresence presence = null;
            List<PresencePerDay> listPresencePerDay = new List<PresencePerDay>();
            PresencePerDay PresencePerDay = null;
            using (var cmd = _context.Database.GetDbConnection().CreateCommand())
            {

                cmd.CommandText = "[dbo].[sp_GetPresenceByDay]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (cmd.Connection.State != System.Data.ConnectionState.Open) cmd.Connection.Open();
                cmd.Parameters.Add(new SqlParameter("@date", date));
                cmd.Parameters.Add(new SqlParameter("@idGroup", idGroup));

                SqlDataReader rdr = (SqlDataReader)cmd.ExecuteReader();
                


                if (rdr.HasRows)
                {
                    try
                    {

                        while (rdr.Read())

                        {   


                            PresencePerDay = new PresencePerDay();
                            lesson = new Lesson();
                            presence = new AppPresence();
                            //  lesson בתוך האובייקט courseid לא השתמשתי בזה בסוף-הגדרתי משתנה 
                            int courseid;
                            if (rdr["NumLesson"] != DBNull.Value) lesson.LessonNumber = int.Parse(rdr["NumLesson"].ToString());
                            if (rdr["IDDailySchedule"] != DBNull.Value) lesson.ScheduleId = int.Parse(rdr["IDDailySchedule"].ToString());
                            if (rdr["TeacherID"] != DBNull.Value) lesson.TeacherId = int.Parse(rdr["TeacherID"].ToString());
                            if (rdr["ScheduleDate"] != DBNull.Value) lesson.Date = DateTime.Parse(rdr["ScheduleDate"].ToString());
                            if (rdr["IsChange"] != DBNull.Value) lesson.IsChanges = bool.Parse(rdr["IsChange"].ToString());
                            if (rdr["CourseID"] != DBNull.Value)
                            {
                                courseid = int.Parse(rdr["CourseID"].ToString());
                                //lesson.LessonName = _courseRepository.GetCourseById(courseid).Name;
                            }
                            if (rdr["Name"] != DBNull.Value) lesson.LessonName = rdr["Name"].ToString();
                            if (rdr["IDPresence"] != DBNull.Value) presence.Idpresence = int.Parse(rdr["IDPresence"].ToString());
                            if (rdr["TypePresenceID"] != DBNull.Value) presence.TypePresenceId = short.Parse(rdr["TypePresenceID"].ToString());
                            if (rdr["Writeby"] != DBNull.Value) presence.Writeby = short.Parse(rdr["Writeby"].ToString());
                            if (rdr["UserCreatedID"] != DBNull.Value) presence.UserCreatedId = int.Parse(rdr["UserCreatedID"].ToString());
                            if (rdr["DateCreated"] != DBNull.Value) presence.DateCreated = DateTime.Parse(rdr["DateCreated"].ToString());
                            if (rdr["UserUpdatedID"] != DBNull.Value) presence.UserUpdatedId = int.Parse(rdr["UserUpdatedID"].ToString());
                            if (rdr["DateUpdated"] != DBNull.Value) presence.DateUpdated = DateTime.Parse(rdr["DateUpdated"].ToString());
                            TabAttendanceMarking AttendanceMarking = new TabAttendanceMarking();
                            
                            if (rdr["MarkingName"] != DBNull.Value) AttendanceMarking.MarkingName = rdr["MarkingName"].ToString();
                            PresencePerDay.Lesson = lesson;
                            presence.TypePresence = AttendanceMarking;
                            PresencePerDay.Presence = presence;
                           
                            if (rdr["GroupId"] != DBNull.Value) PresencePerDay.GroupId = int.Parse(rdr["GroupId"].ToString());
                            if (rdr["IdStudent"] != DBNull.Value) PresencePerDay.IdStudent = int.Parse(rdr["IdStudent"].ToString());
                            if (rdr["FirstName"] != DBNull.Value) PresencePerDay.FirstName = rdr["FirstName"].ToString();
                            if (rdr["LastName"] != DBNull.Value) PresencePerDay.LastName = rdr["LastName"].ToString();
                            if (rdr["Tz"] != DBNull.Value) PresencePerDay.Tz = rdr["Tz"].ToString();
                          
                            listPresencePerDay.Add(PresencePerDay);
                        }
                    }
                    catch(Exception e)
                    {
                        throw e;


                    }
                }

                //gvGrid.DataSource = lessons;
                //gvGrid.DataBind();
             
                cmd.Connection.Close();
            }
            return listPresencePerDay;
        }

        public List<PresencePerDay> GetPresenceByRangeDateAndGroup(DateTime fromDate, DateTime toDate, int idGroup)
        {
            List<AttendencePerDay> attendences = new List<AttendencePerDay>();
            List<AppPresence> presences = new List<AppPresence>();
            List<Lesson> lessons = new List<Lesson>();
            Lesson lesson = null;
            AppPresence presence = null;
            List<PresencePerDay> listPresencePerDay = new List<PresencePerDay>();
            PresencePerDay PresencePerDay = null;
            using (var cmd = _context.Database.GetDbConnection().CreateCommand())
            {

                cmd.CommandText = "[dbo].[GetPresenceByRangeDateAndGroup]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (cmd.Connection.State != System.Data.ConnectionState.Open) cmd.Connection.Open();
                cmd.Parameters.Add(new SqlParameter("@fromDate", fromDate));
                cmd.Parameters.Add(new SqlParameter("@toDate", toDate));
                cmd.Parameters.Add(new SqlParameter("@idGroup", idGroup));

                SqlDataReader rdr = (SqlDataReader)cmd.ExecuteReader();



                if (rdr.HasRows)
                {
                    try
                    {

                        while (rdr.Read())

                        {


                            PresencePerDay = new PresencePerDay();
                            lesson = new Lesson();
                            presence = new AppPresence();
                            //  lesson בתוך האובייקט courseid לא השתמשתי בזה בסוף-הגדרתי משתנה 
                            int courseid;
                            if (rdr["NumLesson"] != DBNull.Value) lesson.LessonNumber = int.Parse(rdr["NumLesson"].ToString());
                            if (rdr["IDDailySchedule"] != DBNull.Value) lesson.ScheduleId = int.Parse(rdr["IDDailySchedule"].ToString());
                            if (rdr["TeacherID"] != DBNull.Value) lesson.TeacherId = int.Parse(rdr["TeacherID"].ToString());
                            if (rdr["ScheduleDate"] != DBNull.Value) lesson.Date = DateTime.Parse(rdr["ScheduleDate"].ToString());
                            if (rdr["IsChange"] != DBNull.Value) lesson.IsChanges = bool.Parse(rdr["IsChange"].ToString());
                            if (rdr["CourseID"] != DBNull.Value)
                            {
                                courseid = int.Parse(rdr["CourseID"].ToString());
                                //lesson.LessonName = _courseRepository.GetCourseById(courseid).Name;
                            }
                            if (rdr["Name"] != DBNull.Value) lesson.LessonName = rdr["Name"].ToString();
                            if (rdr["IDPresence"] != DBNull.Value) presence.Idpresence = int.Parse(rdr["IDPresence"].ToString());
                            if (rdr["TypePresenceID"] != DBNull.Value) presence.TypePresenceId = short.Parse(rdr["TypePresenceID"].ToString());
                            if (rdr["Writeby"] != DBNull.Value) presence.Writeby = short.Parse(rdr["Writeby"].ToString());
                            if (rdr["UserCreatedID"] != DBNull.Value) presence.UserCreatedId = int.Parse(rdr["UserCreatedID"].ToString());
                            if (rdr["DateCreated"] != DBNull.Value) presence.DateCreated = DateTime.Parse(rdr["DateCreated"].ToString());
                            if (rdr["UserUpdatedID"] != DBNull.Value) presence.UserUpdatedId = int.Parse(rdr["UserUpdatedID"].ToString());
                            if (rdr["DateUpdated"] != DBNull.Value) presence.DateUpdated = DateTime.Parse(rdr["DateUpdated"].ToString());
                            TabAttendanceMarking AttendanceMarking = new TabAttendanceMarking();

                            if (rdr["MarkingName"] != DBNull.Value) AttendanceMarking.MarkingName = rdr["MarkingName"].ToString();
                            PresencePerDay.Lesson = lesson;
                            presence.TypePresence = AttendanceMarking;
                            PresencePerDay.Presence = presence;

                            if (rdr["GroupId"] != DBNull.Value) PresencePerDay.GroupId = int.Parse(rdr["GroupId"].ToString());
                            if (rdr["IdStudent"] != DBNull.Value) PresencePerDay.IdStudent = int.Parse(rdr["IdStudent"].ToString());
                            if (rdr["FirstName"] != DBNull.Value) PresencePerDay.FirstName = rdr["FirstName"].ToString();
                            if (rdr["LastName"] != DBNull.Value) PresencePerDay.LastName = rdr["LastName"].ToString();
                            if (rdr["Tz"] != DBNull.Value) PresencePerDay.Tz = rdr["Tz"].ToString();

                            listPresencePerDay.Add(PresencePerDay);
                        }
                    }
                    catch (Exception e)
                    {
                        throw e;


                    }
                }

                //gvGrid.DataSource = lessons;
                //gvGrid.DataBind();

                cmd.Connection.Close();
            }
            return listPresencePerDay;
        }



        public List<PresencePerDay> GetPresenceByRangeDateToAllGroupByschool(DateTime fromDate, DateTime toDate, int schoolId)
        {
            List<AttendencePerDay> attendences = new List<AttendencePerDay>();
            List<AppPresence> presences = new List<AppPresence>();
            List<Lesson> lessons = new List<Lesson>();
            Lesson lesson = null;
            AppPresence presence = null;
            List<PresencePerDay> listPresencePerDay = new List<PresencePerDay>();
            PresencePerDay PresencePerDay = null;
            using (var cmd = _context.Database.GetDbConnection().CreateCommand())
            {

                cmd.CommandText = "[dbo].[GetPresenceByRangeDateToAllGroupBySchool]";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                if (cmd.Connection.State != System.Data.ConnectionState.Open) cmd.Connection.Open();
                cmd.Parameters.Add(new SqlParameter("@fromDate", fromDate));
                cmd.Parameters.Add(new SqlParameter("@toDate", toDate));
                cmd.Parameters.Add(new SqlParameter("@schoolid", schoolId));

                SqlDataReader rdr = (SqlDataReader)cmd.ExecuteReader();



                if (rdr.HasRows)
                {
                    try
                    {

                        while (rdr.Read())

                        {


                            PresencePerDay = new PresencePerDay();
                            lesson = new Lesson();
                            presence = new AppPresence();
                            //  lesson בתוך האובייקט courseid לא השתמשתי בזה בסוף-הגדרתי משתנה 
                            int courseid;
                            if (rdr["NumLesson"] != DBNull.Value) lesson.LessonNumber = int.Parse(rdr["NumLesson"].ToString());
                            if (rdr["IDDailySchedule"] != DBNull.Value) lesson.ScheduleId = int.Parse(rdr["IDDailySchedule"].ToString());                          
                            if (rdr["ScheduleDate"] != DBNull.Value) lesson.Date = DateTime.Parse(rdr["ScheduleDate"].ToString()); 
                            if (rdr["CourseID"] != DBNull.Value)
                            {
                                courseid = int.Parse(rdr["CourseID"].ToString());
                                //lesson.LessonName = _courseRepository.GetCourseById(courseid).Name;
                            }
                            if (rdr["Name"] != DBNull.Value) lesson.LessonName = rdr["Name"].ToString();
                            if (rdr["IDPresence"] != DBNull.Value) presence.Idpresence = int.Parse(rdr["IDPresence"].ToString());
                            if (rdr["TypePresenceID"] != DBNull.Value) presence.TypePresenceId = short.Parse(rdr["TypePresenceID"].ToString());
                         
                         
                            TabAttendanceMarking AttendanceMarking = new TabAttendanceMarking();

                            if (rdr["MarkingName"] != DBNull.Value) AttendanceMarking.MarkingName = rdr["MarkingName"].ToString();
                            PresencePerDay.Lesson = lesson;
                            presence.TypePresence = AttendanceMarking;
                            PresencePerDay.Presence = presence;
                            if (rdr["GroupId"] != DBNull.Value) PresencePerDay.GroupId = int.Parse(rdr["GroupId"].ToString());
                            if (rdr["IdStudent"] != DBNull.Value) PresencePerDay.IdStudent = int.Parse(rdr["IdStudent"].ToString());
                            if (rdr["FirstName"] != DBNull.Value) PresencePerDay.FirstName = rdr["FirstName"].ToString();
                            if (rdr["LastName"] != DBNull.Value) PresencePerDay.LastName = rdr["LastName"].ToString();
                            if (rdr["Tz"] != DBNull.Value) PresencePerDay.Tz = rdr["Tz"].ToString();

                            listPresencePerDay.Add(PresencePerDay);
                        }
                    }
                    catch (Exception e)
                    {
                        throw e;


                    }
                }

                //gvGrid.DataSource = lessons;
                //gvGrid.DataBind();

                cmd.Connection.Close();
            }
            return listPresencePerDay;
        }





        public AppPresence GetPresenceByStudentIdAndSchedualId(int studentId, int schedualId)
        {
            var a = _context.AppPresences.Include(a => a.TypePresence).FirstOrDefault(p => p.StudentId == studentId
                        && p.DailyScheduleId == schedualId);
            return a;
        }

        //חדש
        public List<AppPresence> addOrUpdateAttendance(string date, int userId, List<AppPresence> presences,List<int> l=null)
        {
            List<AppPresence> lpresences = new List<AppPresence>();

            presences.ForEach(p =>
            {
                if (p.Idpresence == 0 || p.Idpresence == null)
                {
                    p.DateCreated = DateTime.Now;
                        p.UserCreatedId = userId;
                    lpresences.Add(p);
                   //context.AppPresences.Add(p);
                }
                else
                {
                    var x = _context.AppPresences.FirstOrDefault(pr => pr.Idpresence == p.Idpresence);
                    if (x != null)
                    {
                        x.Idpresence = p.Idpresence;
                        x.DailyScheduleId = p.DailyScheduleId;
                        x.StudentId = p.StudentId;
                        x.TypePresenceId = p.TypePresenceId;
                        x.Writeby = p.Writeby;
                        if (p.UserCreatedId == 0)
                            p.UserCreatedId = null;
                        else
                        x.UserCreatedId = p.UserCreatedId;
                        //x.DateCreated = p.DateCreated;

                        x.UserUpdatedId = userId;
                        x.DateUpdated = DateTime.Now;
                        _context.SaveChanges();
                    }
                }

            });
            if (lpresences.Count > 0)
            {
                try
                {
                    lpresences.ForEach(p => {
                        _context.AppPresences.Add(p);
                    _context.SaveChanges();
                    }
                    ) ;
                   // _context.AppPresences.AddRange(lpresences);

                    
                }
                catch(Exception e)
                {
                    
                    throw e;
                }
            }
            //presences = _context.AppPresences.Include(i => i.DailySchedule).Include(i => i.Student).Include(i => i.TypePresence).Include(i => i.UserCreated).Include(i => i.UserCreated);

           return presences;

        }


    }
}
