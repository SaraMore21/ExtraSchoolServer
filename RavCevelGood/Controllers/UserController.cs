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
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        //שליפת משתמשים לפי מוסד
        [HttpGet("GetAllUserBySchoolId/{SchoolId}")]
        public IActionResult GetAllUserBySchoolId(int SchoolId)
        {
            return Ok(_userService.GetAllUserBySchoolId(SchoolId));
        }

        //שליפת משתמשים לפי מוסד ושנה
        [HttpGet("GetUsersBySchoolIDAndYearbookId/{SchoolsId}/{YearbookId}")]
        public IActionResult GetUsersBySchoolIDAndYearbookId(string SchoolsId, int YearbookId)
        {
            try
            {
                return Ok(_userService.GetUsersBySchoolIDAndYearbookId(SchoolsId, YearbookId));
            }
            catch
            {
                return BadRequest();
            }
        }


        //IDשליפת פרטי משתמש לפי 
        [HttpGet("GetUserDetailsByIDUser/{UserId}/{SchoolId}")]
        public IActionResult GetUserDetailsByIDUser(int UserId, int SchoolId)
        {
            return Ok(_userService.GetUserDetailsByIDUser(UserId, SchoolId));
        }

        //  הוספת משתמש ושליחת מייל 
        [HttpPut("AddUser/{UserCreatedId}/{SchoolId}/{yearbookId}/{emailAddress}/{message}")]
        public IActionResult AddUser([FromBody] AppUserPerSchoolWithDetailsDTO User, int UserCreatedId, int SchoolId, int yearbookId, string emailAddress, string message)
        {

            try
            {
                var u = _userService.AddUser(User, UserCreatedId, SchoolId, yearbookId);
                if (u.ID == "4" || u.ID == "3")
                {
                    Task t = Task.Run(() =>
                    {
                        var body = "<div style='text-align-last: center; font-size: large; font-family: revert;'>";
                        body += "<a style='font-weight: bold; '> " + u.User.FirstName + ", שלום רב</a><br>";
                        body += "<a> הופק עבורך שם משתמש וסיסמא לאתר ניהול המוסד"+" <span style='font-weight: bold' > ExtraSchool </span> <br>";
                        body += "שם המשתמש הינו אישי ואין להעבירו לאחר. </a><br><br> ";
                        body += "<a style='font-weight: bold' > שם משתמש: </a>";
                        body += "<a>" + u.User.Tz + "</a> <br>";
                        body += "<a style='font-weight: bold' > סיסמא: </a>";
                        body += "<a>" + u.User.UserPassword + "</a> <br>";
                        body += "<a> יש לשמור קוד זה על מנת לאפשר כניסה לתוכנה</a> <br><br>";
                        body += "<a style='color: dodgerblue; text-decoration: underline;' href = 'https://extraschoolclient2.azurewebsites.net'> לכניסה לאתר </a><br>";
                        body += "<a style='color: dodgerblue; text-decoration: underline;' href = 'https://drive.google.com/file/d/17_zSq8HERuXRBzB2zGGYt1dSACiw1wNV/view?usp=sharing'> לסרטון הסבר על השימוש באתר</a> <br> <br>";
                        body += "<a> על כל שאלה או תקלה ניתן לפנות לתמיכה </a> <br>";
                        body += "<a><span style='font-weight: bold' > טלפון:</span> 0733638688 </a> <br>";
                        body += "<a style='font-weight: bold'> מייל: </a> <a href='mailto:more21service@gmail.com' > more21service@gmail.com </a> <br><br>";
                        body += "<a>בהצלחה רבה </a> <br>";
                        body += "<img  src='https://extraschoolclient2.azurewebsites.net/assets/Image/LogoMail.jpg' style='width: 15%; height: 15%;'/>";


                        _userService.SendEmailWithPassword(emailAddress, message, body);
                    });
                }
                return Ok(u);
            }
            catch (Exception e)
            {
                return Ok(false);
            }
        }

        //עדכון משתמש
        [HttpPost("UpdateUser/{userId}")]
        public IActionResult UpdateUser([FromBody] AppUserPerSchoolWithDetailsDTO user, int userId)
        {
            try
            {
                return Ok(_userService.UpdateUser(user, userId));
            }
            catch (Exception e)
            {
                return Ok(false);
            }
        }

        //מחיקת משתמש
        [HttpDelete("DeleteUser/{UserID}/{SchoolId}")]
        public IActionResult DeleteUser(int UserID, int SchoolId)
        {
            try
            {
                return Ok(_userService.DeleteUser(UserID, SchoolId));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        //שליחת אמייל עם הסיסמא
        //יצא משימוש-נשלח מתוך הוספת משתמש
        //[HttpGet("SendEmailWithPassword/{emailAddress}/{message}/{body}")]
        //public IActionResult SendEmailWithPassword(string emailAddress, string message,string body)
        //{
        //    try
        //    {
        //        return Ok(_userService.SendEmailWithPassword(emailAddress, message, body));
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}
    }
}
