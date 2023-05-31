using DTO.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RavCevelGood.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentPerProfessionController : ControllerBase
    {
        private readonly IDocumentPerProfessionService _DocumentPerProfessionService;
        private readonly IProfessionService _ProfessionService;
        private readonly string _azureToken;
        private readonly string _azureConnectionString;
        private readonly string _azureContainerName;

        public DocumentPerProfessionController(IDocumentPerProfessionService DocumentPerProfessionService,
             IProfessionService ProfessionService)
        {
            _DocumentPerProfessionService = DocumentPerProfessionService;
            _ProfessionService = ProfessionService;
            _azureConnectionString = "DefaultEndpointsProtocol=https;AccountName=storagefilesmore21;AccountKey=jjoAcM0UWI8LAXLJXj/BSEmuq1cXz54WoM+VR9fO6rhUNjji3WEoBvqEzdc83up+HJxudzpJVLIjCo9djfvtRg==;EndpointSuffix=core.windows.net";
            _azureContainerName = "upload-container";
            _azureToken = "sp=r&st=2021-09-05T07:09:22Z&se=4000-01-01T16:09:22Z&spr=https&sv=2020-08-04&sr=c&sig=rfQUXoumLEarC%2BNrpsSX1d0tH%2FmupgC%2F0QWn4qpq49k%3D";
        }

        //שליפת כל המסמכים
        [HttpGet("GetLstDocumentPerProfession/{SchoolId}/{ProfessionId}")]
        public IActionResult GetLstDocumentPerProfession(int SchoolId, int ProfessionId)
        {
            try
            {
                var list = _DocumentPerProfessionService.GetLstDocumentPerProfession(ProfessionId, SchoolId);
                list = list.OrderBy(o => o.FolderId).ToList();
                List<AppDocumentPerProfessionDTO> lst = new List<AppDocumentPerProfessionDTO>();
                int index;
                list.ForEach(f =>
                {
                    if (f.Path != null && f.Path != "")
                        f.Path += "?" + _azureToken;
                });

                var required = list.Where(w => w.RequiredDocumentPerProfessionId != null && w.RequiredDocumentPerProfessionId != 0);

                var exsist = list.Where(w => w.ExsistDocumentId != null && w.ExsistDocumentId != 0);

                var list1 = required.GroupBy(g => g.RequiredDocumentPerProfessionId);
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
        [HttpPost("UploadDocumentPerProfession/{uniqueCodeID}")]
        public IActionResult UploadDocumentPerProfession([FromBody] AppDocumentPerProfessionDTO DocumentPerProfessionDTO, int uniqueCodeID = 0)
        {
            try
            {

                AppDocumentPerProfessionDTO Result = _DocumentPerProfessionService.UploadDocumentPerProfession(DocumentPerProfessionDTO, uniqueCodeID);
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
        [HttpPost("UploadFewDocumentsPerProfession/{NameFolder}/{uniqueCodeID}/{userId}/{customerId}")]
        public IActionResult UploadFewDocumentsPerProfession(string NameFolder, [FromBody] List<AppDocumentPerProfessionDTO> LstDocumentPerProfessionDTO, int uniqueCodeID, int userId, int customerId)
        {
            try
            {

                var Result = _DocumentPerProfessionService.UploadFewDocumentsPerProfession(LstDocumentPerProfessionDTO, NameFolder, uniqueCodeID, userId, customerId);
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
        [HttpDelete("DeleteDocumentPerProfession/{idDocumentPerProfession}/{idProfession}/{uniqueCodeDocumentId}")]
        public IActionResult DeleteDocumentPerProfession(int idDocumentPerProfession, int idProfession, int uniqueCodeDocumentId)
        {
            try
            {

                return Ok(_DocumentPerProfessionService.DeleteDocumentPerProfession(idDocumentPerProfession, idProfession, uniqueCodeDocumentId));

            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
        //מחיקת מספר מסמכים - תיקיה
        [HttpDelete("DeleteFewDocumentPerProfession/{idFolder}/{requiredDocumentPerProfessionId}/{idProfession}/{uniqueCodeDocumentId}")]
        public IActionResult DeleteFewDocumentPerProfession(int idFolder, int requiredDocumentPerProfessionId, int idProfession, int uniqueCodeDocumentId)
        {
            try
            {

                return Ok(_DocumentPerProfessionService.DeleteFewDocumentPerProfession(idFolder, requiredDocumentPerProfessionId, idProfession, uniqueCodeDocumentId));

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
                _DocumentPerProfessionService.SaveNameFile(idfile, NameFile, uniqeId);

                return Ok();
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}
