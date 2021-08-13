using ApplicationCore.Movies.Interfaces;
using Domain.Entities.Movies;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationCore.Movies.Commands.AddFavorite
{
    public class AddFavoriteCommandHandler : IRequestHandler<AddFavoriteCommand, int>
    {
        private readonly IMovieRepository _movieRepository;

        public AddFavoriteCommandHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<int> Handle(AddFavoriteCommand request, CancellationToken cancellationToken)
        {
            var entity = new FavoriteMovie(request.Title, request.MovieId, request.Poster);
            await _movieRepository.AddAsync(entity);
            return entity.Id;
        }
    }
}
