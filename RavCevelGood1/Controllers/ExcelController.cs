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
        [Route("UploadExcelFile/{schoolId}/{userId}")]
        public IActionResult UploadExcelFile(int schoolId, int userId, bool isFull = false)
        {
            try
            {
                var file = Request.Form.Files[0];
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), "Resources");

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fileType = fileName.Split('.').Last();
                    var invalidChars = Path.GetInvalidPathChars();
                    fileName = schoolId+'.' + DateTime.UtcNow.AddHours(2).ToString("dd-MM-yyyyHH_mm") + '.' + fileType;
                    //+DateTime.Today.ToShortDateString();
                    var fullPath = Path.Combine(pathToSave, fileName);
                    invalidChars.ToList().ForEach(c =>
                    {
                        fullPath = fullPath.Replace(c, '_');
                    });
                    if (!Directory.Exists("Resources/" + schoolId))
                    {
                        Directory.CreateDirectory("Resources/" + schoolId);
                    }
                    fullPath = Path.Combine("Resources", schoolId.ToString(), fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    bool retval = false;

                    if (isFull)
                        return Ok();// retval = BLL.ExcelReader.ReadExcelWorkBook(fullPath, mosad.Id);
                    else
                    {
                        List<string> tablesToRead = JsonConvert.DeserializeObject<List<string>>(Request.Form["tablesToRead"]);
                        // ImportExcelOpenXml.Fill_dataTable(fullPath);
                        retval = _ExcelService.ReadFewSheetsFromExcel(fullPath, schoolId, 1, tablesToRead, DateTime.Today, DateTime.Today, 0);
                    }
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

                return BadRequest(e.Message);
            }
        }
    }
}
