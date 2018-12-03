using Store.Core;
using System;

namespace Store.Web.Dtos
{
	public class CustomerDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime? Birthday { get; set; }
		public MembershipType MembershipType { get; set; }
		public bool IsNewsLetterSubscriber { get; set; }
	}
}
