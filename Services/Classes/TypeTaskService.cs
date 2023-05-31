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
    public class TypeTaskService : ITypeTaskService
    {
        private readonly ITypeTaskRepository _TypeTaskRepository;
        private readonly IMapper _mapper;

        public TypeTaskService(ITypeTaskRepository TypeTaskRepository,IMapper mapper)
        {
            _TypeTaskRepository = TypeTaskRepository;
            _mapper = mapper;
        }

        public List<TabTypeTaskDTO> GetTypeTaskBySchoolId(int schoolId)
        {
            return _mapper.Map<List<TabTypeTaskDTO>>(_TypeTaskRepository.GetLstTypeTaskByIdSchool(schoolId));
        }
    }
}
