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
    public class CoordinationController : ControllerBase
    {
        private readonly ICoordinationService _coordinationService;

        public CoordinationController(ICoordinationService coordinationService)
        {
            _coordinationService = coordinationService;
        }

        [HttpGet("GetCoordinationByCoordinationTypeId/{coordinationId}")]
        public IActionResult GetCoordinationByCoordinationTypeId(int coordinationId)
        {
            return Ok(_coordinationService.GetCoordinationByCoordinationTypeId(coordinationId));
        }
        [HttpPut("GetAllCoordinationsByListSchoolId/")]
        public IActionResult GetAllCoordinationsByListSchoolId([FromBody]List<int> listSchoolId)
        {
            return Ok(_coordinationService.GetAllCoordinationsByListSchoolId(listSchoolId));
        }

        [HttpGet("GetAllPrimaryKeyGenericTypeByCoordinationId/{coordinationId}/{tableName}")]
        public IActionResult GetAllPrimaryKeyGenericTypeByCoordinationId(int coordinationId, string tableName)
        {
            return Ok(_coordinationService.GetAllPrimaryKeyGenericTypeByCoordinationId(coordinationId, tableName));
        }
    }
}
