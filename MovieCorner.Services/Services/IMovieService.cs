﻿using System.Collections.Generic;
using ManagerAPI.Models.DTOs;

namespace MovieCorner.Services.Services
{
    public interface IMovieService
    {
        List<MovieListDto> GetMovies();

        MovieListDto GetMovie(int id);

        List<MovieDto> GetOwnMovies(string userId);

        MovieListDto CreateMovie(MovieCreateDto model, string userId);

        void UpdateMovie(MovieUpdateDto model, int id);

        void DeleteMovie(int id);

        void UpdateSeenStatus(int id, string userId, bool seen);

        void UpdateMovieMappings(string userId, List<MovieListDto> mappings);
    }
}