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
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;
        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }
        //שליפת נוכחות יומית לקבוצה
        [HttpGet("GetDailyAttendanceForGroup/{groupId}/{date}")]
        public IActionResult GetDailyAttendanceForGroup(int groupId, string date)
        {
            try
            {
                return Ok(_attendanceService.GetDailyAttendanceForGroup(groupId,Convert.ToDateTime(date)));
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException != null ? e.InnerException.Message : e.Message);
            }
        }
    }
}
