using DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.Interfaces
{
    public interface IAgeGroupRepository
    {
        List<TabAgeGroup> GetLstAgeGroupBySchoolId(int schoolId);
        List<TabAgeGroup> GetAllAgeGroupsBySchools(string Schools);
        List<String> GetAllNameAgeGroupsByCoordinationCode(string coordinationCode);
        TabAgeGroup GetAgeGroupByCoordinationCodeAndSchoolIdAndName(int schoolId, string coordinationCode, string name);

    }
}
