using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Infrastructure.Services.MovieApi
{
    public class MovieApiHttpClient
    {
        private readonly HttpClient _httpClient;

        public MovieApiHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T> SendGet<T>(string url)
        {
            var response = await _httpClient.GetAsync(url);
            return await HandleResponse<T>(response);
        }

        public static async Task<T> HandleResponse<T>(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
                return default;

            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseString);
        }
    }
}
