using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Classes;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RavCevelGood.Controllers
{
    [Route("api/School")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly ISchoolService _SchoolService;
        private readonly ICacheService _CacheService;

        public SchoolController( ISchoolService SchoolService)
        {
            _SchoolService = SchoolService;
        }

        //שליפת מוסד לפי ID
        [HttpGet("School/{schoolId}")]
        public IActionResult School(int schoolId)
        {
            try
            {
                var response = (_SchoolService.GetSchoolById(schoolId));
                return Ok(response);
            }
            catch (Exception)
            {
                throw;
            }
        }
        //שליפת טבלאות בסיס
        [HttpGet("TableCode")]
        public IActionResult TableCode()
        {
            try
            {
                var response = (_SchoolService.GetAllTable());

                return Ok(response);
            }
            catch (Exception e)
            {

                throw;
            }
        }
        //שליחת סיסמא למייל ע"פ שם משתמש
        [HttpGet("GetPasswordToEmailByUserCode/{UserCode}/{Email}")]
        public IActionResult GetPasswordToEmailByUserCode(string UserCode,string Email)
        {
            try { 
            return Ok(_SchoolService.GetPasswordToEmailByUserCode(UserCode,Email));
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        //שליפת מוסדות למשתמש ע"פ שם משתמש וסיסמא
        [HttpGet("GetSchoolByUserCodeAndPassword/{UserCode}/{UserPassword}")]
        public IActionResult GetSchoolByUserCodeAndPassword(string UserCode, string UserPassword)
        {
            try
            {
                return Ok(_SchoolService.GetSchoolByUserCodeAndPassword(UserCode, UserPassword));
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        //שליפת שנתונים למוסד
        [HttpGet("GetAllYearbook/{SchoolId}")]
        public IActionResult GetAllYearbook(int SchoolId)
        {
            try
            {
                return Ok(_SchoolService.GetAllYearbook(SchoolId));
            }
            catch(Exception e) 
            { return null; }
        }
        //הוספת שנתון למוסד
        [HttpGet("AddYearbook/{FromDate}/{ToDate}/{Name}/{UserCreatedId}/{SchoolId}")]
        public IActionResult AddYearbook(string FromDate,string ToDate,string Name,int UserCreatedId,int SchoolId)
        {
            try { 
            DateTime fromDate = DateTime.Parse(FromDate); DateTime toDate = DateTime.Parse(ToDate);
            return Ok(_SchoolService.AddYearbook(fromDate, toDate, Name, UserCreatedId,SchoolId));
            }
            catch
            {
                return BadRequest();
            }
        }

       //שליפת מוסדות ושנתונים ללקוח
       [HttpGet("GetAllSchoolAndYearbookPerCustomer/{UserCode}/{UserPassword}")]
       public IActionResult GetAllSchoolAndYearbookPerCustomer(string UserCode,string UserPassword)
       {
            return Ok(_SchoolService.GetAllSchoolAndYearbookPerCustomer(UserCode, UserPassword));
       }
        //[HttpGet("GeCodeTable/")]
        //public IActionResult GetCodeTable()
        //{
        //    try
        //    {
        //        return Ok(_SchoolService.GetPasswordToEmailByUserCode(UserCode));
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}
    }
}
