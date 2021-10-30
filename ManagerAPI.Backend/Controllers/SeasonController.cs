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
    /// Season controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrator,Status Library User,Status Library Moderator,Status Library Administrator,Root")]
    public class SeasonController : MyController<Season, SeasonModel, SeasonListDto, SeasonDto>
    {
        private readonly ISeasonService _seasonService;

        /// <summary>
        /// Init season controller
        /// </summary>
        /// <param name="seasonService">Season service</param>
        public SeasonController(ISeasonService seasonService) : base(seasonService)
        {
            this._seasonService = seasonService;
        }

        /// <summary>
        /// Update seen status endpoint
        /// </summary>
        /// <param name="models">Models</param>
        [HttpPut("map/status")]
        public IActionResult UpdateSeenStatus([FromBody] List<SeasonSeenStatusModel> models)
        {
            foreach (var season in models)
            {
                this._seasonService.UpdateSeenStatus(season.Id, season.Seen);
            }

            return this.Ok();
        }

        /// <summary>
        /// Add incremented endpoint
        /// </summary>
        /// <param name="seriesId">Path param id</param>
        /// <param name="count">Count of new seasons</param>
        [HttpPost("{seriesId:int}")]
        [Authorize(Roles = "Administrator,Root,Moderator,Status Library Moderator,Status Library Administrator")]
        public IActionResult AddIncremented(int seriesId, [FromQuery] int count)
        {
            this._seasonService.AddIncremented(seriesId, count);
            return this.Ok();
        }

        /// <summary>
        /// Delete last endpoint
        /// </summary>
        /// <param name="seasonId">Path param id</param>
        [HttpDelete("decremented/{seasonId}")]
        [Authorize(Roles = "Administrator,Root,Status Library Administrator")]
        public IActionResult DeleteDecremented(int seasonId)
        {
            this._seasonService.DeleteDecremented(seasonId);
            return this.Ok();
        }
    }
}