using ManagerAPI.Domain.Entities;
using ManagerAPI.Services.Common;
using ManagerAPI.Services.Services.Interfaces;
using ManagerAPI.Shared.DTOs;
using ManagerAPI.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ManagerAPI.Backend.Controllers
{
    /// <summary>
    /// Gender controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GenderController : MyController<Gender, GenderModel, GenderListDto, GenderDto>
    {
        /// <summary>
        /// Injector Constructor
        /// </summary>
        /// <param name="genderService">Message Service</param>
        public GenderController(IGenderService genderService) : base(genderService)
        {
        }
    }
}