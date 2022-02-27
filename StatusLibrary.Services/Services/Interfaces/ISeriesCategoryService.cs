using ManagerAPI.Domain.Entities.SL;
using ManagerAPI.Services.Repositories;
using ManagerAPI.Shared.DTOs.SL;

namespace StatusLibrary.Services.Services.Interfaces;

/// <summary>
/// Series Category Series
/// </summary>
public interface ISeriesCategoryService : INotificationRepository<SeriesCategory, int>
{
    /// <summary>
    /// Gets selector list for the given series.
    /// </summary>
    /// <param name="seriesId">Series Id</param>
    /// <returns>Series category selector list for the requested series.</returns>
    List<SeriesCategorySelectorListDto> GetSelectorList(int seriesId);
}
