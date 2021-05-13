
using System.Collections.Generic;
using System.Threading.Tasks;
using EagleEye.Api.Domain;

namespace EagleEye.Api.Data
{
    public interface IMovieRepository
    {
        Task<bool> AddMovie(Movie movie);
        Task<IEnumerable<Movie>> GetMovieMetadata(int? movieId);
        Task<IEnumerable<MovieStat>> GetMovieStats();
    }
}
