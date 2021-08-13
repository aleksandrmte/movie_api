using ApplicationCore.Movies.Queries.GetTopRatedMovies;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ApplicationCore.Movies.Commands.AddFavorite;
using ApplicationCore.Movies.Queries.GetFavoriteMovies;
using ApplicationCore.Movies.Queries.GetMovie;
using ApplicationCore.Movies.Queries.GetPopularMovies;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(){ }

        public async Task<IActionResult> Index(int page = 1)
        {
            var model = await Mediator.Send(new GetTopRatedMoviesQuery(page));
            return View(new MoviesPaginationModel
            {
                TotalPages = model.TotalPages,
                Page = model.Page,
                Movies = model.Movies
            });
        }

        public async Task<IActionResult> Popular(int page = 1)
        {
            var model = await Mediator.Send(new GetPopularMoviesQuery(page));
            return View(new MoviesPaginationModel
            {
                TotalPages = model.TotalPages,
                Page = model.Page,
                Movies = model.Movies
            });
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id <= 0)
                return NotFound();

            var model = await Mediator.Send(new GetMovieQuery(id));

            return View(model);
        }

        public async Task<IActionResult> Favorites()
        {
            var model = await Mediator.Send(new GetFavoriteMoviesQuery());

            return View(model.Movies);
        }

        public async Task<IActionResult> AddFavorite(int movieId)
        {
            var model = await Mediator.Send(new GetMovieQuery(movieId));
            await Mediator.Send(new AddFavoriteCommand(model.Title, movieId, model.PosterPath));
            return RedirectToAction("Favorites");
        }
    }
}
