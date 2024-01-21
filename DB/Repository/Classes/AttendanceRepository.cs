using DB.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.Classes
{
    public class AttendanceRepository: IAttendanceRepository
    {
        public bool GetDailyAttendanceForGroup(int groupId, DateTime date)
        {
            return true;
        }
    }
}
