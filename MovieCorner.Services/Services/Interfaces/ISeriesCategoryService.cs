using ManagerAPI.Domain.Entities.SL;
using ManagerAPI.Services.Common.Repository;
using ManagerAPI.Shared.DTOs.SL;
using System.Collections.Generic;

namespace MovieCorner.Services.Services.Interfaces
{
    /// <summary>
    /// Series Category Series
    /// </summary>
    public interface ISeriesCategoryService : IRepository<SeriesCategory>
    {
        /// <summary>
        /// Gets selector list for the given series.
        /// </summary>
        /// <param name="seriesId">Series Id</param>
        /// <returns>Series category selector list for the requested series.</returns>
        List<SeriesCategorySelectorListDto> GetSelectorList(int seriesId);
    }
}