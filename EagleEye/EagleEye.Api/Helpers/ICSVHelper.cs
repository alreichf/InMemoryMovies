
using System.Collections.Generic;
using EagleEye.Api.Domain;

namespace EagleEye.Api.Helpers
{
    public interface ICSVHelper
    {
        IAsyncEnumerable<Movie> GenerateMovieEntityRecordsFromCSV();
        IAsyncEnumerable<MovieStat> GenerateMovieStatsEntityRecordsFromCSV();
    }
}
