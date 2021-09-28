using ManagerAPI.Domain.Entities.SL;
using ManagerAPI.Services.Common;
using ManagerAPI.Shared.DTOs.SL;
using ManagerAPI.Shared.Models.SL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieCorner.Services.Services.Interfaces;
using System.Collections.Generic;

namespace ManagerAPI.Backend.Controllers
{
    /// <summary>
    /// Episode controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrator,Status Library User,Status Library Moderator,Status Library Administrator,Root")]
    public class EpisodeController : MyController<Episode, EpisodeModel, EpisodeListDto, EpisodeDto>
    {
        private readonly IEpisodeService _episodeService;

        /// <summary>
        /// Init episode controller
        /// </summary>
        /// <param name="episodeService">Episode service</param>
        public EpisodeController(IEpisodeService episodeService) : base(episodeService)
        {
            this._episodeService = episodeService;
        }

        /// <summary>
        /// Update seen status endpoint
        /// </summary>
        /// <param name="models">Model</param>
        [HttpPut("map/status")]
        public IActionResult UpdateSeenStatus([FromBody] List<EpisodeSeenStatusModel> models)
        {
            foreach (var episode in models)
            {
                this._episodeService.UpdateSeenStatus(episode.Id, episode.Seen);
            }

            return this.Ok();
        }

        /// <summary>
        /// Add incremented episode to season endpoint
        /// </summary>
        /// <param name="seasonId">Path param id</param>
        /// <param name="count">Number of new episodes</param>
        [HttpPost("{seasonId:int}")]
        [Authorize(Roles = "Administrator,Root,Moderator,Status Library Moderator,Status Library Administrator")]
        public IActionResult AddIncremented(int seasonId, [FromQuery] int count)
        {
            this._episodeService.AddIncremented(seasonId, count);
            return this.Ok();
        }

        /// <summary>
        /// Remove last episode id endpoint
        /// </summary>
        /// <param name="episodeId">Path param id</param>
        [HttpDelete("decremented/{episodeId}")]
        [Authorize(Roles = "Administrator,Root,Status Library Administrator")]
        public IActionResult DeleteDecremented(int episodeId)
        {
            this._episodeService.DeleteDecremented(episodeId);
            return this.Ok();
        }

        /// <summary>
        /// Get my endpoint
        /// </summary>
        /// <param name="id">Path param id</param>
        [HttpGet("my/{id}")]
        public IActionResult GetMy(int id)
        {
            return this.Ok(this._episodeService.GetMy(id));
        }

        /// <summary>
        /// Update short endpoint
        /// </summary>
        /// <param name="id">Path param id</param>
        /// <param name="model">Model</param>
        [HttpPut("short/{id}")]
        [Authorize(Roles = "Administrator,Root,Moderator,Status Library Moderator,Status Library Administrator")]
        public IActionResult UpdateShort(int id, [FromBody] EpisodeShortModel model)
        {
            this._episodeService.Update<EpisodeShortModel>(id, model);
            return this.Ok();
        }

        /// <summary>
        /// Update image endpoint
        /// </summary>
        /// <param name="id">Path param id</param>
        /// <param name="model">Model</param>
        [HttpPut("image/{id}")]
        [Authorize(Roles = "Administrator,Root,Moderator,Status Library Moderator,Status Library Administrator")]
        public IActionResult UpdateImage(int id, [FromBody] EpisodeImageModel model)
        {
            this._episodeService.UpdateImage(id, model);
            return this.Ok();
        }
    }
}