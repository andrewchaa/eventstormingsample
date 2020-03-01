using System;
using System.Buffers;
using System.Threading;
using System.Threading.Tasks;
using EventStormingSample.Domains;
using EventStormingSample.Infrastructure;
using EventStormingSample.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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

            var customer = new Customer(nameResult.Value, addressResult.Value);
            var commandResult = await _mediator.Send(new CreateCustomerCommand(customer));
            
            _logger.LogInformation($"Successfully created a customer {commandResult.Value}");

            return Ok(new
            {
                CustomerId = commandResult.Value,
                Errors = new string[]{}
            });
        }
    }

    public class CustomerContact
    {
        public static OpResult<CustomerContact> Create(string mobile,
            string email)
        {
            return new OpResult<CustomerContact>(new CustomerContact());
        }
    }

    public class Customer
    {
        public CustomerName CustomerName { get; }
        public CustomerAddress CustomerAddress { get; }

        public Customer(CustomerName customerName, CustomerAddress customerAddress)
        {
            CustomerName = customerName;
            CustomerAddress = customerAddress;
        }
    }

    public class CreateCustomerCommand : IRequest<OpResult<Guid>>
    {
        public Customer Customer { get; }

        public CreateCustomerCommand(Customer customer)
        {
            Customer = customer;
        }
    }
    
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, OpResult<Guid>>
    {
        public async Task<OpResult<Guid>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            return new OpResult<Guid>(Guid.NewGuid());
        }
    }
}