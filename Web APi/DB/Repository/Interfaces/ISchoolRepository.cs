using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Model;

namespace DB.Repository.Interfaces
{
    public interface ISchoolRepository
    {
         AppSchool GetSchoolBySchoolId(int SchoolId);
        //שליפת סיסמא ע"פ שם משתמש
        public List<AppUserPerSchool> GetPasswordByUserCode(string UserCode);
        //public List<AppSchool> GetSchoolByUserCodeAndPassword(string UserCode, string UserPassword);
        public AppUserPerSchool GetUserIDByUserCodeAndPassword(string UserCode, string UserPassword);
        public List<AppSchool> GetSchoolByUserId(int UserId);
        List<VCodeTable> GetAllTable();
        List<AppYearbookPerSchool> GetAllYearbook(int SchoolId);
        AppYearbookPerSchool AddYearbook(DateTime FromDate, DateTime ToDate, string Name, int UserCreatedId,int SchoolId);
        List<AppUserPerSchool> GetAllSchoolAndYearbookPerCustomer(SecUser User);
        SecUser GetUserToCustomerByUserCodeAndUserPassword(string UserCode, string UserPassword);
        List<AppYearbook> GetAllYearbook();
        List<AppUserPerSchool> GetAllSchoolAndYearbookPerUser(SecUser User);
        List<int> GetSchoolIdsByCoordinationId(string coordinationId);
        int GetSchoolIdYearbookPerSchoollByYearBookId(int schoolId, int YearbookId);
        public List<TLearningStyle> GetAllLearningStyles();

    }
}
