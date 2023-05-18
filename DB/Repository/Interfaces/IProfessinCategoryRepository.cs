using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Model;

namespace DB.Repository.Interfaces
{
    public interface IProfessinCategoryRepository
    {
        List<TabProfessionCategory> GetAllProfessionCategories();
        TabProfessionCategory GetProfessionCategoriesById(int id);

    }
}
