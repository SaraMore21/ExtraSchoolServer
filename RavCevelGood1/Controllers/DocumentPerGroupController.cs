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
                return Ok(list);
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

        [HttpDelete("DeleteDocumentPerGroup/{idDocumentPerGroup}/{idGroup}")]
        public IActionResult DeleteDocumentPerGroup(int idDocumentPerGroup, int idGroup)
        {
            try
            {

                _DocumentPerGroupService.DeleteDocumentPerGroup(idDocumentPerGroup, idGroup);

                return Ok();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}
