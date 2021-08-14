﻿using ApplicationCore.Movies.Dto;
using ApplicationCore.Movies.Services.MovieApi;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationCore.Movies.Queries.GetTopRatedMovies
{
    public class GetTopRatedMoviesQueryHandler : IRequestHandler<GetTopRatedMoviesQuery, MovieListVm>
    {
        private readonly IMovieApiService _movieApiService;
        private readonly IMapper _mapper;

        public GetTopRatedMoviesQueryHandler(IMovieApiService movieApiService, IMapper mapper)
        {
            _movieApiService = movieApiService;
            _mapper = mapper;
        }

        public async Task<MovieListVm> Handle(GetTopRatedMoviesQuery request, CancellationToken cancellationToken)
        {
            var data = await _movieApiService.GetTopRated(request.Page);
            return _mapper.Map<MovieListVm>(data);
        }
    }
}
