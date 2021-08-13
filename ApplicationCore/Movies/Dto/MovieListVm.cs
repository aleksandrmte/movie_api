using System.Collections.Generic;

namespace ApplicationCore.Movies.Dto
{
    public class MovieListVm
    {
        public IList<MovieDto> Movies { get; set; }
        public int TotalPages { get; set; }
        public int Page { get; set; }
    }
}
