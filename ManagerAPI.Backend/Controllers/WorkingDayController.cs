using ManagerAPI.Domain.Entities.WM;
using ManagerAPI.Services.Common;
using ManagerAPI.Services.Services.Interfaces;
using ManagerAPI.Shared.DTOs.WM;
using ManagerAPI.Shared.Models.WM;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ManagerAPI.Backend.Controllers
{
    /// <summary>
    /// Working day controller
    /// </summary>
    [Route("api/working-day")]
    [ApiController]
    public class WorkingDayController : MyController<WorkingDay, int, WorkingDayModel, WorkingDayListDto, WorkingDayDto>
    {
        private readonly IWorkingDayService _workingDayService;

        /// <summary>
        /// Init working day controller
        /// </summary>
        /// <param name="workingDayService">Working day service</param>
        public WorkingDayController(IWorkingDayService workingDayService) : base(workingDayService)
        {
            this._workingDayService = workingDayService;
        }

        /// <summary>
        /// Get endpoint
        /// </summary>
        /// <param name="day">Day</param>
        [HttpGet("day/{day}")]
        public IActionResult Get(DateTime day)
        {
            return this.Ok(this._workingDayService.Get(day));
        }

        /// <summary>
        /// Get stat endpoint
        /// </summary>
        /// <param name="id">Path param id</param>
        [HttpGet("{id}/stat")]
        public IActionResult Stat(int id)
        {
            return this.Ok(this._workingDayService.Stat(id));
        }
    }
}