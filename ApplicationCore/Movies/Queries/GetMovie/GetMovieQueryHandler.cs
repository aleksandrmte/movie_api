using ApplicationCore.Movies.Dto;
using ApplicationCore.Movies.Services.MovieApi;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationCore.Movies.Queries.GetMovie
{
    public class GetMovieQueryHandler : IRequestHandler<GetMovieQuery, MovieDto>
    {
        private readonly IMapper _mapper;
        private readonly IMovieApiService _movieApiService;

        public GetMovieQueryHandler(IMapper mapper, IMovieApiService movieApiService)
        {
            _mapper = mapper;
            _movieApiService = movieApiService;
        }

        public async Task<MovieDto> Handle(GetMovieQuery request, CancellationToken cancellationToken)
        {
            var data = await _movieApiService.GetDetails(request.Id);
            return _mapper.Map<MovieDto>(data);
        }
    }
}
