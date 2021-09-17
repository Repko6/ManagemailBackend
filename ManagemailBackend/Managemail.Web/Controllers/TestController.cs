using System;
using Managemail.Common;
using Microsoft.AspNetCore.Mvc;

namespace Managemail.Web
{
    [ApiController]
    [Route(StringConstants.DefaultApiRoute + "[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public String Get()
        {
            return "Hello world!";
        }
    }
}
