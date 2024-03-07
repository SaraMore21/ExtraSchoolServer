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

        [HttpPost("AddOrUpdate/{SchoolID}/{YearbookId}")]
        public IActionResult AddOrUpdate(int SchoolID, int YearbookId, AppTaskToStudentDTO TaskToStudentDTO)
        {
            return Ok(_TaskToStudentService.AddOrUpdate(SchoolID, YearbookId, TaskToStudentDTO));
        }

        [HttpGet("DeleteTaskToStudent/{SchoolID}/{TaskToStudentId}")]
        public IActionResult DeleteTaskToStudent(int SchoolID, int TaskToStudentId, int YearbookId = 0)
        {
            return Ok(_TaskToStudentService.DeleteTaskToStudent(SchoolID, YearbookId, TaskToStudentId));
        }    
        
        [HttpGet("UpdateActiveTask/{SchoolID}/{TaskToStudentId}/{IsActive}")]
        public IActionResult UpdateActiveTask(int SchoolID, int TaskToStudentId, bool IsActive,int YearbookId = 0)
        {
            return Ok(_TaskToStudentService.UpdateActiveTask(SchoolID,  TaskToStudentId, IsActive));
        }     
        

    }
}
