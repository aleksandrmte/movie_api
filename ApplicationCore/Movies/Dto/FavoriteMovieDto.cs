using ApplicationCore.Common.Mappings;
using AutoMapper;
using Domain.Entities.Movies;

namespace ApplicationCore.Movies.Dto
{
    public class FavoriteMovieDto : IMapFrom<FavoriteMovie>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int MovieId { get; set; }
        public string Poster { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<FavoriteMovie, FavoriteMovieDto>();
        }
    }
}
