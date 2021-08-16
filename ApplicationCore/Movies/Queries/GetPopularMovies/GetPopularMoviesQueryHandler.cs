using ApplicationCore.Movies.Dto;
using ApplicationCore.Movies.Extensions;
using ApplicationCore.Movies.Interfaces;
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
        private readonly IMovieRepository _movieRepository;

        public GetPopularMoviesQueryHandler(IMapper mapper, IMovieApiService movieApiService, IMovieRepository movieRepository)
        {
            _mapper = mapper;
            _movieApiService = movieApiService;
            _movieRepository = movieRepository;
        }

        public async Task<MovieListVm> Handle(GetPopularMoviesQuery request, CancellationToken cancellationToken)
        {
            var data = await _movieApiService.GetPopular(request.Page);
            var result = _mapper.Map<MovieListVm>(data);
            result.FillFavoriteMovies(await _movieRepository.ListAllAsync());
            return result;
        }
    }
}
