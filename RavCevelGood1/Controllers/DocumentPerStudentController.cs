using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
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
    public class DocumentPerStudentController : ControllerBase
    {
        private readonly IDocumentPerStudentService _DocumentPerStudentService;
        private readonly IStudentService _StudentService;
        private readonly string _azureToken;
        private readonly string _azureConnectionString;
        private readonly string _azureContainerName;

        public DocumentPerStudentController(IDocumentPerStudentService DocumentPerStudentService,
             IStudentService StudentService)
        {
            _DocumentPerStudentService = DocumentPerStudentService;
            _StudentService = StudentService;
            _azureConnectionString = "DefaultEndpointsProtocol=https;AccountName=storagefilesmore21;AccountKey=jjoAcM0UWI8LAXLJXj/BSEmuq1cXz54WoM+VR9fO6rhUNjji3WEoBvqEzdc83up+HJxudzpJVLIjCo9djfvtRg==;EndpointSuffix=core.windows.net";
            _azureContainerName = "upload-container";
            _azureToken = "sp=r&st=2021-09-05T07:09:22Z&se=4000-01-01T16:09:22Z&spr=https&sv=2020-08-04&sr=c&sig=rfQUXoumLEarC%2BNrpsSX1d0tH%2FmupgC%2F0QWn4qpq49k%3D";
        }

        [HttpGet("GetLstDocumentPerStudent/{SchoolId}/{studentId}")]
        public IActionResult GetLstDocumentPerStudent(int SchoolId, int studentId)
        {
            try
            {
                var list = _DocumentPerStudentService.GetLstDocumentPerStudent(studentId, SchoolId);
                list.ForEach(f =>
                {
                    if (f.Path != null && f.Path != "")
                        f.Path +="?"+ _azureToken;
                });
                return Ok(list);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpPost("UploadDocumentPerStudent")]
        public  IActionResult UploadDocumentPerStudent([FromBody]AppDocumentPerStudentDTO DocumentPerStudentDTO)
        {
            try
            {

                AppDocumentPerStudentDTO Result=_DocumentPerStudentService.UploadDocumentPerStudent(DocumentPerStudentDTO);
                if (Result != null)
                    Result.Path +="?"+ _azureToken;
                return Ok(Result);

            }
            catch (Exception ex)
            {

                return BadRequest( ex.InnerException!=null?ex.InnerException.Message:ex.Message);
            }
        }

        [HttpDelete("DeleteDocumentPerStudent/{idDocumentPerStudent}/{idStudent}")]
        public IActionResult DeleteDocumentPerStudent(int idDocumentPerStudent,int idStudent)
        {
            try
            {

                _DocumentPerStudentService.DeleteDocumentPerStudent(idDocumentPerStudent,idStudent);
             
                return Ok();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

    }
}
