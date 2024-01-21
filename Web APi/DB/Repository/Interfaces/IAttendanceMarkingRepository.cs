using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Model;

namespace DB.Repository.Interfaces
{
    public interface IAttendanceMarkingRepository
    {
        List<TabAttendanceMarking> GetAllPresence();
    }
}
