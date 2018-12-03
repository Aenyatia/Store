using System;

namespace Store.Core
{
	public class Customer
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public bool IsNewsLetterSubscriber { get; set; }
		public DateTime? Birthday { get; set; }

		public int MembershipTypeId { get; set; }
		public MembershipType MembershipType { get; set; }
	}
}
