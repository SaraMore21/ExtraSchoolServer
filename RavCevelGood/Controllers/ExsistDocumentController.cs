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
    public class ExsistDocumentController : ControllerBase
    {
        private readonly IExsistDocumentService _ExsistDocumentService;

        public ExsistDocumentController(IExsistDocumentService ExsistDocumentService)
        {
            _ExsistDocumentService = ExsistDocumentService;
         
        }

        //שליפת הקוד הבא בשביל להעלות מסמך שהוא לא מהדרושים
        [HttpGet("AddAndGetTheNextExsistDocument/{SchoolId}/{userId}")]
        public IActionResult AddAndGetTheNextExsistDocument(int SchoolId, int userId)
        {
            try
            {

                return Ok(_ExsistDocumentService.AddAndGetTheNextExsistDocument(userId));
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}
