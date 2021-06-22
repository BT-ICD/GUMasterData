using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GUMasterData.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> logger;
        public TestController(ILogger<TestController> logger) 
        {
            this.logger = logger;
        }
        [HttpGet]
        public IActionResult Test()
        {
            Object result = null;
            var x = result.ToString();
            logger.LogInformation($"Test Method Logger Demo");
            return Ok();
        }
    }
}
