using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RentaProject.Application.Service.Contracts;

namespace RentaProject.Distributed.WebApi.Controllers
{
    [ApiController]
    public class UploadFile : ControllerBase
    {
        private readonly IRentaProjectService _rentaProjectService;

        public UploadFile(IRentaProjectService rentaProjectService)
        {
            _rentaProjectService = rentaProjectService;
        }

        [HttpPost]
        [Route("IncomeStatement")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> NewIncomeStatement(IFormFile formFile)
        {
            string path = await _rentaProjectService.NewIncomeStatement(formFile);
            var returnFile = System.IO.File.OpenRead(path);

            return Ok(returnFile);
        }
    }
}
