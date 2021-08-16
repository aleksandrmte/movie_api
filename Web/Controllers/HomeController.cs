using System.Linq;
using ApplicationCore.Movies.Queries.GetTopRatedMovies;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ApplicationCore.Movies.Commands.AddFavorite;
using ApplicationCore.Movies.Commands.DeleteFavorite;
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

            return View(_mapper.Map<MovieViewModel>(model));
        }

        public async Task<IActionResult> Favorites()
        {
            var data = await Mediator.Send(new GetFavoriteMoviesQuery());
            var model = data.Movies.Select(_mapper.Map<MovieViewModel>);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddFavorite(AddFavoriteCommand command)
        {
            var model = await Mediator.Send(new GetMovieQuery(command.MovieId));
            command.Title = model.Title;
            command.Poster = model.PosterPath;
            var entityId = await Mediator.Send(command);
            return Json(entityId);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteFavorite(int id)
        {
            await Mediator.Send(new DeleteFavoriteCommand(id));
            return Json("Ok");
        }
    }
}
