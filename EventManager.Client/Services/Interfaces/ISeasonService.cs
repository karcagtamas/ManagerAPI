using KarcagS.Blazor.Common.Http;
using ManagerAPI.Shared.Models.SL;

namespace EventManager.Client.Services.Interfaces;

/// <summary>
/// Season Service
/// </summary>
public interface ISeasonService : IHttpCall<int>
{
    /// <summary>
    /// Update seen statuses
    /// </summary>
    /// <param name="models">Models</param>
    Task<bool> UpdateSeenStatus(List<SeasonSeenStatusModel> models);

    /// <summary>
    /// Add incremented season to series
    /// </summary>
    /// <param name="seriesId">Series Id</param>
    /// <param name="count">Number of new seasons</param>
    Task<bool> AddIncremented(int seriesId, int count);

    /// <summary>
    /// Delete season by Id
    /// </summary>
    /// <param name="seasonId">Season Id</param>
    Task<bool> DeleteDecremented(int seasonId);
}