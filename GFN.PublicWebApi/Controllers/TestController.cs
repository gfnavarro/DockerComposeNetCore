using GFN.PublicWebApi.AppLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GFN.PublicWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {

        private readonly ILogger<TestController> logger;
        PrivateDataAppLogic privateDataService;

        public TestController(ILogger<TestController> logger, PrivateDataAppLogic privateDataService)
        {
            this.logger = logger;
            this.privateDataService = privateDataService;
        }

        [HttpGet("public")]
        public string GetPublic()
        {
            return "Value from PUBLIC: " + DateTime.Now;
        }

        [HttpGet("private")]
        public async Task<string> GetPrivate()
        {
            return await this.privateDataService.GetData();
        }

        [HttpGet("private/{count}")]
        public async Task<List<string>> GetPrivateLast(int count)
        {
            return await this.privateDataService.GetData(count);
        }
    }
}
