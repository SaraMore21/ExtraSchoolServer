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
    public class GroupRepository : IGroupRepository
    {
        private readonly ExtraSchoolContext _context;

        public GroupRepository(ExtraSchoolContext context)
        {
            _context = context;
        }


        public bool AddListGroups(List<AppGroup> groups)
        {
            try
            {
                _context.AppGroups.AddRange(groups);
                _context.SaveChanges();
                return true;
            }
            catch (Exception )
            {

                return false;
            }
        }

        //public List<AppGroup> GetGroupsByIdSchool(int SchoolId,int YearbookId)
        //{
        //    try { 
        //    //שליפת הקבוצות של השנה המבוקשת
        //    var a= _context.AppGroupPerYearbooks.Include(g => g.Group).Include(u=>u.AppUserPerGroups).Where(w => w.YearbookId == YearbookId && w.Group.SchoolId == SchoolId ).Select(s => s.Group).ToList();//.AppGroups.Where(w => w.SchoolId == SchoolId&&w.).ToList();
        //        //a.ForEach(f => f.AppGroupPerYearbooks = null);
        //        return a;
        //    }
        //    catch(Exception e)
        //    {
        //        return null;
        //    }
        //}

        public List<AppGroupPerYearbook> GetGroupsByIdSchool(string Schools, int YearbookId)
        {
            try
            {
                Schools = Schools.Remove(Schools.Length - 1);

                string[] arr = Schools.Split(',');
                //שליפת הקבוצות של השנה המבוקשת
                var b = _context.AppGroupPerYearbooks.Include(y => y.Yearbook.Yearbook).Include(g => g.Group).ThenInclude(s => s.School).Include(g=> g.Group.AgeGroup).Include(i=> i.Group.TypeGroup).Where(w => 
                w.Group != null && w.Yearbook.YearbookId == YearbookId  && (arr.Any(a=> a == w.Group.SchoolId.ToString()) == true ));//.AppGroups.Where(w => w.SchoolId == SchoolId&&w.).ToList();
                //a.ForEach(f => f.AppGroupPerYearbooks = null);
                var a = b.ToList();
                return a;
            }
            catch (Exception )
            {
                return null;
            }
        }

        public List<AppStudentPerGroup> GetStudentPerGroup(int GroupPerYearbookId, int YearbookId)
        {
            //&& w.FromDate <= DateTime.Today && w.ToDate >= DateTime.Today
            return _context.AppStudentPerGroups.Include(s => s.Student).Where(w => w.GroupId == GroupPerYearbookId).ToList();
        }

        public int DeleteGroup(int GroupPerYearbookId, int YearbookId)
        {
            var group = _context.AppGroupPerYearbooks.FirstOrDefault(f => f.IdgroupPerYearbook == GroupPerYearbookId);
            var ListStudent = _context.AppStudentPerGroups.Where(w => w.GroupId == GroupPerYearbookId);
            _context.AppStudentPerGroups.RemoveRange(ListStudent);
            _context.SaveChanges();
            var ListUserPerGroup = _context.AppUserPerGroups.Where(w => w.GroupId == GroupPerYearbookId);
            _context.AppUserPerGroups.RemoveRange(ListUserPerGroup);
            _context.SaveChanges();
            var ListGroupSemesterPerCourse = _context.AppGroupSemesterPerCourses.Where(w => w.GroupId == GroupPerYearbookId);
            _context.AppGroupSemesterPerCourses.RemoveRange(ListGroupSemesterPerCourse);
            _context.AppGroupPerYearbooks.Remove(group);
            _context.SaveChanges();
            var g = _context.AppGroups.Include(a => a.AppGroupPerYearbooks).FirstOrDefault(f => f.Idgroup == group.GroupId);
            if (g != null && g.AppGroupPerYearbooks.Count() == 0)
            {
                _context.AppGroups.Remove(g);
                _context.SaveChanges();
                return 2;
            }
            return 1;
        }


        //Edit userPerGroup NOT group
        public bool EditGroup(int IdgroupPerYearbook, int UserUpdateId, List<AppUserPerGroup> ListUsersPerGroup)
        {
            #region-הערה :מה שהיה קיים בעבר
            //AppUserPerGroup UPG;
            //var groupPerYearbook = _context.AppGroupPerYearbooks.FirstOrDefault(f => f.YearbookId == YearbookId && f.GroupId == Group.Idgroup);
            //var ListShiuch = _context.AppUserPerGroups.Where(w => w.GroupId == groupPerYearbook.IdgroupPerYearbook);
            ////var UPG = ListShiuch.FirstOrDefault(f => f.FromDate == FromDate && f.ToDate == ToDate&&f.UserId!=UserId);
            ////if(UPG!=null) UPG.UserId=UserId;
            //#region מחיקת השיוכים הנמצאים בתוך טווח התאריכים או שווים לטווח התאריכים של השיוך החדש
            //var ListUPG = ListShiuch.Where(w => w.FromDate >= FromDate && w.ToDate <= ToDate).ToList();
            //_context.AppUserPerGroups.RemoveRange(ListUPG);
            //#endregion
            //#region אחרת-אם קיים שיוך שהתאריך התחלה של השיוך החדש  בתוך השיוך הקיים והתאריך הסיום שלו אח"כ אז -עדכון התאריך סיום של הישן לתאריך התחלה של החדש.
            //UPG = ListShiuch.FirstOrDefault(f => f.FromDate < FromDate && f.ToDate < ToDate&&f.ToDate>FromDate);
            //if (UPG != null) UPG.ToDate = FromDate.AddDays(-1);
            //#endregion
            //#region	ואם קיים שיוך שהתאריך סיום שלו אחרי התאריך סיום של החדש והתאריך התחלה שלו לפני התאריך סיום של החדש מעדכנים את התאריך התחלה של הישן לפי התאריך סיום של החדש.
            //UPG = ListShiuch.FirstOrDefault(f => f.ToDate > ToDate && f.FromDate > FromDate&&f.FromDate<ToDate);
            //if (UPG != null) UPG.FromDate = ToDate.AddDays(1);
            //#endregion
            //#region  אם הטווח תאריכים של השיוך החדש נמצא בתוך שיוך קיים-השיוך שקיים מתחלק לשניים לפי תאריך התחלה וסיום של השיוך החדש
            //UPG = ListShiuch.FirstOrDefault(f => f.FromDate < FromDate && f.ToDate > ToDate);
            //if (UPG != null) { 
            //var newShiuch = new AppUserPerGroup() { GroupId = groupPerYearbook.IdgroupPerYearbook, UserId = UserId, FromDate = ToDate.AddDays(1), ToDate = ((DateTime)UPG.ToDate) };
            //_context.AppUserPerGroups.Add(newShiuch);
            //UPG.ToDate = FromDate.AddDays(-1);
            //}
            //#endregion
            ////הוספת השיוך
            //_context.AppUserPerGroups.Add(new AppUserPerGroup() { GroupId = groupPerYearbook.IdgroupPerYearbook, UserId = UserId, FromDate = FromDate, ToDate = ToDate });
            //_context.SaveChanges();
            //var gruop = _context.AppGroups.FirstOrDefault(f => f.Idgroup == Group.Idgroup);
            //return gruop;
            #endregion
            var ListUPG = _context.AppUserPerGroups.Where(w => w.GroupId == IdgroupPerYearbook);
            foreach (var item in ListUPG)
            {
                var upg = ListUsersPerGroup.FirstOrDefault(f => f.IduserPerGroup == item.IduserPerGroup);
                if (upg == null)
                    _context.Remove(item);
                else
                {
                    item.FromDate = upg.FromDate; item.ToDate = upg.ToDate; item.UserId = upg.User != null ? upg.User.IduserPerSchool : null; item.UserUpdatedId = UserUpdateId; item.DateUpdated = DateTime.Today;
                    item.Group = upg.Group;
                }
                ListUsersPerGroup.Remove(upg);
            }
            ListUsersPerGroup.ForEach(f =>
            {
                f.UserId = f.User != null ? f.User.IduserPerSchool : null;
                f.User = null;
                f.GroupId = IdgroupPerYearbook;
                f.UserCreatedId = UserUpdateId;
                f.DateCreated = DateTime.Today;
            });
            _context.AppUserPerGroups.AddRange(ListUsersPerGroup);
            _context.SaveChanges();
            return true;
        }

        //REAL edit group
        public AppGroup EditGroup2 (AppGroup group, int userUpdatedId)
        {
            AppGroup a = _context.AppGroups.Include(ag=>ag.AgeGroup).Include(tg=>tg.TypeGroup).FirstOrDefault(g => g.Idgroup == group.Idgroup);
            if (a!=null)
            {
                a.AgeGroupId = group.AgeGroupId;
               // a.DateCreated = group.DateCreated;
                a.DateUpdated = DateTime.Today;
              //  a.ExtensionId = group.ExtensionId;
               // a.ListeningTimeId = group.ListeningTimeId;
                a.NameGroup = group.NameGroup;
                a.TypeGroupId = group.TypeGroupId;
               // a.UserCreatedId = group.UserCreatedId;
                a.UserUpdatedId = userUpdatedId;
               // a.VoiceSpaceId = group.VoiceSpaceId;
                _context.SaveChanges();
                 a = _context.AppGroups.Include(ag => ag.AgeGroup).Include(tg => tg.TypeGroup).FirstOrDefault(g => g.Idgroup == group.Idgroup);
                return a;
            }
            return null;
        } 

        public AppGroupPerYearbook AddGroup(AppGroup Group, int UserCreatedId, int SchoolId, int YearbookId, int userId)
        {
            Group.SchoolId = SchoolId;
            Group.UserCreatedId = UserCreatedId;
            Group.DateCreated = DateTime.Today;
            _context.AppGroups.Add(Group);
            _context.SaveChanges();
            var group = new AppGroupPerYearbook() { GroupId = Group.Idgroup, YearbookId = YearbookId, UserCreatedId = UserCreatedId, DateCreated = DateTime.Today };
            _context.AppGroupPerYearbooks.Add(group);
            _context.SaveChanges();
            if (Group.CoordinationCode == null)
            {
                var g = _context.AppYearbookPerSchools.FirstOrDefault(f => f.IdyearbookPerSchool == YearbookId);
                _context.AppUserPerGroups.Add(new AppUserPerGroup() { GroupId = group.IdgroupPerYearbook, UserId = userId, FromDate = g != null ? g.FromDate : null, ToDate = g != null ? g.ToDate : null, UserCreatedId = UserCreatedId, DateCreated = DateTime.Today });
                _context.SaveChanges();
            }
            var gr = _context.AppGroupPerYearbooks.Include(y => y.Yearbook.Yearbook).Include(g => g.Group).ThenInclude(s => s.School).Include(g => g.Group.AgeGroup).Include(i => i.Group.TypeGroup)
                .FirstOrDefault(w => w.IdgroupPerYearbook == group.IdgroupPerYearbook);
            return gr;
        }

        


        public List<string> AddStudentInGroup(int GroupPerYearbookId, int StudentId, int YearbookId, string FromDate, string ToDate, int UserCreatedId)
        {
            var group = _context.AppGroupPerYearbooks.Include(g => g.Group).ThenInclude(t => t.TypeGroup).FirstOrDefault(f => f.IdgroupPerYearbook == GroupPerYearbookId);
            var g = group.Group;
            DateTime fromDate; DateTime toDate;

            //אם הטווח תאריכים הוא לפי הקבוצה
            if (FromDate == "null" && ToDate == "null")
            {
                var Yearbook = _context.AppYearbookPerSchools.FirstOrDefault(f => f.IdyearbookPerSchool == YearbookId);
                fromDate = (DateTime)Yearbook.FromDate; toDate = (DateTime)Yearbook.ToDate;
            }
            else
            {
                fromDate = DateTime.Parse(FromDate);
                toDate = DateTime.Parse(ToDate);
            }
            var ListSPG = _context.AppStudentPerGroups.Where(f => f.GroupId == group.IdgroupPerYearbook && f.StudentId == StudentId).ToList();
            if (ListSPG.FirstOrDefault(f => (f.FromDate <= fromDate && f.ToDate >= toDate) || (f.FromDate >= fromDate && f.ToDate <= toDate) || (f.FromDate >= fromDate && f.ToDate >= toDate && f.FromDate <= toDate) || (f.FromDate <= fromDate && f.ToDate <= toDate && f.ToDate >= fromDate)) != null)
                return new List<string>() { "0", "תלמיד זה משוייך לקבוצה שהזנת בתאריכים נפגשים" };
            if (g.TypeGroup.IsMultiple == true)
                _context.AppStudentPerGroups.Add(new AppStudentPerGroup() { StudentId = StudentId, GroupId = group.IdgroupPerYearbook, FromDate = fromDate, ToDate = toDate, UserCreatedId = UserCreatedId, DateCreated = DateTime.Today });
            else
            {
                var listSPGinCompatibleTypeGroup = _context.AppStudentPerGroups.Include(g => g.Group).ThenInclude(g => g.Group).ThenInclude(t => t.TypeGroup).Where(w => w.StudentId == StudentId && w.Group != null && w.Group.Group != null && w.Group.Group.TypeGroup != null && w.Group.Group.TypeGroup.IdtypeGroup == g.TypeGroupId);
                if (listSPGinCompatibleTypeGroup.FirstOrDefault(f => (f.FromDate <= fromDate && f.ToDate >= toDate) || (f.FromDate >= fromDate && f.ToDate <= toDate) || (f.FromDate >= fromDate && f.ToDate >= toDate && f.FromDate <= toDate) || (f.FromDate <= fromDate && f.ToDate <= toDate && f.ToDate >= fromDate)) != null)
                    return new List<string>() { "0", "תלמיד זה משוייך לקבוצה אחרת בתאריכים נפגשים" };
                else
                    _context.AppStudentPerGroups.Add(new AppStudentPerGroup() { StudentId = StudentId, GroupId = group.IdgroupPerYearbook, FromDate = fromDate, ToDate = toDate, UserCreatedId = UserCreatedId, DateCreated = DateTime.Today });

            }
            _context.SaveChanges();
            return new List<string>() { "1", "התלמיד נוסף בהצלחה" };
        }

        public AppGroupPerYearbook IsGroupHasTasks(int GroupPerYearbookId)
        {
            AppGroupPerYearbook appGroupPerYearbook = _context.AppGroupPerYearbooks.Include(i => i.AppGroupSemesterPerCourses).ThenInclude(i => i.AppTaskExsists)
                .Include(i => i.AppGroupSemesterPerCourses).ThenInclude(i => i.Course).FirstOrDefault(f => f.IdgroupPerYearbook == GroupPerYearbookId);
            return appGroupPerYearbook;
        }

        public List<AppGroup> GetAllNameGroup(int SchoolId)
        {
            return _context.AppGroups.Where(w => w.SchoolId == SchoolId).ToList();
        }

        public AppGroupPerYearbook AddGroupInYearbook(int UserId, int GroupId, int YearbookId, int UserCreatedId)
        {
            var group = new AppGroupPerYearbook() { YearbookId = YearbookId, GroupId = GroupId, UserCreatedId = UserCreatedId, DateCreated = DateTime.Today };
            if (_context.AppGroupPerYearbooks.FirstOrDefault(f => f.YearbookId == YearbookId && f.GroupId == GroupId) != null) return null;
            _context.AppGroupPerYearbooks.Add(group);
            _context.SaveChanges();
            var g = _context.AppYearbookPerSchools.FirstOrDefault(f => f.IdyearbookPerSchool == YearbookId);
            _context.AppUserPerGroups.Add(new AppUserPerGroup() { GroupId = group.IdgroupPerYearbook, UserId = UserId, FromDate = g != null ? g.FromDate : null, ToDate = g != null ? g.ToDate : null, UserCreatedId = UserCreatedId, DateCreated = DateTime.Today });
            _context.SaveChanges();
            group = _context.AppGroupPerYearbooks.Include(g => g.Group).ThenInclude(s => s.School).FirstOrDefault(f => f.IdgroupPerYearbook == group.IdgroupPerYearbook);
            return group;
        }

        //public bool AddStudentInGroup(int GroupId,int StudentId)
        //{
        //    var StudentPerGroup = new AppStudentPerGroup()
        //    {
        //        GroupId = GroupId, StudentId = StudentId, DateCreated = DateTime.UtcNow.AddHours(2)
        //    }
        //    _context.AppStudentPerGroups.Add()
        //}
        public List<AppUserPerGroup> GetUsersPerGroupByGroupId(int GroupId)
        {
            var result = _context.AppUserPerGroups.Include(u => u.User.User).Where(f => f.GroupId == GroupId).OrderBy(o => o.FromDate).ToList();
            return result;
        }
        public string GetNameGroupByGroupid(int groupId)
        {
            var x = _context.AppGroupPerYearbooks.FirstOrDefault(f => f.IdgroupPerYearbook == groupId);
            if (x != null && x.Group != null)
                return x.Group.NameGroup;
            else return "";
        }

        public AppStudentPerGroup DeleteStudentInGroup(int StudentId, int GroupId)
        {

            var StudentPerGroups = _context.AppStudentPerGroups.FirstOrDefault(f => f.StudentId == StudentId && f.GroupId == GroupId);
            var TasksToStudents = _context.AppTaskToStudents.Include(t => t.TaskExsist.Course).Where(f => f.TaskExsist != null && f.TaskExsist.Course != null && f.TaskExsist.Course.GroupId == StudentPerGroups.GroupId && f.StudentId == StudentPerGroups.StudentId);
            if (TasksToStudents.FirstOrDefault(f => f.Grade != null || f.FinalScore != null) != null) return null;

            if (StudentPerGroups != null)
            {
                _context.AppTaskToStudents.RemoveRange(TasksToStudents);
                _context.AppStudentPerGroups.Remove(StudentPerGroups);
                _context.SaveChanges();
            }
            else
                StudentPerGroups = new AppStudentPerGroup();
            return StudentPerGroups;
        }

        public List<string> EditStudentInGroup(AppStudentPerGroup StudentPerGroup, DateTime SPGFromDate, DateTime SPGToDate, int UserUpdateId)
        {
            StudentPerGroup = _context.AppStudentPerGroups.FirstOrDefault(f => f.IdstudentPerGroup == StudentPerGroup.IdstudentPerGroup);
            //var SPG = _context.AppStudentPerGroups.FirstOrDefault(f => f.IdstudentPerGroup == StudentPerGroup.IdstudentPerGroup);
            var ListSPG = _context.AppStudentPerGroups.Where(f => f.GroupId == StudentPerGroup.GroupId && f.StudentId == StudentPerGroup.StudentId && f.IdstudentPerGroup != StudentPerGroup.IdstudentPerGroup).ToList();
            if (ListSPG.FirstOrDefault(f => (f.FromDate <= SPGFromDate && f.ToDate >= SPGToDate) || (f.FromDate >= SPGFromDate && f.ToDate <= SPGToDate) || (f.FromDate >= SPGFromDate && f.ToDate >= SPGToDate && f.FromDate <= SPGToDate) || (f.FromDate <= SPGFromDate && f.ToDate <= SPGToDate && f.ToDate >= SPGFromDate)) != null)
                return new List<string>() { "0", "תלמיד זה משוייך לקבוצה שהזנת בתאריכים נפגשים" };
            var group = _context.AppGroupPerYearbooks.Include(g => g.Group).ThenInclude(t => t.TypeGroup).FirstOrDefault(f => f.IdgroupPerYearbook == StudentPerGroup.GroupId);
            var g = group.Group;
            if (g.TypeGroup.IsMultiple == true)
            {
                StudentPerGroup.FromDate = SPGFromDate;
                StudentPerGroup.ToDate = SPGToDate;
                StudentPerGroup.UserUpdatedId = UserUpdateId;
                StudentPerGroup.DateUpdated = DateTime.Today;
            }
            else
            {
                var listSPGinCompatibleTypeGroup = _context.AppStudentPerGroups.Include(g => g.Group).ThenInclude(g => g.Group).ThenInclude(t => t.TypeGroup).Where(w => w.StudentId == StudentPerGroup.StudentId && w.Group != null && w.Group.Group != null && w.Group.Group.TypeGroup != null && w.Group.Group.TypeGroup.IdtypeGroup == g.TypeGroupId && w.IdstudentPerGroup != StudentPerGroup.IdstudentPerGroup);
                if (listSPGinCompatibleTypeGroup.FirstOrDefault(f => (f.FromDate <= SPGFromDate && f.ToDate >= SPGToDate) || (f.FromDate >= SPGFromDate && f.ToDate <= SPGToDate) || (f.FromDate >= SPGFromDate && f.ToDate >= SPGToDate && f.FromDate <= SPGToDate) || (f.FromDate <= SPGFromDate && f.ToDate <= SPGToDate && f.ToDate >= SPGFromDate)) != null)
                    return new List<string>() { "0", "תלמיד זה משוייך לקבוצה אחרת בתאריכים נפגשים" };
                else
                {
                    StudentPerGroup.FromDate = SPGFromDate;
                    StudentPerGroup.ToDate = SPGToDate;
                    StudentPerGroup.UserUpdatedId = UserUpdateId;
                    StudentPerGroup.DateUpdated = DateTime.Today;
                }

            }
            _context.SaveChanges();
            return new List<string>() { "1", "טווח התאריכים של התלמיד בקבוצה זו עודכן בהצלחה" };
        }

        public AppGroupPerYearbook GetGroupByCourseID(int courseId)
        {
            AppGroupPerYearbook appGroupPerYearbook= _context.AppGroupSemesterPerCourses.Include(i=> i.Group).FirstOrDefault(f => f.IdgroupSemesterPerCourse == courseId)?.Group;
            return appGroupPerYearbook;
        }
    
         
    
    }
}
