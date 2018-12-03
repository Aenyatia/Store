using Store.Web.Extensions;
using System;
using System.ComponentModel.DataAnnotations;

namespace Store.Web.Validators
{
	public class PastDate : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			var birthday = validationContext.ObjectInstance.GetPropertyValue<DateTime?>("Birthday");

			if (birthday == null)
				return ValidationResult.Success;

			return birthday.Value.Date <= DateTime.Now.Date
				? ValidationResult.Success
				: new ValidationResult("Your birthday cannot be from the future.");
		}
	}
}
