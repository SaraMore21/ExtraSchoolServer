using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DTO.Classes;
using Services.Interfaces;
using DB.Model;
using DB.Repository.Interfaces;

namespace Services.Classes
{
   public class StatusTaskPerformanceService:IStatusTaskPerformanceService
    {
        private readonly IStatusTaskPerformanceRepository _StatusTaskPerformanceRepository;
        private readonly IMapper _mapper;

        public StatusTaskPerformanceService(IStatusTaskPerformanceRepository StatusTaskPerformanceRepository, IMapper mapper)
        {
            _StatusTaskPerformanceRepository = StatusTaskPerformanceRepository;
            _mapper = mapper;
        }






        public List<TStatusTaskPerformanceDTO> GetAllStatusTaskPerformanceBySchoolId(int schoolId)
        {
            return _mapper.Map<List<TStatusTaskPerformanceDTO>>(_StatusTaskPerformanceRepository.GetAllStatusTaskPerformanceBySchoolId(schoolId));
        }
    }

}

