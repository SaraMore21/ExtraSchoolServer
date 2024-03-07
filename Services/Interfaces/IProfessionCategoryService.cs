using DTO.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IProfessionCategoryService
    {
        List<TAB_ProfessionCategoryDTO> GetAllProfessionCategories();
        TAB_ProfessionCategoryDTO GetProfessionCategoriesById(int id);

    }
}
