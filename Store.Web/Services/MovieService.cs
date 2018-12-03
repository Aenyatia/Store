using Store.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Store.Web.Services
{
	public class MovieService
	{
		private static readonly ISet<Movie> Movies = new HashSet<Movie>
		{
			new Movie
			{
				Id = 1,
				Name = "Hangover",
				AddedAt = DateTime.Now,
				Genre = Genre.Action,
				NumberInStock = 10,
				Release = DateTime.Now.AddDays(-100)
			},
			new Movie
			{
				Id = 2,
				Name = "Die Hard",
				AddedAt = DateTime.Now,
				Genre = Genre.Fantasy,
				NumberInStock = 5,
				Release = DateTime.Now.AddDays(-50)
			}
		};

		public IEnumerable<Movie> GetMovies()
		{
			return Movies;
		}

		public Movie GetMovieById(int movieId)
		{
			return Movies.SingleOrDefault(m => m.Id == movieId);
		}

		public Movie CreateMovie(string commandName, byte commandGenreId, DateTime commandReleaseDate, int commandNumberInStock)
		{
			var movie = new Movie
			{
				Id = Movies.Count + 1,
				Name = commandName,
				Release = commandReleaseDate,
				GenreId = commandGenreId,
				AddedAt = DateTime.Now,
				NumberInStock = commandNumberInStock
			};

			Movies.Add(movie);

			return movie;
		}

		public void UpdateMovie(Movie movie, string name, byte genreId, DateTime releaseDate, int numberInStock)
		{
			movie.Name = name;
			movie.GenreId = genreId;
			movie.Release = releaseDate;
			movie.NumberInStock = numberInStock;
		}
	}
}
