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

    public class DocumentPerSchoolController : ControllerBase
    {
        private readonly IDocumentPerSchoolService _DocumentPerSchoolService;
        private readonly ISchoolService _SchoolService;
        private readonly string _azureToken;
        private readonly string _azureConnectionString;
        private readonly string _azureContainerName;

        public DocumentPerSchoolController(IDocumentPerSchoolService DocumentPerSchoolService,
             ISchoolService SchoolService)
        {
            _DocumentPerSchoolService = DocumentPerSchoolService;
            _SchoolService = SchoolService;
            _azureConnectionString = "DefaultEndpointsProtocol=https;AccountName=storagefilesmore21;AccountKey=jjoAcM0UWI8LAXLJXj/BSEmuq1cXz54WoM+VR9fO6rhUNjji3WEoBvqEzdc83up+HJxudzpJVLIjCo9djfvtRg==;EndpointSuffix=core.windows.net";
            _azureContainerName = "upload-container";
            _azureToken = "sp=r&st=2021-09-05T07:09:22Z&se=4000-01-01T16:09:22Z&spr=https&sv=2020-08-04&sr=c&sig=rfQUXoumLEarC%2BNrpsSX1d0tH%2FmupgC%2F0QWn4qpq49k%3D";
        }


        //שליפת כל המסמכים
        [HttpGet("GetLstDocumentPerSchool/{SchoolId}")]
        public IActionResult GetLstDocumentPerSchool(int SchoolId)
        {
            try
            {
                var list = _DocumentPerSchoolService.GetLstDocumentPerSchool(SchoolId);
                list = list.OrderBy(o => o.FolderId).ToList();
                list.ForEach(f =>
                {
                    if (f.Path != null && f.Path != "")
                        f.Path += "?" + _azureToken;
                });

                var required = list.Where(w => w.RequiredDocumentPerSchoolId != null && w.RequiredDocumentPerSchoolId != 0);

                var exsist = list.Where(w => w.ExsistDocumentId != null && w.ExsistDocumentId != 0);

                var list1 = required.GroupBy(g => g.RequiredDocumentPerSchoolId);
                var list2 = exsist.GroupBy(g => g.ExsistDocumentId);
                list1 = list1.Concat(list2);

                return Ok(list1);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        //העלאת מסמך בודד
        [HttpPost("UploadDocumentPerSchool/{uniqueCodeID}")]
        public IActionResult UploadDocumentPerSchool([FromBody] AppDocumentPerSchoolDTO DocumentPerSchoolDTO, int uniqueCodeID = 0)
        {
            try
            {

                AppDocumentPerSchoolDTO Result = _DocumentPerSchoolService.UploadDocumentPerSchool(DocumentPerSchoolDTO, uniqueCodeID);
                if (Result != null)
                    Result.Path += "?" + _azureToken;
                return Ok(Result);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
        //העלאת מספר מסמכים - תיקיה
        [HttpPost("UploadFewDocumentsPerSchool/{NameFolder}/{uniqueCodeID}/{userId}/{customerId}")]
        public IActionResult UploadFewDocumentsPerSchool(string NameFolder, [FromBody] List<AppDocumentPerSchoolDTO> LstDocumentPerSchoolDTO, string uniqueCodeID, int userId, int customerId)
        {
            try
            {

                var Result = _DocumentPerSchoolService.UploadFewDocumentsPerSchool(LstDocumentPerSchoolDTO, NameFolder, uniqueCodeID, userId, customerId);
                if (Result != null)
                    Result.ForEach(f =>
                    {
                        f.Path += "?" + _azureToken;
                        f.FolderName = NameFolder;

                    });
                return Ok(Result);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
        //מחיקת מסמך
        [HttpDelete("DeleteDocumentPerSchool/{idDocumentPerSchool}/{idSchool}/{uniqueCodeDocumentId}")]
        public IActionResult DeleteDocumentPerSchool(int idDocumentPerSchool, int idSchool, int uniqueCodeDocumentId)
        {
            try
            {

                return Ok(_DocumentPerSchoolService.DeleteDocumentPerSchool(idDocumentPerSchool, idSchool, uniqueCodeDocumentId));

            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
        //מחיקת מספר מסמכים - תיקיה
        [HttpDelete("DeleteFewDocumentPerSchool/{idFolder}/{requiredDocumentPerSchoolId}/{idSchool}/{uniqueCodeDocumentId}")]
        public IActionResult DeleteFewDocumentPerSchool(int idFolder, int requiredDocumentPerSchoolId, int idSchool, int uniqueCodeDocumentId)
        {
            try
            {

                return Ok(_DocumentPerSchoolService.DeleteFewDocumentPerSchool(idFolder, requiredDocumentPerSchoolId, idSchool, uniqueCodeDocumentId));

            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
        //שמירת עריכת שם לקובץ
        [HttpGet("SaveNameFile/{idfile}/{NameFile}/{uniqeId}")]
        public IActionResult SaveNameFile(int idfile, string NameFile, int uniqeId)
        {
            try
            {
                _DocumentPerSchoolService.SaveNameFile(idfile, NameFile, uniqeId);

                return Ok();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }

}
