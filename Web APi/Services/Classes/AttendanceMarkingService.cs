using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DB.Repository.Interfaces;
using DTO.Classes;
using Services.Interfaces;


namespace Services.Classes
{
    class AttendanceMarkingService:IAttendanceMarkingService
    {
        private readonly IAttendanceMarkingRepository _AttendanceMarkingRepository;
        private readonly IMapper _mapper;

        public AttendanceMarkingService(IAttendanceMarkingRepository AttendanceMarkingRepository, IMapper mapper)
        {
            _AttendanceMarkingRepository = AttendanceMarkingRepository;
            _mapper = mapper;
        }

        public List<TabAttendanceMarkingDTO> GetAllPresence()
        {
            return _mapper.Map<List<TabAttendanceMarkingDTO>>(_AttendanceMarkingRepository.GetAllPresence());
        }
    }
}

