using System;
using Store.Web.Commands;
using System.ComponentModel.DataAnnotations;

namespace Store.Web.Validators
{
	public class EightteenYears : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			var customer = (CreateCustomer)validationContext.ObjectInstance;

			if (customer.MembershipTypeId == 1)
				return ValidationResult.Success;

			if (customer.Birthday == null)
				return new ValidationResult("Birthdate is required.");

			var age = DateTime.Today.Year - customer.Birthday.Value.Year;

			return age >= 18 
				? ValidationResult.Success 
				: new ValidationResult("Customer should be at least 18 years old to go on a membership.");
		}
	}
}
