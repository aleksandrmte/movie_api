using System.Collections.Generic;

namespace Web.Models.Movies
{
    public class MoviePaginationViewModel
    {
        public IEnumerable<MovieViewModel> Results { get; set; } = new List<MovieViewModel>();
        public int TotalPages { get; set; }
        public int Page { get; set; }
    }
}
