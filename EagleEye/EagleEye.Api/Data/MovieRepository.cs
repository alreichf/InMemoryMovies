
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EagleEye.Api.Domain;
using EagleEye.Api.Helpers;
using Microsoft.Extensions.Logging;

namespace EagleEye.Api.Data
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ICSVHelper _cSVHelper;
        private readonly ILogger<MovieRepository> _logger;

        public MovieRepository(ICSVHelper cSVHelper, ILogger<MovieRepository> logger)
        {
            _cSVHelper = cSVHelper;
            _logger = logger;
        }

        private static readonly IList<Movie> Database = new List<Movie>
        {
            new Movie
            {
               Id =  1,
               MovieId = 3,
               Title = "Elysium",
               Language = "AR",
               Duration = TimeSpan.Parse("01:49:00"),
               ReleaseYear = 2013
            },
            new Movie
            {
               Id =  2,
               MovieId = 3,
               Title = "Elysium",
               Language = "EN",
               Duration = TimeSpan.Parse("01:49:00"),
               ReleaseYear = 2013
            },
            new Movie
            {
               Id =  3,
               MovieId = 3,
               Title = "Elysium",
               Language = "EN",
               Duration = TimeSpan.Parse("01:49:00"),
               ReleaseYear = 2013
            },
            new Movie
            {
               Id =  4,
               MovieId = 3,
               Title = "Elysium",
               Language = "HI",
               Duration = TimeSpan.Parse("01:49:00"),
               ReleaseYear = 2013
            },
            new Movie
            {
               Id =  5,
               MovieId = 3,
               Title = "Элизиум – Рай Не На Земле",
               Language = "RU",
               Duration = TimeSpan.Parse("01:49:00"),
               ReleaseYear = 2013
            },
            new Movie
            {
               Id =  6,
               MovieId = 3,
               Title = "エリジウム",
               Language = "JA",
               Duration = TimeSpan.Parse("01:49:00"),
               ReleaseYear = 2013
            },
            new Movie
            {
               Id =  7,
               MovieId = 4,
               Title = "Django Unchained",
               Language = "EN",
               Duration = TimeSpan.Parse("02:45:00"),
               ReleaseYear = 2012
            },
            new Movie
            {
               Id =  8,
               MovieId = 4,
               Title = "توتال ريكول",
               Language = "AR",
               Duration = TimeSpan.Parse("02:45:00"),
               ReleaseYear = 2012
            },
            new Movie
            {
               Id =  9,
               MovieId = 5,
               Title = "Total Recall",
               Language = "HI",
               Duration = TimeSpan.Parse("01:58:00"),
               ReleaseYear = 2012
            },
            new Movie
            {
               Id =  10,
               MovieId = 5,
               Title = "TOTAL RECALL (2012)",
               Language = "EN",
               Duration = TimeSpan.Parse("01:58:00"),
               ReleaseYear = 2012
            }
        };

        private static readonly IEnumerable<MovieStat> movieStats = new List<MovieStat>
        {
            new MovieStat
            {
                MovieId = 3,
                WatchDurationMs = 4309295
            },
            new MovieStat
            {
                MovieId = 4,
                WatchDurationMs = 5412842
            },
            new MovieStat
            {
                MovieId = 5,
                WatchDurationMs = 7107064
            },
            new MovieStat
            {
                MovieId = 3,
                WatchDurationMs = 1792718
            },
            new MovieStat
            {
                MovieId = 5,
                WatchDurationMs = 5862265
            },
            new MovieStat
            {
                MovieId = 4,
                WatchDurationMs = 3920639
            },
            new MovieStat
            {
                MovieId = 3,
                WatchDurationMs = 2010933
            },
        };

        public async Task<bool> AddMovie(Movie movie)
        {
            var found = Database.Where(m => m.Id.Equals(movie.Id));
            if (found.Any())
            {
                throw new Exception("Duplicate Movie Found");
            }

            await Task.Delay(1000);
            Database.Add(movie);

            return true;
        }

        public async Task<IEnumerable<Movie>> GetMovieMetadata(int? movieId)
        {
            var found = Database.Where(m => m.MovieId.Equals(movieId));
            if (!found.Any())
            {
                throw new Exception($"Movie Not Found: {movieId}");
            }

            await Task.Delay(1000);
            return found;
        }

        public async Task<IEnumerable<MovieStat>> GetMovieStats()
        {
            await Task.Delay(1000);
            return movieStats;
        }
    }
}
