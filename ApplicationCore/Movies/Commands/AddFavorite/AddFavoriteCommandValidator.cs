using ApplicationCore.Movies.Interfaces;
using FluentValidation;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationCore.Movies.Commands.AddFavorite
{
    public class AddFavoriteCommandValidator : AbstractValidator<AddFavoriteCommand>
    {
        private readonly IMovieRepository _movieRepository;

        public AddFavoriteCommandValidator(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;

            RuleFor(v => v.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(200).WithMessage("Title must not exceed 200 characters.");

            RuleFor(v => v.MovieId)
                .MustAsync(BeUnique).WithMessage("The specified Movie already exists.");
        }

        public async Task<bool> BeUnique(int movieId, CancellationToken cancellationToken)
        {
            var data = (await _movieRepository.ListAllAsync()).Where(x=>x.MovieId == movieId);
            return !data.Any();

        }
    }
}
