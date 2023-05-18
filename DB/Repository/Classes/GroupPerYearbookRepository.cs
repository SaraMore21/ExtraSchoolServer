using DB.Model;
using DB.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.Classes
{
    public class GroupPerYearbookRepository : IGroupPerYearbookRepository
    {
        private readonly ExtraSchoolContext _context;

        public GroupPerYearbookRepository(ExtraSchoolContext context)
        {
            _context = context;
        }

        public bool AddListGroupsPerYearbook(List<AppGroupPerYearbook> groupsPerYearbook)
        {
            try
            {
                _context.AppGroupPerYearbooks.AddRange(groupsPerYearbook);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }

        public Dictionary<int, bool?> GetDictGroupPerYearBookIsMultipleBySchoolId(int schoolId)
        {
            var x = _context.AppGroupPerYearbooks.Include(i => i.Group.TypeGroup).Where(w => w.Group.SchoolId == schoolId).ToList();
            Dictionary<int, bool?> dict = new Dictionary<int, bool?>();
            x.ForEach(f =>
               {
                   if (f.Group != null && f.Group.TypeGroup != null && f.Group.TypeGroup.IsMultiple != null)
                       dict.Add(f.IdgroupPerYearbook, (bool)f.Group.TypeGroup.IsMultiple);
               }
            );
            return dict;
        }

        public List<AppGroupPerYearbook> GetLstGroupPerYearBookBySchoolId(int idSchool)
        {
            try
            {
                return _context.AppGroupPerYearbooks.Where(w => w.Group.SchoolId == idSchool).ToList();

            }
            catch (Exception e)
            {

                return null;
            }
        }

        public AppYearbookPerSchool GetYearBookByGRoupPerYerBookId(int IdGroupPerYearBook)
        {
            return _context.AppGroupPerYearbooks.Include(i=>i.Yearbook).FirstOrDefault(f => f.IdgroupPerYearbook == IdGroupPerYearBook)?.Yearbook;
        }
    }
}
