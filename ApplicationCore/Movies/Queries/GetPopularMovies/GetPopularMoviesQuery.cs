using ApplicationCore.Movies.Dto;
using MediatR;

namespace ApplicationCore.Movies.Queries.GetPopularMovies
{
    public class GetPopularMoviesQuery: IRequest<MovieListVm>
    {
        public int Page { get; set; }

        public GetPopularMoviesQuery(int page)
        {
            Page = page;
        }
    }
}
