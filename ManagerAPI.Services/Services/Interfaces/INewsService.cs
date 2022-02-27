using ManagerAPI.Domain.Entities;
using ManagerAPI.Services.Repositories;

namespace ManagerAPI.Services.Services.Interfaces
{
    /// <summary>
    /// News Service
    /// </summary>
    public interface INewsService : INotificationRepository<News, int>
    {
    }
}