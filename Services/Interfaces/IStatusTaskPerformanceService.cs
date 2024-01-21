using DTO.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IStatusTaskPerformanceService
    {
        public List<TStatusTaskPerformanceDTO> GetAllStatusTaskPerformanceBySchoolId(int schoolId);
    }
}
