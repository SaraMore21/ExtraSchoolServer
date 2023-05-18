using DB.Model;
using DB.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.Classes
{
    class TypePresenceRepository: ITypePresenceRepository
    {
        private readonly ExtraSchoolContext _context;

        public TypePresenceRepository(ExtraSchoolContext context)
        {
            _context = context;
        }
        public List<TTypePresence> GetAllPresence()
        {
            return _context.TTypePresences.ToList();
        }

    }
}
