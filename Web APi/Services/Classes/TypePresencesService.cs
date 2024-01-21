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
    class TypePresencesService: ITypePresencesService
    {
        private readonly ITypePresenceRepository _TypePresenceRepository;
        private readonly IMapper _mapper;

        public TypePresencesService(ITypePresenceRepository TypePresenceRepository, IMapper mapper)
        {
            _TypePresenceRepository = TypePresenceRepository;
            _mapper = mapper;
        }

        //public List<TTypePresenceDTO> GetAllPresence()
        //{
        //    return _mapper.Map<List<TTypePresenceDTO>>(_TypePresenceRepository.GetAllPresence());
        //}
    }
}
