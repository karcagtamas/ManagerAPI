using ManagerAPI.Domain.Entities;
using ManagerAPI.Services.Repositories;

namespace ManagerAPI.Services.Services.Interfaces;

/// <summary>
/// Gender Service
/// </summary>
public interface IGenderService : INotificationRepository<Gender, int>
{
}
