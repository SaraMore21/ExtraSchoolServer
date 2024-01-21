using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Model;
using DB.Repository.Interfaces;

namespace DB.Repository.Classes
{
    public class AttendanceMarkingRepository : IAttendanceMarkingRepository
    {
        private readonly ExtraSchoolContext _context;

        public AttendanceMarkingRepository(ExtraSchoolContext context)
        {
            _context = context;
        }
        public List<TabAttendanceMarking> GetAllPresence()
        {
            return _context.TabAttendanceMarkings.ToList();
        }

    }
}
