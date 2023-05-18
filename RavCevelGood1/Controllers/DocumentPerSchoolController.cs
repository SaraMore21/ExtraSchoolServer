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

        [HttpGet("GetLstDocumentPerSchool/{SchoolId}")]
        public IActionResult GetLstDocumentPerSchool(int SchoolId)
        {
            try
            {
                var list = _DocumentPerSchoolService.GetLstDocumentPerSchool(SchoolId);
                list.ForEach(f =>
                {
                    if (f.Path != null && f.Path != "")
                        f.Path += "?" + _azureToken;
                });
                var list2 = list.GroupBy(g => g.RequiredDocumentPerSchoolId);
                //var list2 = list.GroupBy(g => g.FolderId != null ? g.FolderId : g.RequiredDocumentPerSchoolId);
                return Ok(list2);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpPost("UploadDocumentPerSchool")]
        public IActionResult UploadDocumentPerSchool([FromBody] AppDocumentPerSchoolDTO DocumentPerSchoolDTO)
        {
            try
            {

                AppDocumentPerSchoolDTO Result = _DocumentPerSchoolService.UploadDocumentPerSchool(DocumentPerSchoolDTO);
                if (Result != null)
                    Result.Path += "?" + _azureToken;
                return Ok(Result);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

        [HttpPost("UploadFewDocumentsPerSchool/{NameFolder}")]
        public IActionResult UploadFewDocumentsPerSchool(string NameFolder, [FromBody] List<AppDocumentPerSchoolDTO> LstDocumentPerSchoolDTO)
        {
            try
            {

                var Result = _DocumentPerSchoolService.UploadFewDocumentsPerSchool(LstDocumentPerSchoolDTO, NameFolder);
                if (Result != null)
                    Result.ForEach(f =>
                    {
                        f.Path += "?" + _azureToken;
                    });
                return Ok(Result);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

        [HttpDelete("DeleteDocumentPerSchool/{idDocumentPerSchool}/{idSchool}")]
        public IActionResult DeleteDocumentPerSchool(int idDocumentPerSchool, int idSchool)
        {
            try
            {

                return Ok(_DocumentPerSchoolService.DeleteDocumentPerSchool(idDocumentPerSchool, idSchool));

            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

        [HttpDelete("DeleteFewDocumentPerSchool/{idFolder}/{requiredDocumentPerSchoolId}")]
        public IActionResult DeleteFewDocumentPerSchool(int idFolder, int requiredDocumentPerSchoolId)
        {
            try
            {

                return Ok(_DocumentPerSchoolService.DeleteFewDocumentPerSchool(idFolder, requiredDocumentPerSchoolId));

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
                _DocumentPerSchoolService.SaveNameFile(idfile, NameFile);

                return Ok();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }

}
