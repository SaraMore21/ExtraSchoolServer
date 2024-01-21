using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Services;
using Services.Interfaces;
using Services.Classes;
using System.Globalization;
using System.Threading;

namespace RavCevelGood.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcelController : ControllerBase
    {

        private readonly IExcelService _ExcelService;

        public ExcelController(IExcelService ExcelService)
        {
            _ExcelService = ExcelService;
        }

        [HttpPost, DisableRequestSizeLimit]
        [Route("UploadExcelFile/{schoolId}/{userId}/{idyearbookPerSchool}/{StartDateStr}/{EndDateStr}/{IsNew}/{IsOverride}")]
        public async Task<IActionResult> UploadExcelFile(int schoolId, int userId, int idyearbookPerSchool, string StartDateStr, string EndDateStr, bool isFull = false, bool IsNew = false, bool IsOverride = false)
        {
         //   String str = "";
            try
            {
                new MailService().SendEmail("sariw1292@gmail.com", "תחילה", "");
                var file = Request.Form.Files[0];
               // str+="sent mail.\n now running: var file = Request.Form.Files[0]; \n file is:" + file;
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), "Resources");
                //  str += "\n var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), 'Resource'); \n pathToSave is:" + pathToSave;
                Thread.CurrentThread.CurrentCulture = new CultureInfo("he-IL");
                DateTime StartDate =/* Convert.ToDateTime(null);*/StartDateStr != null && StartDateStr != "" ? Convert.ToDateTime(StartDateStr) : Convert.ToDateTime(null);
             //   str += "\n DateTime StartDate =StartDateStr != null && StartDateStr != '' ? Convert.ToDateTime(StartDateStr) : Convert.ToDateTime(null); \n StartDate is:" + StartDate;
                DateTime EndDate = /*Convert.ToDateTime(null);*/EndDateStr != null && EndDateStr != "" ? Convert.ToDateTime(EndDateStr) : Convert.ToDateTime(null);
              //  str += "\n DateTime EndDate = EndDateStr != null && EndDateStr != '' ? Convert.ToDateTime(EndDateStr) : Convert.ToDateTime(null); \n EndDate is:" + EndDate;
                //new MailService().SendEmail("sariw1292@gmail.com", "תחילה2","");
                if (file.Length > 0)
                {
              //      str += "\n entered if (file.Length > 0) \n file.length is:" + file.Length;
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
               //     str += "\n var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim(`'`); \n fileName is:" + fileName;

                   var fileType = fileName.Split('.').Last();
              //      str += "\n var fileType = fileName.Split('.').Last(); \n fileType is:" + fileType;

                   var invalidChars = Path.GetInvalidPathChars();

              //      str += "\n var invalidChars = Path.GetInvalidPathChars(); \n invalidChars are:" + invalidChars;

                    fileName = schoolId + "." + DateTime.UtcNow.AddHours(2).ToString("dd-MM-yyyyHH_mm") + '.' + fileType;

                //    str += "\n fileName = schoolId + '.' + DateTime.UtcNow.AddHours(2).ToString('dd-MM-yyyyHH_mm') + '.' + fileType; \n fileName is: " + fileName;

                    //+DateTime.Today.ToShortDateString();
                    var fullPath = Path.Combine(pathToSave, fileName);

               //     str += "\n var fullPath = Path.Combine(pathToSave, fileName); \n fullPath is:" + fullPath;

                    invalidChars.ToList().ForEach(c =>
                    {
                        fullPath = fullPath.Replace(c, '_');
                    });
              //      str += "\n invalidChars.ToList().ForEach(c => \n{\n                        fullPath = fullPath.Replace(c, '_');\n                    }); \n fullPath is:" + fullPath;
                    if (!Directory.Exists("Resources/" + schoolId))
                    {
                        Directory.CreateDirectory("Resources/" + schoolId);
                    }
            //        str += "\n if (!Directory.Exists('Resources / ' + schoolId))\n                    {\n                        Directory.CreateDirectory('Resources/' + schoolId);\n                    }                    ";
                    fullPath = Path.Combine("Resources", schoolId.ToString(), fileName);
             //       str += "full path is:" + fullPath;
                    
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                     {
                        file.CopyTo(stream);
                    }

                    bool retval = false;

                    if (isFull)
                    {
                  //      str += "\n isFull=true";
                        return Ok();// retval = BLL.ExcelReader.ReadExcelWorkBook(fullPath, mosad.Id);
                        
                    }
                    else
                    {
                //        str += "\n isFull=false";
                        List<string> tablesToRead = JsonConvert.DeserializeObject<List<string>>(Request.Form["tablesToRead"]);
                        
                        // ImportExcelOpenXml.Fill_dataTable(fullPath);
                        retval = _ExcelService.ReadFewSheetsFromExcel(fullPath, schoolId, userId, tablesToRead, StartDate, EndDate, idyearbookPerSchool, IsNew, IsOverride);
                 //       str += "\n retval:" + retval;
                    }
                 //   new MailService().SendEmail("sariw1292@gmail.com", "TRY לוג", str);
                 //   new MailService().SendEmail("ravcevel@gmail.com", "TRY לוג", str);

                    if (retval)
                        return Ok();
                    else
                        return BadRequest();
                    
                }

                else
                {
                    return BadRequest("הקובץ ריק");
                }
                
            }
            catch (Exception e)
            {
                new MailService().SendEmail("sariw1292@gmail.com", "שגיאה", e.Message);
                new MailService().SendEmail("ravcevel@gmail.com", "שגיאה", e.Message+"השגיאה קרתה בפונקציה: " +e.StackTrace);
             //   new MailService().SendEmail("sariw1292@gmail.com", " לוג CATCH", str);
           //     new MailService().SendEmail("ravcevel@gmail.com", " לוג CATCH", str);
                return BadRequest(e.Message);
            }
        }

        [HttpGet("ExportExcelFile")]
        public IActionResult ExportExcelFile(int schoolId)
        {
            try
            {
                _ExcelService.ExportExcelFile(schoolId);

                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("downloadFatherCourseExcel/{idschool}")]
        public IActionResult downloadFatherCourseExcel(string idschool)
        {
            try
            {
                // Generate your Excel data and save it as a byte array
                byte[] excelData = _ExcelService.downloadFatherCourseExcel(idschool);

                // Set the content type and provide the byte array as a file attachment
               var a=  File(excelData, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "fatherCourse" + DateTime.UtcNow.AddHours(2).ToString("dd-MM-yyyyHH_mm") + ".xlsx");
                return a;


                //return Ok(_ExcelService.downloadFatherCourseExcel(idschool,email));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }
        [HttpGet("downloadCourseExcel/{idschool}/{idYearbook}")]
        public IActionResult downloadCourseExcel(string idschool,int idYearbook)
        {
            try
            {
                // Generate your Excel data and save it as a byte array
                byte[] excelData = _ExcelService.downloadCourseExcel(idschool,idYearbook);

                // Set the content type and provide the byte array as a file attachment
                var a = File(excelData, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Course" + DateTime.UtcNow.AddHours(2).ToString("dd-MM-yyyyHH_mm") + ".xlsx");
                return a;


                //return Ok(_ExcelService.downloadFatherCourseExcel(idschool,email));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        [HttpGet("downloadScheduleRegularExcel/{idschool}/{idYearbook}")]
        public IActionResult downloadScheduleRegularExcel(string idschool, int idYearbook)
        {
            try
            {
                // Generate your Excel data and save it as a byte array
                byte[] excelData = _ExcelService.downloadScheduleRegularExcel(idschool, idYearbook);

                // Set the content type and provide the byte array as a file attachment
                var a = File(excelData, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Course" + DateTime.UtcNow.AddHours(2).ToString("dd-MM-yyyyHH_mm") + ".xlsx");
                return a;


                //return Ok(_ExcelService.downloadFatherCourseExcel(idschool,email));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }


    }
}
