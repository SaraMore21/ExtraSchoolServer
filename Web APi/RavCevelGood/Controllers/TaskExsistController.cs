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
    public class TaskExsistController : ControllerBase
    {
        private readonly ITaskExsistService _TaskExsistService;

        public TaskExsistController(ITaskExsistService TaskExsistService)
        {
            _TaskExsistService = TaskExsistService;
        }

        [HttpGet("GetAllTaskExsistByTaskId/{taskId}")]
        public IActionResult GetAllTaskExsistByTaskId(int taskId)
        {
            return Ok(_TaskExsistService.GetAllTaskBySchoolId(taskId));
        }

        [HttpPost("AddOrUpdate/{SchoolID}/{YearbookId}")]
        public IActionResult AddOrUpdate(int SchoolID, int YearbookId, AppTaskExsistDTO TaskExsistDTO)
        {

            try
            {
                int sumPercents = 0;
                Tuple<int, AppTaskExsistDTO,int> tuple;
                if (TaskExsistDTO != null && TaskExsistDTO.IdexsistTask==0 && TaskExsistDTO.CourseId != null && TaskExsistDTO.CourseId != 0)
                {
                    sumPercents = _TaskExsistService.getSumPercentsOfCourse(TaskExsistDTO.CourseId,TaskExsistDTO.IdexsistTask);
                    if (sumPercents + TaskExsistDTO.Percents > 100)
                    {
                        var t1 = Tuple.Create(202, "לא ניתן לשייך מטלות לקורס כך שסך האחוזים יעלה על מאה. סך האחוזים המופיע כבר לקורס זה הוא - " + sumPercents);
                        return Ok(t1);
                    }
                }

                AppTaskExsistDTO appTaskExsistDTO = _TaskExsistService.AddOrUpdate(SchoolID, YearbookId, TaskExsistDTO);
                if (sumPercents + TaskExsistDTO.Percents < 100 && TaskExsistDTO.IdexsistTask == 0)
                    tuple = Tuple.Create(203, appTaskExsistDTO,sumPercents + (int)TaskExsistDTO.Percents);
                else
                    tuple = Tuple.Create(200, appTaskExsistDTO,0);

                return Ok(tuple);
            }
            catch (AccessViolationException e)
            {
                var t = Tuple.Create(201, e.Message);
                return Ok(t);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpGet("DeleteTaskExsist/{TaskExsistId}/{deleteTaskToStudents}")]
        public IActionResult DeleteTaskExsist(int TaskExsistId, bool deleteTaskToStudents = false)
        {
            return Ok(_TaskExsistService.DeleteTask(TaskExsistId, deleteTaskToStudents));
        }

        [HttpGet("getSumPercentsOfGroupSemesterPerCourse/{CourseId}/{TaskId}")]
        public IActionResult getSumPercentsOfGroupSemesterPerCourse(int CourseId, int TaskId)
        {
            return Ok(_TaskExsistService.getSumPercentsOfCourse(CourseId, TaskId));
        }

    }
}
