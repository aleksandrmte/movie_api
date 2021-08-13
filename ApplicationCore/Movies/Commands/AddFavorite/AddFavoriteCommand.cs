using MediatR;

namespace ApplicationCore.Movies.Commands.AddFavorite
{
    public class AddFavoriteCommand : IRequest<int>
    {
        public string Title { get; set; }
        public int MovieId { get; set; }
        public string Poster { get; set; }

        public AddFavoriteCommand(string title, int movieId, string poster)
        {
            Title = title;
            MovieId = movieId;
            Poster = poster;
        }
    }
}
