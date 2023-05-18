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

        //שליפת כל המסמכים
        [HttpGet("GetLstDocumentPerTask/{SchoolId}/{TaskId}")]
        public IActionResult GetLstDocumentPerTask(int SchoolId, int TaskId)
        {
            try
            {
                var list = _DocumentPerTaskService.GetLstDocumentPerTask(TaskId, SchoolId);
                list = list.OrderBy(o => o.FolderId).ToList();
                List<AppDocumentPerTaskDTO> lst = new List<AppDocumentPerTaskDTO>();
                int index;
                list.ForEach(f =>
                {
                    if (f.Path != null && f.Path != "")
                        f.Path += "?" + _azureToken;
                });

                var required = list.Where(w => w.RequiredDocumentPerTaskId != null && w.RequiredDocumentPerTaskId != 0);

                var exsist = list.Where(w => w.ExsistDocumentId != null && w.ExsistDocumentId != 0);

                var list1 = required.GroupBy(g => g.RequiredDocumentPerTaskId);
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
        [HttpPost("UploadDocumentPerTask/{uniqueCodeID}")]
        public IActionResult UploadDocumentPerTask([FromBody] AppDocumentPerTaskDTO DocumentPerTaskDTO, int uniqueCodeID = 0)
        {
            try
            {

                AppDocumentPerTaskDTO Result = _DocumentPerTaskService.UploadDocumentPerTask(DocumentPerTaskDTO, uniqueCodeID);
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
        [HttpPost("UploadFewDocumentsPerTask/{NameFolder}/{uniqueCodeID}/{userId}/{customerId}")]
        public IActionResult UploadFewDocumentsPerTask(string NameFolder, [FromBody] List<AppDocumentPerTaskDTO> LstDocumentPerTaskDTO, int uniqueCodeID, int userId, int customerId)
        {
            try
            {

                var Result = _DocumentPerTaskService.UploadFewDocumentsPerTask(LstDocumentPerTaskDTO, NameFolder, uniqueCodeID, userId, customerId);
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
        [HttpDelete("DeleteDocumentPerTask/{idDocumentPerTask}/{idTask}/{uniqueCodeDocumentId}")]
        public IActionResult DeleteDocumentPerTask(int idDocumentPerTask, int idTask, int uniqueCodeDocumentId)
        {
            try
            {

                return Ok(_DocumentPerTaskService.DeleteDocumentPerTask(idDocumentPerTask, idTask, uniqueCodeDocumentId));

            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
        //מחיקת מספר מסמכים - תיקיה
        [HttpDelete("DeleteFewDocumentPerTask/{idFolder}/{requiredDocumentPerTaskId}/{idTask}/{uniqueCodeDocumentId}")]
        public IActionResult DeleteFewDocumentPerTask(int idFolder, int requiredDocumentPerTaskId, int idTask, int uniqueCodeDocumentId)
        {
            try
            {

                return Ok(_DocumentPerTaskService.DeleteFewDocumentPerTask(idFolder, requiredDocumentPerTaskId, idTask, uniqueCodeDocumentId));

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
                _DocumentPerTaskService.SaveNameFile(idfile, NameFile, uniqeId);

                return Ok();
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}
