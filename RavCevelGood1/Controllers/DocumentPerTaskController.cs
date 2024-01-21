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
    public class DocumentPerTaskController : ControllerBase
    {
        private readonly IDocumentPerTaskService _DocumentPerTaskService;
        private readonly ITaskService _TaskService;
        private readonly string _azureToken;
        private readonly string _azureConnectionString;
        private readonly string _azureContainerName;

        public DocumentPerTaskController(IDocumentPerTaskService DocumentPerTaskService,
             ITaskService TaskService)
        {
            _DocumentPerTaskService = DocumentPerTaskService;
            _TaskService = TaskService;
            _azureConnectionString = "DefaultEndpointsProtocol=https;AccountName=storagefilesmore21;AccountKey=jjoAcM0UWI8LAXLJXj/BSEmuq1cXz54WoM+VR9fO6rhUNjji3WEoBvqEzdc83up+HJxudzpJVLIjCo9djfvtRg==;EndpointSuffix=core.windows.net";
            _azureContainerName = "upload-container";
            _azureToken = "sp=r&st=2021-09-05T07:09:22Z&se=4000-01-01T16:09:22Z&spr=https&sv=2020-08-04&sr=c&sig=rfQUXoumLEarC%2BNrpsSX1d0tH%2FmupgC%2F0QWn4qpq49k%3D";
        }

        [HttpGet("GetLstDocumentPerTask/{SchoolId}/{TaskId}")]
        public IActionResult GetLstDocumentPerTask(int SchoolId, int TaskId)
        {
            try
            {
                var list = _DocumentPerTaskService.GetLstDocumentPerTask(TaskId, SchoolId);
                list.ForEach(f =>
                {
                    if (f.Path != null && f.Path != "")
                        f.Path += "?" + _azureToken;
                });
                var list2 = list.GroupBy(g =>g.RequiredDocumentPerTaskId);
                return Ok(list2);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpPost("UploadDocumentPerTask")]
        public IActionResult UploadDocumentPerTask([FromBody] AppDocumentPerTaskDTO DocumentPerTaskDTO)
        {
            try
            {

                AppDocumentPerTaskDTO Result = _DocumentPerTaskService.UploadDocumentPerTask(DocumentPerTaskDTO);
                if (Result != null)
                    Result.Path += "?" + _azureToken;
                return Ok(Result);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

        [HttpPost("UploadFewDocumentsPerTask/{NameFolder}")]
        public IActionResult UploadFewDocumentsPerTask(string NameFolder,[FromBody] List<AppDocumentPerTaskDTO> LstDocumentPerTaskDTO)
        {
            try
            {

                var Result = _DocumentPerTaskService.UploadFewDocumentsPerTask(LstDocumentPerTaskDTO, NameFolder);
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

        [HttpDelete("DeleteDocumentPerTask/{idDocumentPerTask}/{idTask}")]
        public IActionResult DeleteDocumentPerTask(int idDocumentPerTask, int idTask)
        {
            try
            {

                return Ok(_DocumentPerTaskService.DeleteDocumentPerTask(idDocumentPerTask, idTask));

            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

        [HttpDelete("DeleteFewDocumentPerTask/{idFolder}/{requiredDocumentPerTaskId}")]
        public IActionResult DeleteFewDocumentPerTask(int idFolder, int requiredDocumentPerTaskId)
        {
            try
            {

                return Ok(_DocumentPerTaskService.DeleteFewDocumentPerTask(idFolder, requiredDocumentPerTaskId));

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
                 _DocumentPerTaskService.SaveNameFile(idfile, NameFile);

                return Ok();
            }
            catch (Exception e)
            {
                return null;
            }
        }
        
    }
}
