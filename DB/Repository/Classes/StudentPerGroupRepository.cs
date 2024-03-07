using DB.Model;
using DB.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.Classes
{
    public class StudentPerGroupRepository : IStudentPerGroupRepository
    {
        public readonly ExtraSchoolContext _context;

        public StudentPerGroupRepository(ExtraSchoolContext context)
        {
            _context = context;
        }

        public bool AddLstStudentPerGRoup(List<AppStudentPerGroup> lst)
        {
            try
            {
                _context.AppStudentPerGroups.AddRange(lst);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }

        //בדיקה האם ניתן לשייך תלמידה לקבוצה שהיא לא מאופשרת להיות מרובת שיוכים
        //כלומר אם לא קיים לה כבר שיוך לסוג קבוצה זו.
        public bool CheckIfCanAddUserPerGroup(int? studentId, int? groupId, DateTime fromDate, DateTime ToDate)
        {
            try
            {
                var x = _context.AppStudentPerGroups.Where(w => w.StudentId == studentId && ((w.FromDate <= fromDate && w.ToDate >= fromDate) || (w.ToDate >= ToDate && w.FromDate < ToDate) || (w.FromDate >= fromDate && w.ToDate <= ToDate)))
                .Select(g => g.Group.Group.TypeGroupId).ToList();
                var typeGroup = _context.AppGroupPerYearbooks.FirstOrDefault(f => f.IdgroupPerYearbook == groupId)?.Group?.TypeGroupId;
                for (int i = 0; i < x.Count; i++)
                {

                    if (x[i] == typeGroup)
                        return false;
                }

                return true;
            }
            catch (Exception e)
            {

                return false;
            }

        }


        public List<AppStudentPerGroup> GetLstUserPerGroupBySchoolId(int schoolId)
        {
            return _context.AppStudentPerGroups.Where(w => w.Student.SchoolId == schoolId).ToList();
        }
        public AppStudentPerGroup GetStudentPerGroupById(int StudentPerGroupId)
        {
            return _context.AppStudentPerGroups.FirstOrDefault(f => f.IdstudentPerGroup == StudentPerGroupId);
        }


    }
}
