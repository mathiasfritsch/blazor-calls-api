using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppAuthenticated.Controllers
{
 
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
    
        [Route("UnAuthorized")]
        public Person GetUnAuthorized()
        {
            return new Person { Name = "Mathias", Age = 50};
        }

        [Authorize]
        [HttpGet]
        [Route("Authorized")]
        public Person GetAuthorized()
        {
            return new Person { Name = "Mathias", Age = 50 };
        }
    }
}
