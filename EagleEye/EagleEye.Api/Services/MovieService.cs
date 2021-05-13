
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EagleEye.Api.Data;
using EagleEye.Api.Domain;
using Microsoft.Extensions.Logging;

namespace EagleEye.Api.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly ILogger<MovieService> _logger;
        public MovieService(IMovieRepository movieRepository, ILogger<MovieService> logger)
        {
            _movieRepository = movieRepository;
            _logger = logger;
        }
        public async Task<bool> AddMovie(ValueObjects.Movie movie)
        {
            // ideally Automapper
            var domain = new Movie
            {
                Id = movie.Id,
                MovieId = movie.MovieId,
                Title = movie.Title,
                Language = movie.Language,
                Duration = TimeSpan.Parse(movie.Duration),
                ReleaseYear = movie.ReleaseYear
            };

            return await _movieRepository.AddMovie(domain);
        }

        public async Task<IEnumerable<Movie>> GetMovieMetadata(int? movieId)
        {
            return await _movieRepository.GetMovieMetadata(movieId);
        }

        public async Task<IEnumerable<MovieStat>> GetMovieStats()
        {
            return await _movieRepository.GetMovieStats();
        }
    }
}
