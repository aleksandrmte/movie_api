using Ardalis.GuardClauses;
using Domain.Common;

namespace Domain.Entities.Movies
{
    public class Movie: BaseEntity, IAggregateRoot
    {
        public string BackdropPath { get; set; }
        public string Overview { get; set; }
        public double Popularity { get; set; }
        public string PosterPath { get; set; }
        public string ReleaseDate { get; set; }
        public string Title { get; set; }
        public double VoteAverage { get; set; }
        public int VoteCount { get; set; }

        private Movie() { }

        public Movie(string title, string backDropPath, string overview, double popularity, string posterPath, string releaseDate, double voteAverage, int voteCount)
        {
            Guard.Against.NullOrEmpty(title, nameof(Title));

            Title = title;
            BackdropPath = backDropPath;
            Overview = overview;
            Popularity = popularity;
            PosterPath = posterPath;
            ReleaseDate = releaseDate;
            VoteAverage = voteAverage;
            VoteCount = voteCount;
        }
    }
}
