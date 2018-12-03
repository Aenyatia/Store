using Store.Web.Validators;
using System;
using System.ComponentModel.DataAnnotations;

namespace Store.Web.Commands
{
	public class CreateCustomer
	{
		[Required]
		[StringLength(255)]
		public string Name { get; set; }

		[EightteenYears]
		[PastDate]
		public DateTime? Birthday { get; set; }

		[Required]
		[Display(Name = "Membership Type")]
		public byte MembershipTypeId { get; set; }

		[Required]
		public bool IsNewsLetterSubscriber { get; set; }
	}
}
