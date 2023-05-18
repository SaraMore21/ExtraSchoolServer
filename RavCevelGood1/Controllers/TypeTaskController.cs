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
    public class TypeTaskController : ControllerBase
    {
        private readonly ITypeTaskService _TypeTaskService;

        public TypeTaskController(ITypeTaskService TypeTaskService)
        {
            _TypeTaskService = TypeTaskService;
        }

        [HttpGet("GetAllTypeTaskBySchoolId/{SchoolID}")]
        public IActionResult GetAllTypeTaskBySchoolId(int SchoolID)
        {
            return Ok(_TypeTaskService.GetTypeTaskBySchoolId(SchoolID));
        }

    }
}
