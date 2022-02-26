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
    /// Series category controller
    /// </summary>
    [Route("api/series-category")]
    [ApiController]
    [Authorize(Roles = "Administrator,Status Library User,Status Library Moderator,Status Library Administrator,Root")]
    public class SeriesCategoryController : MyController<SeriesCategory, SeriesCategoryModel, SeriesCategoryDto,
            SeriesCategoryDto>
    {
        private readonly ISeriesCategoryService _seriesCategoryService;

        /// <summary>
        /// Init series category controller
        /// </summary>
        /// <param name="service">Series category service</param>
        public SeriesCategoryController(ISeriesCategoryService service) : base(service)
        {
            this._seriesCategoryService = service;
        }

        /// <summary>
        /// Get selector list endpoint
        /// </summary>
        /// <param name="seriesId">Path param id</param>
        [HttpGet("selector/{seriesId}")]
        public IActionResult GetSelectorList(int seriesId)
        {
            return this.Ok(this._seriesCategoryService.GetSelectorList(seriesId));
        }
    }
}