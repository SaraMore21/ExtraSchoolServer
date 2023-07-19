using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Classes;

namespace Services.Interfaces
{
    public interface ICoordinationService
    {
        public AppCoordinationDTO GetCoordinationByCoordinationTypeId(int coordinationTypeId);
        public List<AppCoordinationDTO> GetAllCoordinationsByListSchoolId(List<int> schoolId);
        public List<int> GetAllPrimaryKeyGenericTypeByCoordinationId(int coordinationId, string tableName);
    }
}
