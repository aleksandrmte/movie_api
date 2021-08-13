using ApplicationCore.Movies.Interfaces;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(builder
                => builder.UseInMemoryDatabase("InMemoryDb"));
           
            services.AddScoped<IMovieRepository, MovieRepository>();

            return services;
        }
    }
}
