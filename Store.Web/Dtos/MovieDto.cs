using Store.Core;
using System;

namespace Store.Web.Dtos
{
	public class MovieDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public byte GenreId { get; set; }
		public Genre Genre { get; set; }
		public DateTime AddedAt { get; set; }
		public DateTime Release { get; set; }
		public int NumberInStock { get; set; }
	}
}
