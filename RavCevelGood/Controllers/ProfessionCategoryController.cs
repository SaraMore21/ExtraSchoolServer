using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RavCevelGood.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessionCategoryController : ControllerBase
    {
        private readonly IProfessionCategoryService _professionCategoryService;
        public ProfessionCategoryController(IProfessionCategoryService professionCategoryService)
        {
            _professionCategoryService = professionCategoryService;
        }


        //שליפת רשימת קטגוריות
        [HttpGet("GetAllProfessionCategories")]
        public IActionResult GetAllProfessionCategories() {
            try
            {
                return Ok(_professionCategoryService.GetAllProfessionCategories());
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
