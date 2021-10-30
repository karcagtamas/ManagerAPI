using ManagerAPI.Domain.Entities.SL;
using ManagerAPI.Services.Common.Repository;
using ManagerAPI.Shared.DTOs.SL;
using ManagerAPI.Shared.Models.SL;

namespace MovieCorner.Services.Services.Interfaces
{
    /// <summary>
    /// Episode service
    /// </summary>
    public interface IEpisodeService : IRepository<Episode>
    {
        /// <summary>
        /// Update seen status for episode
        /// </summary>
        /// <param name="id">Episode Id</param>
        /// <param name="seen">Seen status</param>
        void UpdateSeenStatus(int id, bool seen);

        /// <summary>
        /// Add episode to the given season.
        /// The episode number will be next number after the last episode.
        /// </summary>
        /// <param name="seasonId">Season Id</param>
        /// <param name="count">Number of new episodes</param>
        void AddIncremented(int seasonId, int count);

        /// <summary>
        /// Delete episode by the given Id.
        /// Every continous episode's number will be decremented by one.
        /// </summary>
        /// <param name="episodeId">Episode Id</param>
        void DeleteDecremented(int episodeId);

        /// <summary>
        /// Gets my object by the given Id.
        /// </summary>
        /// <param name="id">Episode Id</param>
        /// <returns>My episode object</returns>
        MyEpisodeDto GetMy(int id);

        /// <summary>
        /// Updates episode's image.
        /// </summary>
        /// <param name="id">Episode Id</param>
        /// <param name="model">New image model</param>
        void UpdateImage(int id, EpisodeImageModel model);
    }
}