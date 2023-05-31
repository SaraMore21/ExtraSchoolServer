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

        [HttpGet("GetLstDocumentPerStudent/{SchoolId}/{StudentId}")]
        public IActionResult GetLstDocumentPerStudent(int SchoolId, int StudentId)
        {
            try
            {
                var list = _DocumentPerStudentService.GetLstDocumentPerStudent(StudentId, SchoolId);
                list.ForEach(f =>
                {
                    if (f.Path != null && f.Path != "")
                        f.Path += "?" + _azureToken;
                });

                //כל הדרושים וקיימים של דרושים
                var required = list.Where(w => w.RequiredDocumentPerStudentId != null && w.RequiredDocumentPerStudentId != 0);
                //כל הקיימים 
                var exsist = list.Where(w => w.ExsistDocumentId != null && w.ExsistDocumentId != 0);
                var list1 = required.GroupBy(g => g.RequiredDocumentPerStudentId);
                var list2 = exsist.GroupBy(g => g.ExsistDocumentId);
                list1 = list1.Concat(list2);

                return Ok(list1);

            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpPost("UploadDocumentPerStudent")]
        public IActionResult UploadDocumentPerStudent([FromBody] AppDocumentPerStudentDTO DocumentPerStudentDTO)
        {
            try
            {

                AppDocumentPerStudentDTO Result = _DocumentPerStudentService.UploadDocumentPerStudent(DocumentPerStudentDTO);
                if (Result != null)
                    Result.Path += "?" + _azureToken;
                return Ok(Result);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

        [HttpPost("UploadFewDocumentsPerStudent/{NameFolder}")]
        public IActionResult UploadFewDocumentsPerStudent(string NameFolder, [FromBody] List<AppDocumentPerStudentDTO> LstDocumentPerStudentDTO)
        {
            try
            {

                var Result = _DocumentPerStudentService.UploadFewDocumentsPerStudent(LstDocumentPerStudentDTO, NameFolder);
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

        [HttpDelete("DeleteDocumentPerStudent/{idDocumentPerStudent}/{idStudent}")]
        public IActionResult DeleteDocumentPerStudent(int idDocumentPerStudent, int idStudent)
        {
            try
            {

                return Ok(_DocumentPerStudentService.DeleteDocumentPerStudent(idDocumentPerStudent, idStudent));

            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

        [HttpDelete("DeleteFewDocumentPerStudent/{idFolder}/{requiredDocumentPerStudentId}")]
        public IActionResult DeleteFewDocumentPerStudent(int idFolder, int requiredDocumentPerStudentId)
        {
            try
            {

                return Ok(_DocumentPerStudentService.DeleteFewDocumentPerStudent(idFolder, requiredDocumentPerStudentId));

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
                _DocumentPerStudentService.SaveNameFile(idfile, NameFile);

                return Ok();
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}
