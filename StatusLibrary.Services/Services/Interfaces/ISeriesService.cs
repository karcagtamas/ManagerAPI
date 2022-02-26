using ManagerAPI.Domain.Entities.SL;
using ManagerAPI.Services.Common.Repository;
using ManagerAPI.Shared.DTOs.SL;
using ManagerAPI.Shared.Models.SL;

namespace StatusLibrary.Services.Services.Interfaces;

/// <summary>
/// Series Service
/// </summary>
public interface ISeriesService : IRepository<Series>
{
    /// <summary>
    /// Gets my list
    /// </summary>
    /// <returns>My series list</returns>
    List<MySeriesListDto> GetMyList();

    /// <summary>
    /// Gets my object
    /// </summary>
    /// <param name="id">Series Id</param>
    /// <returns>Get my series object by Id</returns>
    MySeriesDto GetMy(int id);

    /// <summary>
    /// Update my list
    /// </summary>
    /// <param name="ids">Current my series list</param>
    void UpdateMySeries(List<int> ids);

    /// <summary>
    /// Update seen status for mapped series
    /// </summary>
    /// <param name="id">Series id</param>
    /// <param name="seen">Seen status</param>
    void UpdateSeenStatus(int id, bool seen);

    /// <summary>
    /// Add series to my list
    /// </summary>
    /// <param name="id">Series Id</param>
    void AddSeriesToMySeries(int id);

    /// <summary>
    /// Remove series from my list
    /// </summary>
    /// <param name="id">Series Id</param>
    void RemoveSeriesFromMySeries(int id);

    /// <summary>
    /// Get my selector list
    /// </summary>
    /// <param name="onlyMine">Return only mine elements</param>
    /// <returns>Get my series selector list</returns>
    List<MySeriesSelectorListDto> GetMySelectorList(bool onlyMine);

    /// <summary>
    /// Updates series's image.
    /// </summary>
    /// <param name="id">Series Id</param>
    /// <param name="model">New image model</param>
    void UpdateImage(int id, SeriesImageModel model);

    /// <summary>
    /// Updates series's categories
    /// </summary>
    /// <param name="id">Series Id</param>
    /// <param name="model">Categories model</param>
    void UpdateCategories(int id, SeriesCategoryUpdateModel model);

    /// <summary>
    /// Updates series's rate status for current user.
    /// </summary>
    /// <param name="id">Series Id</param>
    /// <param name="model">Rate model</param>
    void UpdateRate(int id, SeriesRateModel model);
}
