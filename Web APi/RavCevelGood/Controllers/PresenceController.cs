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
    public class PresenceController : ControllerBase
    {
        private readonly IPresenceService _presenceService;

        public PresenceController(IPresenceService presenceService)
        {
            _presenceService = presenceService;
        }

        //
        [HttpGet("GetLessonsByDate/{date}/{idGroup}")]
        public IActionResult GetLessonsByDate(DateTime date, int idGroup)
        {
            try
            {
                var a = _presenceService.GetLessonsByDate(date, idGroup);
                return Ok(a);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        [HttpPost("GetNochectByDateIdgroup/{date}/{idGroup}")]
        public ActionResult<List<AttendencePerDayDTO>> GetNochectByDateIdgroup(DateTime date, int idGroup)
        {
            try
            {
                List<AttendencePerDayDTO> a = _presenceService.GetNochectByDateIdgroup(date, idGroup);
                return Ok(a);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        [HttpPost("GetNochectByDay/{date}/{idGroup}")]
        public ActionResult<List<AttendencePerDayDTO>> GetNochectByDay(DateTime date, int idGroup)
        {
            try
            {
                List<AttendencePerDayDTO> a = _presenceService.GetNochectByDay(date, idGroup);
                return Ok(a);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        [HttpPost("addOrUpdateAttendance/{date}/{userId}")]
        public IActionResult addOrUpdateAttendance(string date, int userId, List<AppPresenceDTO> AppPresenceDTO)
        {
            return Ok(_presenceService.addOrUpdateAttendance(date, userId, AppPresenceDTO));
        }




    }
}
