using DTO.Classes;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DB.Repository.Interfaces;


namespace Services.Classes
{
    class CheckTypeService : ICheckTypeService
    {
        private readonly ICheckTypeRepository _CheckTypeRepository;
        private readonly IMapper _mapper;

        public CheckTypeService(ICheckTypeRepository CheckTypeRepository, IMapper mapper)
        {
            _CheckTypeRepository = CheckTypeRepository;
            _mapper = mapper;
        }

        public List<TCheckTypeDTO> GetAll()
        {
            return _mapper.Map<List<TCheckTypeDTO>>(_CheckTypeRepository.GetAll());
        }

    }
}

