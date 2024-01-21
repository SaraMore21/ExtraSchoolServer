using DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.Interfaces
{
    public interface IStudentPerGroupRepository
    {
         bool AddLstStudentPerGRoup(List<AppStudentPerGroup> lst);

         List<AppStudentPerGroup> GetLstUserPerGroupBySchoolId(int schoolId);

        bool CheckIfCanAddUserPerGroup(int? studentId, int? groupId, DateTime fromDate, DateTime ToDate);
        AppStudentPerGroup GetStudentPerGroupById(int StudentPerGroupId);
    }
}
