using Store.Core;
using Store.Web.Extensions;
using System;
using System.ComponentModel.DataAnnotations;

namespace Store.Web.Validators
{
	public class EightteenYears : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			var membershipTypeId = validationContext.ObjectInstance.GetPropertyValue<byte>("MembershipTypeId");
			var birthday = validationContext.ObjectInstance.GetPropertyValue<DateTime?>("Birthday");

			if (membershipTypeId == MembershipType.Undefine || membershipTypeId == MembershipType.PayAsYouGo)
				return ValidationResult.Success;

			if (birthday == null)
				return new ValidationResult("Birthday is required.");

			var age = DateTime.Today.Year - birthday.Value.Year;

			return age >= 18
				? ValidationResult.Success
				: new ValidationResult("Customer should be at least 18 years old to go on a membership.");
		}
	}
}
