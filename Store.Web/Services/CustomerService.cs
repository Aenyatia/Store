using Store.Core;
using System.Collections.Generic;

namespace Store.Web.Services
{
	public class CustomerService
	{
		private static readonly ISet<Customer> Customers = new HashSet<Customer>
		{
			new Customer()
		};

		public IEnumerable<Customer> GetCustomers()
		{
			return Customers;
		}
	}
}
