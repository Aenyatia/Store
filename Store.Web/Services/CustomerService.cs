using Store.Core;
using System;
using System.Collections.Generic;
using System.Linq;

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

		public Customer GetCustomerById(int customerId)
		{
			return Customers.SingleOrDefault(c => c.Id == customerId);
		}

		public Customer CreateCustomer(string name, DateTime? birthday, int membershipTypeId, bool isSubscriber)
		{
			var customer = new Customer
			{
				Id = Customers.Count + 1,
				Name = name,
				Birthday = birthday,
				MembershipTypeId = membershipTypeId,
				IsNewsLetterSubscriber = isSubscriber
			};

			Customers.Add(customer);

			return customer;
		}
	}
}
