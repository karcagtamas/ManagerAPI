using KarcagS.Blazor.Common.Http;
using ManagerAPI.Shared.DTOs.SL;

namespace EventManager.Client.Services.Interfaces;

/// <summary>
/// Series Category Service
/// </summary>
public interface ISeriesCategoryService : IHttpCall<int>
{
    /// <summary>
    /// Get selector list by Series Id
    /// </summary>
    /// <param name="seriesId">Series Id</param>
    /// <returns>Selector list</returns>
    Task<List<SeriesCategorySelectorListDto>> GetSelectorList(int seriesId);
}