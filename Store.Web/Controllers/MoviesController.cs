using Microsoft.AspNetCore.Mvc;
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
	}
}
