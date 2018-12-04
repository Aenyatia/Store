using Store.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace Store.Web.Commands
{
	public class CreateMovie
	{
		[Required]
		[StringLength(255)]
		public string Name { get; set; }

		[Required]
		[EnumDataType(typeof(Genre))]
		[Display(Name = "Genre")]
		public byte GenreId { get; set; }

		[Required]
		[Display(Name = "Relese Date")]
		public DateTime ReleaseDate { get; set; }

		[Required]
		[Range(1, 20)]
		[Display(Name = "Number in Stock")]
		public int NumberInStock { get; set; }
	}
}
