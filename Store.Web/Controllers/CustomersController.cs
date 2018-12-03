using Microsoft.AspNetCore.Mvc;
using Store.Web.Commands;
using Store.Web.Services;

namespace Store.Web.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class CustomersController : ControllerBase
	{
		private readonly CustomerService _customerService;

		public CustomersController(CustomerService customerService)
		{
			_customerService = customerService;
		}

		[HttpGet]
		public IActionResult Get()
		{
			var customers = _customerService.GetCustomers();

			return Ok(customers);
		}

		[HttpGet("{customerId}")]
		public IActionResult Get(int customerId)
		{
			var customer = _customerService.GetCustomerById(customerId);

			if (customer == null)
				return NotFound();

			return Ok(customer);
		}

		[HttpPost]
		public IActionResult Post([FromBody] CreateCustomer command)
		{
			var customer = _customerService
				.CreateCustomer(command.Name, command.Birthday, command.MembershipTypeId, command.IsNewsLetterSubscriber);

			return CreatedAtAction("Get", new { customerId = customer.Id }, customer);
		}

		[HttpPut]
		public IActionResult Put([FromBody] UpdateCustomer command)
		{
			_customerService
				.UpdateCustomer(command.Id, command.Name, command.Birthday, command.MembershipTypeId, command.IsNewsLetterSubscriber);

			return NoContent();
		}
	}
}
