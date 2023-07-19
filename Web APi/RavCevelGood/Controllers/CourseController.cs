using DTO.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NPOI.SS.Formula.Functions;
using Services.Classes;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RavCevelGood.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {

        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        //IDשליפת קורסים לפי קורס אב
        [HttpGet("GetAllCourseByFatherCourseId/{FatherCourseId}")]
        public IActionResult GetAllCourseByFatherCourseId(int FatherCourseId)
        {
            try
            {
                return Ok(_courseService.GetAllCourseByFatherCourseId(FatherCourseId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message ?? e.InnerException.Message);
            }
        }
        //public string staticstringmakepassword(string pwdchars, int pwdlen)
        //{
        //    string tmpstr = "";
        //    int irandnum;
        //    Random rnd = new Random();
        //    for(int I = 0; I < 7; I++ ){
        //        irandnum = And.Next(pwdchars.Length);
        //        tmpstr + = pwdchars[irandnum];
        //    }
        //    return tmpstr;
        //}

        //שליפת קורסים עפ"י מוסד ושנתון
        [HttpGet("GetAllCourseBySchoolDAndYearbookId/{SchoolsId}/{YearbookId}")]
        public IActionResult GetAllCourseBySchoolDAndYearbookId(string SchoolsId, int YearbookId)
        {
            return Ok(_courseService.GetAllCourseBySchoolDAndYearbookId(SchoolsId, YearbookId));
        }
        //שליפת קורסים עפ"י מוסד 
        [HttpGet("GetAllCourseBySchoolId/{SchoolId}")]
        public IActionResult GetAllCourseBySchoolId(int SchoolId)
        {
            return Ok(_courseService.GetAllCourseBySchoolId(SchoolId));
        }
        //שליפת סמסטרים בשנתון
        [HttpGet("GetAllSemester/{YearbookId}")]
        public IActionResult GetAllSemester(int YearbookId)
        {
            return Ok(_courseService.GetAllSemester(YearbookId));
        }
        ////הוספת קורס  
        //[HttpPut("AddCourse/{SchoolId}/{SemesterId}/{CourseId}/{GroupId}/{SemesterFromDate}/{SemesterToDate}/{TeacherId}/{YearbookId}/{UserCreatedId}")]
        //public IActionResult AddCourse(int SchoolId, int SemesterId, int CourseId, int GroupId, string SemesterFromDate, string SemesterToDate, int TeacherId, int YearbookId, int UserCreatedId, [FromBody] AppCourseDTO Course)
        //{
        //    try
        //    {
        //        var semesterFromDate = DateTime.Parse(SemesterFromDate);
        //        var semesterToDate = DateTime.Parse(SemesterToDate);
        //        return Ok(_courseService.AddCourse(SchoolId, SemesterId, CourseId, GroupId, semesterFromDate, semesterToDate, TeacherId, YearbookId, UserCreatedId, Course));
        //    }
        //    catch (Exception e) { throw e; }
        //}
        //מחיקת קורס-אם קיים קורס אחד בשם זה -מוחק גם את הקורס הבסיסי
        [HttpDelete("DeleteCourse/{GroupSemesterPerCourseId}")]
        public IActionResult DeleteCourse(int GroupSemesterPerCourseId)
        {
            try
            {
                return Ok(_courseService.DeleteCourse(GroupSemesterPerCourseId));
            }
            catch (Exception e) { return null; }
        }
        //שליפת שיוכי מורה לקורס
        [HttpGet("GetUsersPerCourse/{CourseId}")]
        public IActionResult GetUsersPerCourse(int CourseId)
        {
            try
            {
                return Ok(_courseService.GetUsersPerCourse(CourseId));
            }
            catch (Exception)
            {
                return null;
            }
        }
        //עריכת קורס-עריכת שיוכי מורה לקורס
        [HttpPost("EditCourse/{CourseId}/{CourseCode}")]
        public IActionResult EditCourse(int CourseId, string CourseCode, [FromBody] List<AppUserPerCourseDTO> ListUserPerCourse)
        {
            try
            {
                return Ok(_courseService.EditCourse(CourseId, CourseCode, ListUserPerCourse));
            }
            catch (Exception e)
            {
                return Ok(false);
            }
        }
        [HttpPut("AddFatherCourse")]
        public IActionResult AddFatherCourse([FromBody] AppCourseDTO Course)
        {
            try
            {
                return Ok(_courseService.AddFatherCourse(Course));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        //הוספת קורס
        [HttpPut("AddCourse/{TeacherId}")]
        public IActionResult AddCourse(AppGroupSemesterPerCourseDTO course, int TeacherId)
        {
            try
            {
                return Ok(_courseService.AddCourse(course, TeacherId));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        //GroupId שליפת הקורסים לקבוצה לפי  
        [HttpGet("GetCoursesForGroup/{GroupId}/{scheduleDate}")]
        public IActionResult GetCoursesForGroup(int GroupId, string scheduleDate)
        {
            try
            {
                return Ok(_courseService.GetCoursesForGroup(GroupId, Convert.ToDateTime(scheduleDate)));
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException != null ? e.InnerException.Message : e.Message);
            }
        }
        //שליפת המורה המשוייכת לקורס בטווח תאריכים
        [HttpGet("GetUserPerCourse/{CourseId}/{Date}")]
        public IActionResult GetUserPerCourse(int CourseId, DateTime Date)
        {
            try
            {

                return Ok(_courseService.GetUserPerCourse(CourseId, Convert.ToDateTime(Date)));
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException != null ? e.InnerException.Message : e.Message);
            }
        }

        [HttpGet("TestGetCoordinatedCourse")]
        public IActionResult TestGetCoordinatedCourse()
        {
            return Ok(_courseService.TestGetCoordinatedCourse());
        }

        [HttpPut("AddCoordinatedCourse/{yearbookId}")]
        public IActionResult AddCoordinationsCourse(AppGroupSemesterPerCourseDTO course, int YearbookId)
        {
            try
            {

                return Ok(_courseService.AddCoordinationsCourse(course, YearbookId));
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException != null ? e.InnerException.Message : e.Message);
            }
        }

    }
}

