using ApplicationCore.Common.Interfaces;
using Domain.Entities.Movies;

namespace ApplicationCore.Movies.Interfaces
{
    public interface IMovieRepository : IAsyncRepository<FavoriteMovie>
    {
    }
}
