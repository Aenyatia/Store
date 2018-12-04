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
			var movieDtos = _movieService.GetMovies();

			return Ok(movieDtos);
		}

		[HttpGet("{movieId}")]
		public IActionResult Get(int movieId)
		{
			var movieDto = _movieService.GetMovieById(movieId);

			if (movieDto == null)
				return NotFound();

			return Ok(movieDto);
		}

		[HttpPost]
		public IActionResult Post([FromBody] CreateMovie command)
		{
			var movieDto = _movieService.CreateMovie(command);

			return CreatedAtAction("Get", new { movieId = movieDto.Id }, movieDto);
		}

		[HttpPut("{movieId}")]
		public IActionResult Put(int movieId, [FromBody] UpdateMovie command)
		{
			_movieService.UpdateMovie(movieId, command);

			return NoContent();
		}

		[HttpDelete("{movieId}")]
		public IActionResult Delete(int movieId)
		{
			_movieService.DeleteMovie(movieId);

			return NoContent();
		}
	}
}
