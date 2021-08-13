using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Threading.Tasks;
using Web;
using Xunit;

namespace Tests
{
    public class UnitTest1
    {
        private readonly HttpClient _httpClient;

        public UnitTest1()
        {
            var appFactory = new WebApplicationFactory<Startup>();
            _httpClient = appFactory.CreateClient();
        }

        [Fact]
        public async Task TestClient()
        {
            var result = await _httpClient.GetAsync("Home/Details/0");
            Assert.Equal(HttpStatusCode.NotFound, result.StatusCode);
        }

        [Fact]
        public async Task TestClient2()
        {
            var result = await _httpClient.GetAsync("Home/Index");
            Assert.True(result.IsSuccessStatusCode);
        }
    }
}
