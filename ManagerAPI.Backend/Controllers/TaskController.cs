using ManagerAPI.Domain.Entities;
using ManagerAPI.Services.Common;
using ManagerAPI.Services.Services.Interfaces;
using ManagerAPI.Shared.DTOs;
using ManagerAPI.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace ManagerAPI.Backend.Controllers
{
    /// <summary>
    /// Task controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : MyController<Task, TaskModel, TaskListDto, TaskDto>
    {
        private readonly ITaskService _taskService;

        /// <summary>
        /// Init task controller
        /// </summary>
        /// <param name="taskService">Task service</param>
        public TaskController(ITaskService taskService) : base(taskService)
        {
            this._taskService = taskService;
        }

        /// <summary>
        /// Get date grouping endpoint
        /// </summary>
        /// <param name="isSolved">Query param</param>
        [HttpGet("date")]
        public IActionResult GetDate([FromQuery] bool? isSolved)
        {
            return this.Ok(this._taskService.GetDate(isSolved));
        }
    }
}