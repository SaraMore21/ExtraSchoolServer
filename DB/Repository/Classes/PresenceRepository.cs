using DB.Model;
using DB.Repository.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DB.Repository.Classes
{
    public class PresenceRepository:IPresenceRepository
    {
        private readonly ExtraSchoolContext _context;
        private readonly ICourseRepository _courseRepository;
        public PresenceRepository(ExtraSchoolContext context, ICourseRepository courseRepository)
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

        
        public AppPresence GetPresenceByStudentIdAndSchedualId(int studentId, int schedualId)
        {
            var a = _context.AppPresences.Include(a => a.TypePresence).FirstOrDefault(p => p.StudentId == studentId
                        && p.DailyScheduleId == schedualId);
            return a;
        }

        //חדש
        public List<AppPresence> addOrUpdateAttendance(string date, int userId, List<AppPresence> presences)
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
                _context.AppPresences.AddRange(lpresences);

                _context.SaveChanges();
            }
            //presences = _context.AppPresences.Include(i => i.DailySchedule).Include(i => i.Student).Include(i => i.TypePresence).Include(i => i.UserCreated).Include(i => i.UserCreated);

            return presences;

        }


    }
}
