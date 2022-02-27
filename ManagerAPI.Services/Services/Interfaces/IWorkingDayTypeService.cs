using ManagerAPI.Domain.Entities.WM;
using ManagerAPI.Services.Repositories;

namespace ManagerAPI.Services.Services.Interfaces;

/// <summary>
/// Working Day Type Service
/// </summary>
public interface IWorkingDayTypeService : INotificationRepository<WorkingDayType, int>
{
}
