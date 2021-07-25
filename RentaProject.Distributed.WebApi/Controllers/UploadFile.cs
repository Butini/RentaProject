using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentaProject.Distributed.WebApi.Controllers
{
    public class UploadFile : ControllerBase
    {
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpGet]
        [Route("upload")]
        public string Upload(string s)
        {
            return s;
        }
    }
}
