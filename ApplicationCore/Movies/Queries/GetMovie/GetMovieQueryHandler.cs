using System.Linq;
using ApplicationCore.Movies.Dto;
using ApplicationCore.Movies.Services.MovieApi;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ApplicationCore.Movies.Interfaces;
using ApplicationCore.Movies.Specifications;

namespace ApplicationCore.Movies.Queries.GetMovie
{
    public class GetMovieQueryHandler : IRequestHandler<GetMovieQuery, MovieDto>
    {
        private readonly IMapper _mapper;
        private readonly IMovieApiService _movieApiService;
        private readonly IMovieRepository _movieRepository;

        public GetMovieQueryHandler(IMapper mapper, IMovieApiService movieApiService, IMovieRepository movieRepository)
        {
            _mapper = mapper;
            _movieApiService = movieApiService;
            _movieRepository = movieRepository;
        }

        public async Task<MovieDto> Handle(GetMovieQuery request, CancellationToken cancellationToken)
        {
            var data = await _movieApiService.GetDetails(request.Id);
            if (data == null)
                return null;
            var movie = _mapper.Map<MovieDto>(data);
            var favoriteMovie = (await _movieRepository.ListAsync(new GetFavoriteMovieByIdSpecification(request.Id))).FirstOrDefault();
            if (favoriteMovie == null) 
                return movie;
            movie.IsFavorite = true;
            movie.FavoriteMovieId = favoriteMovie.Id;
            return movie;
        }
    }
}
