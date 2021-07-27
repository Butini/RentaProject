using Microsoft.AspNetCore.Http;
using RentaProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaProject.Infrastructure.Utils.Contracts
{
    public interface IFileManager
    {
        public Task<string> UploadFile(IFormFile formFile);
        public bool DeleteFile(FilePathEntity filePath);
    }
}
