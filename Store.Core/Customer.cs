using System;

namespace Store.Core
{
	public class Customer
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public bool IsNewsletterSubscriber { get; set; }
		public DateTime? Birthday { get; set; }

		public byte MembershipTypeId { get; set; }
		public MembershipType MembershipType { get; set; }
	}
}
