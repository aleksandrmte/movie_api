using ApplicationCore.Movies.Dto;
using Domain.Entities.Movies;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationCore.Movies.Extensions
{
    public static class MovieExtensions
    {
        public static void FillFavoriteMovies(this MovieListVm data, IReadOnlyList<FavoriteMovie> favoriteMovies)
        {
            data.Results.ForEach(x =>
            {
                var favorite = favoriteMovies.FirstOrDefault(f => f.MovieId == x.Id);
                if (favorite == null)
                    return;
                x.IsFavorite = true;
                x.FavoriteMovieId = favorite.MovieId;
            });
        }
    }
}
