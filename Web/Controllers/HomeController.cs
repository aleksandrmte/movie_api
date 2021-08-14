using ApplicationCore.Movies.Queries.GetTopRatedMovies;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ApplicationCore.Movies.Commands.AddFavorite;
using ApplicationCore.Movies.Queries.GetFavoriteMovies;
using ApplicationCore.Movies.Queries.GetMovie;
using ApplicationCore.Movies.Queries.GetPopularMovies;
using AutoMapper;
using Web.Models;
using Web.Models.Movies;

namespace Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IMapper _mapper;

        public HomeController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var model = await Mediator.Send(new GetTopRatedMoviesQuery(page));
            return View(_mapper.Map<MoviePaginationViewModel>(model));
        }

        public async Task<IActionResult> Popular(int page = 1)
        {
            var model = await Mediator.Send(new GetPopularMoviesQuery(page));
            return View(_mapper.Map<MoviePaginationViewModel>(model));
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
