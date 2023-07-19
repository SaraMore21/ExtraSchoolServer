using DB.Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Classes
{
    public class AttendanceService: IAttendanceService
    {
        private readonly IAttendanceRepository _attendanceRepository;
        public AttendanceService(IAttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        public bool GetDailyAttendanceForGroup(int groupId, DateTime date)
        {
          return _attendanceRepository.GetDailyAttendanceForGroup(groupId, date);
        }
    }
}
