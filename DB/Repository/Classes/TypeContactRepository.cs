using DB.Model;
using DB.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.Classes
{
    public class TypeContactRepository : ITypeContactRepository
    {
        public readonly ExtraSchoolContext _context;
        public TypeContactRepository(ExtraSchoolContext context)
        {
            _context = context;
        }

        public List<TTypeContact> GetTypeContactBySchoolID(int SchoolId)
        {
           var contactTypeList = _context.TTypeContacts.Where(w => w.SchoolId == SchoolId).ToList();
            return contactTypeList;
        }
    }
}
