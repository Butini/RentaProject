using Microsoft.AspNetCore.Http;
using RentaProject.Domain.Entities;
using RentaProject.Infrastructure.Repository.Contracts;
using RentaProject.Infrastructure.Utils.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaProject.Infrastructure.Repository.Implementation
{
    public class RentaProjectRepository : IRentaProjectRepository
    {
        private readonly IExcelManager _excelManager;
        private readonly IFileManager _fileManager;

        public RentaProjectRepository(IExcelManager excelManager, IFileManager fileManager)
        {
            _excelManager = excelManager;
            _fileManager = fileManager;
        }

        public bool DeleteFile(FilePathEntity filePath)
        {
            return _fileManager.DeleteFile(filePath);
        }

        public string NewExcel(List<ActionEntity> actionList, List<BitcoinEntity> bitcoinList, string code)
        {
            return _excelManager.NewExcel(actionList, bitcoinList, code);
        }

        public (List<ActionEntity> actionList, List<BitcoinEntity> bitcoinList) ReadExcel(FilePathEntity fileManager)
        {
            return _excelManager.ReadExcel(fileManager);
        }

        public async Task<string> UploadFile(IFormFile formFile)
        {
            return await _fileManager.UploadFile(formFile);
        }
    }
}
