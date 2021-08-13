using ApplicationCore.Movies.Services.MovieApi;
using ApplicationCore.Movies.Services.MovieApi.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services.MovieApi
{
    public class MovieApiService : IMovieApiService
    {
        private readonly MovieApiHttpClient _httpClient;
        private readonly string _apiKey;

        private readonly Dictionary<MovieLoadType, string> _urls = new Dictionary<MovieLoadType, string>
        {
            {MovieLoadType.Popular, "/3/movie/popular"},
            {MovieLoadType.TopRated, "/3/movie/top_rated"},
            {MovieLoadType.Details, "/3/movie/"}
        };

        public MovieApiService(MovieApiHttpClient httpClient, MovieApiKey apiKeyConfig)
        {
            _httpClient = httpClient;
            _apiKey = apiKeyConfig.ApiKey;
        }

        public async Task<MovieApiResponse> GetPopular(int page)
        {
            return await _httpClient.SendGet<MovieApiResponse>($"{_urls[MovieLoadType.Popular]}?api_key={_apiKey}&page={page}");
        }

        public async Task<MovieApiResponse> GetTopRated(int page)
        {
            return await _httpClient.SendGet<MovieApiResponse>($"{_urls[MovieLoadType.TopRated]}?api_key={_apiKey}&page={page}");
        }

        public async Task<MovieApiModel> GetDetails(int id)
        {
            var result = await _httpClient.SendGet<MovieApiModel>($"{_urls[MovieLoadType.Details]}{id}?api_key={_apiKey}");
            return result;
        }
    }

    public enum MovieLoadType
    {
        Popular = 1,
        TopRated,
        Details
    }

    public class MovieApiKey
    {
        public string ApiKey { get; set; }
    }
}
