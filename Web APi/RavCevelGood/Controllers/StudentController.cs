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
        // עידכון תלמיד
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
        [HttpPost("UpdateProfilePathToStudent/{StudentID}/{SchoolId}/{Userid}")]
        public IActionResult UpdateProfilePathToStudent(int StudentID, int SchoolId, int Userid, AppStudentWhithDetailsDTO student)
        {
            try
            {

                //path = WebUtility.UrlDecode(path);
                bool result = _StudentService.UpdateProfilePathToStudent(StudentID, student.PassportPicture, SchoolId, Userid);
                if (result == true)
                    return Ok(student.PassportPicture + _azureToken);
                else
                    return BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException != null ? e.InnerException.Message : e.Message);
            }
        }

        //שליפת הקבוצות לפי תלמידה ושנתון
        [HttpGet("GetGroupsToStudent/{StudentId}/{YearbookId}")]
        public IActionResult GetGroupsToStudent(int StudentId, int YearbookId)
        {
            try
            {
                return Ok(_StudentService.GetGroupsToStudent(StudentId, YearbookId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message ?? e.InnerException.Message);
            }
        }
        //מחיקת שיוך תלמיד לקבוצה
        [HttpDelete("DeleteGroupToStudent/{StudentPerGroupId}")]
        public IActionResult DeleteGroupToStudent(int StudentPerGroupId)
        {
            return Ok(_StudentService.DeleteGroupToStudent(StudentPerGroupId));
        }
        //הוספת שיוך תלמיד לקבוצה
        [HttpPut("AddGroupPerStudent")]
        public IActionResult AddGroupPerStudent([FromBody] AppStudentPerGroupDTO StudentPerGroup)
        {
            try
            {
                return Ok(_StudentService.AddGroupPerStudent(StudentPerGroup));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message ?? e.InnerException.Message);
            }
        }
        //הוספת מטלות לתלמיד
        [HttpPut("AddTasksToStudent/{StudentId}/{UserCreatedId}")]
        public IActionResult AddTasksToStudent([FromBody] List<AppTaskExsistDTO> ListTaskExsist, int StudentId, int UserCreatedId)
        {
            try
            {
                return Ok(_StudentService.AddTasksToStudent(ListTaskExsist, StudentId, UserCreatedId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message ?? e.InnerException.Message);
            }
        }
        //שליפת השיוך תלמידה בקבוצה 
        [HttpGet("GetStudentPerGroupById/{StudentPerGroupId}")]
        public IActionResult GetStudentPerGroupById(int StudentPerGroupId)
        {
            try
            {
                return Ok(_StudentService.GetStudentPerGroupById(StudentPerGroupId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message ?? e.InnerException.Message);
            }
        }

        [HttpGet("GetListStudentsBySchoolIdAndYearbookId/{SchoolsId}/{YearbookId}/")]
        public IActionResult GetListStudentsBySchoolIdAndYearbookId(int page, int pageSize,string SchoolsId, int YearbookId)
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
        [HttpGet("GetPartlyListStudent/{page}/{pageSize}/{YearbookId}/{SchoolsId}")]
        public IActionResult GetPartlyListStudent(int page, int pageSize, int YearbookId, string SchoolsId)
        {
            try
            {
                return Ok(_StudentService.GetPartlyListStudent(page, pageSize, YearbookId, SchoolsId));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        
        [HttpGet("SearchInStudentList/{str}/{YearbookId}/{SchoolsId}")]
        public IActionResult SearchInStudentList(string str, int YearbookId, string SchoolsId)
        {
            try
            {
                return Ok(_StudentService.SearchInStudentList(str, YearbookId, SchoolsId));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        //שליפת אפשרויות סיבת עזיבה למוסד
        [HttpGet("GetReasonForLeavingPerSchool/{SchoolId}")]
        public IActionResult GetReasonForLeavingPerSchool(int SchoolId)
        {
            try
            {
                return Ok(_StudentService.GetReasonForLeavingPerSchool(SchoolId));
            }
            catch(Exception e)
            {
                return BadRequest(e.InnerException != null ? e.InnerException.Message : e.Message);
            }
        }


    }
}
