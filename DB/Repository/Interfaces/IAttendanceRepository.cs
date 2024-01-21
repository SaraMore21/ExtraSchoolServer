using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.Interfaces
{
    public interface IAttendanceRepository
    {
        bool GetDailyAttendanceForGroup(int groupId, DateTime date);
    }
}
