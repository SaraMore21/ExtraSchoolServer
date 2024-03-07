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
    public class TypePresenceController : ControllerBase
    {
        private readonly ITypePresencesService _TypePresencesService;
        public TypePresenceController(ITypePresencesService TypePresencesService)
        {
            _TypePresencesService = TypePresencesService;
        }


        [HttpGet("GetAllPresence")]
        public IActionResult GetAllPresence()
        {
            return Ok(_TypePresencesService.GetAllPresence());
        }
    }
}
