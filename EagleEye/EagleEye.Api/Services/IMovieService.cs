
using System.Collections.Generic;
using System.Threading.Tasks;
using EagleEye.Api.Domain;

namespace EagleEye.Api.Services
{
    public interface IMovieService
    {
        Task<bool> AddMovie(ValueObjects.Movie movie);
        Task<IEnumerable<Movie>> GetMovieMetadata(int? movieId);
        Task<IEnumerable<MovieStat>> GetMovieStats();
    }
}
