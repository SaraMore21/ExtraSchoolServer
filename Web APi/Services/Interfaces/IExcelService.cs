using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IExcelService
    {
        bool ReadFewSheetsFromExcel(string path, int schoolId, int userId, List<string> tablesToRead, DateTime StartDate, DateTime EndDate, int idyearbookPerSchool, bool isNew, bool IsOverride);

        //Task<bool> ReadFewSheetsFromExcel(string path, int schoolId, int userId, List<string> tablesToRead, DateTime? from, DateTime? to, int groupId, int idyearbookPerSchool);
        void ExportExcelFile(int schoolId);
         byte[] downloadFatherCourseExcel(string idschool);
         byte[] downloadCourseExcel(string idschool, int idYearbook);
    }
}
