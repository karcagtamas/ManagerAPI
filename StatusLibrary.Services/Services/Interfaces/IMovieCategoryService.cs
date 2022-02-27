﻿using ManagerAPI.Domain.Entities.SL;
using ManagerAPI.Services.Repositories;
using ManagerAPI.Shared.DTOs.SL;

namespace StatusLibrary.Services.Services.Interfaces;

/// <summary>
/// Movie Category Service
/// </summary>
public interface IMovieCategoryService : INotificationRepository<MovieCategory, int>
{
    /// <summary>
    /// Gets selector list for the given movie.
    /// </summary>
    /// <param name="movieId">Movie Id</param>
    /// <returns>Movie category selector list for the requested movie.</returns>
    List<MovieCategorySelectorListDto> GetSelectorList(int movieId);
}
