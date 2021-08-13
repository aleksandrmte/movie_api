using ApplicationCore.Movies.Dto;
using ApplicationCore.Movies.Interfaces;
using AutoMapper;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationCore.Movies.Queries.GetFavoriteMovies
{
    public class GetFavoriteMoviesQueryHandler : IRequestHandler<GetFavoriteMoviesQuery, FavoriteMovieListVm>
    {
        private readonly IMapper _mapper;
        private readonly IMovieRepository _movieRepository;

        public GetFavoriteMoviesQueryHandler(IMapper mapper, IMovieRepository movieRepository)
        {
            _mapper = mapper;
            _movieRepository = movieRepository;
        }

        public async Task<FavoriteMovieListVm> Handle(GetFavoriteMoviesQuery request, CancellationToken cancellationToken)
        {
            var data = await _movieRepository.ListAllAsync();
            return new FavoriteMovieListVm
            {
                Movies = data.Select(_mapper.Map<FavoriteMovieDto>).ToList()
            };
        }
    }
}
