using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using EagleEye.Api.ValueObjects;
using EagleEye.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EagleEye.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly ILogger<MovieController> _logger;
        private readonly IMovieService _movieService;

        public MovieController(ILogger<MovieController> logger, IMovieService movieService)
        {
            _logger = logger;
            _movieService = movieService;
        }

        [HttpPost("/metadata")]
        public async Task<IActionResult> AddMovie(Movie movie)
        {
            // assuming movie is valid
            if(movie is object && movie.Id.HasValue  && movie.MovieId.HasValue){
                try
                {
                    return Ok(await _movieService.AddMovie(movie));
                }
                catch(Exception ex)
                {
                    _logger.LogInformation(ex.Message);
                    return BadRequest(new { Message = ex.Message, HttpStatusCode.BadRequest });
                }
            }

            return BadRequest(new { Message = "Invalid Request", HttpStatusCode.BadRequest });
        }

        [HttpGet("/metadata/{movieId:int}")]
        public async Task<IActionResult> GetMovie(int? movieId)
        {
            // assuming movie is valid
            if (movieId.HasValue)
            {
                try
                {
                    return Ok(await _movieService.GetMovieMetadata(movieId));
                }
                catch (Exception ex)
                {
                    _logger.LogInformation(ex.Message);
                    return NotFound(new { message = "Not Found", HttpStatusCode.NotFound });
                }
            }

            return BadRequest(new { Message = "Invalid Request", HttpStatusCode.BadRequest });
        }

        [HttpGet("/movie/stats")]
        public async Task<IActionResult> GetMovieStats()
        {
            return Ok(await _movieService.GetMovieStats());
        }
    }
}
