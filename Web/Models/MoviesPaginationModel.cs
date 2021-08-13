using ApplicationCore.Movies.Dto;
using System.Collections.Generic;

namespace Web.Models
{
    public class MoviesPaginationModel
    {
        public IEnumerable<MovieDto> Movies { get; set; } = new List<MovieDto>();
        public int TotalPages { get; set; }
        public int Page { get; set; }
    }
}
