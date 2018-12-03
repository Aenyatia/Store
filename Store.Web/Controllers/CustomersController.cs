using Microsoft.AspNetCore.Mvc;
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
	}
}
