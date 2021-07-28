using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaProject.Application.Service.Contracts
{
    public interface IRentaProjectService
    {
        public Task<string> NewIncomeStatement(IFormFile formFile);
    }
}
