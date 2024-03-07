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
    public class StreetController : ControllerBase
    {
        private readonly IStreetService _streetService;
        public StreetController(IStreetService streetService)
        {
            _streetService = streetService;
        }

        [HttpGet("GetStreetsByCityId/{CityId}")]
        public IActionResult GetStreetsByCityId(int CityId)
        {
            try
            {
                return Ok(_streetService.GetStreetsByCityId(CityId));
            }
            catch(Exception e)
            {
                return BadRequest();
            }
        }
    }
}
