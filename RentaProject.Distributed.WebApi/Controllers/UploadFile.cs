using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentaProject.Distributed.WebApi.Controllers
{
    [ApiController]
    public class UploadFile : ControllerBase
    {
        [HttpPost]
        [Route("IncomeStatement")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> NewIncomeStatement(IFormFile file)
        {
            await WriteFile(file);

            return Ok();
        }

        private async Task<bool> WriteFile(IFormFile file)
        {
            var pathBuild = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\file");

            if (!Directory.Exists(pathBuild))
            {
                Directory.CreateDirectory(pathBuild);
            }

            var path = Path.Combine(pathBuild, file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return true;
        }
    }
}
