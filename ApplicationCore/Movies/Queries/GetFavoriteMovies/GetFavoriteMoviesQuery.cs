using ApplicationCore.Movies.Dto;
using MediatR;

namespace ApplicationCore.Movies.Queries.GetFavoriteMovies
{
    public class GetFavoriteMoviesQuery : IRequest<FavoriteMovieListVm>
    {
    }
}
