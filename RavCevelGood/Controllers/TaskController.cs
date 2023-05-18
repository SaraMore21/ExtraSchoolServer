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
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        // שליפת כל המטלות בשנתון מסויים ובמוסד מסויים/ מס' מוסדות
        [HttpGet("GetAllTaskBySchoolId/{SchoolsID}/{YearbookId}")]
        public IActionResult GetAllTaskBySchoolId(string SchoolsID, int YearbookId)
        {
            return Ok(_taskService.GetAllTaskBySchoolId(SchoolsID, YearbookId));
        }

        //עידכון / הוספה של מטלה
        [HttpPost("AddOrUpdate/{SchoolID}/{YearbookId}")]
        public IActionResult AddOrUpdate(int SchoolID, int YearbookId, AppTaskDTO TaskDTO)
        {
            return Ok(_taskService.AddOrUpdate(SchoolID, YearbookId, TaskDTO));
        }

        //מחיקת מטלה
        [HttpGet("DeleteTask/{SchoolID}/{IdTask}")]
        public IActionResult DeleteTask(int SchoolID, int IdTask, int YearbookId = 0)
        {
            return Ok(_taskService.DeleteTask(SchoolID, YearbookId, IdTask));
        }

        //עידכון או הוספה של מטלה למס' מוסדות תואמים
        [HttpPost("AddOrUpdateTasksOfSpecificCodeByCustomer/{YearbookId}/{IDcustomer}")]
        public IActionResult AddOrUpdateTasksOfSpecificCodeByCustomer(int YearbookId, int IDcustomer, [FromBody] ObjectWithTaskAndListSchools ObjectWithTaskAndListSchools)
        {
            return Ok(_taskService.AddOrUpdateTasksOfSpecificCodeByCustomer(ObjectWithTaskAndListSchools.TaskDTO, ObjectWithTaskAndListSchools.ListSchool, YearbookId, IDcustomer));
        }

    }
}
