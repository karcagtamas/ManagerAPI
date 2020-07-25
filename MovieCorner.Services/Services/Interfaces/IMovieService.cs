﻿using ManagerAPI.Shared.DTOs.MC;
using ManagerAPI.Shared.Models.MC;
using System.Collections.Generic;

namespace MovieCorner.Services.Services.Interfaces
{
    public interface IMovieService
    {
        List<MovieListDto> GetMovies();
        MovieDto GetMovie(int id);
        List<MyMovieDto> GetMyMovies();
        void CreateMovie(MovieModel model);
        void UpdateMovie(int id, MovieModel model);
        void DeleteMovie(int id);
        void UpdateSeenStatus(int id, bool seen);
        void UpdateMyMovies(List<int> ids);
    }
}