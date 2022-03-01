using KarcagS.Blazor.Common.Http;
using ManagerAPI.Shared.DTOs.SL;
using ManagerAPI.Shared.Models.SL;

namespace EventManager.Client.Services.Interfaces
{
    /// <summary>
    /// Series Service
    /// </summary>
    public interface ISeriesService : IHttpCall<int>
    {
        /// <summary>
        /// Get my list
        /// </summary>
        /// <returns>List of series</returns>
        Task<List<MySeriesListDto>> GetMyList();

        /// <summary>
        /// Get my series by Id
        /// </summary>
        /// <param name="id">Series Id</param>
        /// <returns>My Series</returns>
        Task<MySeriesDto?> GetMy(int id);

        /// <summary>
        /// Update my series
        /// </summary>
        /// <param name="model">Model</param>
        Task<bool> UpdateMySeries(MySeriesModel model);

        /// <summary>
        /// Update seen status
        /// </summary>
        /// <param name="model">Model</param>
        Task<bool> UpdateSeenStatus(SeriesSeenStatusModel model);

        /// <summary>
        /// Add series to my list
        /// </summary>
        /// <param name="id">Series Id</param>
        Task<bool> AddSeriesToMySeries(int id);

        /// <summary>
        /// Remove series from my list
        /// </summary>
        /// <param name="id">Series Id</param>
        Task<bool> RemoveSeriesFromMySeries(int id);

        /// <summary>
        /// Get my series selector list
        /// </summary>
        /// <param name="onlyMine">Only my elements</param>
        /// <returns>Selector list</returns>
        Task<List<MySeriesSelectorListDto>> GetMySelectorList(bool onlyMine);

        /// <summary>
        /// Update image
        /// </summary>
        /// <param name="id">Series Id</param>
        /// <param name="model">Model</param>
        Task<bool> UpdateImage(int id, SeriesImageModel model);

        /// <summary>
        /// Update categories
        /// </summary>
        /// <param name="id">Series Id</param>
        /// <param name="model">Model</param>
        Task<bool> UpdateCategories(int id, SeriesCategoryUpdateModel model);

        /// <summary>
        /// Update rate
        /// </summary>
        /// <param name="id">Series Id</param>
        /// <param name="model">Model</param>
        Task<bool> UpdateRate(int id, SeriesRateModel model);
    }
}