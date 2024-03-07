using DB.Model;
using DB.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.Classes
{
    public class TypeGroupRepository : ITypeGroupRepository
    {
        public readonly ExtraSchoolContext _context;
        public TypeGroupRepository(ExtraSchoolContext context)
        {
            _context = context;
        }
        public List<TabTypeGroup> GetLstTypeGroupByIdSchool(int idSchool)
        {
            try
            {
                return _context.TabTypeGroups.Where(w => w.SchoolId == idSchool).ToList();
            }
            catch (Exception)
            {
                return null;
            }      
        }
    }
}
