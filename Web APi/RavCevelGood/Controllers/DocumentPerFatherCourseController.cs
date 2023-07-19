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

        //שליפת כל המסמכים
        [HttpGet("GetLstDocumentPerFatherCourse/{SchoolId}/{FatherCourseId}")]
        public IActionResult GetLstDocumentPerFatherCourse(int SchoolId, int FatherCourseId)
        {
            try
            {
                var list = _DocumentPerFatherCourseService.GetLstDocumentPerFatherCourse(FatherCourseId, SchoolId);
                list = list.OrderBy(o => o.FolderId).ToList();
                List<AppDocumentPerFatherCourseDTO> lst = new List<AppDocumentPerFatherCourseDTO>();
                int index ;
                list.ForEach(f =>
                {
                    if (f.Path != null && f.Path != "")
                        f.Path += "?" + _azureToken;
                //    if(f.FolderId!= null && f.FolderId != 0)
                //    {
                //      if(list[list.Count-1].FolderId==)
                //    }
                //    else
                //    {
                //        lst.Add(f);
                //    }
                });

                var required = list.Where(w => w.RequiredDocumentPerFatherCourseId != null && w.RequiredDocumentPerFatherCourseId != 0);

                var exsist = list.Where(w => w.ExsistDocumentId != null && w.ExsistDocumentId != 0);

                var list1 = required.GroupBy(g => g.RequiredDocumentPerFatherCourseId);
                var list2 = exsist.GroupBy(g => g.ExsistDocumentId);
                list1=list1.Concat(list2);
                //var lst1= list2.ToList();
                //lst1.AddRange(list.Where(w => w.FolderId != null && w.FolderId != 0));
                return Ok(list1);
            }
            catch (Exception e)
            {
                return null;
            }
        }
        //העלאת מסמך בודד
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
        //העלאת מספר מסמכים - תיקיה
        [HttpPost("UploadFewDocumentsPerFatherCourse/{NameFolder}/{uniqueCodeID}/{userId}/{customerId}")]
        public IActionResult UploadFewDocumentsPerFatherCourse(string NameFolder, [FromBody] List<AppDocumentPerFatherCourseDTO> LstDocumentPerFatherCourseDTO, int uniqueCodeID, int userId, int customerId)
        {
            try
            {

                var Result = _DocumentPerFatherCourseService.UploadFewDocumentsPerFatherCourse(LstDocumentPerFatherCourseDTO, NameFolder,uniqueCodeID, userId, customerId);
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
        [HttpDelete("DeleteDocumentPerFatherCourse/{idDocumentPerFatherCourse}/{idFatherCourse}/{uniqueCodeDocumentId}")]
        public IActionResult DeleteDocumentPerFatherCourse(int idDocumentPerFatherCourse, int idFatherCourse,int uniqueCodeDocumentId)
        {
            try
            {

                return Ok(_DocumentPerFatherCourseService.DeleteDocumentPerFatherCourse(idDocumentPerFatherCourse, idFatherCourse, uniqueCodeDocumentId));

            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
        //מחיקת מספר מסמכים - תיקיה
        [HttpDelete("DeleteFewDocumentPerFatherCourse/{idFolder}/{requiredDocumentPerFatherCourseId}/{idFatherCourse}/{uniqueCodeDocumentId}")]
        public IActionResult DeleteFewDocumentPerFatherCourse(int idFolder, int requiredDocumentPerFatherCourseId,int idFatherCourse, int uniqueCodeDocumentId)
        {
            try
            {

                return Ok(_DocumentPerFatherCourseService.DeleteFewDocumentPerFatherCourse(idFolder, requiredDocumentPerFatherCourseId, idFatherCourse, uniqueCodeDocumentId));

            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
        //שמירת עריכת שם לקובץ
        [HttpGet("SaveNameFile/{idfile}/{NameFile}/{uniqeId}")]
        public IActionResult SaveNameFile(int idfile, string NameFile , int uniqeId)
        {
            try
            {
                _DocumentPerFatherCourseService.SaveNameFile(idfile, NameFile, uniqeId);

                return Ok();
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }

}
