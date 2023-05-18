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
    public class CourseRepository : ICourseRepository
    {
        private readonly ExtraSchoolContext _context;
        private readonly IHebrewDateRepository _hebrewDateRepository;

        public CourseRepository(ExtraSchoolContext context, IHebrewDateRepository hebrewDateRepository)
        {
            _context = context;
            _hebrewDateRepository = hebrewDateRepository;
        }

        public List<AppGroupSemesterPerCourse> GetAllCourseBySchoolDAndYearbookId(string SchoolsId, int YearbookId)
        {

            var l = _context.AppGroupSemesterPerCourses.Include(c => c.Course.School).Include(p => p.Course.Profession).Include(g => g.Group).ThenInclude(g => g.Group).Include(s => s.Semester).ThenInclude(y => y.Yearbook)
                .Where(w => w.Semester != null && w.Semester.Yearbook != null && w.Semester.Yearbook.YearbookId == YearbookId && SchoolsId.Contains(w.Course.SchoolId.ToString())).ToList();

            //var l=_context.AppGroupSemesterPerCourses.Include(s=>s.Semester).Include(c=>c.Course).Where(w => w.Semester.YearbookId == YearbookId && w.Course.SchoolId == SchoolId).ToList();
            return l;
        }
        public List<AppCourse> GetAllCourseBySchoolId(int SchoolId)
        {
            //return null;
            var c = _context.AppCourses.Where(w => w.SchoolId == SchoolId).ToList();
            return c;
        }
        public AppCourse GetCourseById(int CourseId)
        {
            //return null;
            int idCourse =(int) _context.AppGroupSemesterPerCourses.FirstOrDefault(w => w.IdgroupSemesterPerCourse == CourseId).CourseId;
            var c = _context.AppCourses.FirstOrDefault(w => w.Idcourse == idCourse);
            return c;
        }
        public List<AppSemester> GetAllSemester(int YearbookId)
        {
            return _context.AppSemesters.Include(y => y.Yearbook).Where(w => w.YearbookId == YearbookId).ToList();
        }
        //public AppGroupSemesterPerCourse AddCourse(int SchoolId, int SemesterId, int CourseId, int GroupId, DateTime SemesterFromDate, DateTime SemesterToDate, int TeacherId,int YearbookId,int UserCreatedId, AppCourse AppCourse)
        //{
        //    AppCourse.UserCreatedId = UserCreatedId;
        //    AppCourse.DateCreate = DateTime.Today;
        //    //if(AppCourse.Idcourse == 0)
        //    //{
        //    //    _context.AppCourses.Add(AppCourse);
        //    //    _context.SaveChanges();
        //    //    CourseId = AppCourse.Idcourse;
        //    //}

        //    //כאן נעצרתי
        //    var hebrewYear = _hebrewDateRepository.GetHebrewYear(SemesterFromDate);
        //    var group = _context.AppGroupPerYearbooks.FirstOrDefault(f => f.IdgroupPerYearbook== GroupId);
        //    var Course = _context.AppCourses.FirstOrDefault(f => f.Idcourse == CourseId);
        //    var CourseCode =(Course!=null?Course.ProfessionId:" ") +","+ hebrewYear+ ","+SemesterId+","+(Course!=null?Course.SchoolId:" ");
        //    var course = new AppGroupSemesterPerCourse() { SemesterId = SemesterId, CourseId = CourseId, GroupId =group!=null? group.IdgroupPerYearbook:null, FromDate = SemesterFromDate, ToDate = SemesterToDate, CourseCode = CourseCode,UserCreatedId=UserCreatedId,DateCreated=DateTime.Today };
        //    var listCourse = _context.AppGroupSemesterPerCourses.Where(w => w.CourseId == CourseId && w.SemesterId == SemesterId && w.GroupId == group.IdgroupPerYearbook);

        //    //להמשיך מפה!
        //    if (listCourse.FirstOrDefault(f => (f.FromDate <= SemesterFromDate && f.ToDate >= SemesterToDate) || (f.FromDate >= SemesterFromDate && f.ToDate <= SemesterToDate) || (f.FromDate >= SemesterFromDate && f.ToDate >= SemesterToDate && f.FromDate <= SemesterToDate) || (f.FromDate <= SemesterFromDate && f.ToDate <= SemesterToDate && f.ToDate >= SemesterFromDate)) != null)
        //        return null;
        //    #region בדיקות תקינות כאשר נתנו אפשרות לדריסת שיוכים קיימים
        //    //AppGroupSemesterPerCourse GSPC;
        //    //    #region מחיקת השיוכים הנמצאים בתוך טווח התאריכים או שווים לטווח התאריכים של השיוך החדש
        //    //    var ListC = listCourse.Where(w => w.FromDate >= SemesterFromDate && w.ToDate <= SemesterToDate).ToList();
        //    //_context.AppGroupSemesterPerCourses.RemoveRange(ListC);
        //    //#endregion
        //    //#region אחרת-אם קיים שיוך שהתאריך התחלה של השיוך החדש  בתוך השיוך הקיים והתאריך הסיום שלו אח"כ אז -עדכון התאריך סיום של הישן לתאריך התחלה של החדש.
        //    //GSPC = listCourse.FirstOrDefault(f => f.FromDate < SemesterFromDate && f.ToDate < SemesterToDate && f.ToDate > SemesterFromDate);
        //    //if (GSPC != null) GSPC.ToDate = SemesterFromDate.AddDays(-1);
        //    //#endregion
        //    //#region	ואם קיים שיוך שהתאריך סיום שלו אחרי התאריך סיום של החדש והתאריך התחלה שלו לפני התאריך סיום של החדש מעדכנים את התאריך התחלה של הישן לפי התאריך סיום של החדש.
        //    //GSPC = listCourse.FirstOrDefault(f => f.ToDate > SemesterToDate && f.FromDate > SemesterFromDate && f.FromDate < SemesterToDate);
        //    //if (GSPC != null) GSPC.FromDate = SemesterToDate.AddDays(1);
        //    //#endregion
        //    //#region  אם הטווח תאריכים של השיוך החדש נמצא בתוך שיוך קיים-השיוך שקיים מתחלק לשניים לפי תאריך התחלה וסיום של השיוך החדש
        //    //GSPC = listCourse.FirstOrDefault(f => f.FromDate < SemesterFromDate && f.ToDate > SemesterToDate);
        //    //if (GSPC != null)
        //    //{
        //    //    var newShiuch = new AppGroupSemesterPerCourse() {  GroupId =group.IdgroupPerYearbook,CourseId=CourseId,SemesterId=SemesterId, FromDate = SemesterToDate.AddDays(1), ToDate = ((DateTime)GSPC.ToDate) };
        //    //    _context.AppGroupSemesterPerCourses.Add(newShiuch);
        //    //    GSPC.ToDate = SemesterFromDate.AddDays(-1);
        //    //}
        //    //#endregion
        //    #endregion
        //    _context.AppGroupSemesterPerCourses.Add(course);
        //    _context.SaveChanges();

        //    _context.AppUserPerCourses.Add(new AppUserPerCourse() { GroupSemesterPerCourseId = course.IdgroupSemesterPerCourse, FromDate = SemesterFromDate, ToDate = SemesterToDate, UserId = TeacherId,UserCreatedId=UserCreatedId,DateCreated=DateTime.Today });
        //    _context.SaveChanges();
        //    course = _context.AppGroupSemesterPerCourses.Include(s=>s.Semester).Include(c => c.Course.Profession).Include(g => g.Group.Group).FirstOrDefault(f => f.IdgroupSemesterPerCourse == course.IdgroupSemesterPerCourse);

        //    return course;
        //}
        public int DeleteCourse(int CourseId)
        {

            var GSpC = _context.AppGroupSemesterPerCourses.Include(c => c.Course).ThenInclude(g => g.AppGroupSemesterPerCourses).FirstOrDefault(f => f.IdgroupSemesterPerCourse == CourseId);
            _context.AppGroupSemesterPerCourses.Remove(GSpC);
            _context.SaveChanges();
            //if (GSpC.Course.AppGroupSemesterPerCourses.Count() == 0)
            //{
            //    _context.AppCourses.Remove(GSpC.Course);
            //    _context.SaveChanges();
            //    return 2;
            //}
            return 1;
        }
        public List<AppUserPerCourse> GetUsersPerCourse(int CourseId)
        {
            //var UPC= _context.AppUserPerCourses.FirstOrDefault(f => f.GroupSemesterPerCourseId == CourseId&&f.FromDate<=DateTime.Today&&f.ToDate>=DateTime.Today);
            // return UPC;
            return _context.AppUserPerCourses.Include(u => u.User).ThenInclude(u => u.User).Where(w => w.GroupSemesterPerCourseId == CourseId).OrderBy(o => o.FromDate).ToList();
        }
        //שליפת המורה המשוייכת לקורס בטווח תאריכים
        public AppUserPerSchool GetUserPerCourse(int CourseId,DateTime Date) 
        {
            return _context.AppUserPerCourses.Include(i=>i.User.User).FirstOrDefault(f => f.GroupSemesterPerCourseId == CourseId && f.FromDate <= Date && f.ToDate >= Date)?.User;
        }

        public bool EditCourse(int CourseId,string CourseCode, List<AppUserPerCourse> ListUserPerCourse)
        {
            var course = _context.AppGroupSemesterPerCourses.FirstOrDefault(f => f.IdgroupSemesterPerCourse == CourseId);
            
            if (course == null) return false;
            course.Code = CourseCode;
            var ListUPC = _context.AppUserPerCourses.Where(w => w.GroupSemesterPerCourseId == CourseId);
            foreach (var item in ListUPC)
            {
                var upc = ListUserPerCourse.FirstOrDefault(f => f.IduserPerCourse == item.IduserPerCourse);
                if (upc == null)
                    _context.Remove(item);
                else
                {
                    item.FromDate = upc.FromDate; item.ToDate = upc.ToDate; item.UserId = upc.UserId;
                }
                ListUserPerCourse.Remove(upc);
            }
            ListUserPerCourse.ForEach(f => f.User = null);
            _context.AppUserPerCourses.AddRange(ListUserPerCourse);
            _context.SaveChanges();
            return true;
        }

        public AppCourse AddFatherCourse(AppCourse Course)
        {
            if (_context.AppCourses.FirstOrDefault(f => f.Name == Course.Name && f.SchoolId == Course.SchoolId) != null) return null;
            _context.AppCourses.Add(Course);
            _context.SaveChanges();
            return Course;
        }
        public List<AppGroupSemesterPerCourse> GetAllCourseByFatherCourseId(int FatherCourseId)
        {
            return _context.AppGroupSemesterPerCourses.Include(s => s.Semester).Include(g => g.Group.Yearbook).Include(i=> i.Group).ThenInclude(g => g.Group).Include(i=> i.Course).Where(w => w.CourseId == FatherCourseId).ToList();
        }
        //הוספת קורס
        public AppGroupSemesterPerCourse AddCourse(AppGroupSemesterPerCourse course,int TeacherId)
        {
            var listCourse = _context.AppGroupSemesterPerCourses.Where(w =>w.CourseId == course.CourseId && w.SemesterId == course.SemesterId && w.GroupId == course.GroupId).ToList();
            if (listCourse.FirstOrDefault(f => (f.FromDate <= course.FromDate && f.ToDate >= course.ToDate) || (f.FromDate >= course.FromDate && f.ToDate <= course.ToDate) || (f.FromDate >= course.FromDate && f.ToDate >= course.ToDate && f.FromDate <= course.ToDate) || (f.FromDate <= course.FromDate && f.ToDate <= course.ToDate && f.ToDate >= course.FromDate)) != null)
               return null;
            course.Semester = null;
            course.Course = null;
            course.Group = null;
            
            _context.AppGroupSemesterPerCourses.Add(course);
            _context.SaveChanges();
            _context.AppUserPerCourses.Add(new AppUserPerCourse() { GroupSemesterPerCourseId = course.IdgroupSemesterPerCourse, FromDate = course.FromDate, ToDate = course.ToDate, UserId = TeacherId, UserCreatedId = course.UserCreatedId, DateCreated = DateTime.Today });
            _context.SaveChanges();
            return _context.AppGroupSemesterPerCourses.Include(s => s.Semester).Include(g => g.Group.Group).FirstOrDefault(f => f.IdgroupSemesterPerCourse == course.IdgroupSemesterPerCourse);
        }

        public AppGroupSemesterPerCourse AddCordinatedCourse(AppGroupSemesterPerCourse course)
        {
            _context.AppGroupSemesterPerCourses.Add(course);
            _context.SaveChanges();
            return _context.AppGroupSemesterPerCourses.Include(s => s.Semester).Include(g => g.Group.Group).FirstOrDefault(f => f.IdgroupSemesterPerCourse == course.IdgroupSemesterPerCourse);
        }

        //GroupId שליפת הקורסים הפעילים לקבוצה לפי  
        public List<AppGroupSemesterPerCourse> GetCoursesForGroup(int GroupId, DateTime scheduleDate)
        {
            return _context.AppGroupSemesterPerCourses.Include(c => c.Course).Where(w => w.GroupId == GroupId && w.FromDate <= scheduleDate.Date && w.ToDate >= scheduleDate.Date&&w.Course.Name!=null&&w.Course.Name!="").ToList();
        }
        public Tuple<AppGroupSemesterPerCourse, List<AppSchool>> TestGetCoordinatedCourse()
        {
            var gpc = _context.AppGroupSemesterPerCourses.FirstOrDefault(g => g.IdgroupSemesterPerCourse == 16);
            return null;
        }
    }
}
