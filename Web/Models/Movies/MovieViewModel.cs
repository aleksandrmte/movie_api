namespace Web.Models.Movies
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        public string BackdropPath { get; set; }
        public string Overview { get; set; }
        public double Popularity { get; set; }
        public string PosterPath { get; set; }
        public string ReleaseDate { get; set; }
        public string Title { get; set; }
        public double VoteAverage { get; set; }
        public int VoteCount { get; set; }
        public int FavoriteMovieId { get; set; }
        public bool IsFavorite { get; set; }
    }
}
