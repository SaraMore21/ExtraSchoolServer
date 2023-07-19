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
    public class CoordinationService: ICoordinationService
    {
        private readonly ICoordinationRepository _coordinationRepository;
        private readonly IMapper _Mapper;

        public CoordinationService(ICoordinationRepository coordinationRepository,IMapper mapper)
        {
            _coordinationRepository = coordinationRepository;
            _Mapper = mapper;
        }

        public List<AppCoordinationDTO> GetAllCoordinationsByListSchoolId(List<int> schoolId)
        {
            return _Mapper.Map<List<AppCoordinationDTO>>(_coordinationRepository.GetAllCoordinationsByListSchoolId(schoolId));
        }

        public AppCoordinationDTO GetCoordinationByCoordinationTypeId(int coordinationTypeId)
        {
          return _Mapper.Map<AppCoordinationDTO>( _coordinationRepository.GetCoordinationByCoordinationTypeId(coordinationTypeId));
        }

        public List<int> GetAllPrimaryKeyGenericTypeByCoordinationId(int coordinationId, string tableName)
        {
            return _coordinationRepository.GetAllPrimaryKeyGenericTypeByCoordinationId(coordinationId, tableName);
        }
    }
}
