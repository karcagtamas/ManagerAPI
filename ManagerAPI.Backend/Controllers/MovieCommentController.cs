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
    /// Movie comment controller
    /// </summary>
    [Route("api/movie-comment")]
    [ApiController]
    [Authorize(Roles = "Administrator,Status Library User,Status Library Moderator,Status Library Administrator,Root")]
    public class MovieCommentController : MyController<MovieComment, MovieCommentModel, MovieCommentListDto, MovieCommentDto>
    {
        private readonly IMovieCommentService _movieCommentService;

        /// <summary>
        /// Init movie comment controller
        /// </summary>
        /// <param name="service">Movie comment service</param>
        public MovieCommentController(IMovieCommentService service) : base(service)
        {
            this._movieCommentService = service;
        }

        /// <summary>
        /// Get list endpoint
        /// </summary>
        /// <param name="movieId">Path param id</param>
        [HttpGet("movie/{movieId}")]
        public IActionResult GetList(int movieId)
        {
            return this.Ok(this._movieCommentService.GetList(movieId));
        }

        /// <summary>
        /// Create endpoint
        /// </summary>
        /// <param name="model">Model</param>
        [HttpPost]
        [Authorize(Roles =
            "Administrator,Status Library User,Status Library Moderator,Status Library Administrator,Root")]
        public override IActionResult Create([FromBody] MovieCommentModel model)
        {
            this._movieCommentService.Add<MovieCommentModel>(model);
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
            this._movieCommentService.Remove(id);
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
        public override IActionResult Update(int id, MovieCommentModel model)
        {
            this._movieCommentService.Update<MovieCommentModel>(id, model);
            return this.Ok();
        }
    }
}