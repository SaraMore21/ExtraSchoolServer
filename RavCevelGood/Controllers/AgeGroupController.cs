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
    public class AgeGroupController : ControllerBase
    {
        private IAgeGroupService _ageGroupService;
        public AgeGroupController(IAgeGroupService ageGroupService)
        {
            _ageGroupService = ageGroupService;
        }
        //שליפת שכבת גיל למוסדות
        [HttpGet("GetAllAgeGroupsBySchools/{Schools}")]
        public IActionResult GetAllAgeGroupsBySchools(string Schools)
        {
            try
            {
                return Ok(_ageGroupService.GetAllAgeGroupsBySchools(Schools));
            }
            catch(Exception e)
            {
                return BadRequest();
            }
        }

        //שליפת שכבת גיל למוסדות תואמים
        [HttpGet("GetAllAgeGroupsByCoordinationCode/{coordinationCode}")]
        public IActionResult GetAllAgeGroupsByCoordinationCode(string coordinationCode)
        {
            try
            {
                return Ok(_ageGroupService.GetAllNameAgeGroupsByCoordinationCode(coordinationCode));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

    }
}
