using AutoMapper;
using Store.Core;
using Store.Web.Commands;
using Store.Web.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Store.Web.Services
{
	public class MovieService
	{
		private readonly IMapper _mapper;

		private static readonly ISet<Movie> Movies = new HashSet<Movie>
		{
			new Movie
			{
				Id = 1,
				Name = "Shrek",
				ReleaseDate = new DateTime(2000, 10, 12),
				NumberInStock = 10,
				AddedAt = DateTime.Now,
				GenreId = (byte)Genre.Fantasy,
				Genre = Genre.Fantasy
			},
			new Movie
			{
				Id = 2,
				Name = "Wall-e",
				ReleaseDate = new DateTime(2010, 06, 13),
				NumberInStock = 3,
				AddedAt = DateTime.Now,
				GenreId = (byte)Genre.Action,
				Genre = Genre.Action
			}
		};

		public MovieService(IMapper mapper)
		{
			_mapper = mapper;
		}

		public IEnumerable<MovieDto> GetMovies()
		{
			return _mapper.Map<IEnumerable<Movie>, IEnumerable<MovieDto>>(Movies);
		}

		public MovieDto GetMovieById(int movieId)
		{
			var movie = Movies.SingleOrDefault(c => c.Id == movieId);

			return _mapper.Map<Movie, MovieDto>(movie);
		}

		public MovieDto CreateMovie(CreateMovie command)
		{
			var movie = new Movie
			{
				Id = Movies.Count + 1,
				Name = command.Name,
				GenreId = command.GenreId,
				NumberInStock = command.NumberInStock,
				ReleaseDate = command.ReleaseDate,
				AddedAt = DateTime.Now
			};

			Movies.Add(movie);

			return _mapper.Map<Movie, MovieDto>(movie);
		}

		public void UpdateMovie(int movieId, UpdateMovie command)
		{
			var movie = Movies.Single(c => c.Id == movieId);

			movie.Name = command.Name;
			movie.GenreId = command.GenreId;
			movie.NumberInStock = command.NumberInStock;
			movie.ReleaseDate = command.ReleaseDate;
			movie.UpdatedAt = DateTime.Now;
		}

		public void DeleteMovie(int movieId)
		{
			var movie = Movies.Single(c => c.Id == movieId);

			Movies.Remove(movie);
		}
	}
}
