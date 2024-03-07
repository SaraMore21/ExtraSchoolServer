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
    public class DocumentPerTaskExsistController : ControllerBase
    {
        private readonly IDocumentPerTaskExsistService _DocumentPerTaskExsistService;
        private readonly ITaskExsistService _TaskExsistService;
        private readonly string _azureToken;
        private readonly string _azureConnectionString;
        private readonly string _azureContainerName;

        public DocumentPerTaskExsistController(IDocumentPerTaskExsistService DocumentPerTaskExsistService,
             ITaskExsistService TaskExsistService)
        {
            _DocumentPerTaskExsistService = DocumentPerTaskExsistService;
            _TaskExsistService = TaskExsistService;
            _azureConnectionString = "DefaultEndpointsProtocol=https;AccountName=storagefilesmore21;AccountKey=jjoAcM0UWI8LAXLJXj/BSEmuq1cXz54WoM+VR9fO6rhUNjji3WEoBvqEzdc83up+HJxudzpJVLIjCo9djfvtRg==;EndpointSuffix=core.windows.net";
            _azureContainerName = "upload-container";
            _azureToken = "sp=r&st=2021-09-05T07:09:22Z&se=4000-01-01T16:09:22Z&spr=https&sv=2020-08-04&sr=c&sig=rfQUXoumLEarC%2BNrpsSX1d0tH%2FmupgC%2F0QWn4qpq49k%3D";
        }

        [HttpGet("GetLstDocumentPerTaskExsist/{SchoolId}/{TaskExsistId}")]
        public IActionResult GetLstDocumentPerTaskExsist(int SchoolId, int TaskExsistId)
        {
            try
            {
                var list = _DocumentPerTaskExsistService.GetLstDocumentPerTaskExsist(TaskExsistId, SchoolId);
                list.ForEach(f =>
                {
                    if (f.Path != null && f.Path != "")
                        f.Path += "?" + _azureToken;
                });

                //כל הדרושים וקיימים של דרושים
                var required = list.Where(w => w.RequiredDocumentPerTaskExsistId != null && w.RequiredDocumentPerTaskExsistId != 0);
                //כל הקיימים 
                var exsist = list.Where(w => w.ExsistDocumentId != null && w.ExsistDocumentId != 0);
                var list1 = required.GroupBy(g => g.RequiredDocumentPerTaskExsistId);
                var list2 = exsist.GroupBy(g => g.ExsistDocumentId);
                list1 = list1.Concat(list2);

                return Ok(list1);

            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpPost("UploadDocumentPerTaskExsist")]
        public IActionResult UploadDocumentPerTaskExsist([FromBody] AppDocumentPerTaskExsistDTO DocumentPerTaskExsistDTO)
        {
            try
            {

                AppDocumentPerTaskExsistDTO Result = _DocumentPerTaskExsistService.UploadDocumentPerTaskExsist(DocumentPerTaskExsistDTO);
                if (Result != null)
                    Result.Path += "?" + _azureToken;
                return Ok(Result);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

        [HttpPost("UploadFewDocumentsPerTaskExsist/{NameFolder}")]
        public IActionResult UploadFewDocumentsPerTaskExsist(string NameFolder, [FromBody] List<AppDocumentPerTaskExsistDTO> LstDocumentPerTaskExsistDTO)
        {
            try
            {

                var Result = _DocumentPerTaskExsistService.UploadFewDocumentsPerTaskExsist(LstDocumentPerTaskExsistDTO, NameFolder);
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

        [HttpDelete("DeleteDocumentPerTaskExsist/{idDocumentPerTaskExsist}/{idTaskExsist}")]
        public IActionResult DeleteDocumentPerTaskExsist(int idDocumentPerTaskExsist, int idTaskExsist)
        {
            try
            {

                return Ok(_DocumentPerTaskExsistService.DeleteDocumentPerTaskExsist(idDocumentPerTaskExsist, idTaskExsist));

            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

        [HttpDelete("DeleteFewDocumentPerTaskExsist/{idFolder}/{requiredDocumentPerTaskExsistId}")]
        public IActionResult DeleteFewDocumentPerTaskExsist(int idFolder, int requiredDocumentPerTaskExsistId)
        {
            try
            {

                return Ok(_DocumentPerTaskExsistService.DeleteFewDocumentPerTaskExsist(idFolder, requiredDocumentPerTaskExsistId));

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
                _DocumentPerTaskExsistService.SaveNameFile(idfile, NameFile);

                return Ok();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }

}
