using AutoMapper;
using Store.Core;
using Store.Web.Commands;
using Store.Web.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Store.Web.Services
{
	public class CustomerService
	{
		private readonly IMapper _mapper;

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

		public CustomerService(IMapper mapper)
		{
			_mapper = mapper;
		}

		public IEnumerable<CustomerDto> GetCustomers()
		{
			return _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDto>>(Customers);
		}

		public CustomerDto GetCustomerById(int customerId)
		{
			var customer = Customers.SingleOrDefault(c => c.Id == customerId);

			return _mapper.Map<Customer, CustomerDto>(customer);
		}

		public CustomerDto CreateCustomer(CreateCustomer command)
		{
			var customer = new Customer
			{
				Id = Customers.Count + 1,
				Name = command.Name,
				Birthday = command.Birthday,
				MembershipTypeId = command.MembershipTypeId,
				IsNewsLetterSubscriber = command.IsNewsLetterSubscriber
			};

			Customers.Add(customer);

			return _mapper.Map<Customer, CustomerDto>(customer);
		}

		public void UpdateCustomer(int customerId, UpdateCustomer command)
		{
			var customer = Customers.Single(c => c.Id == customerId);

			customer.Name = command.Name;
			customer.Birthday = command.Birthday;
			customer.MembershipTypeId = command.MembershipTypeId;
			customer.IsNewsLetterSubscriber = command.IsNewsLetterSubscriber;
		}

		public void DeleteCustomer(int customerId)
		{
			var customer = Customers.Single(c => c.Id == customerId);

			Customers.Remove(customer);
		}
	}
}
