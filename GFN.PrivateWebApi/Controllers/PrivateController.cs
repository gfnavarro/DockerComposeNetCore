using GFN.PrivateWebApi.AppLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GFN.PrivateWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrivateController : ControllerBase
    {
       
        private readonly ILogger<PrivateController> logger;
        SampleAppLogic sampleAppLogic;

        public PrivateController(ILogger<PrivateController> logger, SampleAppLogic sampleAppLogic)
        {
            this.logger = logger;
            this.sampleAppLogic = sampleAppLogic;
        }

        [HttpGet]
        public string Get()
        {
            return "Value from Private: " + DateTime.Now;
        }

        [HttpGet("{count}")]
        public IEnumerable<string> GetLast(int count)
        {
            return sampleAppLogic.GetLastValues(count);
        }
}
}
