using Store.Core;
using System.Collections.Generic;

namespace Store.Web.Services
{
	public class MovieService
	{
		private static readonly ISet<Movie> Movies = new HashSet<Movie>
		{
			new Movie()
		};

		public IEnumerable<Movie> GetMovies()
		{
			return Movies;
		}
	}
}
