using EventManager.Client.Http;
using ManagerAPI.Shared.DTOs.SL;
using ManagerAPI.Shared.Models.SL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventManager.Client.Services.Interfaces
{
    /// <summary>
    /// Episode Service
    /// </summary>
    public interface IEpisodeService : IHttpCall<EpisodeListDto, EpisodeDto, EpisodeModel>
    {
        /// <summary>
        /// Update seen statues
        /// </summary>
        /// <param name="models">Model</param>
        Task<bool> UpdateSeenStatus(List<EpisodeSeenStatusModel> models);

        /// <summary>
        /// Add incremented episode to season
        /// </summary>
        /// <param name="seasonId">Season Id</param>
        Task<bool> AddIncremented(int seasonId);

        /// <summary>
        /// Delete last episode by Id
        /// </summary>
        /// <param name="episodeId">Episode Id</param>
        Task<bool> DeleteDecremented(int episodeId);

        /// <summary>
        /// Get my episode by Id
        /// </summary>
        /// <param name="id">Episode Id</param>
        /// <returns>My Episode</returns>
        Task<MyEpisodeDto> GetMy(int id);

        /// <summary>
        /// short update for episode
        /// </summary>
        /// <param name="id">Episode Id</param>
        /// <param name="model">Model</param>
        Task<bool> UpdateShort(int id, EpisodeShortModel model);

        /// <summary>
        /// Update episode image
        /// </summary>
        /// <param name="id">Episode Id</param>
        /// <param name="model">Model</param>
        Task<bool> UpdateImage(int id, EpisodeImageModel model);
    }
}