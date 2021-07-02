using EventManager.Client.Http;
using ManagerAPI.Shared.DTOs.SL;
using ManagerAPI.Shared.Models.SL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventManager.Client.Services.Interfaces
{
    /// <summary>
    /// Season Service
    /// </summary>
    public interface ISeasonService : IHttpCall<SeasonListDto, SeasonDto, SeasonModel>
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
        Task<bool> AddIncremented(int seriesId);

        /// <summary>
        /// Delete season by Id
        /// </summary>
        /// <param name="seasonId">Season Id</param>
        Task<bool> DeleteDecremented(int seasonId);
    }
}