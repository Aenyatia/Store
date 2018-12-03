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
			var customer = _customerService.CreateCustomer(command);

			return CreatedAtAction("Get", new { customerId = customer.Id }, customer);
		}

		[HttpPut("{customerId}")]
		public IActionResult Put(int customerId, [FromBody] UpdateCustomer command)
		{
			_customerService.UpdateCustomer(customerId, command);

			return NoContent();
		}

		[HttpDelete("{customerId}")]
		public IActionResult Delete(int customerId)
		{
			_customerService.DeleteCustomer(customerId);

			return NoContent();
		}
	}
}
