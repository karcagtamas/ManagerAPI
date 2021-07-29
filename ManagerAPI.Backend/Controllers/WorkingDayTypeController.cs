using ManagerAPI.Domain.Entities.WM;
using ManagerAPI.Services.Common;
using ManagerAPI.Services.Services.Interfaces;
using ManagerAPI.Shared.DTOs.WM;
using ManagerAPI.Shared.Models.WM;
using Microsoft.AspNetCore.Mvc;

namespace ManagerAPI.Backend.Controllers
{
    /// <summary>
    /// Working day type controller
    /// </summary>
    [Route("api/working-day-type")]
    [ApiController]
    public class WorkingDayTypeController : MyController<WorkingDayType, WorkingDayTypeModel, WorkingDayTypeListDto, WorkingDayTypeDto>
    {
        /// <summary>
        /// Init working day type controller
        /// </summary>
        /// <param name="workingDayTypeService">Working day type service</param>
        public WorkingDayTypeController(IWorkingDayTypeService workingDayTypeService) : base(workingDayTypeService)
        {
        }
    }
}
