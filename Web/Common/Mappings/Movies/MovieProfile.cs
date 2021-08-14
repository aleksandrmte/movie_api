using ApplicationCore.Movies.Dto;
using AutoMapper;
using Web.Models.Movies;

namespace Web.Common.Mappings.Movies
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<MovieDto, MovieViewModel>();
            CreateMap<MovieListVm, MoviePaginationViewModel>();
        }
        
    }
}
