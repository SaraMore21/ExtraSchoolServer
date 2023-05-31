using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IAttendanceService
    {
        bool GetDailyAttendanceForGroup(int groupId, DateTime date);
    }
}
