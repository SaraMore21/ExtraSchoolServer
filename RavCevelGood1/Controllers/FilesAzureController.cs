using Azure.Identity;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs.Specialized;
using Azure.Storage.Sas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Services.Classes;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RavCevelGood.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesAzureController : ControllerBase
    {
        private readonly string _azureConnectionString;
        private readonly string _azureContainerName;
        private readonly string _azureToken;

        private readonly IUploadService _uploadService;
        private readonly IStudentService _StudentService;

        public FilesAzureController(IConfiguration configuration, IUploadService uploadService, IStudentService StudentService)
        {
            //_azureConnectionString = configuration.GetConnectionString("AzureConnectionString");
            _azureConnectionString = "DefaultEndpointsProtocol=https;AccountName=storagefilesmore21;AccountKey=jjoAcM0UWI8LAXLJXj/BSEmuq1cXz54WoM+VR9fO6rhUNjji3WEoBvqEzdc83up+HJxudzpJVLIjCo9djfvtRg==;EndpointSuffix=core.windows.net";
            _azureContainerName = "upload-container";
            _azureToken = "sp=r&st=2021-09-05T07:09:22Z&se=4000-01-01T16:09:22Z&spr=https&sv=2020-08-04&sr=c&sig=rfQUXoumLEarC%2BNrpsSX1d0tH%2FmupgC%2F0QWn4qpq49k%3D";
            _uploadService = uploadService ?? throw new ArgumentNullException(nameof(uploadService));
            _StudentService = StudentService;
        }


        [HttpPost, DisableRequestSizeLimit]
        [Route ("UploadAsync")]
        public async Task<IActionResult> UploadAsync()
        {
            try
            {
                var formCollection = await Request.ReadFormAsync();
                var file = formCollection.Files.First();
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    string fileURL = await _uploadService.UploadAsync(file.OpenReadStream(), fileName, file.ContentType);
                    return Ok(new { fileURL });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
        [Produces("text/plain")]

        [HttpPost, DisableRequestSizeLimit]
        [Route ("Upload")]
        public async Task<IActionResult> Upload( string path="",string FileName=" ")
        {
            try
            {

                //var containerName = "<container name>";
                //var accountName = "<storage account name>";
                //var key = "<storage account key>";
                //var cred = new StorageCredentials(accountName, key);
                //var account = new CloudStorageAccount(cred, true);
                //var container1 = account.CreateCloudBlobClient().GetContainerReference(containerName);

                //var writeOnlyPolicy = new SharedAccessBlobPolicy()
                //{
                //    SharedAccessStartTime = DateTime.Now,
                //    SharedAccessExpiryTime = DateTime.Now.AddHours(2),
                //    Permissions = SharedAccessBlobPermissions.Write
                //};

                //var sas1 = container1.GetSharedAccessSignature(writeOnlyPolicy);

                if (path!=null)
                path = path.Replace('-', '/');
            
                int i = 1;
                var formCollection = await Request.ReadFormAsync();
                var file = formCollection.Files.First();

                if (FileName == null || FileName == " ")
                    FileName = file.FileName;
                else
                    FileName = FileName+'.' + file.ContentType.Substring(file.ContentType.IndexOf('/')+1);
                if (file.Length > 0)
                {
                    var container = new BlobContainerClient(_azureConnectionString, _azureContainerName);
                    //var sas = container.GetSharedAccessSignature(writeOnlyPolicy);

                    var createResponse = await container.CreateIfNotExistsAsync();
                    if (createResponse != null && createResponse.GetRawResponse().Status == 201)
                        await container.SetAccessPolicyAsync(Azure.Storage.Blobs.Models.PublicAccessType.Blob);

                    var blob = container.GetBlobClient(path + "/" + FileName);
                    await blob.DeleteIfExistsAsync(Azure.Storage.Blobs.Models.DeleteSnapshotsOption.IncludeSnapshots);
                    using (var fileStream = file.OpenReadStream())
                    {
                        await blob.UploadAsync(fileStream, new BlobHttpHeaders { ContentType = file.ContentType });
                    }
       
                    return Ok( blob.Uri.ToString());
                }

                return BadRequest();
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpGet("GetAllFiles")]
        public async Task<IActionResult> GetAllFiles()
            {
                var blobs = new List<BlobDto>();
                var container = new BlobContainerClient(_azureConnectionString, _azureContainerName);

                await foreach (var blobItem in container.GetBlobsAsync())
                {
                    var uri = container.Uri.AbsoluteUri;
                    var name = blobItem.Name;
                    var fullUri = uri + "/" + name;

                    blobs.Add(new BlobDto { Name = name, Uri = fullUri, ContentType = blobItem.Properties.ContentType });
                }

                return Ok(blobs);
            }

        [HttpGet("Download/{path}")]
        public async Task<IActionResult> Download(string path)
        {
            path = path.Replace('!', '/');
            //path = "2/Students/366/3.vnd.ms-excel";
            var container = new BlobContainerClient(_azureConnectionString, _azureContainerName);

            var blob = container.GetBlobClient(path);

            if (await blob.ExistsAsync())
            {
                var a = await blob.DownloadAsync();

                return File(a.Value.Content, a.Value.ContentType, path);
            }

            return BadRequest();
        }

        [HttpGet("delete/{path}")]
        public async Task<IActionResult> delete(string path)
        {
            path = path.Replace('!', '/');
            //path = "2/Students/366/3.vnd.ms-excel";
            var container = new BlobContainerClient(_azureConnectionString, _azureContainerName);
            var blob = container.GetBlobClient(path);
            if (await blob.ExistsAsync())
            {
                var a = await blob.DeleteAsync();

                //return File(a.Value.Content, a.Value.ContentType, path);
                return Ok();
            }

            return BadRequest();
        }

        [HttpGet("GetAzureSASToken")]
        public IActionResult GetAzureSASToken()
        {

            // Construct the blob endpoint from the account name.
            string blobEndpoint = "https://storagefilesmore21.blob.core.windows.net";

            // Create a new Blob service client with Azure AD credentials.
            BlobClient blobClient = new BlobClient(new Uri(blobEndpoint),
                                                                 new DefaultAzureCredential());
           var s = GetUserDelegationSasBlob(blobClient);


            string accountName = "storagefilesmore21";
            string accountKey = "jjoAcM0UWI8LAXLJXj/BSEmuq1cXz54WoM+VR9fO6rhUNjji3WEoBvqEzdc83up+HJxudzpJVLIjCo9djfvtRg==";

            CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(accountName, accountKey), true);

            CloudBlobClient client = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer blobContainer = client.GetContainerReference("4");

            //Set the expiry time and permissions for the container.
            //In this case no start time is specified, so the shared access signature becomes valid immediately.
            SharedAccessBlobPolicy sasConstraints = new SharedAccessBlobPolicy();
            sasConstraints.SharedAccessExpiryTime = DateTimeOffset.UtcNow.AddMinutes(5);
            sasConstraints.Permissions = SharedAccessBlobPermissions.Read;

            //Generate the shared access signature on the container, setting the constraints directly on the signature.
            string sasContainerToken = blobContainer.GetSharedAccessSignature(sasConstraints);

            return  Ok( sasContainerToken);
        }

        async static Task<Uri> GetUserDelegationSasBlob(BlobClient blobClient)
        {
            BlobServiceClient blobServiceClient =
                blobClient.GetParentBlobContainerClient().GetParentBlobServiceClient();

            // Get a user delegation key for the Blob service that's valid for 7 days.
            // You can use the key to generate any number of shared access signatures 
            // over the lifetime of the key.
            Azure.Storage.Blobs.Models.UserDelegationKey userDelegationKey =
                await blobServiceClient.GetUserDelegationKeyAsync(DateTimeOffset.UtcNow,
                                                                  DateTimeOffset.UtcNow.AddDays(7));

            // Create a SAS token that's also valid for 7 days.
            BlobSasBuilder sasBuilder = new BlobSasBuilder()
            {
                BlobContainerName = blobClient.BlobContainerName,
                BlobName = blobClient.Name,
                Resource = "b",
                StartsOn = DateTimeOffset.UtcNow,
                ExpiresOn = DateTimeOffset.UtcNow.AddDays(7)
            };

            // Specify read and write permissions for the SAS.
            sasBuilder.SetPermissions(BlobSasPermissions.Read |
                                      BlobSasPermissions.Write);

            // Add the SAS token to the blob URI.
            BlobUriBuilder blobUriBuilder = new BlobUriBuilder(blobClient.Uri)
            {
                // Specify the user delegation key.
                Sas = sasBuilder.ToSasQueryParameters(userDelegationKey,
                                                      blobServiceClient.AccountName)
            };

            System.Diagnostics.Debug.WriteLine("Blob user delegation SAS URI: {0}", blobUriBuilder);
            Console.WriteLine();
            return blobUriBuilder.ToUri();
        }

    }

    internal class BlobDto
    {
        public string Name { get; set; }
        public string Uri { get; set; }
        public string ContentType { get; set; }
    }
}

