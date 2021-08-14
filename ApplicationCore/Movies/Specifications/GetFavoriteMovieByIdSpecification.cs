using ApplicationCore.Common.Specifications;
using Domain.Entities.Movies;

namespace ApplicationCore.Movies.Specifications
{
    public sealed class GetFavoriteMovieByIdSpecification : BaseSpecification<FavoriteMovie>
    {
        public GetFavoriteMovieByIdSpecification(int movieId)
            : base(t => t.MovieId == movieId)
        {

        }
    }
}
