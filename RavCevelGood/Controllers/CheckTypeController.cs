using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.Interfaces;

namespace RavCevelGood.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckTypeController : ControllerBase
    {
        private readonly ICheckTypeService _CheckTypeService;
        public CheckTypeController(ICheckTypeService CheckTypeService)
        {
            _CheckTypeService = CheckTypeService;
        }


        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_CheckTypeService.GetAll());
        }
    }
}
