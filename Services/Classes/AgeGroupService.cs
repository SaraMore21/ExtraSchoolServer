using AutoMapper;
using DB.Repository.Interfaces;
using DTO.Classes;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Classes
{
    public class AgeGroupService : IAgeGroupService
    {
        private readonly IAgeGroupRepository _ageGroupRepository;
        private readonly IMapper _mapper;
        public AgeGroupService(IMapper mapper,IAgeGroupRepository ageGroupRepository)
        {
            _ageGroupRepository = ageGroupRepository;
            _mapper = mapper;
        }

        public List<string> GetAllNameAgeGroupsByCoordinationCode(string coordinationCode)
        {
            return _ageGroupRepository.GetAllNameAgeGroupsByCoordinationCode(coordinationCode);
        }

        //שליפת שכבת גיל למוסדות
        public List<TabAgeGroupDTO> GetAllAgeGroupsBySchools(string Schools)
        {
            return _mapper.Map<List<TabAgeGroupDTO>>(_ageGroupRepository.GetAllAgeGroupsBySchools(Schools));
        }
    }
}
