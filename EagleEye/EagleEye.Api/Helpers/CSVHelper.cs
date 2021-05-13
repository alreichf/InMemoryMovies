
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using EagleEye.Api.Domain;
using EagleEye.Api.Mappers;

namespace EagleEye.Api.Helpers
{
    public class CSVHelper : ICSVHelper
    {
        public async IAsyncEnumerable<Movie> GenerateMovieEntityRecordsFromCSV()
        {
            using (var reader = new StreamReader("./Resources/Movie.cs"))
            {
                using (var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csvReader.Context.RegisterClassMap<EagleEyeMovieCsvMapper>();
                    await foreach (var record in csvReader.GetRecordsAsync<Movie>())
                    {
                        yield return record;
                    }
                }
            }
        }

        public async IAsyncEnumerable<MovieStat> GenerateMovieStatsEntityRecordsFromCSV()
        {
            using (var reader = new StreamReader("./Resources/MovieStat.cs"))
            {
                using (var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csvReader.Context.RegisterClassMap<EagleEyeMovieStatCsvMapper>();
                    await foreach (var record in csvReader.GetRecordsAsync<MovieStat>())
                    {
                        yield return record;
                    }
                }
            }
        }
    }
}
