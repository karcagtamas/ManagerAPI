using ManagerAPI.Services.Services.Interfaces;
using ManagerAPI.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ManagerAPI.Backend.Controllers
{
    /// <summary>
    /// Auth controller
    /// </summary>
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        /// <summary>
        /// Init auth controller
        /// </summary>
        /// <param name="authService">Auth service</param>
        public AuthController(IAuthService authService)
        {
            this._authService = authService;
        }

        /// <summary>
        /// Registration endpoint
        /// </summary>
        /// <param name="model">Model</param>
        [HttpPost("registration")]
        [AllowAnonymous]
        public async Task<IActionResult> Registration([FromBody] RegistrationModel model)
        {
            await this._authService.Registration(model);
            return this.Ok();
        }

        /// <summary>
        /// Login endpoint
        /// </summary>
        /// <param name="model">Model</param>
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            string token = await this._authService.Login(model);
            return this.Ok(token);
        }
    }
}