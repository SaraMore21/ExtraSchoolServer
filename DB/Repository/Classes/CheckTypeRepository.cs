using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Model;
using DB.Repository.Interfaces;

namespace DB.Repository.Classes
{
    public class CheckTypeRepository:ICheckTypeRepository
    {
        
        private readonly ExtraSchoolContext _context;

        public CheckTypeRepository(ExtraSchoolContext context)
        {
            _context = context;
        }

        public List<TCheckType> GetAll()
        {
            return _context.TCheckTypes.ToList();
        }

      
    }

}
