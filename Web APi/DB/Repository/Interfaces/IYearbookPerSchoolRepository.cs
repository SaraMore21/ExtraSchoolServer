using DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.Interfaces
{
    public interface IYearbookPerSchoolRepository
    {
        List<AppYearbookPerSchool> GetYearbookPerSchool(int schoolId);

        AppYearbookPerSchool GetYearBookById(int idYearBook);
        int GetYearbookPerSchoolIdByYearbookIdSchoolId(int idYearbook, int idschool);
    }
}
