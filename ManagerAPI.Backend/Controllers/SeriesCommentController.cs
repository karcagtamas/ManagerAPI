using ManagerAPI.Domain.Entities.SL;
using ManagerAPI.Services.Common;
using ManagerAPI.Shared.DTOs.SL;
using ManagerAPI.Shared.Models.SL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieCorner.Services.Services.Interfaces;

namespace ManagerAPI.Backend.Controllers
{
    /// <summary>
    /// Series comment controller
    /// </summary>
    [Route("api/series-comment")]
    [ApiController]
    [Authorize(Roles = "Administrator,Status Library User,Status Library Moderator,Status Library Administrator,Root")]
    public class SeriesCommentController : MyController<SeriesComment, SeriesCommentModel, SeriesCommentListDto, SeriesCommentDto
        >
    {
        private readonly ISeriesCommentService _seriesCommentService;

        /// <summary>
        /// Init Series comment controller
        /// </summary>
        /// <param name="service">Series comment service</param>
        public SeriesCommentController(ISeriesCommentService service) : base(service)
        {
            this._seriesCommentService = service;
        }

        /// <summary>
        /// Get list endpoint
        /// </summary>
        /// <param name="seriesId">Path param id</param>
        [HttpGet("series/{seriesId}")]
        public IActionResult GetList(int seriesId)
        {
            return this.Ok(this._seriesCommentService.GetList(seriesId));
        }

        /// <summary>
        /// Create endpoint
        /// </summary>
        /// <param name="model">Model</param>
        [HttpPost]
        [Authorize(Roles =
            "Administrator,Status Library User,Status Library Moderator,Status Library Administrator,Root")]
        public override IActionResult Create([FromBody] SeriesCommentModel model)
        {
            this._seriesCommentService.Add<SeriesCommentModel>(model);
            return this.Ok();
        }

        /// <summary>
        /// Delete endpoint
        /// </summary>
        /// <param name="id">Path param id</param>
        [HttpDelete("{id}")]
        [Authorize(Roles =
            "Administrator,Status Library User,Status Library Moderator,Status Library Administrator,Root")]
        public override IActionResult Delete(int id)
        {
            this._seriesCommentService.Remove(id);
            return this.Ok();
        }

        /// <summary>
        /// Updat endpoint
        /// </summary>
        /// <param name="id">Path param id</param>
        /// <param name="model">Model</param>
        [HttpPut("{id}")]
        [Authorize(Roles =
            "Administrator,Status Library User,Status Library Moderator,Status Library Administrator,Root")]
        public override IActionResult Update(int id, SeriesCommentModel model)
        {
            this._seriesCommentService.Update<SeriesCommentModel>(id, model);
            return this.Ok();
        }
    }
}