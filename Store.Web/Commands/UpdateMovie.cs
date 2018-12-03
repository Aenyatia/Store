using System;

namespace Store.Web.Commands
{
	public class UpdateMovie
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public byte GenreId { get; set; }
		public DateTime ReleaseDate { get; set; }
		public int NumberInStock { get; set; }
	}
}