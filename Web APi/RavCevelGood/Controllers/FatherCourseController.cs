using DTO.Classes;
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
    public class FatherCourseController : ControllerBase
    {
        private readonly IFatherCourseService _fatherCourseService;
        public FatherCourseController(IFatherCourseService fatherCourseService)
        {
            _fatherCourseService = fatherCourseService;
        }
        //שליפת קורסי אב ע"פ מוסדות ושנתון
        [HttpGet("GetListFatherCoursesBySchoolAndYearbook/{SchoolsId}/{YearbookId}")]
        public IActionResult GetListFatherCoursesBySchoolAndYearbook(string SchoolsId, int YearbookId)
        {
            try
            {
                return Ok(_fatherCourseService.GetListFatherCoursesBySchoolAndYearbook(SchoolsId, YearbookId));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        //הוספת קורס אב
        [HttpPut("AddFatherCourse")]
        public IActionResult AddFatherCourse(AppCourseDTO FatherCourse)
        {
            try
            {
                return Ok(_fatherCourseService.AddFatherCourse(FatherCourse));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message ?? e.InnerException.Message);
            }
        }
        //עריכת קורס אב
        [HttpPost("EditFatherCourse")]
        public IActionResult EditFatherCourse(AppCourseDTO FatherCourse)
        {
            try
            {
                return Ok(_fatherCourseService.EditFatherCourse(FatherCourse));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message ?? e.InnerException.Message);
            }
        }
        //מחיקת קורס אב
        [HttpDelete("DeleteFatherCrouse/{FatherCourseId}")]
        public IActionResult DeleteFatherCrouse(int FatherCourseId)
        {
            try
            {
                return Ok(_fatherCourseService.DeleteFatherCrouse(FatherCourseId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message ?? e.InnerException.Message);
            }
        }
        //הוספת מסמך תואם לכל המוסדות התואמים
        [HttpPut("AddCoordinationsFatherCourse/{YearbookId}/{CoustomerId}")]
        public IActionResult AddCoordinationsFatherCourse([FromBody] ObjectFatherCoursekAndCoordinationId obj, int YearbookId, int CoustomerId)
        {
            try
            {
                return Ok(_fatherCourseService.AddCoordinationsFatherCourse(obj, YearbookId, CoustomerId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message ?? e.InnerException.Message);
            }
        }
        //
        [HttpPost("EditCoordinatorCourseFather/{UserId}/{CoustomerId}")]
        public IActionResult EditCoordinatorCourseFather([FromBody] AppCourseDTO FatherCourse, int UserId, int CoustomerId)
        {
            try
            {
                return Ok(_fatherCourseService.EditCoordinatorCourseFather(FatherCourse, UserId, CoustomerId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message ?? e.InnerException.Message);
            }
        }
        [HttpPost("getFatherCourseById/{getFatherCourseById}")]
        public IActionResult getFatherCourseById(int fatherCourseId)
        {
            try
            {
                return Ok(_fatherCourseService.getFatherCourseById(fatherCourseId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message ?? e.InnerException.Message);
            }
        }
    }
}
