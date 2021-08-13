using ApplicationCore.Movies.Dto;
using MediatR;

namespace ApplicationCore.Movies.Queries.GetMovie
{
    public class GetMovieQuery : IRequest<MovieDto>
    {
        public int Id { get; set; }

        public GetMovieQuery(int id)
        {
            Id = id;
        }
    }
}
