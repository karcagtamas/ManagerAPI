using ManagerAPI.Services.Services.Interfaces;
using ManagerAPI.Shared.DTOs;
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
        private readonly IAuthService authService;
        private readonly ITokenService tokenService;

        /// <summary>
        /// Init auth controller
        /// </summary>
        /// <param name="authService">Auth service</param>
        /// <param name="tokenService">Toke service</param>
        public AuthController(IAuthService authService, ITokenService tokenService)
        {
            this.authService = authService;
            this.tokenService = tokenService;
        }

        /// <summary>
        /// Registration endpoint
        /// </summary>
        /// <param name="model">Model</param>
        [HttpPost("Registration")]
        [AllowAnonymous]
        public async Task Registration([FromBody] RegistrationModel model)
        {
            await authService.Registration(model);
        }

        /// <summary>
        /// Login endpoint
        /// </summary>
        /// <param name="model">Model</param>
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<TokenDTO> Login([FromBody] LoginModel model)
        {
            return await authService.Login(model);
        }

        [HttpGet("Refresh")]
        [AllowAnonymous]
        public async Task<TokenDTO> Refresh([FromQuery] string refreshToken, [FromQuery] string clientId)
        {
            return await tokenService.Refresh(refreshToken, clientId);
        }
    }
}