using CsvHelper.Configuration;
using EagleEye.Api.Domain;

namespace EagleEye.Api.Mappers
{
    public class EagleEyeMovieStatCsvMapper : ClassMap<MovieStat>
    {

        public EagleEyeMovieStatCsvMapper()
        {
            Map(movieStat => movieStat.MovieId).Index(0).Name("MovieId");
            Map(movieStat => movieStat.WatchDurationMs).Index(0).Name("WatchDurationMs");
        }
    }
}
