using DB.Model;
using DB.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.Classes
{
    public class TypeTaskRepository : ITypeTaskRepository
    {
        private readonly ExtraSchoolContext _context;

        public TypeTaskRepository(ExtraSchoolContext context)
        {
            _context = context;
        }

        public List<TabTypeTask> GetLstTypeTaskByIdSchool(int idSchool)
        {
            return _context.TabTypeTasks/*.Where(w => w.SchoolId == idSchool)*/.ToList();
        }
    }
}
