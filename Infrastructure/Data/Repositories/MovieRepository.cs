using ApplicationCore.Movies.Interfaces;
using Domain.Entities.Movies;

namespace Infrastructure.Data.Repositories
{
    public class MovieRepository : EfRepository<FavoriteMovie>, IMovieRepository
    {
        public MovieRepository(DataContext dbContext) : base(dbContext)
        {
        }
    }
}
