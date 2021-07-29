using ManagerAPI.Domain.Entities;
using ManagerAPI.Services.Common.Repository;

namespace ManagerAPI.Services.Services.Interfaces
{
    /// <summary>
    /// News Service
    /// </summary>
    public interface INewsService : IRepository<News>
    {
    }
}