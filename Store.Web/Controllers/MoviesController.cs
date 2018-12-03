using Microsoft.AspNetCore.Mvc;
using Store.Web.Commands;
using Store.Web.Services;

namespace Store.Web.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class MoviesController : ControllerBase
	{
		private readonly MovieService _movieService;

		public MoviesController(MovieService movieService)
		{
			_movieService = movieService;
		}

		[HttpGet]
		public IActionResult Get()
		{
			var movies = _movieService.GetMovies();

			return Ok(movies);
		}

		[HttpGet("{movieId}")]
		public IActionResult Get(int movieId)
		{
			var movie = _movieService.GetMovieById(movieId);

			if (movie == null)
				return NotFound();

			return Ok(movie);
		}

		[HttpPost]
		public IActionResult Post([FromBody] CreateMovie command)
		{
			var movie = _movieService
				.CreateMovie(command.Name, command.GenreId, command.ReleaseDate, command.NumberInStock);

			return CreatedAtAction("Get", new { movieId = movie.Id }, movie);
		}

		[HttpPost]
		public IActionResult Put([FromBody] UpdateMovie command)
		{
			_movieService
				.UpdateMovie(command.Id, command.Name, command.GenreId, command.ReleaseDate, command.NumberInStock);

			return NoContent();
		}
	}
}
