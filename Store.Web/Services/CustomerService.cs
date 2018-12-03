using System;
using Store.Core;
using System.Collections.Generic;

namespace Store.Web.Services
{
	public class CustomerService
	{
		private static readonly ISet<Customer> Customers = new HashSet<Customer>
		{
			new Customer
			{
				Id = 1,
				Name = "Customer One",
				Birthday = new DateTime(2000, 12, 12),
				MembershipType = new MembershipType
				{
					Id = 1,
					Name = "Annual",
					DiscountRate = 10,
					DurationInMonths = 12,
					SignUpFee = 300
				},
				IsNewsLetterSubscriber = true
			},
			new Customer
			{
				Id = 2,
				Name = "Customer Two",
				Birthday = new DateTime(1980, 10, 15),
				MembershipType = new MembershipType
				{
					Id = 2,
					Name = "Monthly",
					DiscountRate = 5,
					DurationInMonths = 1,
					SignUpFee = 30
				},
				IsNewsLetterSubscriber = false
			}
		};

		public IEnumerable<Customer> GetCustomers()
		{
			return Customers;
		}
	}
}
