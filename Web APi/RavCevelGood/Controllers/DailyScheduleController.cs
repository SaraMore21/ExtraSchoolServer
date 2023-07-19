using DTO.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace RavCevelGood.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyScheduleController : ControllerBase
    {
        private readonly IDailyScheduleService _DailyScheduleService;
        private readonly ICourseService _CourseService;

        public DailyScheduleController(IDailyScheduleService dailyScheduleService, ICourseService courseService)
        {
            _DailyScheduleService = dailyScheduleService;
            _CourseService = courseService;
        }
        //שליפת המורות הפנויות לפי נתוני שיעור ספציפי במוסד
        [HttpGet("GetAvailableTeachers/{scheduleDate}/{numLesson}/{SchoolId}/{CourseId}")]
        public IActionResult GetAvailableTeachers(string scheduleDate, int numLesson, int SchoolId, int CourseId)
        {
            return Ok(_DailyScheduleService.GetAvailableTeachers(Convert.ToDateTime(scheduleDate), numLesson, SchoolId, CourseId));
        }
      

        //שליפת המורות הפנויות לפי טווח שעות ושאר נתוני השיעור
        [HttpGet("GetAvailableTeachersByHourRange/{ScheduleDate}/{StartTime}/{EndTime}/{SchoolId}/{CourseId}")]
        public IActionResult GetAvailableTeachersByHourRange(string ScheduleDate, string StartTime, string EndTime, int SchoolId, int CourseId)
        {
            try
            {
                return Ok(_DailyScheduleService.GetAvailableTeachersByHourRange(Convert.ToDateTime(ScheduleDate), TimeSpan.Parse(StartTime), TimeSpan.Parse(EndTime), SchoolId, CourseId));
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException != null ? e.InnerException.Message : e.Message);
            }
        }
        //שליפת מספרי השיעורים הפנויים לקבוצה בתאריך
        [HttpGet("GetNumLessonAvailable/{GroupId}/{ScheduleDate}")]
        public IActionResult GetNumLessonAvailable(int GroupId, string ScheduleDate)
        {
            try
            {
                return Ok(_DailyScheduleService.GetNumLessonAvailable(GroupId,Convert.ToDateTime(ScheduleDate)));
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException != null ? e.InnerException.Message : e.Message);
            }
        }
        //שליפת מורה לפי הקורס הנבחר
        [HttpGet("GetTeacherBySelectCourse/{GroupSemesterPerCourseId}/{scheduleDate}")]
        public IActionResult GetTeacherBySelectCourse(int GroupSemesterPerCourseId, string scheduleDate)
        {
            try
            {
                return Ok(_DailyScheduleService.GetTeacherBySelectCourse(GroupSemesterPerCourseId, Convert.ToDateTime(scheduleDate)));
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException != null ? e.InnerException.Message : e.Message);
            }
        }
        //שליפת מערכת יומית לקבוצה בתאריך
        [HttpGet("GetDailySchedulePerGroup/{GroupId}/{ScheduleDate}")]
        public IActionResult GetDailySchedulePerGroup(int GroupId, string ScheduleDate)
        {
            try
            {
                return Ok(_DailyScheduleService.GetDailySchedulePerGroup(GroupId, DateTime.ParseExact(ScheduleDate, "dd-MM-yyyy", null)));
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException != null ? e.InnerException.Message : e.Message);
            }
        }
        //עריכת מערכת יומית-שמירת פרטי השיעור 
        [HttpPost("EditDailySchedule")]
        public IActionResult EditDailySchedule([FromBody] AppDailyScheduleDTO DailySchedule)
        {
            try
            {
                return Ok(_DailyScheduleService.EditDailySchedule(DailySchedule));
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException != null ? e.InnerException.Message : e.Message);
            }
        }
        //הוספת מערכת יומית
        [HttpPut("AddDailySchedule")]
        public IActionResult AddDailySchedule([FromBody] AppDailyScheduleDTO DailySchedule)
        {
            try
            {
                return Ok(_DailyScheduleService.AddDailySchedule(DailySchedule));
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException != null ? e.InnerException.Message : e.Message);
            }
        }
        //שליפת נתוני מערכת יומית לפי מערכת קבועה 
        [HttpGet("GetDailyScheduleDetailsByScheduleRegular/{GroupId}/{ScheduleDate}/{StartTime}/{EndTime}")]
        public IActionResult GetDailyScheduleDetailsByScheduleRegular(int GroupId, string ScheduleDate, string StartTime, string EndTime)
        {
            try
            {
                return Ok(_DailyScheduleService.GetDailyScheduleDetailsByScheduleRegular(GroupId, Convert.ToDateTime(ScheduleDate), TimeSpan.Parse(Convert.ToDateTime(StartTime).ToString("HH:mm")), TimeSpan.Parse(Convert.ToDateTime(EndTime).ToString("HH:mm"))));
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException != null ? e.InnerException.Message : e.Message);
            }
        }
        //מחיקת מערכת יומית
        [HttpDelete("DeleteDailySchedule/{IdDailySchedule}")]
        public IActionResult DeleteDailySchedule(int IdDailySchedule)
        {
            try
            {
                return Ok(_DailyScheduleService.DeleteDailySchedule(IdDailySchedule));
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException != null ? e.InnerException.Message : e.Message);
            }
        }
    }
}
