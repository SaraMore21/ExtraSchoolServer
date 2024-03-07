using DB.Model;
using DB.Repository.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.Interfaces
{
    public interface IPresenceRepository
    {
        public List<Lesson> GetLessonsByDate(DateTime date, int idGroup);
        public AppPresence GetPresenceByStudentIdAndSchedualId(int studentId, int schedualId);
        public List<AppPresence> addOrUpdateAttendance(string date, int userId, List<AppPresence> Attendence,List<int> listdaily);
         public List<PresencePerDay> GetPresenceByDay(DateTime date, int idGroup);
        public List<PresencePerDay> GetPresenceByRangeDateAndGroup(DateTime fromdate, DateTime todate, int idGroup);
        public List<PresencePerDay> GetPresenceByRangeDateToAllGroupByschool(DateTime fromdate, DateTime todate, int schoolid);
        // public List<AttendencePerDay> GetNochectByDateIdgroup(DateTime date, int idGroup, List<Lesson> lessons);
    }
}
