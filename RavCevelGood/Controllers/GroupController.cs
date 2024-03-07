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
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        //שליפת קבוצות במוסד
        [HttpGet("GetGroupsByIdSchool/{Schools}/{YearbookId}")]
        public IActionResult GetGroupsByIdSchool(string Schools, int YearbookId)
        {
            try
            {
                var a = _groupService.GetGroupsByIdSchool(Schools, YearbookId);
                return Ok(a);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        //שליפת תלמידים בקבוצה
        [HttpGet("GetStudentPerGroup/{GroupId}/{YearbookId}")]
        public IActionResult GetStudentPerGroup(int GroupId, int YearbookId)
        {
            var a = _groupService.GetStudentPerGroup(GroupId, YearbookId);
            return Ok(a);
        }
        //מחיקת קבוצה
        [HttpDelete("DeleteGroup/{GroupId}/{YearbookId}")]
        public IActionResult DeleteGroup(int GroupId, int YearbookId)
        {
            try
            {
                return Ok(_groupService.DeleteGroup(GroupId, YearbookId));
            }
            catch (Exception e)
            {
                return Ok(false);
            }
        }
        //עריכת USERPERGROUP 
        [HttpPost("EditGroup/{IdgroupPerYearbook}/{UserUpdateId}")]
        public IActionResult EditGroup(int IdgroupPerYearbook, int UserUpdateId, [FromBody] List<AppUserPerGroupDTO> ListUsersPerGroup)
        {
            try
            {
                return Ok(_groupService.EditGroup(IdgroupPerYearbook, UserUpdateId, ListUsersPerGroup));

            }
            catch (Exception e)
            { return Ok(false); }
        }
        //עריכת קבוצה
        [HttpPost("EditGroup2/{userUpdatedId}")]

        public IActionResult EditGroup2([FromBody] AppGroupDTO group, int userUpdatedId)
        {
            try
            {
                return Ok(_groupService.EditGroup2(group, userUpdatedId));

            }
            catch (Exception e)
            { return Ok(false); }
        }
        //הוספת קבוצה 
        [HttpPut("AddGroup/{UserCreatedId}/{SchoolId}/{YearbookId}/{userId}")]
        public IActionResult AddGroup(int UserCreatedId, int SchoolId, int YearbookId, int userId, [FromBody] AppGroupDTO Group)
        {
            try
            {
                return Ok(_groupService.AddGroup(Group, UserCreatedId, SchoolId, YearbookId, userId));
            }
            catch (Exception e)
            { return null; }
        }
        //הוספת תלמיד לקבוצה
        [HttpGet("AddStudentInGroup/{StudentId}/{GroupId}/{YearbookId}/{FromDate}/{ToDate}/{UserCreatedId}")]
        public IActionResult AddStudentInGroup(int StudentId, int GroupId, int YearbookId, string FromDate, string ToDate, int UserCreatedId)
        {
            try
            {
                return Ok(_groupService.AddStudentInGroup(GroupId, StudentId, YearbookId, FromDate, ToDate, UserCreatedId));
            }
            catch (Exception e)
            {
                return Ok(false);
            }
        }
        //שליפת כל הקבוצות במוסד בכל השנים-בשביל שמות הקבוצות
        [HttpGet("GetAllNameGroup/{SchoolId}")]
        public IActionResult GetAllNameGroup(int SchoolId)
        {
            return Ok(_groupService.GetAllNameGroup(SchoolId));
        }
        //הוספת שיוך שנתון קבוצה
        [HttpGet("AddGroupInYearbook/{UserId}/{GroupId}/{YearbookId}/{UserCreatedId}")]
        public IActionResult AddGroupInYearbook(int UserId, int GroupId, int YearbookId, int UserCreatedId)
        {
            return Ok(_groupService.AddGroupInYearbook(UserId, GroupId, YearbookId, UserCreatedId));
        }
        //שליפת מורה לקבוצה בטווח התאריכים המבוקש
        [HttpGet("GetUsersPerGroupByGroupId/{GroupId}")]
        public IActionResult GetUsersPerGroupByGroupId(int GroupId)
        {
            try
            {
                return Ok(_groupService.GetUsersPerGroupByGroupId(GroupId));
            }
            catch (Exception e)
            {
                return null;
            }
        }
        //מחיקת תלמיד מקבוצה
        [HttpDelete("DeleteStudentInGroup/{StudentId}/{GroupId}")]
        public IActionResult DeleteStudentInGroup(int StudentId, int GroupId)
        {
            try
            {
                return Ok(_groupService.DeleteStudentInGroup(StudentId, GroupId));
            }
            catch (Exception e)
            {
                return Ok(false);
            }
        }
        //עריכת תלמיד בקבוצה
        [HttpPost("EditStudentInGroup/{FromDate}/{ToDate}/{UserUpdateId}")]
        public IActionResult EditStudentInGroup([FromBody] AppStudentPerGroupDTO StudentPerGroup, string FromDate, string ToDate, int UserUpdateId)
        {
            DateTime fromDate = DateTime.Parse(FromDate); DateTime toDate = DateTime.Parse(ToDate);
            return Ok(_groupService.EditStudentInGroup(StudentPerGroup, fromDate, toDate, UserUpdateId));
        }

        [HttpPost("AddCoordinatedGroup/{UserCreatedId}/{YearbookId}/{userId}")]
       public IActionResult AddCoordinatedGroup([FromBody]AppGroupDTO Group, int UserCreatedId, int YearbookId, int userId)
        {
            return Ok(_groupService.AddCoordinatedGroup(Group, UserCreatedId, YearbookId, userId));
        }
    }
}
