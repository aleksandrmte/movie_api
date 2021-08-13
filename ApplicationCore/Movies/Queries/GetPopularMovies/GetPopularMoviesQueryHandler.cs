using System.Linq;
using ApplicationCore.Movies.Dto;
using ApplicationCore.Movies.Services.MovieApi;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationCore.Movies.Queries.GetPopularMovies
{
    public class GetPopularMoviesQueryHandler : IRequestHandler<GetPopularMoviesQuery, MovieListVm>
    {
        private readonly IMapper _mapper;
        private readonly IMovieApiService _movieApiService;

        public GetPopularMoviesQueryHandler(IMapper mapper, IMovieApiService movieApiService)
        {
            _mapper = mapper;
            _movieApiService = movieApiService;
        }

        public async Task<MovieListVm> Handle(GetPopularMoviesQuery request, CancellationToken cancellationToken)
        {
            var data = await _movieApiService.GetPopular(request.Page);
            return new MovieListVm
            {
                Movies = data.Results.Select(_mapper.Map<MovieDto>).ToList(),
                TotalPages = data.TotalPages,
                Page = data.Page
            };
        }
    }
}
