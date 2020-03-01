using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventStormingSample.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EventStormingSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateCustomer([FromBody] CreateCustomerRequest request)
        {
            return Ok();
        }
    }
}