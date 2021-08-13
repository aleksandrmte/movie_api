using Ardalis.GuardClauses;
using Domain.Common;

namespace Domain.Entities.Movies
{
    public class FavoriteMovie: BaseEntity, IAggregateRoot
    {
        public string Title { get; private set; }
        public int MovieId { get; private set; }
        public string Poster { get; private set; }

        private FavoriteMovie() { }

        public FavoriteMovie(string title, int movieId, string poster)
        {
            Guard.Against.NullOrEmpty(title, nameof(Title));
            Guard.Against.NegativeOrZero(movieId, nameof(MovieId));

            Title = title;
            MovieId = movieId;
            Poster = poster;
        }
    }
}
