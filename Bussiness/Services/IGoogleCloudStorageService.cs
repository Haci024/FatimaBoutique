using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IGoogleCloudStorageService
    {
        Task<string> GetSignedUrl(string fileNameToRead, int timeOutInMinutes = 30);
        Task<string> UploadFile(IFormFile fileToUpload, string fileNameToSave);
        Task DeleteFile(string fileNameToDelete);
    }
}
