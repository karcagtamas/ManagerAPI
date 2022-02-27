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
    /// Movie controller
    /// </summary>
    [Route("api/[controller]")]
    [Authorize(Roles = "Administrator,Status Library User,Status Library Moderator,Status Library Administrator,Root")]
    [ApiController]
    public class MovieController : MyController<Movie, int, MovieModel, MovieListDto, MovieDto>
    {
        private readonly IMovieService _movieService;

        /// <summary>
        /// Movie controller
        /// </summary>
        /// <param name="movieService">Movie service</param>
        public MovieController(IMovieService movieService) : base(movieService)
        {
            this._movieService = movieService;
        }

        /// <summary>
        /// Get my list endpoint
        /// </summary>
        [HttpGet("my")]
        public IActionResult GetMyList()
        {
            return this.Ok(this._movieService.GetMyList());
        }

        /// <summary>
        /// Get my endpoint
        /// </summary>
        /// <param name="id">Path param id</param>
        [HttpGet("my/{id}")]
        public IActionResult GetMy(int id)
        {
            return this.Ok(this._movieService.GetMy(id));
        }

        /// <summary>
        /// Get my selector list endpoint
        /// </summary>
        /// <param name="onlyMine">Query param</param>
        [HttpGet("selector")]
        public IActionResult GetMySelectorList([FromQuery] bool onlyMine)
        {
            return this.Ok(this._movieService.GetMySelectorList(onlyMine));
        }

        /// <summary>
        /// Update my list endpoint
        /// </summary>
        /// <param name="model">Model</param>
        [HttpPut("map")]
        public IActionResult UpdateMyMovies([FromBody] MyMovieModel model)
        {
            this._movieService.UpdateMyMovies(model.Ids);
            return this.Ok();
        }

        /// <summary>
        /// Update seen status endpoint
        /// </summary>
        /// <param name="models">Models</param>
        [HttpPut("map/status")]
        public IActionResult UpdateSeenStatus([FromBody] List<MovieSeenUpdateModel> models)
        {
            foreach (var model in models)
            {
                this._movieService.UpdateSeenStatus(model.Id, model.Seen);
            }

            return this.Ok();
        }

        /// <summary>
        /// Add to my list endpoint
        /// </summary>
        /// <param name="id">Path param id</param>
        [HttpPost("map/{id}")]
        public IActionResult AddMovieToMyMovies(int id)
        {
            this._movieService.AddMovieToMyMovies(id);
            return this.Ok();
        }

        /// <summary>
        /// Remove from my list endpoint
        /// </summary>
        /// <param name="id">Path param id</param>
        [HttpDelete("map/{id}")]
        public IActionResult RemoveMovieFromMyMovies(int id)
        {
            this._movieService.RemoveMovieFromMyMovies(id);
            return this.Ok();
        }

        /// <summary>
        /// Update image endpoint
        /// </summary>
        /// <param name="id">Path param id</param>
        /// <param name="model">Model</param>
        [HttpPut("image/{id}")]
        [Authorize(Roles = "Administrator,Root,Moderator,Status Library Moderator,Status Library Administrator")]
        public IActionResult UpdateImage(int id, [FromBody] MovieImageModel model)
        {
            this._movieService.UpdateImage(id, model);
            return this.Ok();
        }

        /// <summary>
        /// Update categories
        /// </summary>
        /// <param name="id">Path param id</param>
        /// <param name="model">Model</param>
        [HttpPut("categories/{id}")]
        [Authorize(Roles = "Administrator,Root,Moderator,Status Library Moderator,Status Library Administrator")]
        public IActionResult UpdateCategories(int id, [FromBody] MovieCategoryUpdateModel model)
        {
            this._movieService.UpdateCategories(id, model);
            return this.Ok();
        }

        /// <summary>
        /// Update rate endpoint
        /// </summary>
        /// <param name="id">Path param id</param>
        /// <param name="model">Model</param>
        [HttpPut("rate/{id}")]
        public IActionResult UpdateRate(int id, [FromBody] MovieRateModel model)
        {
            this._movieService.UpdateRate(id, model);
            return this.Ok();
        }

        /// <summary>
        /// Create endpoint
        /// </summary>
        /// <param name="model">Model</param>
        [HttpPost]
        [Authorize(Roles = "Administrator,Root,Moderator,Status Library Moderator,Status Library Administrator")]
        public override IActionResult Create([FromBody] MovieModel model)
        {
            this._movieService.CreateFromModel(model);
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
            this._movieService.DeleteById(id);
            return this.Ok();
        }

        /// <summary>
        /// Update endpoint
        /// </summary>
        /// <param name="id">Path param id</param>
        /// <param name="model">Model</param>
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator,Root,Moderator,Status Library Moderator,Status Library Administrator")]
        public override IActionResult Update(int id, MovieModel model)
        {
            this._movieService.UpdateByModel(id, model);
            return this.Ok();
        }
    }
}