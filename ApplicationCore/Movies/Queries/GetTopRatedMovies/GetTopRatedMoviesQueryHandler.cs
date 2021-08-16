using ApplicationCore.Movies.Dto;
using ApplicationCore.Movies.Extensions;
using ApplicationCore.Movies.Interfaces;
using ApplicationCore.Movies.Services.MovieApi;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationCore.Movies.Queries.GetTopRatedMovies
{
    public class GetTopRatedMoviesQueryHandler : IRequestHandler<GetTopRatedMoviesQuery, MovieListVm>
    {
        private readonly IMovieApiService _movieApiService;
        private readonly IMapper _mapper;
        private readonly IMovieRepository _movieRepository;

        public GetTopRatedMoviesQueryHandler(IMovieApiService movieApiService, IMapper mapper, IMovieRepository movieRepository)
        {
            _movieApiService = movieApiService;
            _mapper = mapper;
            _movieRepository = movieRepository;
        }

        public async Task<MovieListVm> Handle(GetTopRatedMoviesQuery request, CancellationToken cancellationToken)
        {
            var data = await _movieApiService.GetTopRated(request.Page);
            var result = _mapper.Map<MovieListVm>(data);
            result.FillFavoriteMovies(await _movieRepository.ListAllAsync());
            return result;
        }
    }
}
