using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Model;
using DB.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DB.Repository.Classes
{
    class ProfessionCategoryRepository : IProfessinCategoryRepository
    {

        private readonly ExtraSchoolContext _context;
        public ProfessionCategoryRepository(ExtraSchoolContext context)
        {
            _context = context;
        }

        //שליפת כל הקטגוריות 
        public List<TabProfessionCategory> GetAllProfessionCategories()
        {
            var x = _context.TabProfessionCategories.ToList();
            return x;
        }

        public TabProfessionCategory GetProfessionCategoriesById(int id)
        {
            var x = _context.TabProfessionCategories.FirstOrDefault(f=> f.IdProfessionCategory== id);
            return x;
        }
    }
}
