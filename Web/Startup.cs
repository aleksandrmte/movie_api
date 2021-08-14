using ApplicationCore;
using ApplicationCore.Movies.Services.MovieApi;
using Infrastructure;
using Infrastructure.Data;
using Infrastructure.Services.MovieApi;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Reflection;
using Web.Common.Filters;
using Web.Common.Settings;

namespace Web
{
    public class Startup
    {
        private AppSettings AppSettings { get; } = new AppSettings();

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            configuration.Bind(AppSettings);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //application.core
            services.AddApplication(Assembly.GetExecutingAssembly());
            //infrastructure
            services.AddInfrastructure(Configuration);
            //web
            services.AddMediatR(Assembly.GetExecutingAssembly());
            
            services.AddHttpContextAccessor();

            services.AddHealthChecks()
                .AddDbContextCheck<DataContext>();

            services.AddControllersWithViews(options =>
                options.Filters.Add(new ApiExceptionFilter()));

            services.AddHttpClient<MovieApiHttpClient>(client =>
            {
                client.BaseAddress = new Uri(AppSettings.MovieApi.Host);
                client.Timeout = new TimeSpan(1, 1, 0);
            });
            services.AddSingleton(new MovieApiKey {ApiKey = AppSettings.MovieApi.ApiKey});
            services.AddTransient<IMovieApiService, MovieApiService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();
           
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
