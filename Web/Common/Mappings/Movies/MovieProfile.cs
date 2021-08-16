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
            CreateMap<FavoriteMovieDto, MovieViewModel>()
                .ForMember(dest => dest.IsFavorite, opt => opt.MapFrom(m => true))
                .ForMember(dest => dest.FavoriteMovieId, opt => opt.MapFrom(m => m.Id))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(m => m.MovieId))
                .ForMember(dest => dest.PosterPath, opt => opt.MapFrom(m => m.Poster));
        }

    }
}
