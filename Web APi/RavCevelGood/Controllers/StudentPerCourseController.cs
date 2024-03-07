using DTO.Classes;
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
    public class StudentPerCourseController : Controller
    {
        private readonly IStudentsPerCourseService _StudentsPerCourseService;

        public StudentPerCourseController(IStudentsPerCourseService StudentsPerCourseService)
        {
            _StudentsPerCourseService = StudentsPerCourseService;
        }

        [HttpGet("GetAllStudentByCourseId/{CourseId}")]
        public IActionResult GetAllStudentByCourseId(int CourseId)
        {
            return Ok(_StudentsPerCourseService.GetAllCourseToStudentBycoureID(CourseId));
        }


        [HttpPost("UpdateCoursePerStudent")]
        public IActionResult UpdateCoursePerStudent([FromBody] AppStudentsPerCourseDTO AppStudentsPerCourseDTO)
        {
            return Ok(_StudentsPerCourseService.UpdateCoursePerStudent(AppStudentsPerCourseDTO));
        }
        [HttpPost("AddOrUpdateGradePerCourse")]
        public IActionResult AddOrUpdateGradePerCourse(int schoolID, int courseId, int taskExistId, float finelScorePerStudent, int studentId)
        {
            return Ok(_StudentsPerCourseService.AddOrUpdateGradePerCourse(schoolID, courseId, taskExistId, finelScorePerStudent, studentId));
        }

        [HttpPost("AddListStudentsPerGroupToCourse")]
        public IActionResult AddListStudentsPerGroupToCourse(int idgroup, int idgroupsemesterpercourse, int yearbookid)
        {
            return Ok(_StudentsPerCourseService.AddListStudentsPerGroupToCourse(idgroup, idgroupsemesterpercourse, yearbookid));
        }

        [HttpPost("AddStudentToCourse")]
        public IActionResult AddStudentToCourse(int studentId, int idgroupsemesterpercourse)
        {
            return Ok(_StudentsPerCourseService.AddStudentToCourse(studentId,idgroupsemesterpercourse));
        }


    }
}
