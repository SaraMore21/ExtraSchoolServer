using DB.Model;
using DB.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.Classes
{
    public class YearbookPerSchoolRepository : IYearbookPerSchoolRepository
    {
        private readonly ExtraSchoolContext _context;

        public YearbookPerSchoolRepository(ExtraSchoolContext context)
        {
            _context = context;
        }

        public AppYearbookPerSchool GetYearBookById(int idYearBook)
        {
            return _context.AppYearbookPerSchools.FirstOrDefault(f => f.IdyearbookPerSchool == idYearBook);
        }

        public List<AppYearbookPerSchool> GetYearbookPerSchool(int schoolId)
        {
            return _context.AppYearbookPerSchools.Where(w => w.SchoolId == schoolId).ToList();
        }

        public int GetYearbookPerSchoolIdByYearbookIdSchoolId(int idschool, int idYearbook)
        {
            var a= _context.AppYearbookPerSchools.FirstOrDefault(w => w.SchoolId == idschool && w.YearbookId==idYearbook);
            if (a != null)
              return  a.IdyearbookPerSchool;
            return -1;
        }
    }
}
