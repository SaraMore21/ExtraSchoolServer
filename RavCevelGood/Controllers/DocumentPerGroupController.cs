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
    public class DocumentPerGroupController : ControllerBase
    {
        private readonly IDocumentPerGroupService _DocumentPerGroupService;
        private readonly IGroupService _GroupService;
        private readonly string _azureToken;
        private readonly string _azureConnectionString;
        private readonly string _azureContainerName;

        public DocumentPerGroupController(IDocumentPerGroupService DocumentPerGroupService,
             IGroupService GroupService)
        {
            _DocumentPerGroupService = DocumentPerGroupService;
            _GroupService = GroupService;
            _azureConnectionString = "DefaultEndpointsProtocol=https;AccountName=storagefilesmore21;AccountKey=jjoAcM0UWI8LAXLJXj/BSEmuq1cXz54WoM+VR9fO6rhUNjji3WEoBvqEzdc83up+HJxudzpJVLIjCo9djfvtRg==;EndpointSuffix=core.windows.net";
            _azureContainerName = "upload-container";
            _azureToken = "sp=r&st=2021-09-05T07:09:22Z&se=4000-01-01T16:09:22Z&spr=https&sv=2020-08-04&sr=c&sig=rfQUXoumLEarC%2BNrpsSX1d0tH%2FmupgC%2F0QWn4qpq49k%3D";
        }

        [HttpGet("GetLstDocumentPerGroup/{SchoolId}/{GroupId}")]
        public IActionResult GetLstDocumentPerGroup(int SchoolId, int GroupId)
        {
            try
            {
                var list = _DocumentPerGroupService.GetLstDocumentPerGroup(GroupId, SchoolId);
                list.ForEach(f =>
                {
                    if (f.Path != null && f.Path != "")
                        f.Path += "?" + _azureToken;
                });

                //כל הדרושים וקיימים של דרושים
                var required = list.Where(w => w.RequiredDocumentPerGroupId != null && w.RequiredDocumentPerGroupId != 0);
                //כל הקיימים 
                var exsist = list.Where(w => w.ExsistDocumentId != null && w.ExsistDocumentId != 0);
                var list1 = required.GroupBy(g => g.RequiredDocumentPerGroupId);
                var list2 = exsist.GroupBy(g => g.ExsistDocumentId);
                list1 = list1.Concat(list2);

                return Ok(list1);

            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpPost("UploadDocumentPerGroup")]
        public IActionResult UploadDocumentPerGroup([FromBody] AppDocumentPerGroupDTO DocumentPerGroupDTO)
        {
            try
            {

                AppDocumentPerGroupDTO Result = _DocumentPerGroupService.UploadDocumentPerGroup(DocumentPerGroupDTO);
                if (Result != null)
                    Result.Path += "?" + _azureToken;
                return Ok(Result);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

        [HttpPost("UploadFewDocumentsPerGroup/{NameFolder}")]
        public IActionResult UploadFewDocumentsPerGroup(string NameFolder, [FromBody] List<AppDocumentPerGroupDTO> LstDocumentPerGroupDTO)
        {
            try
            {

                var Result = _DocumentPerGroupService.UploadFewDocumentsPerGroup(LstDocumentPerGroupDTO, NameFolder);
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

        [HttpDelete("DeleteDocumentPerGroup/{idDocumentPerGroup}/{idGroup}")]
        public IActionResult DeleteDocumentPerGroup(int idDocumentPerGroup, int idGroup)
        {
            try
            {

                return Ok(_DocumentPerGroupService.DeleteDocumentPerGroup(idDocumentPerGroup, idGroup));

            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

        [HttpDelete("DeleteFewDocumentPerGroup/{idFolder}/{requiredDocumentPerGroupId}")]
        public IActionResult DeleteFewDocumentPerGroup(int idFolder, int requiredDocumentPerGroupId)
        {
            try
            {

                return Ok(_DocumentPerGroupService.DeleteFewDocumentPerGroup(idFolder, requiredDocumentPerGroupId));

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
                _DocumentPerGroupService.SaveNameFile(idfile, NameFile);

                return Ok();
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
