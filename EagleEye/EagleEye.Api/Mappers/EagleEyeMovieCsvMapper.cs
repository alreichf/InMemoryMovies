using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration;
using EagleEye.Api.Domain;

namespace EagleEye.Api.Mappers
{
    public class EagleEyeMovieCsvMapper : ClassMap<Movie>
    {
        public EagleEyeMovieCsvMapper()
        {
            Map(movie => movie.Id).Index(0).Name("Id");
            Map(movie => movie.MovieId).Index(1).Name("MovieId");
            Map(movie => movie.Title).Index(2).Name("Title");
            Map(movie => movie.Language).Index(3).Name("Language");
            Map(movie => movie.Duration).Index(4).Name("Duration");
            Map(movie => movie.ReleaseYear).Index(5).Name("ReleaseYear");
        }
    }
}
