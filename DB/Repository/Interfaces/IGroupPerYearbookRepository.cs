using DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.Interfaces
{
    public interface IGroupPerYearbookRepository
    {
        bool AddListGroupsPerYearbook(List<AppGroupPerYearbook> groupsPerYearbook);

        List<AppGroupPerYearbook> GetLstGroupPerYearBookBySchoolId(int idSchool);

        AppYearbookPerSchool GetYearBookByGRoupPerYerBookId(int IdGroupPerYearBook);

        Dictionary<int, bool?> GetDictGroupPerYearBookIsMultipleBySchoolId(int schoolId);
    }
}
