using Microsoft.AspNetCore.Http;
using RentaProject.Domain.Entities;
using RentaProject.Infrastructure.Utils.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaProject.Infrastructure.Utils.Implementation
{
    public class FileManager : IFileManager
    {
        public bool DeleteFile(FilePathEntity filePath)
        {
            File.Delete(filePath.Path);
            return true;
        }

        public async Task<string> UploadFile(IFormFile formFile)
        {
            var extension = "." + formFile.FileName.Split(".")[formFile.FileName.Split(".").Length - 1];
            var pathBuild = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\file");

            string fileName = DateTime.Now.Ticks + extension;

            if (!Directory.Exists(pathBuild))
            {
                Directory.CreateDirectory(pathBuild);
            }

            var path = Path.Combine(pathBuild, fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await formFile.CopyToAsync(stream);
            }

            return pathBuild;
        }
    }
}
