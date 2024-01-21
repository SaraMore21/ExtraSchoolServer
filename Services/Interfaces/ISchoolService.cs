using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Classes;

namespace Services.Interfaces
{
    public interface ISchoolService
    {
        //  public  AppSchoolDTO GetSchoolById(int schoolId);
        public List<string> GetPasswordToEmailByUserCode(string UserCode,string Email);
        public ReturnObjectSchoolAndYearbookDTO GetSchoolByUserCodeAndPassword(string UserCode, string UserPassword);
        public AppSchoolDTO GetSchoolById(int schoolId);
        public List<ListCodeTable> GetAllTable();
        public List<AppYearbookPerSchoolDTO> GetAllYearbook(int SchoolId);
        public AppYearbookPerSchoolDTO AddYearbook(DateTime FromDate, DateTime ToDate, string Name, int UserCreatedId,int SchoolId);
        public ReturnObjectSchoolAndYearbookDTO GetAllSchoolAndYearbookPerCustomer(string UserCode,string UserPassword);



             
    }
}
