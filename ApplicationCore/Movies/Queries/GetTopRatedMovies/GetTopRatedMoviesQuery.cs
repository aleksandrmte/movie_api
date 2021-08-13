using ApplicationCore.Movies.Dto;
using MediatR;

namespace ApplicationCore.Movies.Queries.GetTopRatedMovies
{
    public class GetTopRatedMoviesQuery : IRequest<MovieListVm>
    {
        public int Page { get; set; }

        public GetTopRatedMoviesQuery(int page)
        {
            Page = page;
        }
    }
}
