using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO.Classes;

namespace RavCevelGood.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleRegularController : ControllerBase
    {
        private readonly IScheduleRegularService _scheduleRegularService;
        public ScheduleRegularController(IScheduleRegularService scheduleRegularService)
        {
            _scheduleRegularService = scheduleRegularService;
        }

        //שליפת מערכת קבועה לשבוע -לפי תאריך וקבוצה
        [HttpGet("GetScheduleRegularPerWeek/{ScheduleDate}/{GroupId}")]
        public IActionResult GetScheduleRegularPerWeek(string ScheduleDate, int GroupId)
        {
            try
            {
                return Ok(_scheduleRegularService.GetScheduleRegularPerWeek(DateTime.ParseExact(ScheduleDate, "dd-MM-yyyy", null), GroupId));
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException != null ? e.InnerException.Message : e.Message);

            }
        }

        //עריכת מערכת קבועה
        [HttpPost("UpdateScheduleRegularByWebsite/{userId}/{date}")]
        public IActionResult UpdateScheduleRegularByWebsite([FromBody] AppScheduleRegularDTO ScheduleRegular,int userId,string date)
        {
            try
            {
                return Ok(_scheduleRegularService.UpdateScheduleRegularByWebsite(ScheduleRegular,userId,Convert.ToDateTime(date)));
            }
            catch(Exception e)
            {
                return BadRequest(e.InnerException != null ? e.InnerException.Message : e.Message);
            }
        }

    }
}
