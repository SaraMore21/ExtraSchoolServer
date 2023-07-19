using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Model;

namespace DB.Repository.Interfaces
{
    public interface ICoordinationRepository
    {
        AppCoordination GetCoordinationByCoordinationTypeId(int coordinationId);
        List<AppCoordination> GetAllCoordinationsByListSchoolId(List<int> schoolId);
        AppCoordinationType AddCoordinationType(AppCoordinationType coordinationType);
        List<AppSchool> getAllSchoolsByCoordinationId(int coordinationId);
        int getIdCoordinationPerSchoolByCoordinationIdAndSchoolId(int coordinationId, int schoolId);
        List<int> GetAllPrimaryKeyGenericTypeByCoordinationId(int coordinationId, string tableName);

    }
}
