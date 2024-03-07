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
    public class TaskToStudentController : ControllerBase
    {
        private readonly ITaskToStudentService _TaskToStudentService;

        public TaskToStudentController(ITaskToStudentService TaskToStudentService)
        {
            _TaskToStudentService = TaskToStudentService;
        }

        [HttpGet("GetAllTaskToStudentByTaskExsistID/{taskToStudentId}/{SchoolID}/{YearbookId}")]
        public IActionResult GetAllTaskToStudentByTaskExsistID(int taskToStudentId, int SchoolID, int YearbookId)
        {
            return Ok(_TaskToStudentService.GetAllTaskToStudentByTaskExsistID(taskToStudentId, SchoolID, YearbookId));
        }

        [HttpPost("AddOrUpdate/{SchoolID}/{YearbookId}/{isAotomat}")]
        public IActionResult AddOrUpdate(int SchoolID, int YearbookId, AppTaskToStudentDTO TaskToStudentDTO, bool isAotomat)
        {
            return Ok(_TaskToStudentService.AddOrUpdate(SchoolID, YearbookId, TaskToStudentDTO, isAotomat));
        }

        [HttpGet("DeleteTaskToStudent/{SchoolID}/{TaskToStudentId}")]
        public IActionResult DeleteTaskToStudent(int SchoolID, int TaskToStudentId, int YearbookId = 0)
        {
            return Ok(_TaskToStudentService.DeleteTaskToStudent(SchoolID, YearbookId, TaskToStudentId));
        }

        [HttpGet("UpdateActiveTask/{SchoolID}/{TaskToStudentId}/{IsActive}")]
        public IActionResult UpdateActiveTask(int SchoolID, int TaskToStudentId, bool IsActive, int YearbookId = 0)
        {
            return Ok(_TaskToStudentService.UpdateActiveTask(SchoolID, TaskToStudentId, IsActive));
        }
        [HttpPost("EditScoreToStudents")]
        public IActionResult EditScoreToStudents(List<AppTaskToStudentDTO> ListTaskToStudent)
        {
            try
            {
                return Ok(_TaskToStudentService.EditScoreToStudents(ListTaskToStudent));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message ?? e.InnerException.Message);
            }
        }
        //שליפת ציונוי התלמידות בשאלה
        [HttpGet("GetScoreStudentInQuestionOfTask/{QuestionId}")]
        public IActionResult GetScoreStudentInQuestionOfTask(int QuestionId)
        {
            try
            {
                return Ok(_TaskToStudentService.GetScoreStudentInQuestionOfTask(QuestionId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message ?? e.InnerException.Message);
            }
        }
        //עריכת ציוני תלמידות בשאלה
        [HttpPost("EditScoreQuestionToStudents")]
        public IActionResult EditScoreQuestionToStudents([FromBody] List<AppScoreStudentPerQuestionsOfTaskDTO> ListScoreQuestionPerStudent)
        {
            try
            {
               return Ok(_TaskToStudentService.EditScoreQuestionToStudents(ListScoreQuestionPerStudent));
            }
            catch (Exception e) { return BadRequest(e.Message ?? e.InnerException.Message); }
        }

    }
}
