using System;

namespace Store.Core
{
	public class Movie
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public Genre Genre { get; set; }
		public DateTime AddedAt { get; set; }
		public DateTime Release { get; set; }
		public int NumberInStock { get; set; }
	}
}
