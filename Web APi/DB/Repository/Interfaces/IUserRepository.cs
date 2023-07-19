using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Model;
using DB.Repository.Classes;

namespace DB.Repository.Interfaces
{
    public interface IUserRepository
    {
        List<AppUserPerSchool> GetUsersBySchoolIDAndYearbookId(string SchoolsId, int yearbookId);
        List<AppUserPerSchool> GetAllUserBySchoolId(int SchoolId);
        AppUserPerSchool GetUserDetailsByIDUser(int UserID,int SchoolId);
        Tuple<AppUserPerSchool, string, string> AddUser( AppUserPerSchool UserPerSchool, int UserCreatedId, int SchoolId, int yearbookId);
        AppUserPerSchool UpdateUser(AppUserPerSchool u, int userId, int iduserPerSchool=0 , bool isExcel = false);
        int DeleteUser(int UserId, int SchoolId);
        Tuple<Dictionary<int, int>, List<AppUserPerSchool>,int> AddUserByCustomer(int UserId, List<SchoolWithYearBookAndUserPerSchool> schools, int customerId);
        Tuple<AppUserPerSchool,int, bool> AddCopyUserPerSchool(AppUserPerSchool userPerSchool, AppSchool School, int CoustomerId, int? UserCreatedId, int YearbookId);
        SecUser IsUserExsist(string tz, int schoolId);
        int IsUserExsistinSchool(string tz, int schoolId);
        List<AppUserPerSchool> GetListUserDetailsByIDUser(int[][] luser);
    }
}
