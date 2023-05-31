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
    public class TypeContactService : ITypeContactService
    {
           private readonly ITypeContactRepository _TypeContactRepository;
           private readonly IMapper _mapper;

        public TypeContactService(ITypeContactRepository TypeContactRepository, IMapper mapper)
        {
            _TypeContactRepository = TypeContactRepository ;
            _mapper = mapper;
        }
        public List<TTypeContactDTO> GetTypeContactBySchoolID(int SchoolId)
        {
            var x = _mapper.Map<List<TTypeContactDTO>>(_TypeContactRepository.GetTypeContactBySchoolID(SchoolId));
            return x;
        }
    }
}
