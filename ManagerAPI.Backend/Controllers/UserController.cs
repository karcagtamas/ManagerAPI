using ManagerAPI.Services.Services.Interfaces;
using ManagerAPI.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ManagerAPI.Backend.Controllers
{
    /// <summary>
    /// User controller
    /// </summary>
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        /// <summary>
        /// Init user controller
        /// </summary>
        /// <param name="userService">User service</param>
        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        /// <summary>
        /// Get endpoint
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            return this.Ok(await this._userService.GetUser());
        }

        /// <summary>
        /// Get short endpoint
        /// </summary>
        [HttpGet("shorter")]
        public IActionResult GetShortUser()
        {
            return this.Ok(this._userService.GetShortUser());
        }

        /// <summary>
        /// Update endpoint
        /// </summary>
        /// <param name="model">Model</param>
        [HttpPut]
        public IActionResult UpdateUser([FromBody] UserModel model)
        {
            this._userService.UpdateUser(model);
            return this.Ok();
        }

        /// <summary>
        /// Update image endpoint
        /// </summary>
        /// <param name="image">Image</param>
        [HttpPut("profile-image")]
        public IActionResult UpdateProfileImage([FromBody] byte[] image)
        {
            this._userService.UpdateProfileImage(image);
            return this.Ok();
        }

        /// <summary>
        /// Update password endpoint
        /// </summary>
        /// <param name="model">Model</param>
        [HttpPut("password")]
        public async Task<IActionResult> UpdatePassword([FromBody] PasswordUpdateModel model)
        {
            await this._userService.UpdatePassword(model.OldPassword, model.NewPassword);
            return this.Ok();
        }

        /// <summary>
        /// Update username endpoint
        /// </summary>
        /// <param name="model">Model</param>
        [HttpPut("username")]
        public async Task<IActionResult> UpdateUsername([FromBody] UsernameUpdateModel model)
        {
            await this._userService.UpdateUsername(model.UserName);
            return this.Ok();
        }

        /// <summary>
        /// Disable endpoint
        /// </summary>
        [HttpPut("disable")]
        public IActionResult DisableUser()
        {
            this._userService.DisableUser();
            return this.Ok();
        }
    }
}