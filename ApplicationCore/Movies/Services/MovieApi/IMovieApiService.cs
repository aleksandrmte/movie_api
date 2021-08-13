using ApplicationCore.Movies.Services.MovieApi.Dto;
using System.Threading.Tasks;

namespace ApplicationCore.Movies.Services.MovieApi
{
    public interface IMovieApiService
    {
        Task<MovieApiResponse> GetPopular(int page);
        Task<MovieApiResponse> GetTopRated(int page);
        Task<MovieApiModel> GetDetails(int id);
    }
}
