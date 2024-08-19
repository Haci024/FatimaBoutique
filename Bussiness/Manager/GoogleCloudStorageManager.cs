using Business.Services;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;


namespace Business.Manager
{
    public class GoogleCloudStorageManager : IGoogleCloudStorageService
    {
            private readonly GCSConfigOptions _options;
            private readonly ILogger<IGoogleCloudStorageService> _logger;
            private readonly GoogleCredential _googleCredential;

            public GoogleCloudStorageManager(IOptions<GCSConfigOptions> options, ILogger<IGoogleCloudStorageService> logger)
            {
                _options = options.Value;
                _logger = logger;

                try
                {
                    var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                    if (environment == Environments.Production)
                    {
                        // Store the json file in Secrets.
                        _googleCredential = GoogleCredential.FromJson(_options.GCPStorageAuthFile);
                    }
                    else
                    {
                        _googleCredential = GoogleCredential.FromFile(_options.GCPStorageAuthFile);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError($"{ex.Message}");
                    throw;
                }
            }
            public async Task DeleteFile(string fileNameToDelete)
            {
                try
                {
                    using (var storageClient = StorageClient.Create(_googleCredential))
                    {
                        await storageClient.DeleteObjectAsync(_options.GoogleCloudStorageBucketName, fileNameToDelete);
                    }
                    _logger.LogInformation($"File {fileNameToDelete} deleted");
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error occured while deleting file {fileNameToDelete}: {ex.Message}");
                    throw;
                }
            }

            public async Task<string> GetSignedUrl(string fileNameToRead, int timeOutInMinutes = 30)
            {
                try
                {
                    var sac = _googleCredential.UnderlyingCredential as ServiceAccountCredential;
                    var urlSigner = UrlSigner.FromServiceAccountCredential(sac);
                    var signedUrl = await urlSigner.SignAsync(_options.GoogleCloudStorageBucketName, fileNameToRead, TimeSpan.FromMinutes(timeOutInMinutes));
                    _logger.LogInformation($"Signed url obtained for file {fileNameToRead}");
                    return signedUrl.ToString();
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error occured while obtaining signed url for file {fileNameToRead}: {ex.Message}");
                    throw;
                }
            }

            public async Task<string> UploadFile(IFormFile fileToUpload, string fileNameToSave)
            {
                try
                {
                    _logger.LogInformation($"Uploading: file {fileNameToSave} to storage {_options.GoogleCloudStorageBucketName}");
                    using (var memoryStream = new MemoryStream())
                    {
                        await fileToUpload.CopyToAsync(memoryStream);
                       
                        using (var storageClient = StorageClient.Create(_googleCredential))
                        {
                           
                            var uploadedFile = await storageClient.UploadObjectAsync(_options.GoogleCloudStorageBucketName, fileNameToSave, fileToUpload.ContentType, memoryStream);
                            _logger.LogInformation($"Uploaded: file {fileNameToSave} to storage {_options.GoogleCloudStorageBucketName}");
                            return uploadedFile.MediaLink;
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error while uploading file {fileNameToSave}: {ex.Message}");
                    throw;
                }
            }
       
    }
   
}

