using System;
using System.Threading.Tasks;
using EventStormingSample.Commands;
using EventStormingSample.Domains;
using EventStormingSample.Infrastructure;
using EventStormingSample.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EventStormingSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CustomersController> _logger;

        public CustomersController(IMediator mediator, 
            ILogger<CustomersController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
    
        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerRequest request)
        {
            var nameResult = CustomerName.Craete(request.Title, 
                request.FirstName, 
                request.LastName);
            if (nameResult.Status == OpStatus.Error)
            {
                return BadRequest(new
                {
                    CustomerId = string.Empty,
                    nameResult.Errors
                });
            }

            var addressResult = CustomerAddress.Create(request.HouseNoOrName,
                request.Street,
                request.City,
                request.County,
                request.PostCode
            );
            if (addressResult.Status == OpStatus.Error)
            {
                return BadRequest(new
                {
                    CustomerId = string.Empty,
                    addressResult.Errors
                });
            }

            var contactResult = CustomerContact.Create(request.Mobile,
                request.Email);
            if (contactResult.Status == OpStatus.Error)
            {
                return BadRequest(new
                {
                    CustomerId = string.Empty,
                    contactResult.Errors
                });
            }

            var customer = new Customer(new Id<Customer>(Guid.NewGuid()), 
                nameResult.Value, 
                addressResult.Value, 
                contactResult.Value);
            
            var commandResult = await _mediator.Send(new CreateCustomerCommand(customer));
            
            _logger.LogInformation($"Successfully created a customer {commandResult.Value}");

            return Ok(new
            {
                CustomerId = commandResult.Value,
                Errors = new string[]{}
            });
        }
    }
}