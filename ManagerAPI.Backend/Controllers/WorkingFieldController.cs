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
    /// Working field controller
    /// </summary>
    [Route("api/working-field")]
    [ApiController]
    public class WorkingFieldController : MyController<WorkingField, int, WorkingFieldModel, WorkingFieldListDto, WorkingFieldDto>
    {
        private readonly IWorkingFieldService _workingFieldService;

        /// <summary>
        /// Init working field controller
        /// </summary>
        /// <param name="workingFieldService">Working field service</param>
        public WorkingFieldController(IWorkingFieldService workingFieldService) : base(workingFieldService)
        {
            this._workingFieldService = workingFieldService;
        }

        /// <summary>
        /// Get week stat endpoint
        /// </summary>
        /// <param name="week">Week path param</param>
        [HttpGet("week-stat/{week}")]
        public IActionResult GetWeekStat(DateTime week)
        {
            return this.Ok(this._workingFieldService.GetWeekStat(week));
        }

        /// <summary>
        /// Get month status endpoint
        /// </summary>
        /// <param name="year">Year path param</param>
        /// <param name="month">Month path param</param>
        [HttpGet("month-stat/{year}/{month}")]
        public IActionResult GetMonthStat(int year, int month)
        {
            return this.Ok(this._workingFieldService.GetMonthStat(year, month));
        }
    }
}