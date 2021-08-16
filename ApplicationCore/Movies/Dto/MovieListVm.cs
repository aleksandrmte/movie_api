using ApplicationCore.Common.Mappings;
using ApplicationCore.Movies.Services.MovieApi.Dto;
using AutoMapper;
using System.Collections.Generic;

namespace ApplicationCore.Movies.Dto
{
    public class MovieListVm: IMapFrom<MovieApiResponse>
    {
        public List<MovieDto> Results { get; set; }
        public int TotalPages { get; set; }
        public int Page { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<MovieApiResponse, MovieListVm>();
        }
    }
}
