using ManagerAPI.Domain.Entities.SL;
using ManagerAPI.Services.Repositories;

namespace StatusLibrary.Services.Services.Interfaces;

/// <summary>
/// Season Service
/// </summary>
public interface ISeasonService : INotificationRepository<Season, int>
{
    /// <summary>
    /// Update seen status for season's episodes
    /// </summary>
    /// <param name="id">Season Id</param>
    /// <param name="seen">Seen status</param>
    void UpdateSeenStatus(int id, bool seen);

    /// <summary>
    /// Add season to the given series.
    /// The season number will be next number after the last season.
    /// </summary>
    /// <param name="seriesId">Series Id</param>
    /// <param name="count">Number of new seasons</param>
    void AddIncremented(int seriesId, int count);

    /// <summary>
    /// Delete season by the given Id.
    /// Every continuous season's number will be decremented by one.
    /// </summary>
    /// <param name="seasonId">Season Id</param>
    void DeleteDecremented(int seasonId);
}
