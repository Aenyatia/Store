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
			var customerDtos = _customerService.GetCustomers();

			return Ok(customerDtos);
		}

		[HttpGet("{customerId}")]
		public IActionResult Get(int customerId)
		{
			var customerDto = _customerService.GetCustomerById(customerId);

			if (customerDto == null)
				return NotFound();

			return Ok(customerDto);
		}

		[HttpPost]
		public IActionResult Post([FromBody] CreateCustomer command)
		{
			var customerDto = _customerService.CreateCustomer(command);

			return CreatedAtAction("Get", new { customerId = customerDto.Id }, customerDto);
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
