using ManagerAPI.Domain.Entities.SL;
using ManagerAPI.Services.Common;
using ManagerAPI.Shared.DTOs.SL;
using ManagerAPI.Shared.Models.SL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StatusLibrary.Services.Services.Interfaces;

namespace ManagerAPI.Backend.Controllers
{
    /// <summary>
    /// Series controller
    /// </summary>
    [Route("api/[controller]")]
    [Authorize(Roles = "Administrator,Status Library User,Status Library Moderator,Status Library Administrator,Root")]
    [ApiController]
    public class SeriesController : MyController<Series, int, SeriesModel, SeriesListDto, SeriesDto>
    {
        private readonly ISeriesService _seriesService;

        /// <summary>
        /// Init series controller
        /// </summary>
        /// <param name="seriesService">Series service</param>
        public SeriesController(ISeriesService seriesService) : base(seriesService)
        {
            this._seriesService = seriesService;
        }

        /// <summary>
        /// Get my list endpoint
        /// </summary>
        [HttpGet("my")]
        public IActionResult GetMyList()
        {
            return this.Ok(this._seriesService.GetMyList());
        }

        /// <summary>
        /// Get my endpoint
        /// </summary>
        /// <param name="id">Path param id</param>
        [HttpGet("my/{id}")]
        public IActionResult GetMy(int id)
        {
            return this.Ok(this._seriesService.GetMy(id));
        }

        /// <summary>
        /// Get my selector list endpoint
        /// </summary>
        /// <param name="onlyMine">Query param</param>
        [HttpGet("selector")]
        public IActionResult GetMySelectorList([FromQuery] bool onlyMine)
        {
            return this.Ok(this._seriesService.GetMySelectorList(onlyMine));
        }

        /// <summary>
        /// Update my list endpoint
        /// </summary>
        /// <param name="model">Model</param>
        [HttpPut("map")]
        public IActionResult UpdateMySeries([FromBody] MySeriesModel model)
        {
            this._seriesService.UpdateMySeries(model.Ids);
            return this.Ok();
        }

        /// <summary>
        /// Update seen status endpoint
        /// </summary>
        /// <param name="model">Model</param>
        [HttpPut("map/status")]
        public IActionResult UpdateSeenStatus([FromBody] SeriesSeenStatusModel model)
        {
            this._seriesService.UpdateSeenStatus(model.Id, model.Seen);
            return this.Ok();
        }

        /// <summary>
        /// Add to my list endpoint
        /// </summary>
        /// <param name="id">Path param id</param>
        [HttpPost("map/{id}")]
        public IActionResult AddSeriesToMySeries(int id)
        {
            this._seriesService.AddSeriesToMySeries(id);
            return this.Ok();
        }

        /// <summary>
        /// Remove from my list endpoint
        /// </summary>
        /// <param name="id">Path param id</param>
        [HttpDelete("map/{id}")]
        public IActionResult RemoveBookFromMyBooks(int id)
        {
            this._seriesService.RemoveSeriesFromMySeries(id);
            return this.Ok();
        }

        /// <summary>
        /// Update image endpoint
        /// </summary>
        /// <param name="id">Path param id</param>
        /// <param name="model">Model</param>
        [HttpPut("image/{id}")]
        [Authorize(Roles = "Administrator,Root,Moderator,Status Library Moderator,Status Library Administrator")]
        public IActionResult UpdateImage(int id, [FromBody] SeriesImageModel model)
        {
            this._seriesService.UpdateImage(id, model);
            return this.Ok();
        }

        /// <summary>
        /// Update categories endpoint
        /// </summary>
        /// <param name="id">Path param id</param>
        /// <param name="model">Model</param>
        [HttpPut("categories/{id}")]
        [Authorize(Roles = "Administrator,Root,Moderator,Status Library Moderator,Status Library Administrator")]
        public IActionResult UpdateCategories(int id, [FromBody] SeriesCategoryUpdateModel model)
        {
            this._seriesService.UpdateCategories(id, model);
            return this.Ok();
        }

        /// <summary>
        /// Updat rate endpoint
        /// </summary>
        /// <param name="id">Path param id</param>
        /// <param name="model">Model</param>
        [HttpPut("rate/{id}")]
        public IActionResult UpdateRate(int id, [FromBody] SeriesRateModel model)
        {
            this._seriesService.UpdateRate(id, model);
            return this.Ok();
        }

        /// <summary>
        /// Create endpoint
        /// </summary>
        /// <param name="model">Model</param>
        [HttpPost]
        [Authorize(Roles = "Administrator,Root,Moderator,Status Library Moderator,Status Library Administrator")]
        public override IActionResult Create([FromBody] SeriesModel model)
        {
            this._seriesService.CreateFromModel(model);
            return this.Ok();
        }

        /// <summary>
        /// Delete endpoint
        /// </summary>
        /// <param name="id">Path param id</param>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator,Root,Status Library Administrator")]
        public override IActionResult Delete(int id)
        {
            this._seriesService.DeleteById(id);
            return this.Ok();
        }

        /// <summary>
        /// Update endpoint
        /// </summary>
        /// <param name="id">Path param id</param>
        /// <param name="model">Model</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator,Root,Moderator,Status Library Moderator,Status Library Administrator")]
        public override IActionResult Update(int id, SeriesModel model)
        {
            this._seriesService.UpdateByModel(id, model);
            return this.Ok();
        }
    }
}