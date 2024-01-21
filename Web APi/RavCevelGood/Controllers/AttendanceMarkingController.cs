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
    public class AttendanceMarkingController : ControllerBase
    {
        private readonly IAttendanceMarkingService _AttendanceMarkingService;
        public AttendanceMarkingController(IAttendanceMarkingService AttendanceMarkingService)
        {
            _AttendanceMarkingService = AttendanceMarkingService;
        }

        [HttpGet("GetAllPresence")]
        public IActionResult GetAllPresence()
        {
            return Ok(_AttendanceMarkingService.GetAllPresence());
        }
    }
}



    


 
