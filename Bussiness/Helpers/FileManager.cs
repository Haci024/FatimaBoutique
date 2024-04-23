using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Helpers
{
    public static class FileManager
    {
        public static string Save(string rootPath, string folder, IFormFile file)
        {
            string newFileName = Guid.NewGuid().ToString() + file.FileName;
            string path = Path.Combine(rootPath, folder, newFileName);
            using (FileStream str = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(str);
            }

            return newFileName;
        }

        public static bool Delete(string rootPath, string folder, string fileName)
        {
            string path = Path.Combine(rootPath, folder, fileName);

            if (File.Exists(path))
            {
                File.Delete(path);
                return true;
            }
            return false;
        }
    }
}
