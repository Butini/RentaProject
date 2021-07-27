using Microsoft.AspNetCore.Http;
using RentaProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaProject.Infrastructure.Repository.Contracts
{
    public interface IRentaProjectRepository
    {
        public (List<ActionEntity> actionList, List<BitcoinEntity> bitcoinList) ReadExcel(FilePathEntity fileManager);
        public string NewExcel(List<ActionEntity> actionList, List<BitcoinEntity> bitcoinList, string code);
        public Task<string> UploadFile(IFormFile formFile);
        public bool DeleteFile(FilePathEntity filePath);
    }
}
