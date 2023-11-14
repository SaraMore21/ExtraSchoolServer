using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Model;
using DB.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DB.Repository.Classes
{
    public class SchoolRepository : ISchoolRepository
    {
        //private readonly ExtraSchoolContext _context;

        private readonly ExtraSchoolContext _context;

        public SchoolRepository(ExtraSchoolContext context) => _context = context;

        public  AppSchool GetSchoolBySchoolId(int SchoolId)
        {
            try
            {
                return  _context.AppSchools.Include(i=>i.ContactInformation).Include(i=> i.UserContact.ContactInformation).FirstOrDefault(w => w.Idschool == SchoolId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

   
        //שליפת סיסמא ע"פ שם משתמש
        public List<AppUserPerSchool> GetPasswordByUserCode(string UserCode)
        {
            try
            {
                var u = _context.AppUserPerSchools.Include(u => u.User).Include(c=>c.ContactInformation).Where(f =>f.User.UserCode == UserCode).ToList();
                //var u = _context.AppUserPerSchools.Include(u =>u.User).Include(c=>c.ContactInformation).FirstOrDefault(f => f.SchoolId == SchoolId && f.User.UserCode == UserCode);
                //var user = _context.SecUsers.Include(u=>u.AppUserPerSchoolUsers).ThenInclude(c=>c.ContactInformation).FirstOrDefault(f => f.UserCode == UserCode);
                return u;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //שליפת מוסדות המקושרים למשתמש
        public List<AppSchool> GetSchoolByUserId(int UserId)
        {
            return _context.AppUserPerSchools.Include(s => s.School).Where(w => w.UserId == UserId).Select(s => s.School).ToList();
        }
        //שליפת משתמש ע"פ שם משתמש וסיסמא
        public AppUserPerSchool GetUserIDByUserCodeAndPassword(string UserCode, string UserPassword)
        {
            var user = _context.AppUserPerSchools.Include(u=>u.User).FirstOrDefault(f => f.User.UserCode == UserCode && f.User.UserPassword == UserPassword);
            //return user != null && user.User!=null ? user.User.Iduser : 0;
            return user ;
        }

        public List<VCodeTable> GetAllTable()
        {
            return _context.VCodeTables.Select(x => x).ToList();

        }

        public List<AppYearbookPerSchool> GetAllYearbook(int SchoolId)
        {
           return _context.AppYearbookPerSchools.Where(w => w.SchoolId == SchoolId).ToList();
        }

        public AppYearbookPerSchool AddYearbook(DateTime FromDate, DateTime ToDate, string Name, int UserCreatedId,int SchoolId)
        {
            var Yearbook = new AppYearbookPerSchool() {SchoolId=SchoolId,FromDate=FromDate,ToDate=ToDate,Name=Name,UserCreatedId=UserCreatedId,DateCreated=DateTime.Today };
            _context.AppYearbookPerSchools.Add(Yearbook);
            _context.SaveChanges();
            return Yearbook;
        }

        public List<AppUserPerSchool> GetAllSchoolAndYearbookPerCustomer(SecUser User)
        {
            //var user = _context.AppUserPerSchools.Include(l=>l.AppUserPerCustomerUsers).Include(u => u.User).FirstOrDefault(f => f.User.UserCode == UserCode && f.User.UserPassword == UserPassword);
            //if (user == null)
            //    return null;//לא קיים משתמש עם הנתונים שהזנת.
            //else
            //if (user.AppUserPerCustomerUsers.Count() == 0)
            //    return null;//משתמש זה אינו מוגדר כלקוח
            //else
            //{ }
            var c= _context.AppUserPerCustomers.Include(c=>c.Customer).Include(u=>u.User).FirstOrDefault(f => f.UserId == User.Iduser).Customer;
            if (c == null) return null;
            return _context.AppUserPerSchools.Include(s=>s.School).ThenInclude(y=>y.AppYearbookPerSchools).Where(w => w.School.CustomerId == c.Idcustomer&&w.UserId==User.Iduser).ToList();
                //var School = _context.AppSchools.Include(y=>y.AppYearbookPerSchools).Where(w => w.CustomerId == User.AppUserPerCustomerUsers.First().CustomerId).ToList();
           
           // return School;
        }
        public  List<AppUserPerSchool> GetAllSchoolAndYearbookPerUser(SecUser User)
        {
            var a = _context.AppUserPerSchools.Include(s => s.School).ThenInclude(y => y.AppYearbookPerSchools).Where(w => w.UserId == User.Iduser).ToList();
           //return a.Select(s=>s.School).ToList();
            return a;
        }

        public SecUser GetUserToCustomerByUserCodeAndUserPassword(string UserCode, string UserPassword)
        {
            //var user = _context.AppUserPerSchools.Include(l => l.AppUserPerCustomerUsers).Include(u => u.User).FirstOrDefault(f => f.User.UserCode == UserCode && f.User.UserPassword == UserPassword);
            //return user;
            return _context.SecUsers.Include(u=>u.AppUserPerCustomer).FirstOrDefault(f => f.UserCode == UserCode && f.UserPassword == UserPassword);
        }

        public List<AppYearbook> GetAllYearbook()
        {
           return _context.AppYearbooks.ToList();
        }

        public List<int> GetSchoolIdsByCoordinationId(string coordinationId)
        {/*😀😀😀😀😀*/
            //var listSchool= _context.AppSchools.Where(s => s.CoordinationCode == coordinationId).ToList();
            //List<int> listIdSchools = new List<int>();
            //listSchool.ForEach(s =>listIdSchools.Add(s.Idschool));
            //return listIdSchools;
            return null;
        }

       // YearBookId//לפי// yearbookIdPerSchooll//שליפת
        public int GetSchoolIdYearbookPerSchoollByYearBookId(int schoolId, int YearbookId)
        {
            return _context.AppYearbookPerSchools.FirstOrDefault(s => s.SchoolId==schoolId && s.YearbookId == YearbookId).IdyearbookPerSchool;
        }

        public List<TLearningStyle> GetAllLearningStyles()
        {
            return _context.TLearningStyles.ToList();
        }
    }
}
