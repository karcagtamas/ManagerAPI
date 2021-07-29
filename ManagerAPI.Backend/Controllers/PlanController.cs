using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ManagerAPI.Backend.Controllers
{
    /// <summary>
    /// Plan controller
    /// </summary>
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class PlanController : ControllerBase
    {
        /// <summary>
        /// Init plan controller
        /// </summary>
        public PlanController()
        {
        }
    }
}