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
    public class StreetService : IStreetService
    {
        private IStreetRepository _streetRepository;
        private IMapper _mapper;
        public StreetService(IStreetRepository streetRepository,IMapper mapper)
        {
            _streetRepository = streetRepository;
            _mapper = mapper;
        }
        public List<TAB_StreetDTO> GetStreetsByCityId(int CityId)
        {
           return _mapper.Map<List<TAB_StreetDTO>>(_streetRepository.GetStreetsByCityId(CityId));
        }
    }
}
