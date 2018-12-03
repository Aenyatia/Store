using Store.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace Store.Web.Commands
{
	public class CreateMovie
	{
		[Required]
		[MaxLength(255)]
		public string Name { get; set; }

		[Required]
		[EnumDataType(typeof(Genre))]
		public byte GenreId { get; set; }

		[Required]
		public DateTime ReleaseDate { get; set; }

		[Required]
		[Range(1, 20)]
		public int NumberInStock { get; set; }
	}
}
