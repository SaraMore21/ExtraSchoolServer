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

    public class DocumentPerCourseController : ControllerBase
    {
        private readonly IDocumentPerCourseService _DocumentPerCourseService;
        private readonly ICourseService _CourseService;
        private readonly string _azureToken;
        private readonly string _azureConnectionString;
        private readonly string _azureContainerName;

        public DocumentPerCourseController(IDocumentPerCourseService DocumentPerCourseService,
             ICourseService CourseService)
        {
            _DocumentPerCourseService = DocumentPerCourseService;
            _CourseService = CourseService;
            _azureConnectionString = "DefaultEndpointsProtocol=https;AccountName=storagefilesmore21;AccountKey=jjoAcM0UWI8LAXLJXj/BSEmuq1cXz54WoM+VR9fO6rhUNjji3WEoBvqEzdc83up+HJxudzpJVLIjCo9djfvtRg==;EndpointSuffix=core.windows.net";
            _azureContainerName = "upload-container";
            _azureToken = "sp=r&st=2021-09-05T07:09:22Z&se=4000-01-01T16:09:22Z&spr=https&sv=2020-08-04&sr=c&sig=rfQUXoumLEarC%2BNrpsSX1d0tH%2FmupgC%2F0QWn4qpq49k%3D";
        }

        [HttpGet("GetLstDocumentPerCourse/{SchoolId}/{CourseId}")]
        public IActionResult GetLstDocumentPerCourse(int SchoolId, int CourseId)
        {
            try
            {
                var list = _DocumentPerCourseService.GetLstDocumentPerCourse(CourseId, SchoolId);
                list.ForEach(f =>
                {
                    if (f.Path != null && f.Path != "")
                        f.Path += "?" + _azureToken;
                });
                var list2 = list.GroupBy(g =>g.RequiredDocumentPerCourseId);
                return Ok(list2);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpPost("UploadDocumentPerCourse")]
        public IActionResult UploadDocumentPerCourse([FromBody] AppDocumentPerCourseDTO DocumentPerCourseDTO)
        {
            try
            {

                AppDocumentPerCourseDTO Result = _DocumentPerCourseService.UploadDocumentPerCourse(DocumentPerCourseDTO);
                if (Result != null)
                    Result.Path += "?" + _azureToken;
                return Ok(Result);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

        [HttpPost("UploadFewDocumentsPerCourse/{NameFolder}")]
        public IActionResult UploadFewDocumentsPerCourse(string NameFolder,[FromBody] List<AppDocumentPerCourseDTO> LstDocumentPerCourseDTO)
        {
            try
            {

                var Result = _DocumentPerCourseService.UploadFewDocumentsPerCourse(LstDocumentPerCourseDTO, NameFolder);
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

        [HttpDelete("DeleteDocumentPerCourse/{idDocumentPerCourse}/{idCourse}")]
        public IActionResult DeleteDocumentPerCourse(int idDocumentPerCourse, int idCourse)
        {
            try
            {

                return Ok(_DocumentPerCourseService.DeleteDocumentPerCourse(idDocumentPerCourse, idCourse));

            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

        [HttpDelete("DeleteFewDocumentPerCourse/{idFolder}/{requiredDocumentPerCourseId}")]
        public IActionResult DeleteFewDocumentPerCourse(int idFolder, int requiredDocumentPerCourseId)
        {
            try
            {

                return Ok(_DocumentPerCourseService.DeleteFewDocumentPerCourse(idFolder, requiredDocumentPerCourseId));

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
                 _DocumentPerCourseService.SaveNameFile(idfile, NameFile);

                return Ok();
            }
            catch (Exception e)
            {
                return null;
            }
        }
        
    }

}
