namespace Store.Core
{
	public class MembershipType
	{
		public byte Id { get; set; }
		public string Name { get; set; }
		public short SignUpFee { get; set; }
		public byte DurationInMonths { get; set; }
		public byte DiscountRate { get; set; }

		public static byte Undefine = 0;
		public static byte PayAsYouGo = 1;
		public static byte Monthly = 2;
		public static byte Quarterly = 3;
		public static byte Annual = 4;
	}
}
