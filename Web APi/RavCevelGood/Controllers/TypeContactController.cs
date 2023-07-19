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
    public class TypeContactController : ControllerBase
    {
        public readonly ITypeContactService _TypeContactService;

        public TypeContactController(ITypeContactService TypeContactService)
        {
            _TypeContactService = TypeContactService;
        }

        [HttpGet("GetTypeContactBySchoolID/{SchoolId}")]
        public IActionResult GetTypeContactBySchoolID(int SchoolId)
        {
            try
            {
                return Ok(_TypeContactService.GetTypeContactBySchoolID(SchoolId));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
