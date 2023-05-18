using DTO.Classes;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System;

namespace RavCevelGood.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessionController : ControllerBase
    {
        private readonly IProfessionService _professionService;
        public ProfessionController(IProfessionService professionService)
        {
            _professionService = professionService;
        }

        //שליפת רשימת מקצועות לפי מוסד
        [HttpGet("GetAllProfessionByIdSchool/{Schools}")]
        public IActionResult GetAllProfessionByIdSchool(string Schools)
        {
            try
            {
                return Ok(_professionService.GetAllProfessionByIdSchool(Schools));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //שליפת פרטי מקצוע לפי קוד
        [HttpGet("GetProfessionDetailsByProfessionId/{professionId}")]
        public IActionResult GetProfessionDetailsByProfessionId(int professionId)
        {
            try
            {
                return Ok(_professionService.GetProfessionDetailsByProfessionId(professionId));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        //עדכון מקצוע
        [HttpPost("UpdateProfession/{userId}/{SchoolId}")]
        public IActionResult UpdateProfession([FromBody] AppProfessionDTO p, int userId, int SchoolId)
        {
            try
            {
                return Ok(_professionService.UpdateProfession(p, userId, SchoolId));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message??e.InnerException.Message);
            }
        }

        //הוספת מקצוע
        [HttpPut("AddProfession/{userCreatedId}/{schoolId}")]
        public IActionResult AddProfession([FromBody] AppProfessionDTO newProfession, int userCreatedId, int schoolId)
        {
            try
            {
                return Ok(_professionService.AddProfession(newProfession, userCreatedId, schoolId));
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        //מחיקת מקצוע
        [HttpDelete("DeleteProfession/{ProfessionId}")]
        public IActionResult DeleteProfession(int ProfessionId)
        {
            return Ok(_professionService.DeleteProfession(ProfessionId));
        }
        //הוספת מקצועות תואמים
        [HttpPut("AddCoordinationsProfession/{CustomerId}/{UserCreatedId}/{YearbookId}")]
        public IActionResult AddCoordinationsProfession([FromBody] ObjectProfessionAndListSchool ObjectProfessionAndListSchool, int CustomerId, int UserCreatedId, int YearbookId)
        {
            try
            {
                return Ok(_professionService.AddCoordinationsProfession(ObjectProfessionAndListSchool.ListSchool, ObjectProfessionAndListSchool.Profession, CustomerId, UserCreatedId, YearbookId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message ?? e.InnerException.Message);
            }
        }

        //עדכון מקצועות תואמים
        [HttpPost("UpdateCoordinationProfession/{CustomerId}/{UserCreatedId}/{YearbookId}")]
        public IActionResult UpdateCoordinationProfession([FromBody] ObjectProfessionAndListSchool ObjectProfessionAndListSchool, int CustomerId, int UserCreatedId, int YearbookId)
        {
            try
            {
                return Ok(_professionService.UpdateCoordinationProfession(ObjectProfessionAndListSchool.ListSchool, ObjectProfessionAndListSchool.Profession, CustomerId, UserCreatedId, YearbookId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message ?? e.InnerException.Message);
            }
        }
    }
}
