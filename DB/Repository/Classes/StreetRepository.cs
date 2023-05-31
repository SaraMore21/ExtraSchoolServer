using DB.Model;
using DB.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.Classes
{
    public class StreetRepository : IStreetRepository
    {
        private readonly ExtraSchoolContext _context;
        public StreetRepository(ExtraSchoolContext context)
        {
            _context = context;
        }

        public List<TabStreet> GetStreetsByCityId(int CityId)
        {
            return _context.TabStreets.Where(w => w.CityId == CityId).ToList();
        }
    }
}
