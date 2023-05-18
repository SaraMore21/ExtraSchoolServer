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

    public class DocumentPerFatherCourseController : ControllerBase
    {
        private readonly IDocumentPerFatherCourseService _DocumentPerFatherCourseService;
        private readonly IFatherCourseService _FatherCourseService;
        private readonly string _azureToken;
        private readonly string _azureConnectionString;
        private readonly string _azureContainerName;

        public DocumentPerFatherCourseController(IDocumentPerFatherCourseService DocumentPerFatherCourseService,
             IFatherCourseService FatherCourseService)
        {
            _DocumentPerFatherCourseService = DocumentPerFatherCourseService;
            _FatherCourseService = FatherCourseService;
            _azureConnectionString = "DefaultEndpointsProtocol=https;AccountName=storagefilesmore21;AccountKey=jjoAcM0UWI8LAXLJXj/BSEmuq1cXz54WoM+VR9fO6rhUNjji3WEoBvqEzdc83up+HJxudzpJVLIjCo9djfvtRg==;EndpointSuffix=core.windows.net";
            _azureContainerName = "upload-container";
            _azureToken = "sp=r&st=2021-09-05T07:09:22Z&se=4000-01-01T16:09:22Z&spr=https&sv=2020-08-04&sr=c&sig=rfQUXoumLEarC%2BNrpsSX1d0tH%2FmupgC%2F0QWn4qpq49k%3D";
        }

        [HttpGet("GetLstDocumentPerFatherCourse/{SchoolId}/{FatherCourseId}")]
        public IActionResult GetLstDocumentPerFatherCourse(int SchoolId, int FatherCourseId)
        {
            try
            {
                var list = _DocumentPerFatherCourseService.GetLstDocumentPerFatherCourse(FatherCourseId, SchoolId);
                list.ForEach(f =>
                {
                    if (f.Path != null && f.Path != "")
                        f.Path += "?" + _azureToken;
                });
                var list2 = list.GroupBy(g => g.RequiredDocumentPerFatherCourseId);
                return Ok(list2);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpPost("UploadDocumentPerFatherCourse/{uniqueCodeID}")]
        public IActionResult UploadDocumentPerFatherCourse([FromBody] AppDocumentPerFatherCourseDTO DocumentPerFatherCourseDTO, int uniqueCodeID=0)
        {
            try
            {

                AppDocumentPerFatherCourseDTO Result = _DocumentPerFatherCourseService.UploadDocumentPerFatherCourse(DocumentPerFatherCourseDTO, uniqueCodeID);
                if (Result != null)
                    Result.Path += "?" + _azureToken;
                return Ok(Result);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

        [HttpPost("UploadFewDocumentsPerFatherCourse/{NameFolder}/{uniqueCodeID}/{userId}")]
        public IActionResult UploadFewDocumentsPerFatherCourse(string NameFolder, [FromBody] List<AppDocumentPerFatherCourseDTO> LstDocumentPerFatherCourseDTO, int uniqueCodeID, int userId)
        {
            try
            {

                var Result = _DocumentPerFatherCourseService.UploadFewDocumentsPerFatherCourse(LstDocumentPerFatherCourseDTO, NameFolder,uniqueCodeID, userId);
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

        [HttpDelete("DeleteDocumentPerFatherCourse/{idDocumentPerFatherCourse}/{idFatherCourse}")]
        public IActionResult DeleteDocumentPerFatherCourse(int idDocumentPerFatherCourse, int idFatherCourse)
        {
            try
            {

                return Ok(_DocumentPerFatherCourseService.DeleteDocumentPerFatherCourse(idDocumentPerFatherCourse, idFatherCourse));

            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

        [HttpDelete("DeleteFewDocumentPerFatherCourse/{idFolder}/{requiredDocumentPerFatherCourseId}")]
        public IActionResult DeleteFewDocumentPerFatherCourse(int idFolder, int requiredDocumentPerFatherCourseId)
        {
            try
            {

                return Ok(_DocumentPerFatherCourseService.DeleteFewDocumentPerFatherCourse(idFolder, requiredDocumentPerFatherCourseId));

            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

        [HttpGet("SaveNameFile/{idfile}/{NameFile}")]
        public IActionResult SaveNameFile(int idfile, string NameFile)
        {
            try
            {
                _DocumentPerFatherCourseService.SaveNameFile(idfile, NameFile);

                return Ok();
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }

}
