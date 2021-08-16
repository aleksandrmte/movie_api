using ApplicationCore.Movies.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationCore.Movies.Commands.DeleteFavorite
{
    public class DeleteFavoriteCommandHandler : IRequestHandler<DeleteFavoriteCommand, Task>
    {
        private readonly IMovieRepository _movieRepository;

        public DeleteFavoriteCommandHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<Task> Handle(DeleteFavoriteCommand request, CancellationToken cancellationToken)
        {
            var entity = await _movieRepository.GetByIdAsync(request.Id);
            if (entity == null)
                throw new Exception("Movie not found");
            await _movieRepository.DeleteAsync(entity);
            return Task.CompletedTask;
        }
    }
}
