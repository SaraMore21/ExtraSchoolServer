using DB.Model;
using DB.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repository.Classes
{
   public class StatusTaskPerformanceRepository: IStatusTaskPerformanceRepository
    {
        private readonly ExtraSchoolContext _context;

        public StatusTaskPerformanceRepository(ExtraSchoolContext context)
        {
            _context = context;
        }

        public List<TStatusTaskPerformance> GetAllStatusTaskPerformanceBySchoolId(int schoollId)
        {
    
            return _context.TStatusTaskPerformances.Where(s => s.MosadId == schoollId).ToList();

        }
    
    }
}
