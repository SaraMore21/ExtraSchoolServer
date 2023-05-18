using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services;
using AutoMapper;
using Services.Interfaces;
using DTO.Classes;
using Microsoft.Owin.Infrastructure;
using System.Net;

namespace RavCevelGood.Controllers
{
    [Route("api/Student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _StudentService;
        private readonly IMapper _mapper;
        private readonly string _azureToken;

        public StudentController(IMapper mapper, IStudentService StudentService)
        {
            _mapper = mapper;
            _StudentService = StudentService;
            _azureToken = "?sp=r&st=2021-09-05T07:09:22Z&se=4000-01-01T16:09:22Z&spr=https&sv=2020-08-04&sr=c&sig=rfQUXoumLEarC%2BNrpsSX1d0tH%2FmupgC%2F0QWn4qpq49k%3D";
        }

        //IDשליפת תלמידים במוסד עפ"י מוסד
        [HttpGet("ListStudents/{SchoolID}")]
        public IActionResult ListStudents(int SchoolID)
        {
            try
            {
                List<AppStudentDTO> response = (_StudentService.GetListStudentsBySchoolId(SchoolID));

                return Ok(response);
            }
            catch (Exception e)
            {

                throw;
            }
        }
        //מחיקת תלמיד
        [HttpDelete("DeleteStudent/{StudentID}")]
        public IActionResult DeleteStudent(int StudentID)
        {
            try
            {
                return Ok(_StudentService.DeleteStudent(StudentID));
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        // ID שליפת פרטי תלמיד עפ"י 
        [HttpGet("GetStudentDetailsByIDStudent/{StudentID}")]
        public IActionResult GetStudentDetailsByIDStudent(int StudentID)
        {
            return Ok(_StudentService.GetStudentDetailsByIDStudent(StudentID));
        }
        //הוספת תלמיד   
        [HttpPut("AddStudent/{UserCreatedId}/{SchoolId}/{YearbookId}")]
        public IActionResult AddStudent([FromBody] AppStudentWhithDetailsDTO student, int UserCreatedId, int SchoolId, int YearbookId)
        {
            try
            {
                return Ok(_StudentService.AddStudent(student, UserCreatedId, SchoolId, YearbookId));
            }
            catch (Exception e)
            {
                return Ok(false);
            }
        }
        // עידכוןו תלמיד
        [HttpPost("UpdateStudent/{UserCreatedId}/{SchoolId}")]
        public IActionResult UpdateStudent([FromBody] AppStudentWhithDetailsDTO student, int UserCreatedId, int SchoolId)
        {
            try
            {
                return Ok(_StudentService.UpdateStudent(student, UserCreatedId, SchoolId));
            }
            catch (Exception e)
            {
                return Ok(null);
            }
        }
        //עידכון נתיב תמונת הפספורט של התלמידה
        [HttpGet("UpdateProfilePathToStudent/{StudentID}/{path}/{SchoolId}/{Userid}")]
        public IActionResult UpdateProfilePathToStudent(int StudentID, string path, int SchoolId, int Userid)
        {
            try
            {


                path = WebUtility.UrlDecode(path);
                bool result = _StudentService.UpdateProfilePathToStudent(StudentID, path, SchoolId, Userid);
                if (result == true)
                    return Ok(path + _azureToken);
                else
                    return BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException != null ? e.InnerException.Message : e.Message);
            }
        }

        [HttpGet("GetListStudentsBySchoolIdAndYearbookId/{SchoolsId}/{YearbookId}")]
        public IActionResult GetListStudentsBySchoolIdAndYearbookId(string SchoolsId,int YearbookId)
        {
            try
            { 
            return Ok(_StudentService.GetListStudentsBySchoolIdAndYearbookId(SchoolsId, YearbookId));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
