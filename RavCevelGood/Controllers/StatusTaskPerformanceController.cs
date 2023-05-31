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
    public class StatusTaskPerformanceController : ControllerBase
    {
        private readonly IStatusTaskPerformanceService _StatusTaskPerformanceService;

        public StatusTaskPerformanceController(IStatusTaskPerformanceService StatusTaskPerformanceService)
        {
            _StatusTaskPerformanceService = StatusTaskPerformanceService;
        }

        [HttpGet("GetAllStatusTaskPerformanceBySchoolId/{SchoolID}")]
        public IActionResult GetAllStatusTaskPerformanceBySchoolId(int SchoolID)
        {
            return Ok(_StatusTaskPerformanceService.GetAllStatusTaskPerformanceBySchoolId(SchoolID));
        }
    }
}
