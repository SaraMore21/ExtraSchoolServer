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
    class ProfessionCategoryService : IProfessionCategoryService
    {

        private readonly IProfessinCategoryRepository _professionCategoryRepository;
        private readonly IMapper _mapper;

        public ProfessionCategoryService(IProfessinCategoryRepository professionCategoryRepository, IMapper mapper)
        {
            _professionCategoryRepository = professionCategoryRepository;
            _mapper = mapper;
        }

        public List<TAB_ProfessionCategoryDTO> GetAllProfessionCategories()
        {
            return _mapper.Map<List<TAB_ProfessionCategoryDTO>>(_professionCategoryRepository.GetAllProfessionCategories());
        }    

        public TAB_ProfessionCategoryDTO GetProfessionCategoriesById(int id)
        {
            return _mapper.Map<TAB_ProfessionCategoryDTO>(_professionCategoryRepository.GetProfessionCategoriesById(id));
        }
    }
}
