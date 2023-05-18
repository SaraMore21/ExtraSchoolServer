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
    public class QuestionsOfTaskController : ControllerBase
    {
        private readonly IQuestionsOfTaskService _questionsOfTaskService;

        public QuestionsOfTaskController(IQuestionsOfTaskService questionsOfTaskService)
        {
            _questionsOfTaskService = questionsOfTaskService;
        }
        [HttpGet("GetQuestionOfTask/{TaskId}")]
        public IActionResult GetQuestionOfTask(int TaskId)
        {
            try
            {
                return Ok(_questionsOfTaskService.GetQuestionOfTask(TaskId));
            }
            catch(Exception e)
            {
                return BadRequest(e.Message ?? e.InnerException.Message);
            }
        }
    }
}
