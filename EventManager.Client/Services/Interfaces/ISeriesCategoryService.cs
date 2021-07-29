using EventManager.Client.Http;
using ManagerAPI.Shared.DTOs.SL;
using ManagerAPI.Shared.Models.SL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventManager.Client.Services.Interfaces
{
    /// <summary>
    /// Series Category Service
    /// </summary>
    public interface ISeriesCategoryService : IHttpCall<SeriesCategoryDto, SeriesCategoryDto, SeriesCategoryModel>
    {
        /// <summary>
        /// Get selector list by Series Id
        /// </summary>
        /// <param name="seriesId">Series Id</param>
        /// <returns>Selector list</returns>
        Task<List<SeriesCategorySelectorListDto>> GetSelectorList(int seriesId);
    }
}